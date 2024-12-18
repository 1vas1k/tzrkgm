namespace WindowsFormsApp4
{
    partial class UserInteractionForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserInteractionForm));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.moveButton = new System.Windows.Forms.Button();
            this.resetButton = new System.Windows.Forms.Button();
            this.InfMoveButton = new System.Windows.Forms.Button();
            this.openButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::WindowsFormsApp4.Properties.Resources.mista;
            this.pictureBox1.Location = new System.Drawing.Point(100, 100);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 100);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // moveButton
            // 
            this.moveButton.Location = new System.Drawing.Point(12, 12);
            this.moveButton.Name = "moveButton";
            this.moveButton.Size = new System.Drawing.Size(151, 38);
            this.moveButton.TabIndex = 1;
            this.moveButton.Text = "Move image";
            this.moveButton.UseVisualStyleBackColor = true;
            this.moveButton.Click += new System.EventHandler(this.moveButton_Click);
            // 
            // resetButton
            // 
            this.resetButton.Location = new System.Drawing.Point(169, 12);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(151, 38);
            this.resetButton.TabIndex = 2;
            this.resetButton.Text = "Reset position";
            this.resetButton.UseVisualStyleBackColor = true;
            this.resetButton.Click += new System.EventHandler(this.resetButton_Click);
            // 
            // InfMoveButton
            // 
            this.InfMoveButton.Location = new System.Drawing.Point(326, 12);
            this.InfMoveButton.Name = "InfMoveButton";
            this.InfMoveButton.Size = new System.Drawing.Size(151, 38);
            this.InfMoveButton.TabIndex = 3;
            this.InfMoveButton.Text = "Ininity move";
            this.InfMoveButton.UseVisualStyleBackColor = true;
            this.InfMoveButton.Click += new System.EventHandler(this.InfMoveButton_Click);
            // 
            // openButton
            // 
            this.openButton.Location = new System.Drawing.Point(483, 12);
            this.openButton.Name = "openButton";
            this.openButton.Size = new System.Drawing.Size(151, 38);
            this.openButton.TabIndex = 4;
            this.openButton.Text = "Next form";
            this.openButton.UseVisualStyleBackColor = true;
            this.openButton.Click += new System.EventHandler(this.openButton_Click);
            // 
            // UserInteractionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(782, 553);
            this.Controls.Add(this.openButton);
            this.Controls.Add(this.InfMoveButton);
            this.Controls.Add(this.resetButton);
            this.Controls.Add(this.moveButton);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "UserInteractionForm";
            this.Text = "UserInteractionForm";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button moveButton;
        private System.Windows.Forms.Button resetButton;
        private System.Windows.Forms.Button InfMoveButton;
        private System.Windows.Forms.Button openButton;
    }
}

