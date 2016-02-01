using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IDE {
    public partial class Settings : Form {
        SerializeRichTextBox serialize { get; set; }
        public Settings() {
            InitializeComponent();
            serialize = new SerializeRichTextBox();
            serialize.OnBackColorChanged += (a, b) => { richTextBox1.BackColor = b; };
            serialize.OnBorderStyleChanged += (a, b) => { richTextBox1.BorderStyle = b; };
            serialize.OnFontChanged += (a, b) => { richTextBox1.Font = b; };
            serialize.OnForeColorChanged += (a, b) => { richTextBox1.ForeColor = b; };
            serialize.Font = richTextBox1.Font;
            serialize.ForeColor = richTextBox1.ForeColor;
            serialize.BackColor = richTextBox1.BackColor;
            serialize.Borders = richTextBox1.BorderStyle;
            
            prpTEXT.SelectedObject = serialize;
        }
    }
    class SerializeRichTextBox {
        #region Font
        private Font _font;
        public event EventHandler<Font> OnFontChanged;
        public Font Font {
            get {
                return _font; 
            }
            set {
                (OnFontChanged ?? ((a, b) => { })).Invoke(this, value); //GG no C# 6
                _font = value;
            }
        }
        #endregion
        #region BackColor
        private Color _backColor;
        public event EventHandler<Color> OnBackColorChanged;
        public Color BackColor {
            get {
                return _backColor;
            }
            set {
                (OnBackColorChanged??((a,b)=>{ })).Invoke(this,value);
                _backColor = value;
            }
        }
        #endregion
        #region ForeColor
        private Color _foreColor;
        public Color ForeColor {
            get {
                return _foreColor;
            }
            set {
                ( OnForeColorChanged ?? ((a, b) => { })).Invoke(this, value); //GG no C# 6               
                _foreColor = value;
            }
        }
        public event EventHandler<Color> OnForeColorChanged;
        #endregion
        #region Border
        private BorderStyle _borders;
        public BorderStyle Borders {
            get {
                return _borders;
            }
            set {
                (OnBorderStyleChanged ?? ((a, b) => { })).Invoke(this, value); //GG no C# 6
                _borders = value;
            }
        }
        public event EventHandler<BorderStyle> OnBorderStyleChanged;
        #endregion
    }
}