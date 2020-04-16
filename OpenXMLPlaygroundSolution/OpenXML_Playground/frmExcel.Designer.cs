namespace OpenXML_Playground
{
    partial class frmExcel
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnSimpleTest = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSimpleTest
            // 
            this.btnSimpleTest.Font = new System.Drawing.Font("MS Reference Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSimpleTest.Location = new System.Drawing.Point(12, 13);
            this.btnSimpleTest.Name = "btnSimpleTest";
            this.btnSimpleTest.Size = new System.Drawing.Size(301, 47);
            this.btnSimpleTest.TabIndex = 2;
            this.btnSimpleTest.Text = "SIMPLE TEST";
            this.btnSimpleTest.UseVisualStyleBackColor = true;
            this.btnSimpleTest.Click += new System.EventHandler(this.btnSimpleTest_Click);
            // 
            // frmExcel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(325, 181);
            this.Controls.Add(this.btnSimpleTest);
            this.Name = "frmExcel";
            this.Text = "Create Excel Document";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSimpleTest;
    }
}