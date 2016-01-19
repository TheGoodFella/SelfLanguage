using System;
using System.Linq;
using System.Windows.Forms;
using SelfLanguage;

namespace IDE {
    public partial class Debugger : Form {
        Language l { get; set; }
        public Debugger() {
            InitializeComponent();
        }
        public Debugger(char[] program) {
            lstMemory.Items.AddRange(program.Select((s)=>new ListViewItem(Convert.ToString(s))).ToArray()); 
        }

        private void splitter1_SplitterMoved(object sender, SplitterEventArgs e) {
            grpMemoryAndRam.Height = splitter1.Top;
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e) {
            var memory_to_allocate = txtMemoryAlloc.Value;
            var entry_point = txtProgramEntryPoint.Value;
        }
    }
}
