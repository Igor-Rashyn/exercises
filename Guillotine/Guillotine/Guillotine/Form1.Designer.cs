namespace Guillotine
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
            this.heightTextBox = new System.Windows.Forms.TextBox();
            this.widthTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.amountTextBox = new System.Windows.Forms.TextBox();
            this.addToCollectionButton = new System.Windows.Forms.Button();
            this.previousButton = new System.Windows.Forms.Button();
            this.nextButton = new System.Windows.Forms.Button();
            this.allocateButton = new System.Windows.Forms.Button();
            this.myPanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // heightTextBox
            // 
            this.heightTextBox.Location = new System.Drawing.Point(66, 45);
            this.heightTextBox.Name = "heightTextBox";
            this.heightTextBox.Size = new System.Drawing.Size(63, 20);
            this.heightTextBox.TabIndex = 1;
            // 
            // widthTextBox
            // 
            this.widthTextBox.AccessibleDescription = "";
            this.widthTextBox.AccessibleName = "";
            this.widthTextBox.Location = new System.Drawing.Point(67, 15);
            this.widthTextBox.Name = "widthTextBox";
            this.widthTextBox.Size = new System.Drawing.Size(63, 20);
            this.widthTextBox.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Width";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Height";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(146, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Amount";
            // 
            // amountTextBox
            // 
            this.amountTextBox.AccessibleDescription = "";
            this.amountTextBox.AccessibleName = "";
            this.amountTextBox.Location = new System.Drawing.Point(195, 12);
            this.amountTextBox.Name = "amountTextBox";
            this.amountTextBox.Size = new System.Drawing.Size(63, 20);
            this.amountTextBox.TabIndex = 6;
            // 
            // addToCollectionButton
            // 
            this.addToCollectionButton.Location = new System.Drawing.Point(195, 38);
            this.addToCollectionButton.Name = "addToCollectionButton";
            this.addToCollectionButton.Size = new System.Drawing.Size(63, 23);
            this.addToCollectionButton.TabIndex = 7;
            this.addToCollectionButton.Text = "Add";
            this.addToCollectionButton.UseVisualStyleBackColor = true;
            this.addToCollectionButton.Click += new System.EventHandler(this.addToCollectionButton_Click);
            // 
            // previousButton
            // 
            this.previousButton.Location = new System.Drawing.Point(9, 93);
            this.previousButton.Name = "previousButton";
            this.previousButton.Size = new System.Drawing.Size(64, 20);
            this.previousButton.TabIndex = 8;
            this.previousButton.Text = "Previous";
            this.previousButton.UseVisualStyleBackColor = true;
            this.previousButton.Click += new System.EventHandler(this.previousButton_Click);
            // 
            // nextButton
            // 
            this.nextButton.Location = new System.Drawing.Point(79, 93);
            this.nextButton.Name = "nextButton";
            this.nextButton.Size = new System.Drawing.Size(64, 20);
            this.nextButton.TabIndex = 9;
            this.nextButton.Text = "Next";
            this.nextButton.UseVisualStyleBackColor = true;
            this.nextButton.Click += new System.EventHandler(this.nextButton_Click);
            // 
            // allocateButton
            // 
            this.allocateButton.Location = new System.Drawing.Point(195, 93);
            this.allocateButton.Name = "allocateButton";
            this.allocateButton.Size = new System.Drawing.Size(64, 20);
            this.allocateButton.TabIndex = 10;
            this.allocateButton.Text = "Allocate";
            this.allocateButton.UseVisualStyleBackColor = true;
            this.allocateButton.Click += new System.EventHandler(this.allocateButton_Click);
            // 
            // myPanel
            // 
            this.myPanel.Location = new System.Drawing.Point(2, 119);
            this.myPanel.Name = "myPanel";
            this.myPanel.Size = new System.Drawing.Size(412, 505);
            this.myPanel.TabIndex = 11;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(414, 623);
            this.Controls.Add(this.myPanel);
            this.Controls.Add(this.allocateButton);
            this.Controls.Add(this.nextButton);
            this.Controls.Add(this.previousButton);
            this.Controls.Add(this.addToCollectionButton);
            this.Controls.Add(this.amountTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.widthTextBox);
            this.Controls.Add(this.heightTextBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox heightTextBox;
        private System.Windows.Forms.TextBox widthTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox amountTextBox;
        private System.Windows.Forms.Button addToCollectionButton;
        private System.Windows.Forms.Button previousButton;
        private System.Windows.Forms.Button nextButton;
        private System.Windows.Forms.Button allocateButton;
        private System.Windows.Forms.Panel myPanel;
    }
}

