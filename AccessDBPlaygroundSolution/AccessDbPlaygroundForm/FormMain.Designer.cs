namespace AccessDbPlaygroundForm
{
    partial class FormMain
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
            this.btnSetConnectionString = new System.Windows.Forms.Button();
            this.btnReadStudents = new System.Windows.Forms.Button();
            this.listBoxTest = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // btnSetConnectionString
            // 
            this.btnSetConnectionString.Location = new System.Drawing.Point(12, 8);
            this.btnSetConnectionString.Name = "btnSetConnectionString";
            this.btnSetConnectionString.Size = new System.Drawing.Size(75, 23);
            this.btnSetConnectionString.TabIndex = 0;
            this.btnSetConnectionString.Text = "SET CONN";
            this.btnSetConnectionString.UseVisualStyleBackColor = true;
            this.btnSetConnectionString.Click += new System.EventHandler(this.btnSetConnectionString_Click);
            // 
            // btnReadStudents
            // 
            this.btnReadStudents.Location = new System.Drawing.Point(104, 8);
            this.btnReadStudents.Name = "btnReadStudents";
            this.btnReadStudents.Size = new System.Drawing.Size(81, 23);
            this.btnReadStudents.TabIndex = 1;
            this.btnReadStudents.Text = "READ STUD";
            this.btnReadStudents.UseVisualStyleBackColor = true;
            this.btnReadStudents.Click += new System.EventHandler(this.btnReadStudents_Click);
            // 
            // listBoxTest
            // 
            this.listBoxTest.FormattingEnabled = true;
            this.listBoxTest.Location = new System.Drawing.Point(12, 37);
            this.listBoxTest.Name = "listBoxTest";
            this.listBoxTest.Size = new System.Drawing.Size(776, 394);
            this.listBoxTest.TabIndex = 2;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.listBoxTest);
            this.Controls.Add(this.btnReadStudents);
            this.Controls.Add(this.btnSetConnectionString);
            this.Name = "FormMain";
            this.Text = "Access DB Playground";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSetConnectionString;
        private System.Windows.Forms.Button btnReadStudents;
        private System.Windows.Forms.ListBox listBoxTest;
    }
}

