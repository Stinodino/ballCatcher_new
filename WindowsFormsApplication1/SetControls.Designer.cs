namespace BallCatcher
{
    partial class SetControls
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
            this.labelLinks = new System.Windows.Forms.Label();
            this.labelRechts = new System.Windows.Forms.Label();
            this.labelOmhoog = new System.Windows.Forms.Label();
            this.textBoxLinks = new System.Windows.Forms.TextBox();
            this.textBoxRechts = new System.Windows.Forms.TextBox();
            this.textBoxOmhoog = new System.Windows.Forms.TextBox();
            this.buttonInstellen = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelLinks
            // 
            this.labelLinks.AutoSize = true;
            this.labelLinks.Location = new System.Drawing.Point(13, 78);
            this.labelLinks.Name = "labelLinks";
            this.labelLinks.Size = new System.Drawing.Size(50, 20);
            this.labelLinks.TabIndex = 0;
            this.labelLinks.Text = "Links:";
            // 
            // labelRechts
            // 
            this.labelRechts.AutoSize = true;
            this.labelRechts.Location = new System.Drawing.Point(12, 131);
            this.labelRechts.Name = "labelRechts";
            this.labelRechts.Size = new System.Drawing.Size(64, 20);
            this.labelRechts.TabIndex = 1;
            this.labelRechts.Text = "Rechts:";
            // 
            // labelOmhoog
            // 
            this.labelOmhoog.AutoSize = true;
            this.labelOmhoog.Location = new System.Drawing.Point(12, 188);
            this.labelOmhoog.Name = "labelOmhoog";
            this.labelOmhoog.Size = new System.Drawing.Size(74, 20);
            this.labelOmhoog.TabIndex = 2;
            this.labelOmhoog.Text = "Omhoog:";
            // 
            // textBoxLinks
            // 
            this.textBoxLinks.Location = new System.Drawing.Point(109, 75);
            this.textBoxLinks.Name = "textBoxLinks";
            this.textBoxLinks.Size = new System.Drawing.Size(100, 26);
            this.textBoxLinks.TabIndex = 3;
            // 
            // textBoxRechts
            // 
            this.textBoxRechts.Location = new System.Drawing.Point(109, 128);
            this.textBoxRechts.Name = "textBoxRechts";
            this.textBoxRechts.Size = new System.Drawing.Size(100, 26);
            this.textBoxRechts.TabIndex = 4;
            // 
            // textBoxOmhoog
            // 
            this.textBoxOmhoog.Location = new System.Drawing.Point(109, 185);
            this.textBoxOmhoog.Name = "textBoxOmhoog";
            this.textBoxOmhoog.Size = new System.Drawing.Size(100, 26);
            this.textBoxOmhoog.TabIndex = 5;
            // 
            // buttonInstellen
            // 
            this.buttonInstellen.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonInstellen.Location = new System.Drawing.Point(17, 225);
            this.buttonInstellen.Name = "buttonInstellen";
            this.buttonInstellen.Size = new System.Drawing.Size(771, 213);
            this.buttonInstellen.TabIndex = 6;
            this.buttonInstellen.Text = "Instellen";
            this.buttonInstellen.UseVisualStyleBackColor = true;
            this.buttonInstellen.Click += new System.EventHandler(this.ButtonInstellen_Click);
            // 
            // SetControls
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonInstellen);
            this.Controls.Add(this.textBoxOmhoog);
            this.Controls.Add(this.textBoxRechts);
            this.Controls.Add(this.textBoxLinks);
            this.Controls.Add(this.labelOmhoog);
            this.Controls.Add(this.labelRechts);
            this.Controls.Add(this.labelLinks);
            this.Name = "SetControls";
            this.Text = "Controls";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelLinks;
        private System.Windows.Forms.Label labelRechts;
        private System.Windows.Forms.Label labelOmhoog;
        private System.Windows.Forms.TextBox textBoxLinks;
        private System.Windows.Forms.TextBox textBoxRechts;
        private System.Windows.Forms.TextBox textBoxOmhoog;
        private System.Windows.Forms.Button buttonInstellen;
    }
}