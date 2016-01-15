namespace IDE {
    partial class Form1 {
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

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent() {
            this.textEditor2 = new IDE.TextEditor();
            this.SuspendLayout();
            // 
            // textEditor2
            // 
            this.textEditor2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textEditor2.Location = new System.Drawing.Point(0, 0);
            this.textEditor2.Name = "textEditor2";
            this.textEditor2.Size = new System.Drawing.Size(509, 322);
            this.textEditor2.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(509, 322);
            this.Controls.Add(this.textEditor2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private TextEditor textEditor2;
    }
}

