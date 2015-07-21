namespace DrawingBinaryTree
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
            this.addButton = new System.Windows.Forms.Button();
            this.numberTextBox = new System.Windows.Forms.TextBox();
            this.myPictureBox = new System.Windows.Forms.PictureBox();
            this.deleteButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.myPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(86, 20);
            this.addButton.Name = "addButton";
            this.addButton.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.addButton.Size = new System.Drawing.Size(71, 24);
            this.addButton.TabIndex = 0;
            this.addButton.Text = "Add";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // numberTextBox
            // 
            this.numberTextBox.Location = new System.Drawing.Point(8, 23);
            this.numberTextBox.Name = "numberTextBox";
            this.numberTextBox.Size = new System.Drawing.Size(72, 20);
            this.numberTextBox.TabIndex = 1;
            // 
            // myPictureBox
            // 
            this.myPictureBox.BackColor = System.Drawing.SystemColors.Window;
            this.myPictureBox.Location = new System.Drawing.Point(8, 49);
            this.myPictureBox.Name = "myPictureBox";
            this.myPictureBox.Size = new System.Drawing.Size(876, 431);
            this.myPictureBox.TabIndex = 3;
            this.myPictureBox.TabStop = false;
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(163, 20);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(69, 23);
            this.deleteButton.TabIndex = 4;
            this.deleteButton.Text = "Delete";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(896, 487);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.myPictureBox);
            this.Controls.Add(this.numberTextBox);
            this.Controls.Add(this.addButton);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.myPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.TextBox numberTextBox;
        private System.Windows.Forms.PictureBox myPictureBox;
        private System.Windows.Forms.Button deleteButton;
    }
}

