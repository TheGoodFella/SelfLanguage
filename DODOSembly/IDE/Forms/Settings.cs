using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Text;
using System.IO;
using System.Xml.Serialization;

namespace IDE {
    public partial class Settings : Form {
        SerializeRichTextBox serialize { get; set; }
        EventHandler<SerializeRichTextBox> Close;
        public Settings(EventHandler<SerializeRichTextBox> e):this() {
            Close = e;
        }
        public Settings() {
            InitializeComponent();
            serialize = new SerializeRichTextBox();
            #region Text
            serialize.Font = richTextBox1.Font;
            serialize.ForeColor = richTextBox1.ForeColor;
            serialize.BackColor = richTextBox1.BackColor;
            serialize.Borders = richTextBox1.BorderStyle;
            serialize.OnBackColorChanged += (y,k)=>SafeSet<Color>((a, b) => { richTextBox1.BackColor = b; },y,k);
            serialize.OnBorderStyleChanged += (y,k)=>SafeSet<BorderStyle>((a, b) => { richTextBox1.BorderStyle = b; },y,k);
            serialize.OnFontChanged += (y,k)=>SafeSet<Font>((a, b) => { richTextBox1.Font = b; },y,k);
            serialize.OnForeColorChanged += (y,k)=>SafeSet<Color>((a, b) => { richTextBox1.ForeColor = b; },y,k);
            #endregion
            #region Form
            serialize.FormBorderStyle = this.FormBorderStyle;
            serialize.FormBackColor = this.BackColor;
            serialize.OnFormBackColorChanged += (y,k)=>SafeSet<Color>((a, b) => { this.BackColor = b; },y,k);
            serialize.OnFormBorderStyleChanged += (y,k)=>SafeSet<FormBorderStyle>((a, b) => { this.FormBorderStyle = b; },y,k);
            #endregion
            prpTEXT.SelectedObject = serialize;

        }
        protected bool SafeSet<T>(Action<object,T> a,object sender, T value) {
            try {
                a(sender, value);
                return true;
            } catch (Exception e) {
                MessageBox.Show(e.Message);
                return false;
            }
        }

        //private void exportToolStripMenuItem_Click(object sender, EventArgs e) {
        //    var path = "";
        //    var save = new SaveFileDialog() { 
        //        DefaultExt = "xml",FileName="settings"
        //    };
        //    var result = save.ShowDialog();
        //    if (result != System.Windows.Forms.DialogResult.OK) {
        //        return;
        //    } else {
        //        path = save.FileName;
        //    }
        //    var xml = new XmlSerializer(typeof(SerializeRichTextBox));
        //    xml.Serialize(new StreamWriter(path), serialize);            
        //}
    }
    public class SerializeRichTextBox {
        public SerializeRichTextBox() { }
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
        public string FontToSerialize {
            get {
                return _font.ToString();
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
        #region FORM
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