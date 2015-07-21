namespace Paint
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
            this.DefaultColorBox = new System.Windows.Forms.PictureBox();
            this.BlackColorBox = new System.Windows.Forms.PictureBox();
            this.WhiteColorBox = new System.Windows.Forms.PictureBox();
            this.SilverColorBox = new System.Windows.Forms.PictureBox();
            this.DimGrayColorBox = new System.Windows.Forms.PictureBox();
            this.SaddleBrownColorBox = new System.Windows.Forms.PictureBox();
            this.MaroonColorBox = new System.Windows.Forms.PictureBox();
            this.PinkColorBox = new System.Windows.Forms.PictureBox();
            this.RedColorBox = new System.Windows.Forms.PictureBox();
            this.OrangeRedColorBox = new System.Windows.Forms.PictureBox();
            this.OrangeColorBox = new System.Windows.Forms.PictureBox();
            this.KhakiColorBox = new System.Windows.Forms.PictureBox();
            this.GoldColorBox = new System.Windows.Forms.PictureBox();
            this.GreenYellowColorBox = new System.Windows.Forms.PictureBox();
            this.GreenColorBox = new System.Windows.Forms.PictureBox();
            this.LightSkyBlueColorBox = new System.Windows.Forms.PictureBox();
            this.RoyalBlueColorBox = new System.Windows.Forms.PictureBox();
            this.SteelBlueColorBox = new System.Windows.Forms.PictureBox();
            this.BlueColorBox = new System.Windows.Forms.PictureBox();
            this.ThistleColorBox = new System.Windows.Forms.PictureBox();
            this.PurpleColorBox = new System.Windows.Forms.PictureBox();
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.SizePen5 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.SizePen3 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.SizePen1 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.FileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FileLoadMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.DefaultColorBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BlackColorBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WhiteColorBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SilverColorBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DimGrayColorBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SaddleBrownColorBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaroonColorBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PinkColorBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RedColorBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OrangeRedColorBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OrangeColorBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.KhakiColorBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoldColorBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GreenYellowColorBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GreenColorBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LightSkyBlueColorBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RoyalBlueColorBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SteelBlueColorBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BlueColorBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ThistleColorBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PurpleColorBox)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // DefaultColorBox
            // 
            this.DefaultColorBox.BackColor = System.Drawing.Color.Black;
            this.DefaultColorBox.Location = new System.Drawing.Point(12, 335);
            this.DefaultColorBox.Name = "DefaultColorBox";
            this.DefaultColorBox.Size = new System.Drawing.Size(69, 58);
            this.DefaultColorBox.TabIndex = 1;
            this.DefaultColorBox.TabStop = false;
            // 
            // BlackColorBox
            // 
            this.BlackColorBox.BackColor = System.Drawing.Color.Black;
            this.BlackColorBox.Location = new System.Drawing.Point(97, 334);
            this.BlackColorBox.Name = "BlackColorBox";
            this.BlackColorBox.Size = new System.Drawing.Size(27, 26);
            this.BlackColorBox.TabIndex = 2;
            this.BlackColorBox.TabStop = false;
            this.BlackColorBox.Click += new System.EventHandler(this.SelectColor_Click);
            // 
            // WhiteColorBox
            // 
            this.WhiteColorBox.BackColor = System.Drawing.Color.White;
            this.WhiteColorBox.Location = new System.Drawing.Point(97, 366);
            this.WhiteColorBox.Name = "WhiteColorBox";
            this.WhiteColorBox.Size = new System.Drawing.Size(27, 26);
            this.WhiteColorBox.TabIndex = 3;
            this.WhiteColorBox.TabStop = false;
            this.WhiteColorBox.Click += new System.EventHandler(this.SelectColor_Click);
            // 
            // SilverColorBox
            // 
            this.SilverColorBox.BackColor = System.Drawing.Color.Silver;
            this.SilverColorBox.Location = new System.Drawing.Point(130, 366);
            this.SilverColorBox.Name = "SilverColorBox";
            this.SilverColorBox.Size = new System.Drawing.Size(27, 26);
            this.SilverColorBox.TabIndex = 5;
            this.SilverColorBox.TabStop = false;
            this.SilverColorBox.Click += new System.EventHandler(this.SelectColor_Click);
            // 
            // DimGrayColorBox
            // 
            this.DimGrayColorBox.BackColor = System.Drawing.Color.DimGray;
            this.DimGrayColorBox.Location = new System.Drawing.Point(130, 334);
            this.DimGrayColorBox.Name = "DimGrayColorBox";
            this.DimGrayColorBox.Size = new System.Drawing.Size(27, 26);
            this.DimGrayColorBox.TabIndex = 4;
            this.DimGrayColorBox.TabStop = false;
            this.DimGrayColorBox.Click += new System.EventHandler(this.SelectColor_Click);
            // 
            // SaddleBrownColorBox
            // 
            this.SaddleBrownColorBox.BackColor = System.Drawing.Color.SaddleBrown;
            this.SaddleBrownColorBox.Location = new System.Drawing.Point(163, 366);
            this.SaddleBrownColorBox.Name = "SaddleBrownColorBox";
            this.SaddleBrownColorBox.Size = new System.Drawing.Size(27, 26);
            this.SaddleBrownColorBox.TabIndex = 7;
            this.SaddleBrownColorBox.TabStop = false;
            this.SaddleBrownColorBox.Click += new System.EventHandler(this.SelectColor_Click);
            // 
            // MaroonColorBox
            // 
            this.MaroonColorBox.BackColor = System.Drawing.Color.Maroon;
            this.MaroonColorBox.Location = new System.Drawing.Point(163, 334);
            this.MaroonColorBox.Name = "MaroonColorBox";
            this.MaroonColorBox.Size = new System.Drawing.Size(27, 26);
            this.MaroonColorBox.TabIndex = 6;
            this.MaroonColorBox.TabStop = false;
            this.MaroonColorBox.Click += new System.EventHandler(this.SelectColor_Click);
            // 
            // PinkColorBox
            // 
            this.PinkColorBox.BackColor = System.Drawing.Color.Pink;
            this.PinkColorBox.Location = new System.Drawing.Point(196, 366);
            this.PinkColorBox.Name = "PinkColorBox";
            this.PinkColorBox.Size = new System.Drawing.Size(27, 26);
            this.PinkColorBox.TabIndex = 9;
            this.PinkColorBox.TabStop = false;
            this.PinkColorBox.Click += new System.EventHandler(this.SelectColor_Click);
            // 
            // RedColorBox
            // 
            this.RedColorBox.BackColor = System.Drawing.Color.Red;
            this.RedColorBox.Location = new System.Drawing.Point(196, 334);
            this.RedColorBox.Name = "RedColorBox";
            this.RedColorBox.Size = new System.Drawing.Size(27, 26);
            this.RedColorBox.TabIndex = 8;
            this.RedColorBox.TabStop = false;
            this.RedColorBox.Click += new System.EventHandler(this.SelectColor_Click);
            // 
            // OrangeRedColorBox
            // 
            this.OrangeRedColorBox.BackColor = System.Drawing.Color.OrangeRed;
            this.OrangeRedColorBox.Location = new System.Drawing.Point(229, 334);
            this.OrangeRedColorBox.Name = "OrangeRedColorBox";
            this.OrangeRedColorBox.Size = new System.Drawing.Size(27, 26);
            this.OrangeRedColorBox.TabIndex = 11;
            this.OrangeRedColorBox.TabStop = false;
            this.OrangeRedColorBox.Click += new System.EventHandler(this.SelectColor_Click);
            // 
            // OrangeColorBox
            // 
            this.OrangeColorBox.BackColor = System.Drawing.Color.Orange;
            this.OrangeColorBox.Location = new System.Drawing.Point(229, 366);
            this.OrangeColorBox.Name = "OrangeColorBox";
            this.OrangeColorBox.Size = new System.Drawing.Size(27, 26);
            this.OrangeColorBox.TabIndex = 10;
            this.OrangeColorBox.TabStop = false;
            this.OrangeColorBox.Click += new System.EventHandler(this.SelectColor_Click);
            // 
            // KhakiColorBox
            // 
            this.KhakiColorBox.BackColor = System.Drawing.Color.Khaki;
            this.KhakiColorBox.Location = new System.Drawing.Point(262, 366);
            this.KhakiColorBox.Name = "KhakiColorBox";
            this.KhakiColorBox.Size = new System.Drawing.Size(27, 26);
            this.KhakiColorBox.TabIndex = 13;
            this.KhakiColorBox.TabStop = false;
            this.KhakiColorBox.Click += new System.EventHandler(this.SelectColor_Click);
            // 
            // GoldColorBox
            // 
            this.GoldColorBox.BackColor = System.Drawing.Color.Gold;
            this.GoldColorBox.Location = new System.Drawing.Point(262, 334);
            this.GoldColorBox.Name = "GoldColorBox";
            this.GoldColorBox.Size = new System.Drawing.Size(27, 26);
            this.GoldColorBox.TabIndex = 12;
            this.GoldColorBox.TabStop = false;
            this.GoldColorBox.Click += new System.EventHandler(this.SelectColor_Click);
            // 
            // GreenYellowColorBox
            // 
            this.GreenYellowColorBox.BackColor = System.Drawing.Color.GreenYellow;
            this.GreenYellowColorBox.Location = new System.Drawing.Point(295, 365);
            this.GreenYellowColorBox.Name = "GreenYellowColorBox";
            this.GreenYellowColorBox.Size = new System.Drawing.Size(27, 26);
            this.GreenYellowColorBox.TabIndex = 15;
            this.GreenYellowColorBox.TabStop = false;
            this.GreenYellowColorBox.Click += new System.EventHandler(this.SelectColor_Click);
            // 
            // GreenColorBox
            // 
            this.GreenColorBox.BackColor = System.Drawing.Color.Green;
            this.GreenColorBox.Location = new System.Drawing.Point(295, 333);
            this.GreenColorBox.Name = "GreenColorBox";
            this.GreenColorBox.Size = new System.Drawing.Size(27, 26);
            this.GreenColorBox.TabIndex = 14;
            this.GreenColorBox.TabStop = false;
            this.GreenColorBox.Click += new System.EventHandler(this.SelectColor_Click);
            // 
            // LightSkyBlueColorBox
            // 
            this.LightSkyBlueColorBox.BackColor = System.Drawing.Color.LightSkyBlue;
            this.LightSkyBlueColorBox.Location = new System.Drawing.Point(328, 365);
            this.LightSkyBlueColorBox.Name = "LightSkyBlueColorBox";
            this.LightSkyBlueColorBox.Size = new System.Drawing.Size(27, 26);
            this.LightSkyBlueColorBox.TabIndex = 17;
            this.LightSkyBlueColorBox.TabStop = false;
            this.LightSkyBlueColorBox.Click += new System.EventHandler(this.SelectColor_Click);
            // 
            // RoyalBlueColorBox
            // 
            this.RoyalBlueColorBox.BackColor = System.Drawing.Color.RoyalBlue;
            this.RoyalBlueColorBox.Location = new System.Drawing.Point(328, 333);
            this.RoyalBlueColorBox.Name = "RoyalBlueColorBox";
            this.RoyalBlueColorBox.Size = new System.Drawing.Size(27, 26);
            this.RoyalBlueColorBox.TabIndex = 16;
            this.RoyalBlueColorBox.TabStop = false;
            this.RoyalBlueColorBox.Click += new System.EventHandler(this.SelectColor_Click);
            // 
            // SteelBlueColorBox
            // 
            this.SteelBlueColorBox.BackColor = System.Drawing.Color.SteelBlue;
            this.SteelBlueColorBox.Location = new System.Drawing.Point(361, 365);
            this.SteelBlueColorBox.Name = "SteelBlueColorBox";
            this.SteelBlueColorBox.Size = new System.Drawing.Size(27, 26);
            this.SteelBlueColorBox.TabIndex = 19;
            this.SteelBlueColorBox.TabStop = false;
            this.SteelBlueColorBox.Click += new System.EventHandler(this.SelectColor_Click);
            // 
            // BlueColorBox
            // 
            this.BlueColorBox.BackColor = System.Drawing.Color.Blue;
            this.BlueColorBox.Location = new System.Drawing.Point(361, 333);
            this.BlueColorBox.Name = "BlueColorBox";
            this.BlueColorBox.Size = new System.Drawing.Size(27, 26);
            this.BlueColorBox.TabIndex = 18;
            this.BlueColorBox.TabStop = false;
            this.BlueColorBox.Click += new System.EventHandler(this.SelectColor_Click);
            // 
            // ThistleColorBox
            // 
            this.ThistleColorBox.BackColor = System.Drawing.Color.Thistle;
            this.ThistleColorBox.Location = new System.Drawing.Point(394, 365);
            this.ThistleColorBox.Name = "ThistleColorBox";
            this.ThistleColorBox.Size = new System.Drawing.Size(27, 26);
            this.ThistleColorBox.TabIndex = 21;
            this.ThistleColorBox.TabStop = false;
            this.ThistleColorBox.Click += new System.EventHandler(this.SelectColor_Click);
            // 
            // PurpleColorBox
            // 
            this.PurpleColorBox.BackColor = System.Drawing.Color.Purple;
            this.PurpleColorBox.Location = new System.Drawing.Point(394, 333);
            this.PurpleColorBox.Name = "PurpleColorBox";
            this.PurpleColorBox.Size = new System.Drawing.Size(27, 26);
            this.PurpleColorBox.TabIndex = 20;
            this.PurpleColorBox.TabStop = false;
            this.PurpleColorBox.Click += new System.EventHandler(this.SelectColor_Click);
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.SizePen5,
            this.SizePen3,
            this.SizePen1});
            this.shapeContainer1.Size = new System.Drawing.Size(876, 407);
            this.shapeContainer1.TabIndex = 22;
            this.shapeContainer1.TabStop = false;
            // 
            // SizePen5
            // 
            this.SizePen5.BorderWidth = 5;
            this.SizePen5.Name = "SizePen5";
            this.SizePen5.X1 = 503;
            this.SizePen5.X2 = 573;
            this.SizePen5.Y1 = 372;
            this.SizePen5.Y2 = 372;
            this.SizePen5.Click += new System.EventHandler(this.ChangeSize_Click);
            // 
            // SizePen3
            // 
            this.SizePen3.BorderWidth = 3;
            this.SizePen3.Name = "SizePen3";
            this.SizePen3.X1 = 502;
            this.SizePen3.X2 = 573;
            this.SizePen3.Y1 = 354;
            this.SizePen3.Y2 = 354;
            this.SizePen3.Click += new System.EventHandler(this.ChangeSize_Click);
            // 
            // SizePen1
            // 
            this.SizePen1.Name = "SizePen1";
            this.SizePen1.X1 = 502;
            this.SizePen1.X2 = 573;
            this.SizePen1.Y1 = 337;
            this.SizePen1.Y2 = 337;
            this.SizePen1.Click += new System.EventHandler(this.ChangeSize_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(512, 383);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 23;
            this.label1.Text = "Толщина";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(876, 24);
            this.menuStrip1.TabIndex = 25;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // FileMenuItem
            // 
            this.FileMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileLoadMenu,
            this.toolStripMenuItem3});
            this.FileMenuItem.Name = "FileMenuItem";
            this.FileMenuItem.Size = new System.Drawing.Size(37, 20);
            this.FileMenuItem.Text = "File";
            // 
            // FileLoadMenu
            // 
            this.FileLoadMenu.Name = "FileLoadMenu";
            this.FileLoadMenu.Size = new System.Drawing.Size(100, 22);
            this.FileLoadMenu.Text = "Load";
            this.FileLoadMenu.Click += new System.EventHandler(this.FileLoadMenu_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(100, 22);
            this.toolStripMenuItem3.Text = "Save";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.FileSaveMenu_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Location = new System.Drawing.Point(3, 28);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(900, 300);
            this.pictureBox1.TabIndex = 26;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(876, 407);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ThistleColorBox);
            this.Controls.Add(this.PurpleColorBox);
            this.Controls.Add(this.SteelBlueColorBox);
            this.Controls.Add(this.BlueColorBox);
            this.Controls.Add(this.LightSkyBlueColorBox);
            this.Controls.Add(this.RoyalBlueColorBox);
            this.Controls.Add(this.GreenYellowColorBox);
            this.Controls.Add(this.GreenColorBox);
            this.Controls.Add(this.KhakiColorBox);
            this.Controls.Add(this.GoldColorBox);
            this.Controls.Add(this.OrangeRedColorBox);
            this.Controls.Add(this.OrangeColorBox);
            this.Controls.Add(this.PinkColorBox);
            this.Controls.Add(this.RedColorBox);
            this.Controls.Add(this.SaddleBrownColorBox);
            this.Controls.Add(this.MaroonColorBox);
            this.Controls.Add(this.SilverColorBox);
            this.Controls.Add(this.DimGrayColorBox);
            this.Controls.Add(this.WhiteColorBox);
            this.Controls.Add(this.BlackColorBox);
            this.Controls.Add(this.DefaultColorBox);
            this.Controls.Add(this.shapeContainer1);
            this.Cursor = System.Windows.Forms.Cursors.Cross;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.DefaultColorBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BlackColorBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WhiteColorBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SilverColorBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DimGrayColorBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SaddleBrownColorBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaroonColorBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PinkColorBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RedColorBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OrangeRedColorBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OrangeColorBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.KhakiColorBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoldColorBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GreenYellowColorBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GreenColorBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LightSkyBlueColorBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RoyalBlueColorBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SteelBlueColorBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BlueColorBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ThistleColorBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PurpleColorBox)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox DefaultColorBox;
        private System.Windows.Forms.PictureBox BlackColorBox;
        private System.Windows.Forms.PictureBox WhiteColorBox;
        private System.Windows.Forms.PictureBox SilverColorBox;
        private System.Windows.Forms.PictureBox DimGrayColorBox;
        private System.Windows.Forms.PictureBox SaddleBrownColorBox;
        private System.Windows.Forms.PictureBox MaroonColorBox;
        private System.Windows.Forms.PictureBox PinkColorBox;
        private System.Windows.Forms.PictureBox RedColorBox;
        private System.Windows.Forms.PictureBox OrangeRedColorBox;
        private System.Windows.Forms.PictureBox OrangeColorBox;
        private System.Windows.Forms.PictureBox KhakiColorBox;
        private System.Windows.Forms.PictureBox GoldColorBox;
        private System.Windows.Forms.PictureBox GreenYellowColorBox;
        private System.Windows.Forms.PictureBox GreenColorBox;
        private System.Windows.Forms.PictureBox LightSkyBlueColorBox;
        private System.Windows.Forms.PictureBox RoyalBlueColorBox;
        private System.Windows.Forms.PictureBox SteelBlueColorBox;
        private System.Windows.Forms.PictureBox BlueColorBox;
        private System.Windows.Forms.PictureBox ThistleColorBox;
        private System.Windows.Forms.PictureBox PurpleColorBox;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private Microsoft.VisualBasic.PowerPacks.LineShape SizePen5;
        private Microsoft.VisualBasic.PowerPacks.LineShape SizePen3;
        private Microsoft.VisualBasic.PowerPacks.LineShape SizePen1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem FileMenuItem;
        private System.Windows.Forms.ToolStripMenuItem FileLoadMenu;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}

