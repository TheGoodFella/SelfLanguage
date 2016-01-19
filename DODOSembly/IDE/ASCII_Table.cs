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
        public int ZoomFactor = 0;
        private int[] ASCII_Offset = new int[] { 36, 126 };
        List<char> ls_char { get; set; }

        public ASCII_Table() {
            InitializeComponent();
            ls_char = new List<char>();
        }
        public void GenerateTable() {
            ls_char = Enumerable.Range(ASCII_Offset[0], ASCII_Offset[1]).Select((s) => Convert.ToChar(s)).ToList();            
            var possible_per_row = GetDividors(ASCII_Offset[0], ASCII_Offset[1]);
            tableLayoutPanel1.RowCount = possible_per_row[ZoomFactor];
            tableLayoutPanel1.ColumnCount = (ASCII_Offset[1] - ASCII_Offset[0]) / possible_per_row[ZoomFactor];
            for (int i = 0; i < possible_per_row[ZoomFactor]; i++) {
                //tableLayoutPanel1.
            }
        }
        public List<int> GetDividors(int n1, int n2){
            return Enumerable.Range(2, n2/2).Where((x) => Convert.ToDouble(n2 - n1) % (double)x == 0).ToList();
        }
    }
}
