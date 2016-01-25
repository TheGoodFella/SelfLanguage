using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using SelfLanguage;

namespace IDE {
    public partial class Debugger : Form {
        Language l { get; set; }
        private int Memory { get; set; }
        private int EntryPoint { get; set; }
        private string _program { get; set; }
        private  bool DebugGoOn { get; set; }
        public Debugger() {
            InitializeComponent();
        }
        public Debugger(string program) {
            InitializeComponent();
            _program = program;
            lstMemory.Items.AddRange(program.Select((s) => new ListViewItem(Convert.ToString(s))).ToArray());
            txtMemoryAlloc.Maximum = Int16.MaxValue;
            txtMemoryAlloc.Value = Convert.ToDecimal(program.Length);
        }

        private void splitter1_SplitterMoved(object sender, SplitterEventArgs e) {
            grpMemoryAndRam.Height = splitter1.Top;
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e) {

        }

        private void btnAll_Click(object sender, EventArgs e) {
            Memory = Convert.ToInt32(txtMemoryAlloc.Value);
            EntryPoint = Convert.ToInt32(txtProgramEntryPoint.Value);
            l = new Language(Memory);
        }

        private void btnAllAndLoad_Click(object sender, EventArgs e) {
            Memory = Convert.ToInt32(txtMemoryAlloc.Value);
            EntryPoint = Convert.ToInt32(txtProgramEntryPoint.Value);
            l = new Language(Memory);
            l.LoadInMemory(_program, EntryPoint);
        }

        private void btnLoad_Click(object sender, EventArgs e) {
            l.LoadInMemory(_program, EntryPoint);
        }

        private void Debugger_KeyPress(object sender, KeyPressEventArgs e) {

        }

        private void Debugger_KeyUp(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.F10) {
                DebugGoOn = true;
            }
        }


        private ListViewItem[] ItemsToArray(ListView l) {
            return Enumerable.Range(0, l.Items.Count).Select((k) => l.Items[k]).ToArray();
        }
        #region Debug
        /// <summary>
        /// Fast debugger, adding 100ms delay between each debug event
        /// </summary>       
        private void fastToolStripMenuItem_Click(object sender, EventArgs e) {
            GenericCreateLanguageDebug(() => System.Threading.Thread.Sleep(100));
            var task = new Task(() => l.Run(EntryPoint, true));
            task.Start(); //This is done in 2 rows(dec+run) for clarity
        }
        private void slow1000msDelayPerCommandToolStripMenuItem_Click(object sender, EventArgs e) {
            GenericCreateLanguageDebug(() => System.Threading.Thread.Sleep(1000));
            var task = new Task(() => l.Run(EntryPoint, true) );
            task.Start(); //This is done in 2 rows(dec+run) for clarity
        }
        private void userF10ToolStripMenuItem_Click(object sender, EventArgs e) {
            GenericCreateLanguageDebug(() => { while (!DebugGoOn) { System.Threading.Thread.Sleep(100); } });
            var task = new Task(() => l.Run(EntryPoint, true) );
            task.Start(); //This is done in 2 rows(dec+run) for clarity
        }
        #endregion
        private void GenericCreateLanguageDebug(Action whatDebug) {
            if (l == null) {
                MessageBox.Show(string.Format("The program is running with default allocated memory, missing allocation?\n\nThe program is going to be loaded in the position 0, an it is going to be allocated {0} bytes of memory",_program.Length));
                EntryPoint = 0;
                Memory = _program.Length;
                l = new Language(Memory);
                l.LoadInMemory(_program, 0);
            }
            l.ExceptionRised += new Action<SelfLanguage.Utility.Logging>((a) => {
                this.Invoke(new Action(() => MessageBox.Show(a.Message)));
            });
            l.GenericLog = (s) => {
                try {
                    lstLogger.Invoke(new Action(() => lstLogger.Items.Add(s.Message)));
                } catch (ObjectDisposedException) {
                    //Disposed, nothing to bother about it
                }
            };
            l.Debug = (k) => {
                try {
                    lstMemory.Invoke(new Action(() => {
                        DebugGoOn = false;
                        lstMemory.SuspendLayout();
                        lstMemory.Items.Clear();
                        lstMemory.Items.AddRange(l.Memory.Select((theStuff) => new ListViewItem(Convert.ToString(theStuff))).ToArray());
                        for (int i = 0; i < lstMemory.Items.Count; i++) {
                            lstMemory.Items[i].BackColor = lstMemory.BackColor;
                        }
                        lstMemory.Items[k.Pointer + 1].BackColor = System.Drawing.Color.LightBlue;
                        lstMemory.ResumeLayout();
                    }));
                    whatDebug();
                } catch (ObjectDisposedException) {
                    //Disposed, nothing to bother about it
                }
            };
        }
    }
}
