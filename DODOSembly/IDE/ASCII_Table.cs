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
    public partial class ASCII_Table : UserControl {
        List<char> ls_char { get; set; }
        public ASCII_Table() {
            InitializeComponent();
            ls_char = new List<char>();
        }
        public void GenerateTable() {
            
            //ls_char=  Enumerable.Range(32, 126).Select((s) =>Convert.ToString(Convert.ToChar(s))).ToList().Aggregate((l1,l2)=>l1+l2);
            //richTextBox1.Text=ls_char.
        }

    }
}
