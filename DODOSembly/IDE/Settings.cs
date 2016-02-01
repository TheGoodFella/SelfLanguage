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
            #region Text
            serialize.Font = richTextBox1.Font;
            serialize.ForeColor = richTextBox1.ForeColor;
            serialize.BackColor = richTextBox1.BackColor;
            serialize.Borders = richTextBox1.BorderStyle;
            serialize.OnBackColorChanged += (a, b) => { richTextBox1.BackColor = b; };
            serialize.OnBorderStyleChanged += (a, b) => { richTextBox1.BorderStyle = b; };
            serialize.OnFontChanged += (a, b) => { richTextBox1.Font = b; };
            serialize.OnForeColorChanged += (a, b) => { richTextBox1.ForeColor = b; };
            #endregion
            #region Form
            serialize.FormBorderStyle = this.FormBorderStyle;
            serialize.FormBackColor = this.BackColor;
            serialize.OnFormBackColorChanged += (a, b) => { this.BackColor = b; };
            serialize.OnFormBorderStyleChanged += (a, b) => { this.FormBorderStyle = b; };

            #endregion
            prpTEXT.SelectedObject = serialize;
        }
    }
    class SerializeRichTextBox {
        #region TEXT
        #region Font
        private Font _font;
        public event EventHandler<Font> OnFontChanged;
        [
            Description("Defines the Font"),
            CategoryAttribute("Text")
        ]
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
        [
            Description("Defines the BackColor"),
            CategoryAttribute("Text")
        ]
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
        [
            Description("Defines the ForeColor"),
            CategoryAttribute("Text")
        ]
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
        [
            Description("Defines the Borders"),
            CategoryAttribute("Text")
        ]
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
        #endregion
        #region Form
        #region FormBackColor
        private Color _formBackColor;
        [
            Description("Defines the form back color"),
            Category("Form")
        ]
        public Color FormBackColor {
            get { return _formBackColor; }
            set {
                (OnFormBackColorChanged ?? ((a, b) => { })).Invoke(this, value); //GG no C# 6
                _formBackColor = value;
            }
        }
        public event EventHandler<Color> OnFormBackColorChanged;
        #endregion
        #region FormBorder
        private FormBorderStyle _formBorderStyle;
        [
            Description("Defines the Form Border style"),
            Category("Form")    
        ]
        public FormBorderStyle FormBorderStyle {
            get {
                return _formBorderStyle;
            }
            set {
                (OnFormBorderStyleChanged ?? ((a, b) => { })).Invoke(this, value); //GG no C# 6
                _formBorderStyle = value;
            }
        }
        public event EventHandler<FormBorderStyle> OnFormBorderStyleChanged;
        #endregion
        #endregion
    }
}