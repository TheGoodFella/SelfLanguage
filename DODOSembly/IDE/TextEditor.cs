using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IDE {
    public partial class TextEditor : UserControl {
        public override string Text {
            get {
                return txtCode.Text;
            }
            set {
                txtCode.Text = value;
            }
        }

        public EventHandler<string> OnCompile;

        private char[] NotToIncludeInPointersChar = new char[] { '\t', '\n', '\r' };
        private string[] CommentsStartOfLine = new string[] { "#", "//" };
        Documentation Intellisense { get; set; }

        public TextEditor() {
            InitializeComponent();
            Intellisense = new Documentation();
            Intellisense.Add("j", Color.Red, "Jump");
            Intellisense.Add("p", Color.Red, "Pop");
            Intellisense.Add("i", Color.Red, "Interrupt");
            Intellisense.Add("s", Color.Red, "Set value carry");
            Intellisense.Add("n", Color.Red, "Write value carry");
            Intellisense.Add("m", Color.Red, "Move");
            Intellisense.Add("\\", Color.Red, "End of program");
        }

        private void txtCode_TextChanged(object sender, EventArgs e) {
            var v = txtCode.SelectionStart;
            Pointer_number();
            //txtCode.SelectionStart = 0;
            //txtCode.SelectionLength = txtCode.Text.Length;
            //txtCode.SelectionBackColor = txtCode.BackColor;
            Intellisense_Worker();
            txtCode.SelectionStart = v;
            if (txtCode.Text.Take(txtCode.SelectionStart).Count() > 0) {
                txtStatusPointer.Text = string.Format("Currently at pointer: {0}", txtCode.Text.Take(txtCode.SelectionStart).Select((s) => CleanPointer(Convert.ToString(s))).Aggregate((n1, n2) => n1 + n2));
            } else {
                txtStatusPointer.Text = string.Format("Currently at pointer: {0}", 0);
            }
        }
        private void Pointer_number() {
            var count_line_l = txtCode.Lines.ToList().Select((line) => CleanPointer(line));
            var int_lines_c = new List<int>();
            Enumerable.Range(1, txtCode.Lines.Length).ToList().ForEach((s) => {
                int_lines_c.Add(count_line_l.Take(s).Aggregate((n1, n2) => n1 + n2));
            });
            int_lines_c.Select((k) => Convert.ToString(k)).ToArray();
            var temp = new List<string>();
            Enumerable.Range(1, int_lines_c.Count).ToList().ForEach((k) => temp.Add(k + " " + int_lines_c[k - 1]));
            txtPointers.Lines = temp.ToArray();
        }

        private int CleanPointer(string s) {
            if(CommentsStartOfLine.Any((k)=>s.IndexOf(k)==0)){ return 0; }
            return s.Where((e) => !NotToIncludeInPointersChar.Any((k) => e == k)).Count();
        }

        private void Intellisense_Worker() {
            return;

            var tmp_text = txtCode.Text;
            var accumulator = "";
            int firstVisibleChar = txtCode.GetCharIndexFromPosition(new Point(0, 0));
            var lastVisibleChar = txtCode.SelectionStart;
            Enumerable.Range(firstVisibleChar, lastVisibleChar).ToList().ForEach((s) => { //Fuck this, took me 30 minutes
                accumulator += tmp_text[s];
                if (Intellisense.Any((k) => k == accumulator)) {
                    txtCode.SelectionStart = s - (accumulator.Length - 1);
                    txtCode.SelectionLength = accumulator.Length;
                    txtCode.SelectionBackColor = Intellisense[accumulator];
                    txtCode.SelectionStart = txtCode.Text.Length;
                    txtCode.SelectionLength = 0;
                    txtCode.SelectionBackColor = txtCode.BackColor;
                    accumulator = "";
                } else if (!Intellisense.Any((k) => k.Contains(accumulator))) {
                    accumulator = (accumulator.Length == 1) ? "" : accumulator.Skip(1).ToList().Select((e) => Convert.ToString(e)).Aggregate((first, second) => first + second);
                }
            });
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e) {


        }

        private void txtCode_FontChanged(object sender, EventArgs e) {
            txtPointers.Font = ((RichTextBox)sender).Font;
        }

        private void timer1_Tick(object sender, EventArgs e) {
            txtPointers.ZoomFactor = txtCode.ZoomFactor;
            var line = txtCode.Text.Take(txtCode.SelectionStart).Count((s) => s == '\n');
            if (line != 0) { var n_text = txtPointers.Lines.Take(line).Select((s) => s.Length).Aggregate((n1, n2) => n1 + n2); txtPointers.SelectionStart = n_text; }
            txtPointers.SelectionLength = 0;
            txtPointers.ScrollToCaret();
        }

        private void splitter_SplitterMoved(object sender, SplitterEventArgs e) {

        }

        private void changeSelectionColorToolStripMenuItem_Click(object sender, EventArgs e) {
            var v = new ColorDialog();
            var result = v.ShowDialog();
            if (result == DialogResult.OK) {
                txtCode.SelectionColor = v.Color;
            }
        }

        private void changeSelectionBackcolorToolStripMenuItem_Click(object sender, EventArgs e) {
            var v = new ColorDialog();
            var result = v.ShowDialog();
            if (result == DialogResult.OK) {
                txtCode.SelectionBackColor = v.Color;
            }
        }

        private void fontToolStripMenuItem_Click_1(object sender, EventArgs e) {
            var f = new FontDialog();
            var result = f.ShowDialog();
            if (result == DialogResult.OK) {
                txtCode.Font = f.Font;
                txtPointers.Font = f.Font;
            }
        }

        private void compileToolStripMenuItem_Click(object sender, EventArgs e) {
            var to_compile = txtCode.Lines.Where((s)=>CleanPointer(s)!=0);
            //// var v = to_compile.Select((s) => Intellisense.Keys.Any((n) => n.Take(n.Length) == s.Take(n.Length)) ? "\0" + s : s).Aggregate((n1,n2)=>n1+n2);
            //var v = new List<string>();
            //to_compile.ToList().ForEach((s) => {
            //    while (Intellisense.Any((k) => s.IndexOf(k) != -1)) {
            //        var index = s.IndexOf(
            //    }
            //});
            var query = to_compile.Select((s)=>{
                while(Intellisense.Keys.Any((k)=>s.Contains(k) && ((s.Length > 1)?(s.Take(s.IndexOf(k)-1).First()!='\0'):(true)) )){
                    var contained = Intellisense.Keys.Where((p)=>s.Contains(p)).First();
                    s=s.Replace(contained, '\0' + contained);   
                }
                return s;
            });


            if (OnCompile != null) { OnCompile(this, query.Aggregate((first,second)=>first + second)); }
        }

    }

    class Documentation {
        List<Tuple<string, Color, string>> doc = new List<Tuple<string, Color, string>>();
        public Documentation() { }
        public Color this[string s] {
            get {
                return doc.First((k) => k.Item1 == s).Item2;
            }
        }
        public bool Any(Func<string, bool> s) {
            return Keys.Any(s);
        }
        public string[] Keys {
            get {
                return doc.Select((s) => s.Item1).ToArray();
            }
        }
        public Tuple<string, Color, string> this[int i] {
            get {
                return doc.ElementAt(i);
            }
        }
        public void Add(string Command, Color c) {
            if (doc.Any((k) => k.Item1 == Command)) { throw new ArgumentException("The docs already contain this command"); } else {
                doc.Add(Tuple.Create<string, Color, string>(Command, c, ""));
            }
        }
        public void Add(string Command, Color c, string docs) {
            if (doc.Any((k) => k.Item1 == Command)) { throw new ArgumentException("The docs already contain this command"); }
            doc.Add(new Tuple<string, Color, string>(Command, c, docs));
        }
    }
}
