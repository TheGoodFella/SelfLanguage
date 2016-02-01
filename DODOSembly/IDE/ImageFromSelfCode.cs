using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Collections;
using FastDrawing;

namespace IDE {
    class ImageFromSelfCode {
        public FastBitmap Image { get; set; }
        public ImageFromSelfCode() {
            Image = new FastBitmap(new Bitmap(100,100));
        }
        public void CreateImage(string code) {
            var code_bytes = new BitArray(ASCIIEncoding.ASCII.GetBytes(code));
            
            Enumerable.Range(0, code_bytes.Length).ToList().ForEach((i) => {
                var x = i % Image.Width;
                var y = (int)i / Image.Width;
                Image[x, y] = code_bytes[i]==true?Color.Black:Color.White;
            });
            var x1 = code_bytes.Length % Image.Width;
            var y1= (int)code_bytes.Length / Image.Width;
            Image[x1, y1] = Color.Red;
            Image.ToBitmap().Save(@"C:\l.bmp");
            
        }
    }
}
