namespace BallCatcher
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
            this.buttonControls2 = new System.Windows.Forms.Button();
            this.buttonControls1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxNaam1
            // 
            this.textBoxNaam1.Location = new System.Drawing.Point(90, 83);
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
            this.labelSpeler1.Location = new System.Drawing.Point(12, 86);
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
            // buttonControls2
            // 
            this.buttonControls2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonControls2.Location = new System.Drawing.Point(331, 125);
            this.buttonControls2.Name = "buttonControls2";
            this.buttonControls2.Size = new System.Drawing.Size(223, 33);
            this.buttonControls2.TabIndex = 6;
            this.buttonControls2.Text = "Controls";
            this.buttonControls2.UseVisualStyleBackColor = true;
            this.buttonControls2.Click += new System.EventHandler(this.ButtonControls2_Click);
            // 
            // buttonControls1
            // 
            this.buttonControls1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonControls1.Location = new System.Drawing.Point(331, 80);
            this.buttonControls1.Name = "buttonControls1";
            this.buttonControls1.Size = new System.Drawing.Size(223, 33);
            this.buttonControls1.TabIndex = 7;
            this.buttonControls1.Text = "Controls";
            this.buttonControls1.UseVisualStyleBackColor = true;
            this.buttonControls1.Click += new System.EventHandler(this.ButtonControls1_Click);
            // 
            // Start
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(686, 403);
            this.Controls.Add(this.buttonControls1);
            this.Controls.Add(this.buttonControls2);
            this.Controls.Add(this.labelControls);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.labelSpeler2);
            this.Controls.Add(this.labelSpeler1);
            this.Controls.Add(this.textBoxNaam2);
            this.Controls.Add(this.textBoxNaam1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Start";
            this.Text = "BallCatcher | Start nieuw spel";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Start_KeyPress);
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
        private System.Windows.Forms.Button buttonControls2;
        private System.Windows.Forms.Button buttonControls1;
    }
}