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
            serialize.BackColorChanged += serialize_BackColorChanged;
            prpTEXT.SelectedObject = serialize;
        }

        void serialize_BackColorChanged(object sender, Color e) {
            try {
                propertyTextBox1.BackColor = e;
            } catch(Exception a){
                MessageBox.Show(a.Message);
            }
        }
    }
    class PropertyTextBox : RichTextBox {
        [Browsable(false)]
        public override string Text {
            get {
                return base.Text;
            }
            set {
                base.Text = value;
            }
        }
        [Browsable(false)]
        public override bool AllowDrop {
            get {
                return base.AllowDrop;
            }
            set {
                base.AllowDrop = value;
            }
        }
        [Browsable(false)]
        public override AnchorStyles Anchor {
            get {
                return base.Anchor;
            }
            set {
                base.Anchor = value;
            }
        }
        [Browsable(false)]
        public override Point AutoScrollOffset {
            get {
                return base.AutoScrollOffset;
            }
            set {
                base.AutoScrollOffset = value;
            }
        }
        [Browsable(false)]
        public override bool AutoSize {
            get {
                return base.AutoSize;
            }
            set {
                base.AutoSize = value;
            }
        }
        [Browsable(false)]
        public override BindingContext BindingContext {
            get {
                return base.BindingContext;
            }
            set {
                base.BindingContext = value;
            }
        }
        [Browsable(false)]
        protected override bool CanEnableIme {
            get {
                return base.CanEnableIme;
            }
        }
        [Browsable(false)]
        protected override bool CanRaiseEvents {
            get {
                return base.CanRaiseEvents;
            }
        }
        [Browsable(false)]
        public override ContextMenu ContextMenu {
            get {
                return base.ContextMenu;
            }
            set {
                base.ContextMenu = value;
            }
        }
        [Browsable(false)]
        public override ContextMenuStrip ContextMenuStrip {
            get {
                return base.ContextMenuStrip;
            }
            set {
                base.ContextMenuStrip = value;
            }
        }
        [Browsable(false)]
        protected override CreateParams CreateParams {
            get {
                return base.CreateParams;
            }
        }
        [Browsable(false)]
        protected override ImeMode DefaultImeMode {
            get {
                return base.DefaultImeMode;
            }
        }
        [Browsable(false)]
        protected override Size DefaultMaximumSize {
            get {
                return base.DefaultMaximumSize;
            }
        }
        [Browsable(false)]
        protected override Padding DefaultMargin {
            get {
                return base.DefaultMargin;
            }
        }
        [Browsable(false)]
        protected override Size DefaultMinimumSize {
            get {
                return base.DefaultMinimumSize;
            }
        }
        [Browsable(false)]
        protected override Padding DefaultPadding {
            get {
                return base.DefaultPadding;
            }
        }
        [Browsable(false)]
        protected override Size DefaultSize {
            get {
                return base.DefaultSize;
            }
        }
        [Browsable(false)]
        public override Rectangle DisplayRectangle {
            get {
                return base.DisplayRectangle;
            }
        }
        [Browsable(false)]
        public override bool Focused {
            get {
                return base.Focused;
            }
        }
        [Browsable(false)]
        protected override ImeMode ImeModeBase {
            get {
                return base.ImeModeBase;
            }
            set {
                base.ImeModeBase = value;
            }
        }
        [Browsable(false)]
        public override System.Windows.Forms.Layout.LayoutEngine LayoutEngine {
            get {
                return base.LayoutEngine;
            }
        }
        [Browsable(false)]
        public override Size MaximumSize {
            get {
                return base.MaximumSize;
            }
            set {
                base.MaximumSize = value;
            }
        }
        [Browsable(false)]
        public override bool Multiline {
            get {
                return base.Multiline;
            }
            set {
                base.Multiline = value;
            }
        }
        [Browsable(false)]
        public override DockStyle Dock {
            get {
                return base.Dock;
            }
            set {
                base.Dock = value;
            }
        }
        [Browsable(false)]
        protected override bool ScaleChildren {
            get {
                return base.ScaleChildren;
            }
        }
        [Browsable(false)]
        public override string SelectedText {
            get {
                return base.SelectedText;
            }
            set {
                base.SelectedText = value;
            }
        }
        [Browsable(false)]
        public override int SelectionLength {
            get {
                return base.SelectionLength;
            }
            set {
                base.SelectionLength = value;
            }
        }
        [Browsable(false)]
        public override ISite Site {
            get {
                return base.Site;
            }
            set {
                base.Site = value;
            }
        }
        [Browsable(false)]
        public override int TextLength {
            get {
                return base.TextLength;
            }
        }
        [Browsable(false)]
        public new bool ReadOnly {
            get {
                return base.ReadOnly;
            }
            set {
                base.ReadOnly = value;
            }
        }
        [Browsable(false)]
        public new string AccessibleDescription {
            get {
                return base.AccessibleDescription;
            }
            set {
                base.AccessibleDescription = value;
            }
        }
        [Browsable(false)]
        public new string AccessibleName {
            get {
                return base.AccessibleName;
            }
            set {
                base.AccessibleName = value;
            }
        }
        [Browsable(false)]
        public new AccessibleRole AccessibleRole {
            get {
                return base.AccessibleRole;
            }
            set {
                base.AccessibleRole = value;
            }
        }
        [Browsable(false)]
        public new object Tag {
            get {
                return base.Tag;
            }
            set {
                base.Tag = value;
            }
        }
        [Browsable(false)]                
        public new ControlBindingsCollection DataBindings {
            get {
                return base.DataBindings;
            }
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
        public event EventHandler<Color> BackColorChanged;
        public Color BackColor {
            get {
                return _backColor;
            }
            set {
                (BackColorChanged??((a,b)=>{ })).Invoke(this,value);
                _backColor = value;
            }
        }
        #endregion
        private Color _foreColor;
        public Color ForeColor {
            get {
                return _foreColor;
            }
            set {
                _foreColor = value;
            }
        }
        public event EventHandler<Color> OnColorChanged;
    }
}