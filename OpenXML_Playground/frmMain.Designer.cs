namespace OpenXML_Playground
{
    partial class frmMain
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnSimpleTest = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSimpleTest
            // 
            this.btnSimpleTest.Font = new System.Drawing.Font("MS Reference Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSimpleTest.Location = new System.Drawing.Point(12, 12);
            this.btnSimpleTest.Name = "btnSimpleTest";
            this.btnSimpleTest.Size = new System.Drawing.Size(460, 47);
            this.btnSimpleTest.TabIndex = 0;
            this.btnSimpleTest.Text = "SIMPLE TEST";
            this.btnSimpleTest.UseVisualStyleBackColor = true;
            this.btnSimpleTest.Click += new System.EventHandler(this.btnSimpleWordText_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 361);
            this.Controls.Add(this.btnSimpleTest);
            this.Name = "Form1";
            this.Text = "OpenXML PlayGround";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSimpleTest;
    }
}

