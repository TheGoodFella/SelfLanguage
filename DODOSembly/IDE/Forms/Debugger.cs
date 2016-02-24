#define DEBUG

using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using SelfLanguage;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
#if DEBUG
using System.CodeDom.Compiler;
using System.Diagnostics;
using Microsoft.CSharp;
#endif


namespace IDE {
    public partial class Debugger : Form {
        Language language { get; set; }
        private int Memory { get; set; }
        private int EntryPoint { get; set; }
        private string _program { get; set; }
        private bool DebugGoOn { get; set; }
        private bool DebugErrorColor { get; set; }
        private Color DebugColor { get; set; }
        private Color ErrorColor { get; set; }
        public Debugger() {
            InitializeComponent();
            DebugColor = Color.LightBlue;
            ErrorColor = Color.Red;
            txtMemoryAlloc.Maximum = Int16.MaxValue;
            DebugErrorColor = false;
        }
        public Debugger(string program):this() {
            _program = program;
            txtMemoryAlloc.Value = Convert.ToDecimal(program.Length);
            lstMemory.Items.AddRange(program.Select((s) => new ListViewItem(Convert.ToString(s))).ToArray());
        }

        private void splitter1_SplitterMoved(object sender, SplitterEventArgs e) {
            grpMemoryAndRam.Height = splitter1.Top;
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e) {

        }

        private void btnAll_Click(object sender, EventArgs e) {
            Memory = Convert.ToInt32(txtMemoryAlloc.Value);
            EntryPoint = Convert.ToInt32(txtProgramEntryPoint.Value);
            language = new Language(Memory);
        }

        private void btnAllAndLoad_Click(object sender, EventArgs e) {
            Memory = Convert.ToInt32(txtMemoryAlloc.Value);
            EntryPoint = Convert.ToInt32(txtProgramEntryPoint.Value);
            language = new Language(Memory);
            language.LoadInMemory(_program, EntryPoint);
        }

        private void btnLoad_Click(object sender, EventArgs e) {
            language.LoadInMemory(_program, EntryPoint);
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
            var task = new Task(() => language.Run(EntryPoint, true));
            task.Start(); //This is done in 2 rows(dec+run) for clarity
        }
        private void runToolStripMenuItem_Click(object sender, EventArgs e) {
            GenericCreateLanguageDebug(() => { });
            var task = new Task(() => language.Run(EntryPoint, true));
            task.Start(); //This is done in 2 rows(dec+run) for clarity
        }
        private void slow1000msDelayPerCommandToolStripMenuItem_Click(object sender, EventArgs e) {
            GenericCreateLanguageDebug(() => System.Threading.Thread.Sleep(1000));
            var task = new Task(() => language.Run(EntryPoint, true) );
            task.Start(); //This is done in 2 rows(dec+run) for clarity
        }
        private void userF10ToolStripMenuItem_Click(object sender, EventArgs e) {
            GenericCreateLanguageDebug(() => { while (!DebugGoOn) { System.Threading.Thread.Sleep(100); } });
            var task = new Task(() => language.Run(EntryPoint, true) );
            task.Start(); //This is done in 2 rows(dec+run) for clarity
        }
        #endregion

        private void GenericCreateLanguageDebug(Action whatDebug) {
            if (language == null) {
                MessageBox.Show(string.Format("The program is running with default allocated memory, missing allocation?\n\nThe program is going to get loaded in the position 0, an it is going to get allocated {0} bytes of memory",_program.Length));
                EntryPoint = 0;
                Memory = _program.Length;
                language = new Language(Memory);
                language.LoadInMemory(_program, 0);
            }
            language.ExceptionRised += new Action<SelfLanguage.Utility.Logging>((a) => {
                DebugErrorColor = true;
                this.Invoke(new Action(() =>{
                    MessageBox.Show(a.Message  + " at " + a.Pointer);
                    lstMemory.Items[a.Pointer].BackColor = ErrorColor;
                }));
                
            });
            language.GenericLog = (s) => {
                try {
                    lstLogger.Invoke(new Action(() => lstLogger.Items.Add(s.Message)));
                    //lstLogger.Invoke(new Action(() => MessageBox.Show(s.Message)));
                } catch (ObjectDisposedException) {
                    //Disposed, nothing to bother about it
                }
            };
            language.Debug = (k) => {
                try {
                    lstMemory.Invoke(new Action(() => {
                        if (DebugErrorColor) { return; }
                        DebugGoOn = false;
                        lstMemory.SuspendLayout();
                        lstMemory.Items.Clear();
                        lstMemory.Items.AddRange(language.Memory.Select((theStuff) => new ListViewItem(Convert.ToString(theStuff))).ToArray());
                        for (int i = 0; i < lstMemory.Items.Count; i++) {
                            lstMemory.Items[i].BackColor = lstMemory.BackColor;
                        }
                        lstMemory.Items[k.Pointer + 1].BackColor = DebugColor;
                        lstRam.Items.Clear();
                        lstRam.Items.AddRange(language.Ram.Select((s) =>string.Format("Value> {0}, Name> {1}, Type> {2}",s.IncapsulatedValue,s.Name,s.GetType().Name)).ToArray());
                        lstStack.Items.Clear();
                        lstStack.Items.AddRange(language.CommandStackCarry.Select((ma) => ma.ToString()).ToArray());
                        lstMemory.ResumeLayout();
                    }));
                    whatDebug();
                } catch (ObjectDisposedException) {
                    //Disposed, nothing to bother about it
                }
            };
        }
        private void compileToolStripMenuItem_Click(object sender, EventArgs e) {
        }
    }
}
