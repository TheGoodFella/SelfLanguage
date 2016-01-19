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

        private int[] ASCII_Offset = new int[] { 36, 90 };
        private List<char> ls_char { get; set; }

        public EventHandler SomethingPressed { get; set; }

        public ASCII_Table() {
            InitializeComponent();
            ls_char = new List<char>();
            GenerateTable();
            var ls1 = ls_char.Select((k) => new ListViewItem(Convert.ToString(k))).ToArray();
            lstV.Items.AddRange(ls1);
        }
        public void GenerateTable() {
            ls_char = Enumerable.Range(ASCII_Offset[0], ASCII_Offset[1]).Select((s) =>(Convert.ToChar(s))).ToList();
        }
        private void lstV_MouseDoubleClick(object sender, MouseEventArgs e) {
            SomethingPressed(lstV.SelectedItems[0], e);
        }

    }
}
