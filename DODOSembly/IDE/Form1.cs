using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace IDE {
    public partial class Form1 : Form {
        private char[] to_ignore = new char[] { '\n','\r','\t' };

        public Form1() {
            InitializeComponent();
            textEditor1.OnCompile = OnCompile;
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e) {
            var v = new SaveFileDialog();
            v.DefaultExt = ".das";
            v.AddExtension = true;
            var out_p= v.ShowDialog();
            if (out_p == System.Windows.Forms.DialogResult.OK) {
                File.WriteAllText(v.FileName, textEditor1.Text);
            }
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e) {
            var v = new OpenFileDialog();
            v.DefaultExt = ".das";
            var out_p = v.ShowDialog();
            if (out_p == System.Windows.Forms.DialogResult.OK) {
                textEditor1.Text = File.ReadAllText(v.FileName);
            }
        }
        private void OnCompile(object sender, string e) {
            File.WriteAllBytes("C:\\lavoro-temp\\l.a", e.Select((k) => Convert.ToByte(k)).ToArray());
            //File.WriteAllText("C:\\kkk.a", e.Where((k) => !to_ignore.Any((s) => k == s)));
        }
    }
}
