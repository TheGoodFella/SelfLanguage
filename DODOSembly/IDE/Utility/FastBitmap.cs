using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Linq;

namespace FastDrawing {
    class ColorIsChanged {
        private Color _color;
        public Color Color { get { return _color; } set { Changed = true; _color = value; } }
        public bool Changed { get; set; }
        public ColorIsChanged() { }
        public ColorIsChanged(Color c, bool b) { Color = c; Changed = b; }
        public static implicit operator ColorIsChanged(bool l) { return new ColorIsChanged(Color.Black, l); }
        public static implicit operator ColorIsChanged(Color c) { return new ColorIsChanged(c, true); }
    }
    class FastBitmap {
        public int Width { get { return _innerBitmap.Count; } }
        public int Height { get { return _innerBitmap[0].Count; } }
        List<List<ColorIsChanged>> _innerBitmap { get; set; } //x = width, y = height
        Bitmap _oldBitmap { get; set; }
        /// <summary>
        /// Generates a new FastBitmap from a bitmap, keep in mind that Fast bitmap is implicitly 
        /// convertible in Bitmap and vice-versa
        /// </summary>
        /// <param name="b"></param>
        public FastBitmap(Bitmap b) {
            this._oldBitmap = b;
            init();
        }
        void init() {
            this._innerBitmap = new List<List<ColorIsChanged>>();
            _innerBitmap = this.GetListColor();
        }
        /// <summary>
        /// Get the color at the x,y position
        /// </summary>
        /// <param name="x">If is greater than the img width, the img will be expanded</param>
        /// <param name="y">If is greater than the img height, the img will be expanded</param>
        /// <returns></returns>
        public Color this[int x, int y] {
            get { return _innerBitmap[x][y].Color; }
            set {
                if (!((x < _innerBitmap.Count) && (y < _innerBitmap[0].Count))) {
                    Expand(x - _innerBitmap.Count + 1, y - _innerBitmap[0].Count + 1);
                }
                _innerBitmap[x][y] = value;
            }
        }
        /// <summary>
        /// Clearer than the implicit conversion, look out, this function is slow
        /// </summary>
        /// <returns>The converted FastBitmap into Bitmap</returns>
        public Bitmap ToBitmap() {
            if (_oldBitmap == null || _innerBitmap.Count != _oldBitmap.Height || _innerBitmap[0].Count != _oldBitmap.Width) {
                _oldBitmap = new Bitmap(_innerBitmap[0].Count, _innerBitmap.Count);
                for (int i = 0; i < _innerBitmap.Count; i++) {
                    for (int x = 0; x < _innerBitmap[i].Count; x++) {
                        _innerBitmap[i][x].Changed = true;
                    }
                }
            }
            this.SetAllColor();
            return _oldBitmap;
        }
        #region Private Gesture
        private List<List<ColorIsChanged>> GetListColor() {
            BitmapData bitmapData = _oldBitmap.LockBits(new Rectangle(0, 0, _oldBitmap.Width, _oldBitmap.Height), ImageLockMode.ReadWrite, _oldBitmap.PixelFormat);
            int bytesPerPixel = Bitmap.GetPixelFormatSize(_oldBitmap.PixelFormat) / 8;
            int byteCount = bitmapData.Stride * _oldBitmap.Height;
            byte[] pixels = new byte[byteCount];
            IntPtr ptrFirstPixel = bitmapData.Scan0;
            Marshal.Copy(ptrFirstPixel, pixels, 0, pixels.Length);
            int heightInPixels = bitmapData.Height;
            int widthInBytes = bitmapData.Width * bytesPerPixel;
            var lsC = new List<List<Color>>();
            for (int y = 0; y < heightInPixels; y++) {
                int currentLine = y * bitmapData.Stride;
                lsC.Add(new List<Color>());
                for (int x = 0; x < widthInBytes; x = x + bytesPerPixel) {
                    int blue = pixels[currentLine + x];
                    int green = pixels[currentLine + x + 1];
                    int red = pixels[currentLine + x + 2];
                    lsC[y].Add(Color.FromArgb(0, red, green, blue));
                }
            }
            _oldBitmap.UnlockBits(bitmapData);
            return lsC.Select((s) => s.Select((k) => new ColorIsChanged(k, true)).ToList()).ToList();
        }
        private void SetAllColor() {
            BitmapData bd = _oldBitmap.LockBits(new Rectangle(0, 0, _oldBitmap.Width, _oldBitmap.Height), ImageLockMode.ReadWrite, _oldBitmap.PixelFormat);
            int bytesPerPixel = Bitmap.GetPixelFormatSize(_oldBitmap.PixelFormat) / 8;
            int byteCount = bd.Stride * _oldBitmap.Height;
            byte[] pixels = new byte[byteCount];
            IntPtr ptrFirstPixel = bd.Scan0;
            Marshal.Copy(ptrFirstPixel, pixels, 0, pixels.Length);
            int heightInPixels = bd.Height;
            int widthInBytes = bd.Width * bytesPerPixel;
            for (int x = 0; x < heightInPixels; x++) {
                int currentLine = x * bd.Stride;
                for (int y = 0,z=0; y < widthInBytes; y = y + bytesPerPixel,z++) {
                    if (_innerBitmap[x][z].Changed) {
                        pixels[currentLine + y] = (byte)_innerBitmap[x][z].Color.B;
                        pixels[currentLine + y + 1] = (byte)_innerBitmap[x][z].Color.G;
                        pixels[currentLine + y + 2] = (byte)_innerBitmap[x][z].Color.R;
                        _innerBitmap[x][z].Changed = false;
                    }
                }
            }
            Marshal.Copy(pixels, 0, ptrFirstPixel, pixels.Length);
            _oldBitmap.UnlockBits(bd);
        }
        private void Expand(int xp, int yp) {
            for (int x = 0; x < xp; x++) {
                _innerBitmap.Add(new List<ColorIsChanged>());
            }
            int minCy = (_innerBitmap[0].Count + (yp < 0 ? 0 : yp));
            for (int x = 0; x < _innerBitmap.Count; x++) {
                for (int y = _innerBitmap[x].Count; y < minCy; y++) {
                    _innerBitmap[x].Add(Color.Black);
                }
            }
        }
        #endregion
        #region Utility
        /// <summary>
        /// Returns the bitmap zoommed
        /// </summary>
        /// <param name="factor">Must be an integer number greater than 1</param>
        /// <returns>The Bitmap zoommed</returns>
        public FastBitmap Zoom(int factor) {
            FastBitmap toReturn = new FastBitmap(new Bitmap(1, 1));
            for (int x = 0, ux = 0; x < _innerBitmap.Count; x++, ux += factor) {
                for (int y = 0, uy = 0; y < _innerBitmap[x].Count; y++, uy += factor) {
                    for (int ix = 0; ix < factor; ix++) {
                        for (int iy = 0; iy < factor; iy++) {
                            toReturn[ux + ix, uy + iy] = _innerBitmap[x][y].Color;
                        }
                    }
                }
            }
            return toReturn;
        }
        /// <summary>
        /// Foreach loop List-like, the items are read-only, this wont throw any exception if you try to change
        /// something, it just wont be changed
        /// </summary>
        /// <param name="toDo">Action to be done for each line</param>
        public void ForEach(Action<List<ColorIsChanged>> toDo) {
            _innerBitmap.ForEach(toDo);
        }
        #endregion
        #region Operators
        public static implicit operator Bitmap(FastBitmap f) {
            return f.ToBitmap();
        }
        public static implicit operator FastBitmap(Bitmap b) {
            return new FastBitmap(b);
        }
        public static explicit operator List<List<Color>>(FastBitmap c) {
            c.ToBitmap();
            return c._innerBitmap.Select((s)=>s.Select((k)=>k.Color).ToList()).ToList();
        }
        #endregion
    }
}