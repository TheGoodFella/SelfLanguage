namespace IDE {
    partial class Debugger {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.grpMemoryAndRam = new System.Windows.Forms.GroupBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.lstRam = new System.Windows.Forms.ListBox();
            this.lstStack = new System.Windows.Forms.ListBox();
            this.lstMemory = new System.Windows.Forms.ListView();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.fastToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.slow1000msDelayPerCommandToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.userF10ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.compileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.grpExecution = new System.Windows.Forms.GroupBox();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnAllAndLoad = new System.Windows.Forms.Button();
            this.btnAll = new System.Windows.Forms.Button();
            this.lblProgramEntryPoint = new System.Windows.Forms.Label();
            this.txtProgramEntryPoint = new System.Windows.Forms.NumericUpDown();
            this.lblMemoryToAlloc = new System.Windows.Forms.Label();
            this.txtMemoryAlloc = new System.Windows.Forms.NumericUpDown();
            this.grpLogger = new System.Windows.Forms.GroupBox();
            this.lstLogger = new System.Windows.Forms.ListBox();
            this.runToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.grpMemoryAndRam.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.grpExecution.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtProgramEntryPoint)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMemoryAlloc)).BeginInit();
            this.grpLogger.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpMemoryAndRam
            // 
            this.grpMemoryAndRam.Controls.Add(this.splitContainer1);
            this.grpMemoryAndRam.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpMemoryAndRam.Location = new System.Drawing.Point(0, 24);
            this.grpMemoryAndRam.Name = "grpMemoryAndRam";
            this.grpMemoryAndRam.Size = new System.Drawing.Size(471, 182);
            this.grpMemoryAndRam.TabIndex = 0;
            this.grpMemoryAndRam.TabStop = false;
            this.grpMemoryAndRam.Text = "Memory, Ram and Stack";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 16);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.lstMemory);
            this.splitContainer1.Size = new System.Drawing.Size(465, 163);
            this.splitContainer1.SplitterDistance = 77;
            this.splitContainer1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.lstRam);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.lstStack);
            this.splitContainer2.Size = new System.Drawing.Size(465, 77);
            this.splitContainer2.SplitterDistance = 353;
            this.splitContainer2.TabIndex = 0;
            // 
            // lstRam
            // 
            this.lstRam.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstRam.FormattingEnabled = true;
            this.lstRam.Location = new System.Drawing.Point(0, 0);
            this.lstRam.Name = "lstRam";
            this.lstRam.Size = new System.Drawing.Size(353, 77);
            this.lstRam.TabIndex = 0;
            // 
            // lstStack
            // 
            this.lstStack.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstStack.FormattingEnabled = true;
            this.lstStack.Location = new System.Drawing.Point(0, 0);
            this.lstStack.Name = "lstStack";
            this.lstStack.Size = new System.Drawing.Size(108, 77);
            this.lstStack.TabIndex = 1;
            // 
            // lstMemory
            // 
            this.lstMemory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstMemory.Font = new System.Drawing.Font("Courier New", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstMemory.Location = new System.Drawing.Point(0, 0);
            this.lstMemory.Name = "lstMemory";
            this.lstMemory.Size = new System.Drawing.Size(465, 82);
            this.lstMemory.TabIndex = 0;
            this.lstMemory.UseCompatibleStateImageBehavior = false;
            // 
            // splitter1
            // 
            this.splitter1.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter1.Location = new System.Drawing.Point(0, 206);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(471, 3);
            this.splitter1.TabIndex = 1;
            this.splitter1.TabStop = false;
            this.splitter1.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splitter1_SplitterMoved);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.compileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(471, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.runToolStripMenuItem,
            this.fastToolStripMenuItem,
            this.slow1000msDelayPerCommandToolStripMenuItem,
            this.userF10ToolStripMenuItem});
            this.toolStripMenuItem1.Image = global::IDE.Properties.Resources.Go;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(70, 20);
            this.toolStripMenuItem1.Text = "Debug";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // fastToolStripMenuItem
            // 
            this.fastToolStripMenuItem.Name = "fastToolStripMenuItem";
            this.fastToolStripMenuItem.Size = new System.Drawing.Size(256, 22);
            this.fastToolStripMenuItem.Text = "Fast (100ms) delay per command";
            this.fastToolStripMenuItem.Click += new System.EventHandler(this.fastToolStripMenuItem_Click);
            // 
            // slow1000msDelayPerCommandToolStripMenuItem
            // 
            this.slow1000msDelayPerCommandToolStripMenuItem.Name = "slow1000msDelayPerCommandToolStripMenuItem";
            this.slow1000msDelayPerCommandToolStripMenuItem.Size = new System.Drawing.Size(256, 22);
            this.slow1000msDelayPerCommandToolStripMenuItem.Text = "Slow(1000ms) delay per command";
            this.slow1000msDelayPerCommandToolStripMenuItem.Click += new System.EventHandler(this.slow1000msDelayPerCommandToolStripMenuItem_Click);
            // 
            // userF10ToolStripMenuItem
            // 
            this.userF10ToolStripMenuItem.Name = "userF10ToolStripMenuItem";
            this.userF10ToolStripMenuItem.Size = new System.Drawing.Size(256, 22);
            this.userF10ToolStripMenuItem.Text = "User(F10)";
            this.userF10ToolStripMenuItem.Click += new System.EventHandler(this.userF10ToolStripMenuItem_Click);
            // 
            // compileToolStripMenuItem
            // 
            this.compileToolStripMenuItem.Name = "compileToolStripMenuItem";
            this.compileToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
            this.compileToolStripMenuItem.Text = "Compile";
            this.compileToolStripMenuItem.Visible = false;
            this.compileToolStripMenuItem.Click += new System.EventHandler(this.compileToolStripMenuItem_Click);
            // 
            // grpExecution
            // 
            this.grpExecution.Controls.Add(this.btnLoad);
            this.grpExecution.Controls.Add(this.btnAllAndLoad);
            this.grpExecution.Controls.Add(this.btnAll);
            this.grpExecution.Controls.Add(this.lblProgramEntryPoint);
            this.grpExecution.Controls.Add(this.txtProgramEntryPoint);
            this.grpExecution.Controls.Add(this.lblMemoryToAlloc);
            this.grpExecution.Controls.Add(this.txtMemoryAlloc);
            this.grpExecution.Dock = System.Windows.Forms.DockStyle.Left;
            this.grpExecution.Location = new System.Drawing.Point(0, 209);
            this.grpExecution.Name = "grpExecution";
            this.grpExecution.Size = new System.Drawing.Size(221, 218);
            this.grpExecution.TabIndex = 3;
            this.grpExecution.TabStop = false;
            this.grpExecution.Text = "Running options";
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(7, 142);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(176, 23);
            this.btnLoad.TabIndex = 6;
            this.btnLoad.Text = "Load in memory the program";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnAllAndLoad
            // 
            this.btnAllAndLoad.Location = new System.Drawing.Point(7, 113);
            this.btnAllAndLoad.Name = "btnAllAndLoad";
            this.btnAllAndLoad.Size = new System.Drawing.Size(176, 23);
            this.btnAllAndLoad.TabIndex = 5;
            this.btnAllAndLoad.Text = "Allocate and load program";
            this.btnAllAndLoad.UseVisualStyleBackColor = true;
            this.btnAllAndLoad.Click += new System.EventHandler(this.btnAllAndLoad_Click);
            // 
            // btnAll
            // 
            this.btnAll.Location = new System.Drawing.Point(7, 84);
            this.btnAll.Name = "btnAll";
            this.btnAll.Size = new System.Drawing.Size(176, 23);
            this.btnAll.TabIndex = 4;
            this.btnAll.Text = "Allocate";
            this.btnAll.UseVisualStyleBackColor = true;
            this.btnAll.Click += new System.EventHandler(this.btnAll_Click);
            // 
            // lblProgramEntryPoint
            // 
            this.lblProgramEntryPoint.AutoSize = true;
            this.lblProgramEntryPoint.Location = new System.Drawing.Point(87, 59);
            this.lblProgramEntryPoint.Name = "lblProgramEntryPoint";
            this.lblProgramEntryPoint.Size = new System.Drawing.Size(99, 13);
            this.lblProgramEntryPoint.TabIndex = 3;
            this.lblProgramEntryPoint.Text = "Program entry Point";
            // 
            // txtProgramEntryPoint
            // 
            this.txtProgramEntryPoint.Location = new System.Drawing.Point(7, 57);
            this.txtProgramEntryPoint.Maximum = new decimal(new int[] {
            600,
            0,
            0,
            0});
            this.txtProgramEntryPoint.Name = "txtProgramEntryPoint";
            this.txtProgramEntryPoint.Size = new System.Drawing.Size(74, 20);
            this.txtProgramEntryPoint.TabIndex = 2;
            // 
            // lblMemoryToAlloc
            // 
            this.lblMemoryToAlloc.AutoSize = true;
            this.lblMemoryToAlloc.Location = new System.Drawing.Point(87, 32);
            this.lblMemoryToAlloc.Name = "lblMemoryToAlloc";
            this.lblMemoryToAlloc.Size = new System.Drawing.Size(96, 13);
            this.lblMemoryToAlloc.TabIndex = 1;
            this.lblMemoryToAlloc.Text = "Memory to allocate";
            // 
            // txtMemoryAlloc
            // 
            this.txtMemoryAlloc.Location = new System.Drawing.Point(6, 30);
            this.txtMemoryAlloc.Maximum = new decimal(new int[] {
            600,
            0,
            0,
            0});
            this.txtMemoryAlloc.Name = "txtMemoryAlloc";
            this.txtMemoryAlloc.Size = new System.Drawing.Size(75, 20);
            this.txtMemoryAlloc.TabIndex = 0;
            // 
            // grpLogger
            // 
            this.grpLogger.Controls.Add(this.lstLogger);
            this.grpLogger.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpLogger.Location = new System.Drawing.Point(221, 209);
            this.grpLogger.Name = "grpLogger";
            this.grpLogger.Size = new System.Drawing.Size(250, 218);
            this.grpLogger.TabIndex = 7;
            this.grpLogger.TabStop = false;
            this.grpLogger.Text = "Logger";
            // 
            // lstLogger
            // 
            this.lstLogger.BackColor = System.Drawing.SystemColors.MenuText;
            this.lstLogger.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstLogger.ForeColor = System.Drawing.Color.White;
            this.lstLogger.FormattingEnabled = true;
            this.lstLogger.Location = new System.Drawing.Point(3, 16);
            this.lstLogger.Name = "lstLogger";
            this.lstLogger.Size = new System.Drawing.Size(244, 199);
            this.lstLogger.TabIndex = 0;
            // 
            // runToolStripMenuItem
            // 
            this.runToolStripMenuItem.Name = "runToolStripMenuItem";
            this.runToolStripMenuItem.Size = new System.Drawing.Size(256, 22);
            this.runToolStripMenuItem.Text = "Run";
            this.runToolStripMenuItem.Click += new System.EventHandler(this.runToolStripMenuItem_Click);
            // 
            // Debugger
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(471, 427);
            this.Controls.Add(this.grpLogger);
            this.Controls.Add(this.grpExecution);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.grpMemoryAndRam);
            this.Controls.Add(this.menuStrip1);
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Debugger";
            this.Text = "Debugger";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Debugger_KeyPress);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Debugger_KeyUp);
            this.grpMemoryAndRam.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.grpExecution.ResumeLayout(false);
            this.grpExecution.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtProgramEntryPoint)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMemoryAlloc)).EndInit();
            this.grpLogger.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpMemoryAndRam;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListView lstMemory;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.GroupBox grpExecution;
        private System.Windows.Forms.NumericUpDown txtMemoryAlloc;
        private System.Windows.Forms.Label lblMemoryToAlloc;
        private System.Windows.Forms.Label lblProgramEntryPoint;
        private System.Windows.Forms.NumericUpDown txtProgramEntryPoint;
        private System.Windows.Forms.Button btnAllAndLoad;
        private System.Windows.Forms.Button btnAll;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.GroupBox grpLogger;
        private System.Windows.Forms.ListBox lstLogger;
        private System.Windows.Forms.ToolStripMenuItem fastToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem slow1000msDelayPerCommandToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem userF10ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem compileToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.ListBox lstRam;
        private System.Windows.Forms.ListBox lstStack;
        private System.Windows.Forms.ToolStripMenuItem runToolStripMenuItem;



    }
}