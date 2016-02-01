namespace IDE {
    partial class TextEditor {
        /// <summary> 
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione componenti

        /// <summary> 
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare 
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.splitter = new System.Windows.Forms.SplitContainer();
            this.txtPointers = new IDE.CustomTextBox();
            this.pnlIntellisense = new System.Windows.Forms.Panel();
            this.txtCode = new IDE.CustomTextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.textToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeSelectionColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeSelectionBackcolorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fontToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.codeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.compileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.txtStatusPointer = new System.Windows.Forms.ToolStripStatusLabel();
            this.tmrZoom = new System.Windows.Forms.Timer(this.components);
            this.txtIntellisense = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitter)).BeginInit();
            this.splitter.Panel1.SuspendLayout();
            this.splitter.Panel2.SuspendLayout();
            this.splitter.SuspendLayout();
            this.pnlIntellisense.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitter
            // 
            this.splitter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitter.Location = new System.Drawing.Point(0, 24);
            this.splitter.Name = "splitter";
            // 
            // splitter.Panel1
            // 
            this.splitter.Panel1.Controls.Add(this.txtPointers);
            // 
            // splitter.Panel2
            // 
            this.splitter.Panel2.Controls.Add(this.pnlIntellisense);
            this.splitter.Panel2.Controls.Add(this.txtCode);
            this.splitter.Size = new System.Drawing.Size(603, 285);
            this.splitter.SplitterDistance = 91;
            this.splitter.TabIndex = 2;
            this.splitter.TabStop = false;
            // 
            // txtPointers
            // 
            this.txtPointers.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPointers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPointers.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txtPointers.Location = new System.Drawing.Point(0, 0);
            this.txtPointers.Name = "txtPointers";
            this.txtPointers.ReadOnly = true;
            this.txtPointers.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtPointers.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.txtPointers.Size = new System.Drawing.Size(91, 285);
            this.txtPointers.TabIndex = 0;
            this.txtPointers.TabStop = false;
            this.txtPointers.Text = "";
            this.txtPointers.WordWrap = false;
            // 
            // pnlIntellisense
            // 
            this.pnlIntellisense.Controls.Add(this.txtIntellisense);
            this.pnlIntellisense.Location = new System.Drawing.Point(125, 56);
            this.pnlIntellisense.Name = "pnlIntellisense";
            this.pnlIntellisense.Size = new System.Drawing.Size(200, 100);
            this.pnlIntellisense.TabIndex = 5;
            this.pnlIntellisense.Visible = false;
            // 
            // txtCode
            // 
            this.txtCode.AcceptsTab = true;
            this.txtCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCode.Location = new System.Drawing.Point(0, 0);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(508, 285);
            this.txtCode.TabIndex = 1;
            this.txtCode.Text = "";
            this.txtCode.WordWrap = false;
            this.txtCode.FontChanged += new System.EventHandler(this.txtCode_FontChanged);
            this.txtCode.TextChanged += new System.EventHandler(this.txtCode_TextChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.textToolStripMenuItem,
            this.codeToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(603, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // textToolStripMenuItem
            // 
            this.textToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.changeSelectionColorToolStripMenuItem,
            this.changeSelectionBackcolorToolStripMenuItem,
            this.fontToolStripMenuItem});
            this.textToolStripMenuItem.Name = "textToolStripMenuItem";
            this.textToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.textToolStripMenuItem.Text = "Text";
            // 
            // changeSelectionColorToolStripMenuItem
            // 
            this.changeSelectionColorToolStripMenuItem.Name = "changeSelectionColorToolStripMenuItem";
            this.changeSelectionColorToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.changeSelectionColorToolStripMenuItem.Text = "Change selection Forecolor";
            this.changeSelectionColorToolStripMenuItem.Click += new System.EventHandler(this.changeSelectionColorToolStripMenuItem_Click);
            // 
            // changeSelectionBackcolorToolStripMenuItem
            // 
            this.changeSelectionBackcolorToolStripMenuItem.Name = "changeSelectionBackcolorToolStripMenuItem";
            this.changeSelectionBackcolorToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.changeSelectionBackcolorToolStripMenuItem.Text = "Change selection Backcolor";
            this.changeSelectionBackcolorToolStripMenuItem.Click += new System.EventHandler(this.changeSelectionBackcolorToolStripMenuItem_Click);
            // 
            // fontToolStripMenuItem
            // 
            this.fontToolStripMenuItem.Name = "fontToolStripMenuItem";
            this.fontToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.fontToolStripMenuItem.Text = "Font";
            this.fontToolStripMenuItem.Click += new System.EventHandler(this.fontToolStripMenuItem_Click_1);
            // 
            // codeToolStripMenuItem
            // 
            this.codeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.compileToolStripMenuItem});
            this.codeToolStripMenuItem.Name = "codeToolStripMenuItem";
            this.codeToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.codeToolStripMenuItem.Text = "Code";
            // 
            // compileToolStripMenuItem
            // 
            this.compileToolStripMenuItem.Name = "compileToolStripMenuItem";
            this.compileToolStripMenuItem.Size = new System.Drawing.Size(95, 22);
            this.compileToolStripMenuItem.Text = "Run";
            this.compileToolStripMenuItem.Click += new System.EventHandler(this.compileToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.txtStatusPointer});
            this.statusStrip1.Location = new System.Drawing.Point(0, 309);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(603, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // txtStatusPointer
            // 
            this.txtStatusPointer.Name = "txtStatusPointer";
            this.txtStatusPointer.Size = new System.Drawing.Size(122, 17);
            this.txtStatusPointer.Text = "Currently at pointer: 0";
            // 
            // tmrZoom
            // 
            this.tmrZoom.Enabled = true;
            this.tmrZoom.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // txtIntellisense
            // 
            this.txtIntellisense.BackColor = System.Drawing.SystemColors.Control;
            this.txtIntellisense.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtIntellisense.Location = new System.Drawing.Point(0, 0);
            this.txtIntellisense.Name = "txtIntellisense";
            this.txtIntellisense.Size = new System.Drawing.Size(200, 100);
            this.txtIntellisense.TabIndex = 0;
            this.txtIntellisense.Text = "";
            // 
            // TextEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitter);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Name = "TextEditor";
            this.Size = new System.Drawing.Size(603, 331);
            this.splitter.Panel1.ResumeLayout(false);
            this.splitter.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitter)).EndInit();
            this.splitter.ResumeLayout(false);
            this.pnlIntellisense.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitter;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel txtStatusPointer;
        private System.Windows.Forms.Timer tmrZoom;
        private System.Windows.Forms.ToolStripMenuItem textToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changeSelectionColorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changeSelectionBackcolorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fontToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem codeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem compileToolStripMenuItem;
        private CustomTextBox txtCode;
        private CustomTextBox txtPointers;
        private System.Windows.Forms.Panel pnlIntellisense;
        private System.Windows.Forms.RichTextBox txtIntellisense;
    }
}
