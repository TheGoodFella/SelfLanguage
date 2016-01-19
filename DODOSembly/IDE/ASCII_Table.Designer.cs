namespace IDE {
    partial class ASCII_Table {
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.lstV = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // lstV
            // 
            this.lstV.AccessibleName = "";
            this.lstV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstV.Location = new System.Drawing.Point(0, 0);
            this.lstV.Name = "lstV";
            this.lstV.Size = new System.Drawing.Size(150, 150);
            this.lstV.TabIndex = 0;
            this.lstV.UseCompatibleStateImageBehavior = false;
            this.lstV.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lstV_MouseDoubleClick);
            // 
            // ASCII_Table
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lstV);
            this.Name = "ASCII_Table";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lstV;






    }
}
