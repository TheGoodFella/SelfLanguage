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

        protected override void Select(bool directed, bool forward) {
            lstV.Select();
        }

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


        private void lstV_KeyPress(object sender, KeyPressEventArgs e) {
        }

        private void lstV_KeyDown(object sender, KeyEventArgs e) {
            if ((e.KeyCode == Keys.Subtract || e.KeyCode == Keys.OemMinus)&&e.Control) {
                lstV.Font = new Font(lstV.Font.FontFamily, (lstV.Font.Size - 1>1?lstV.Font.Size-1:1));
            } else if (e.KeyCode == Keys.Add && e.Control) {
                lstV.Font = new Font(lstV.Font.FontFamily, (lstV.Font.Size + 1 < 100 ? lstV.Font.Size + 1 : 100));
            }
        }
    }
}
