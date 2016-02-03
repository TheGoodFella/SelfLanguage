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
        Language l { get; set; }
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
                MessageBox.Show(string.Format("The program is running with default allocated memory, missing allocation?\n\nThe program is going to get loaded in the position 0, an it is going to get allocated {0} bytes of memory",_program.Length));
                EntryPoint = 0;
                Memory = _program.Length;
                l = new Language(Memory);
                l.LoadInMemory(_program, 0);
            }
            l.ExceptionRised += new Action<SelfLanguage.Utility.Logging>((a) => {
                DebugErrorColor = true;
                this.Invoke(new Action(() =>{
                    MessageBox.Show(a.Message  + " at " + a.Pointer);
                    lstMemory.Items[a.Pointer].BackColor = ErrorColor;
                }));
                
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
                        if (DebugErrorColor) { return; }
                        DebugGoOn = false;
                        lstMemory.SuspendLayout();
                        lstMemory.Items.Clear();
                        lstMemory.Items.AddRange(l.Memory.Select((theStuff) => new ListViewItem(Convert.ToString(theStuff))).ToArray());
                        for (int i = 0; i < lstMemory.Items.Count; i++) {
                            lstMemory.Items[i].BackColor = lstMemory.BackColor;
                        }
                        lstMemory.Items[k.Pointer + 1].BackColor = DebugColor;
                        lstMemory.ResumeLayout();
                    }));
                    whatDebug();
                } catch (ObjectDisposedException) {
                    //Disposed, nothing to bother about it
                }
            };
        }

        private void compileToolStripMenuItem_Click(object sender, EventArgs e) {
#if DEBUG
            createDLL();
#endif   
            var selfC = new SelfLanguage.Compiler.SelfCompiler();
            selfC.Compile(Path.Combine(@"C:\lavoro-temp", "l.exe"), "#e=0\n#m=100\n" + _program, File.ReadAllText(@"../../ProjectTemplates/ConsoleTmp.cs"));
        }
#if DEBUG
        private bool createDLL(){
            CompilerParameters parameters = new CompilerParameters();
            parameters.GenerateExecutable = false;
            parameters.OutputAssembly = "SelfDLL.dll";
            parameters.ReferencedAssemblies.AddRange(new string[] { "System.dll", "mscorlib.dll", "System.Data.dll", "System.Core.dll"});
            var files_name = Directory.GetFiles("../../").Where((s) => s.Contains("SelfLanguage") && s.Contains(".cs"));
            var all_files = files_name.ToList()
                .Select((w) => File.ReadAllLines(w));
            var all_usings = noDuplicates(all_files.Select((k)=>k.Where((l)=>l.IndexOf("using")!=-1)).Aggregate((first,second)=>{
                first.ToList().AddRange(second.ToList());
                return first;
            }).ToArray());
            var code = all_files.Select((l)=>l.Where((z)=>z.IndexOf("using")==-1).ToList()).Aggregate((first,second)=>{
                first.ToList().AddRange(second.ToList());
                return first;
            }) ;
            var _united_code = all_usings.Aggregate((a, b) => a + b) + code.Aggregate((a, b) => a + b);
            var er = new CSharpCodeProvider((new Dictionary<string, string> {{"CompilerVersion","v4.0"}}));
            var r = er.CompileAssemblyFromSource(parameters, _united_code);
            Enumerable.Range(0, r.Errors.Count).ToList().ForEach((k) => MessageBox.Show(r.Errors[k].ErrorText));
            return r.Errors.Count == 0;
        }
        private string[] noDuplicates(string[] s) {
            var tmp = new System.Collections.Generic.List<string>();
            s.ToList().ForEach((k) => {
                if (!tmp.Contains(k)) {
                    tmp.Add(k);
                }
            });
            return tmp.ToArray();
        }
#endif
        
    }
}
