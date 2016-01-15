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
        public TextEditor() {
            InitializeComponent();
        }

        private void txtCode_TextChanged(object sender, EventArgs e) {
            var v = txtCode.Lines.ToList().Select((s)=>k(s));
            Enumerable.Range(0, txtCode.Text.Length).ToList().ForEach((index) => {
                m(index,v);
            });
        }
        private int k(string s) {
            return s.Length;
        }
        private void m(int index,IEnumerable<int> v ) {
            while(index < txtPointers.Lines.Length) { txtPointers.Text += "\r\n"; }
            txtPointers.Lines[index] = Convert.ToString(v.Take(index).Aggregate((n1, n2) => n1 + n2));
        }
    }
}
