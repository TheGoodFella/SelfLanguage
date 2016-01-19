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
        List<TableContent> ls_table = new List<TableContent>();
        List<char> ls_char { get; set; }

        public ASCII_Table() {
            InitializeComponent();
            ls_char = new List<char>();
            GenerateTable();
            bindingSource1.DataSource = ls_table;
        }
        public void GenerateTable() {
            ls_table = Enumerable.Range(ASCII_Offset[0], ASCII_Offset[1]).Select((s) => new TableContent(Convert.ToString(s),Convert.ToString(Convert.ToChar(s)))).ToList();
        }
        public List<int> GetDividors(int n1, int n2){
            return Enumerable.Range(2, n2/2).Where((x) => Convert.ToDouble(n2 - n1) % (double)x == 0).ToList();
        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }
    }
    class TableContent
    {
        public string CharCode { get; set; }
        public string Char_ { get; set; }
        public TableContent(string charcode,string char_){
            Char_ = char_;
            CharCode = charcode;
        }
    }
}
