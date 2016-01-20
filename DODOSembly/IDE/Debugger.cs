﻿using System;
using System.Linq;
using System.Windows.Forms;
using SelfLanguage;

namespace IDE {
    public partial class Debugger : Form {
        Language l { get; set; }
        private int Memory { get; set; }
        private int EntryPoint { get; set; }
        private string _program { get; set; }
        public Debugger() {
            InitializeComponent();
        }
        public Debugger(string program) {
            InitializeComponent();
            _program = program;
            lstMemory.Items.AddRange(program.Select((s)=>new ListViewItem(Convert.ToString(s))).ToArray()); 
        }

        private void splitter1_SplitterMoved(object sender, SplitterEventArgs e) {
            grpMemoryAndRam.Height = splitter1.Top;
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e) {
            l.Run(EntryPoint);
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            Memory = Convert.ToInt32(txtMemoryAlloc.Value);
            EntryPoint = Convert.ToInt32(txtProgramEntryPoint.Value);
            l = new Language(Memory);
        }

        private void btnAllAndLoad_Click(object sender, EventArgs e)
        {
            Memory = Convert.ToInt32(txtMemoryAlloc.Value);
            EntryPoint = Convert.ToInt32(txtProgramEntryPoint.Value);
            l = new Language(Memory);
            l.LoadInMemory(_program, EntryPoint);
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            l.LoadInMemory(_program, EntryPoint);
        }
    }
}