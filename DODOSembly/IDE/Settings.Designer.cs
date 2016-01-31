namespace IDE {
    partial class Settings {
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.prpTEXT = new System.Windows.Forms.PropertyGrid();
            this.propertyTextBox1 = new IDE.PropertyTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(780, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.prpTEXT);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.propertyTextBox1);
            this.splitContainer1.Size = new System.Drawing.Size(780, 534);
            this.splitContainer1.SplitterDistance = 260;
            this.splitContainer1.TabIndex = 3;
            // 
            // prpTEXT
            // 
            this.prpTEXT.CategoryForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.prpTEXT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.prpTEXT.Location = new System.Drawing.Point(0, 0);
            this.prpTEXT.Name = "prpTEXT";
            this.prpTEXT.Size = new System.Drawing.Size(260, 534);
            this.prpTEXT.TabIndex = 1;
            // 
            // propertyTextBox1
            // 
            this.propertyTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyTextBox1.Location = new System.Drawing.Point(0, 0);
            this.propertyTextBox1.Name = "propertyTextBox1";
            this.propertyTextBox1.Size = new System.Drawing.Size(516, 534);
            this.propertyTextBox1.TabIndex = 0;
            this.propertyTextBox1.Text = "";
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(780, 558);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Settings";
            this.Text = "Settings";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PropertyGrid prpTEXT;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private PropertyTextBox propertyTextBox1;

    }
}