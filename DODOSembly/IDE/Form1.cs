using System;
using System.Windows.Forms;
using System.IO;
using System.Linq;
using SelfLanguage;

namespace IDE {
    public partial class Form1 : Form {
        private char[] to_ignore = new char[] { '\n','\r','\t' };

        public Form1() {
            InitializeComponent();
            textEditor1.OnRun += OnRun;
            asciI_Table1.SomethingPressed = new EventHandler((s,e) => {
                textEditor1.Select();
                textEditor1.AppendText(Convert.ToString(Convert.ToInt32(Convert.ToChar(((dynamic)s).Text))));
            });
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
        private void OnRun(object sender, string e) {
            var Debugger1 = new Debugger(e);
            Debugger1.Show();
            
        }
    }
}
