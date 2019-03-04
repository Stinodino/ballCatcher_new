namespace WindowsFormsApplication1
{
    partial class Start
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Start));
            this.textBoxNaam1 = new System.Windows.Forms.TextBox();
            this.textBoxNaam2 = new System.Windows.Forms.TextBox();
            this.labelSpeler1 = new System.Windows.Forms.Label();
            this.labelSpeler2 = new System.Windows.Forms.Label();
            this.buttonStart = new System.Windows.Forms.Button();
            this.labelControls = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBoxNaam1
            // 
            this.textBoxNaam1.Location = new System.Drawing.Point(90, 87);
            this.textBoxNaam1.Name = "textBoxNaam1";
            this.textBoxNaam1.Size = new System.Drawing.Size(235, 26);
            this.textBoxNaam1.TabIndex = 0;
            // 
            // textBoxNaam2
            // 
            this.textBoxNaam2.Location = new System.Drawing.Point(90, 128);
            this.textBoxNaam2.Name = "textBoxNaam2";
            this.textBoxNaam2.Size = new System.Drawing.Size(235, 26);
            this.textBoxNaam2.TabIndex = 1;
            // 
            // labelSpeler1
            // 
            this.labelSpeler1.AutoSize = true;
            this.labelSpeler1.Location = new System.Drawing.Point(12, 90);
            this.labelSpeler1.Name = "labelSpeler1";
            this.labelSpeler1.Size = new System.Drawing.Size(72, 20);
            this.labelSpeler1.TabIndex = 2;
            this.labelSpeler1.Text = "Speler 1:";
            // 
            // labelSpeler2
            // 
            this.labelSpeler2.AutoSize = true;
            this.labelSpeler2.Location = new System.Drawing.Point(12, 131);
            this.labelSpeler2.Name = "labelSpeler2";
            this.labelSpeler2.Size = new System.Drawing.Size(72, 20);
            this.labelSpeler2.TabIndex = 3;
            this.labelSpeler2.Text = "Speler 2:";
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(90, 171);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(235, 65);
            this.buttonStart.TabIndex = 4;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.ButtonStart_Click);
            // 
            // labelControls
            // 
            this.labelControls.AutoSize = true;
            this.labelControls.Location = new System.Drawing.Point(90, 243);
            this.labelControls.Name = "labelControls";
            this.labelControls.Size = new System.Drawing.Size(0, 20);
            this.labelControls.TabIndex = 5;
            // 
            // Start
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(560, 387);
            this.Controls.Add(this.labelControls);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.labelSpeler2);
            this.Controls.Add(this.labelSpeler1);
            this.Controls.Add(this.textBoxNaam2);
            this.Controls.Add(this.textBoxNaam1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Start";
            this.Text = "BallCatcher | Start nieuw spel";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxNaam1;
        private System.Windows.Forms.TextBox textBoxNaam2;
        private System.Windows.Forms.Label labelSpeler1;
        private System.Windows.Forms.Label labelSpeler2;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Label labelControls;
    }
}