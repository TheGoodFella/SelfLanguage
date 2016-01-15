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
        
        Documentation Intellisense { get; set; }

        public TextEditor() {
            InitializeComponent();
            Intellisense = new Documentation();
            Intellisense.Add("j", Color.Red,"Jump");
            Intellisense.Add("p", Color.Red, "Pop");
            Intellisense.Add("i", Color.Red, "Interrupt");
            Intellisense.Add("s", Color.Red, "Set value carry");
            Intellisense.Add("n", Color.Red, "Write value carry");
            Intellisense.Add("m", Color.Red, "Move");
            Intellisense.Add("\\", Color.Red, "End of program");
            //CommandList.Add("j", () => JumpCommand(_pointer));          //Jump
            //CommandList.Add("p", () => PopOrPush(_pointer));            //pop is 0 or push that is 1
            //CommandList.Add("i", () => Interrupt(_pointer));            //Interrupt n
            //CommandList.Add("s", () => SetCarry(_pointer));             //Set value carry
            //CommandList.Add("n", () => WriteValueCarry());              //Write value carry in logger
            //CommandList.Add("m", () => Move(_pointer + 2));               //Move&Here;what
            //CommandList.Add("\\", () => _pointer = int.MaxValue - 1);   //End of program
        }

        private void txtCode_TextChanged(object sender, EventArgs e) {
            Pointer_number();
            Intellisense_Worker();
        }
        private void Pointer_number() {
            var count_line_l = txtCode.Lines.ToList().Select((line) => line.Length);
            var int_lines_c = new List<int>();
            Enumerable.Range(1, txtCode.Lines.Length).ToList().ForEach((s) => {
                int_lines_c.Add(count_line_l.Take(s).Aggregate((n1, n2) => n1 + n2));
            });
            int_lines_c.Select((k) => Convert.ToString(k)).ToArray();
            var temp = new List<string>();
            Enumerable.Range(1, int_lines_c.Count).ToList().ForEach((k) => temp.Add(k + " " + int_lines_c[k - 1]));
            txtPointers.Lines = temp.ToArray();
        }
        private void Intellisense_Worker() {
            Enumerable.Range(0, txtCode.Lines.Length).ToList().ForEach((i) => {
                var contained = Intellisense.Keys.Where((item) => txtCode.Lines[i].Contains(item));
                contained.ToList().ForEach((item) => {
                    var index = Convert.ToInt32((txtPointers.Lines.ElementAtOrDefault(i-1)??"0 0").Split(' ').ElementAt(1));
                    Change_Color(index + txtCode.Lines[i].IndexOf(item) + i, item.Length, Intellisense[item]);
                });
            });
        }
        private void Change_Color(int from, int length,Color c) {
            txtCode.SelectionStart = from;
            txtCode.SelectionLength = length;
            txtCode.SelectionBackColor = c;
            txtCode.SelectionStart = txtCode.Text.Length;
            txtCode.SelectionBackColor = txtCode.BackColor;
        }
        
    }
    class Documentation {
        List<Tuple<string,Color,string>> doc = new List<Tuple<string,Color,string>>();
        public Documentation() { }
        public Color this[string s] {
            get {
                return doc.First((k) => k.Item1 == s).Item2;
            }
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
            if(doc.Any((k)=>k.Item1 == Command)){ throw new ArgumentException("The docs already contain this command");}
            else{
                doc.Add(Tuple.Create<string,Color,string>(Command,c,""));
            }
        }
        public void Add(string Command, Color c, string docs) {
            if(doc.Any((k)=>k.Item1 == Command)){ throw new ArgumentException("The docs already contain this command");}
            doc.Add(new Tuple<string, Color, string>(Command, c, docs));            
        }
    }
}
