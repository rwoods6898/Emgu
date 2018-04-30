namespace Emgu_Example
{
    partial class Serialout
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.Output = new System.Windows.Forms.Label();
            this.Orignial = new System.Windows.Forms.Label();
            this.ThresholdImage = new System.Windows.Forms.Label();
            this.Grayscale = new System.Windows.Forms.Label();
            this.Thresholdvalue = new System.Windows.Forms.Label();
            this.Input = new System.Windows.Forms.TextBox();
            this.CountLeft = new System.Windows.Forms.TextBox();
            this.CountRight = new System.Windows.Forms.TextBox();
            this.RightBar = new System.Windows.Forms.TrackBar();
            this.CountCenter = new System.Windows.Forms.TextBox();
            this.LeftBar = new System.Windows.Forms.TrackBar();
            this.yellowInput = new System.Windows.Forms.TextBox();
            this.LeftSideBar = new System.Windows.Forms.TrackBar();
            this.RightSideBar = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RightBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LeftBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LeftSideBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RightSideBar)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 36);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(298, 288);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(316, 36);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(298, 288);
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Location = new System.Drawing.Point(620, 36);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(298, 288);
            this.pictureBox3.TabIndex = 2;
            this.pictureBox3.TabStop = false;
            // 
            // Output
            // 
            this.Output.AutoSize = true;
            this.Output.Location = new System.Drawing.Point(443, 343);
            this.Output.Name = "Output";
            this.Output.Size = new System.Drawing.Size(51, 17);
            this.Output.TabIndex = 3;
            this.Output.Text = "Output";
            this.Output.Click += new System.EventHandler(this.label1_Click);
            // 
            // Orignial
            // 
            this.Orignial.AutoSize = true;
            this.Orignial.Location = new System.Drawing.Point(137, 9);
            this.Orignial.Name = "Orignial";
            this.Orignial.Size = new System.Drawing.Size(57, 17);
            this.Orignial.TabIndex = 4;
            this.Orignial.Text = "Original";
            // 
            // ThresholdImage
            // 
            this.ThresholdImage.AutoSize = true;
            this.ThresholdImage.Location = new System.Drawing.Point(411, 9);
            this.ThresholdImage.Name = "ThresholdImage";
            this.ThresholdImage.Size = new System.Drawing.Size(102, 17);
            this.ThresholdImage.TabIndex = 5;
            this.ThresholdImage.Text = "Working Image";
            // 
            // Grayscale
            // 
            this.Grayscale.AutoSize = true;
            this.Grayscale.Location = new System.Drawing.Point(731, 9);
            this.Grayscale.Name = "Grayscale";
            this.Grayscale.Size = new System.Drawing.Size(78, 17);
            this.Grayscale.TabIndex = 6;
            this.Grayscale.Text = "Gray Scale";
            this.Grayscale.Click += new System.EventHandler(this.label2_Click);
            // 
            // Thresholdvalue
            // 
            this.Thresholdvalue.AutoSize = true;
            this.Thresholdvalue.Location = new System.Drawing.Point(12, 343);
            this.Thresholdvalue.Name = "Thresholdvalue";
            this.Thresholdvalue.Size = new System.Drawing.Size(116, 17);
            this.Thresholdvalue.TabIndex = 7;
            this.Thresholdvalue.Text = "Threshold Value:";
            this.Thresholdvalue.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // Input
            // 
            this.Input.Location = new System.Drawing.Point(134, 340);
            this.Input.Name = "Input";
            this.Input.Size = new System.Drawing.Size(100, 22);
            this.Input.TabIndex = 8;
            this.Input.TextChanged += new System.EventHandler(this.Input_TextChanged);
            // 
            // CountLeft
            // 
            this.CountLeft.Location = new System.Drawing.Point(316, 405);
            this.CountLeft.Name = "CountLeft";
            this.CountLeft.Size = new System.Drawing.Size(100, 22);
            this.CountLeft.TabIndex = 10;
            this.CountLeft.TextChanged += new System.EventHandler(this.CountLeft_TextChanged);
            // 
            // CountRight
            // 
            this.CountRight.Location = new System.Drawing.Point(514, 405);
            this.CountRight.Name = "CountRight";
            this.CountRight.Size = new System.Drawing.Size(100, 22);
            this.CountRight.TabIndex = 12;
            // 
            // RightBar
            // 
            this.RightBar.Location = new System.Drawing.Point(620, 392);
            this.RightBar.Maximum = 100;
            this.RightBar.Name = "RightBar";
            this.RightBar.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightBar.Size = new System.Drawing.Size(298, 56);
            this.RightBar.TabIndex = 13;
            this.RightBar.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // CountCenter
            // 
            this.CountCenter.Location = new System.Drawing.Point(413, 363);
            this.CountCenter.Name = "CountCenter";
            this.CountCenter.Size = new System.Drawing.Size(100, 22);
            this.CountCenter.TabIndex = 14;
            this.CountCenter.TextChanged += new System.EventHandler(this.CountCenter_TextChanged);
            // 
            // LeftBar
            // 
            this.LeftBar.Location = new System.Drawing.Point(12, 392);
            this.LeftBar.Maximum = 100;
            this.LeftBar.Name = "LeftBar";
            this.LeftBar.Size = new System.Drawing.Size(298, 56);
            this.LeftBar.TabIndex = 15;
            this.LeftBar.Scroll += new System.EventHandler(this.trackBar1_Scroll_1);
            // 
            // yellowInput
            // 
            this.yellowInput.Location = new System.Drawing.Point(818, 340);
            this.yellowInput.Name = "yellowInput";
            this.yellowInput.Size = new System.Drawing.Size(100, 22);
            this.yellowInput.TabIndex = 16;
            this.yellowInput.TextChanged += new System.EventHandler(this.yellowInput_TextChanged);
            // 
            // LeftSideBar
            // 
            this.LeftSideBar.Location = new System.Drawing.Point(12, 454);
            this.LeftSideBar.Maximum = 100;
            this.LeftSideBar.Name = "LeftSideBar";
            this.LeftSideBar.Size = new System.Drawing.Size(298, 56);
            this.LeftSideBar.TabIndex = 17;
            this.LeftSideBar.Scroll += new System.EventHandler(this.LeftSideBar_Scroll);
            // 
            // RightSideBar
            // 
            this.RightSideBar.Location = new System.Drawing.Point(620, 454);
            this.RightSideBar.Maximum = 100;
            this.RightSideBar.Name = "RightSideBar";
            this.RightSideBar.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightSideBar.Size = new System.Drawing.Size(298, 56);
            this.RightSideBar.TabIndex = 18;
            this.RightSideBar.Scroll += new System.EventHandler(this.RightSideBar_Scroll);
            // 
            // Serialout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(934, 522);
            this.Controls.Add(this.RightSideBar);
            this.Controls.Add(this.LeftSideBar);
            this.Controls.Add(this.yellowInput);
            this.Controls.Add(this.LeftBar);
            this.Controls.Add(this.CountCenter);
            this.Controls.Add(this.RightBar);
            this.Controls.Add(this.CountRight);
            this.Controls.Add(this.CountLeft);
            this.Controls.Add(this.Input);
            this.Controls.Add(this.Thresholdvalue);
            this.Controls.Add(this.Grayscale);
            this.Controls.Add(this.ThresholdImage);
            this.Controls.Add(this.Orignial);
            this.Controls.Add(this.Output);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Serialout";
            this.Text = "Line Follow with Serial";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RightBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LeftBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LeftSideBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RightSideBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label Output;
        private System.Windows.Forms.Label Orignial;
        private System.Windows.Forms.Label ThresholdImage;
        private System.Windows.Forms.Label Grayscale;
        private System.Windows.Forms.Label Thresholdvalue;
        private System.Windows.Forms.TextBox Input;
        private System.Windows.Forms.TextBox CountLeft;
        private System.Windows.Forms.TextBox CountRight;
        private System.Windows.Forms.TrackBar RightBar;
        private System.Windows.Forms.TextBox CountCenter;
        private System.Windows.Forms.TrackBar LeftBar;
        private System.Windows.Forms.TextBox yellowInput;
        private System.Windows.Forms.TrackBar LeftSideBar;
        private System.Windows.Forms.TrackBar RightSideBar;
    }
}

