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
            this.components = new System.ComponentModel.Container();
            this.grpMemoryAndRam = new System.Windows.Forms.GroupBox();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lstRam = new System.Windows.Forms.ListView();
            this.lstMemory = new System.Windows.Forms.ListView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.grpExecution = new System.Windows.Forms.GroupBox();
            this.txtMemoryAlloc = new System.Windows.Forms.NumericUpDown();
            this.lblMemoryToAlloc = new System.Windows.Forms.Label();
            this.txtProgramEntryPoint = new System.Windows.Forms.NumericUpDown();
            this.lblProgramEntryPoint = new System.Windows.Forms.Label();
            this.grpMemoryAndRam.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.grpExecution.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMemoryAlloc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProgramEntryPoint)).BeginInit();
            this.SuspendLayout();
            // 
            // grpMemoryAndRam
            // 
            this.grpMemoryAndRam.Controls.Add(this.splitContainer1);
            this.grpMemoryAndRam.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpMemoryAndRam.Location = new System.Drawing.Point(0, 24);
            this.grpMemoryAndRam.Name = "grpMemoryAndRam";
            this.grpMemoryAndRam.Size = new System.Drawing.Size(546, 182);
            this.grpMemoryAndRam.TabIndex = 0;
            this.grpMemoryAndRam.TabStop = false;
            this.grpMemoryAndRam.Text = "Memory and Ram";
            // 
            // splitter1
            // 
            this.splitter1.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter1.Location = new System.Drawing.Point(0, 206);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(546, 3);
            this.splitter1.TabIndex = 1;
            this.splitter1.TabStop = false;
            this.splitter1.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splitter1_SplitterMoved);
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
            this.splitContainer1.Panel1.Controls.Add(this.lstRam);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.lstMemory);
            this.splitContainer1.Size = new System.Drawing.Size(540, 163);
            this.splitContainer1.SplitterDistance = 77;
            this.splitContainer1.TabIndex = 0;
            // 
            // lstRam
            // 
            this.lstRam.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstRam.Location = new System.Drawing.Point(0, 0);
            this.lstRam.Name = "lstRam";
            this.lstRam.Size = new System.Drawing.Size(540, 77);
            this.lstRam.TabIndex = 0;
            this.lstRam.UseCompatibleStateImageBehavior = false;
            // 
            // lstMemory
            // 
            this.lstMemory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstMemory.Location = new System.Drawing.Point(0, 0);
            this.lstMemory.Name = "lstMemory";
            this.lstMemory.Size = new System.Drawing.Size(540, 82);
            this.lstMemory.TabIndex = 0;
            this.lstMemory.UseCompatibleStateImageBehavior = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(546, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Image = global::IDE.Properties.Resources.Go;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(38, 20);
            this.toolStripMenuItem1.Text = " ";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            // 
            // grpExecution
            // 
            this.grpExecution.Controls.Add(this.lblProgramEntryPoint);
            this.grpExecution.Controls.Add(this.txtProgramEntryPoint);
            this.grpExecution.Controls.Add(this.lblMemoryToAlloc);
            this.grpExecution.Controls.Add(this.txtMemoryAlloc);
            this.grpExecution.Dock = System.Windows.Forms.DockStyle.Left;
            this.grpExecution.Location = new System.Drawing.Point(0, 209);
            this.grpExecution.Name = "grpExecution";
            this.grpExecution.Size = new System.Drawing.Size(200, 218);
            this.grpExecution.TabIndex = 3;
            this.grpExecution.TabStop = false;
            this.grpExecution.Text = "Running options";
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
            // lblMemoryToAlloc
            // 
            this.lblMemoryToAlloc.AutoSize = true;
            this.lblMemoryToAlloc.Location = new System.Drawing.Point(87, 32);
            this.lblMemoryToAlloc.Name = "lblMemoryToAlloc";
            this.lblMemoryToAlloc.Size = new System.Drawing.Size(96, 13);
            this.lblMemoryToAlloc.TabIndex = 1;
            this.lblMemoryToAlloc.Text = "Memory to allocate";
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
            // lblProgramEntryPoint
            // 
            this.lblProgramEntryPoint.AutoSize = true;
            this.lblProgramEntryPoint.Location = new System.Drawing.Point(87, 59);
            this.lblProgramEntryPoint.Name = "lblProgramEntryPoint";
            this.lblProgramEntryPoint.Size = new System.Drawing.Size(99, 13);
            this.lblProgramEntryPoint.TabIndex = 3;
            this.lblProgramEntryPoint.Text = "Program entry Point";
            // 
            // Debugger
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(546, 427);
            this.Controls.Add(this.grpExecution);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.grpMemoryAndRam);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Debugger";
            this.Text = "Debugger";
            this.grpMemoryAndRam.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.grpExecution.ResumeLayout(false);
            this.grpExecution.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMemoryAlloc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProgramEntryPoint)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpMemoryAndRam;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListView lstRam;
        private System.Windows.Forms.ListView lstMemory;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.GroupBox grpExecution;
        private System.Windows.Forms.NumericUpDown txtMemoryAlloc;
        private System.Windows.Forms.Label lblMemoryToAlloc;
        private System.Windows.Forms.Label lblProgramEntryPoint;
        private System.Windows.Forms.NumericUpDown txtProgramEntryPoint;



    }
}