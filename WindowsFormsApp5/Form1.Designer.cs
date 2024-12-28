namespace WindowsFormsApp5
{
    partial class Form1
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
            this.ScaleUp = new System.Windows.Forms.Button();
            this.ScaleDown = new System.Windows.Forms.Button();
            this.Rotate = new System.Windows.Forms.Button();
            this.ReflectionX = new System.Windows.Forms.Button();
            this.ReflectionY = new System.Windows.Forms.Button();
            this.ReflectionSimetry = new System.Windows.Forms.Button();
            this.DegreeBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // ScaleUp
            // 
            this.ScaleUp.Location = new System.Drawing.Point(24, 362);
            this.ScaleUp.Name = "ScaleUp";
            this.ScaleUp.Size = new System.Drawing.Size(115, 23);
            this.ScaleUp.TabIndex = 0;
            this.ScaleUp.Text = "Scale up";
            this.ScaleUp.UseVisualStyleBackColor = true;
            this.ScaleUp.Click += new System.EventHandler(this.ScaleUp_Click);
            // 
            // ScaleDown
            // 
            this.ScaleDown.Location = new System.Drawing.Point(24, 407);
            this.ScaleDown.Name = "ScaleDown";
            this.ScaleDown.Size = new System.Drawing.Size(115, 23);
            this.ScaleDown.TabIndex = 1;
            this.ScaleDown.Text = "Scale down";
            this.ScaleDown.UseVisualStyleBackColor = true;
            this.ScaleDown.Click += new System.EventHandler(this.ScaleDown_Click);
            // 
            // Rotate
            // 
            this.Rotate.Location = new System.Drawing.Point(237, 407);
            this.Rotate.Name = "Rotate";
            this.Rotate.Size = new System.Drawing.Size(115, 23);
            this.Rotate.TabIndex = 2;
            this.Rotate.Text = "Rotate";
            this.Rotate.UseVisualStyleBackColor = true;
            this.Rotate.Click += new System.EventHandler(this.Rotate_Click);
            // 
            // ReflectionX
            // 
            this.ReflectionX.Location = new System.Drawing.Point(459, 362);
            this.ReflectionX.Name = "ReflectionX";
            this.ReflectionX.Size = new System.Drawing.Size(115, 23);
            this.ReflectionX.TabIndex = 4;
            this.ReflectionX.Text = "OX reflection";
            this.ReflectionX.UseVisualStyleBackColor = true;
            this.ReflectionX.Click += new System.EventHandler(this.ReflectionX_Click);
            // 
            // ReflectionY
            // 
            this.ReflectionY.Location = new System.Drawing.Point(459, 407);
            this.ReflectionY.Name = "ReflectionY";
            this.ReflectionY.Size = new System.Drawing.Size(115, 23);
            this.ReflectionY.TabIndex = 5;
            this.ReflectionY.Text = "OY reflection";
            this.ReflectionY.UseVisualStyleBackColor = true;
            this.ReflectionY.Click += new System.EventHandler(this.ReflectionY_Click);
            // 
            // ReflectionSimetry
            // 
            this.ReflectionSimetry.Location = new System.Drawing.Point(658, 383);
            this.ReflectionSimetry.Name = "ReflectionSimetry";
            this.ReflectionSimetry.Size = new System.Drawing.Size(115, 23);
            this.ReflectionSimetry.TabIndex = 6;
            this.ReflectionSimetry.Text = "Simetry reflection";
            this.ReflectionSimetry.UseVisualStyleBackColor = true;
            this.ReflectionSimetry.Click += new System.EventHandler(this.ReflectionSimetry_Click);
            // 
            // DegreeBox
            // 
            this.DegreeBox.Location = new System.Drawing.Point(237, 362);
            this.DegreeBox.Name = "DegreeBox";
            this.DegreeBox.Size = new System.Drawing.Size(115, 22);
            this.DegreeBox.TabIndex = 7;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.DegreeBox);
            this.Controls.Add(this.ReflectionSimetry);
            this.Controls.Add(this.ReflectionY);
            this.Controls.Add(this.ReflectionX);
            this.Controls.Add(this.Rotate);
            this.Controls.Add(this.ScaleDown);
            this.Controls.Add(this.ScaleUp);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ScaleUp;
        private System.Windows.Forms.Button ScaleDown;
        private System.Windows.Forms.Button Rotate;
        private System.Windows.Forms.Button ReflectionX;
        private System.Windows.Forms.Button ReflectionY;
        private System.Windows.Forms.Button ReflectionSimetry;
        private System.Windows.Forms.TextBox DegreeBox;
    }
}

