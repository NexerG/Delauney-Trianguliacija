
namespace ScatterPlot
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
            this.Generate = new System.Windows.Forms.Button();
            this.Amount = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.DelauneyTriangulation = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.Flip_Count = new System.Windows.Forms.TextBox();
            this.CB_Apskritimai = new System.Windows.Forms.CheckBox();
            this.CB_SpalvLinijos = new System.Windows.Forms.CheckBox();
            this.MonteKA = new System.Windows.Forms.Button();
            this.MonteKATB = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Tikslumas = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // Generate
            // 
            this.Generate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Generate.Location = new System.Drawing.Point(25, 357);
            this.Generate.Name = "Generate";
            this.Generate.Size = new System.Drawing.Size(75, 23);
            this.Generate.TabIndex = 0;
            this.Generate.Text = "Generate";
            this.Generate.UseVisualStyleBackColor = true;
            this.Generate.Click += new System.EventHandler(this.Generate_Click);
            // 
            // Amount
            // 
            this.Amount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Amount.Location = new System.Drawing.Point(25, 403);
            this.Amount.Name = "Amount";
            this.Amount.Size = new System.Drawing.Size(100, 20);
            this.Amount.TabIndex = 4;
            this.Amount.Text = "100";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Location = new System.Drawing.Point(25, 32);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(694, 319);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(148, 389);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "label1";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 383);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Taškų kiekis";
            // 
            // DelauneyTriangulation
            // 
            this.DelauneyTriangulation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.DelauneyTriangulation.Location = new System.Drawing.Point(218, 357);
            this.DelauneyTriangulation.Name = "DelauneyTriangulation";
            this.DelauneyTriangulation.Size = new System.Drawing.Size(125, 23);
            this.DelauneyTriangulation.TabIndex = 8;
            this.DelauneyTriangulation.Text = "DelauneyTriangulation";
            this.DelauneyTriangulation.UseVisualStyleBackColor = true;
            this.DelauneyTriangulation.Click += new System.EventHandler(this.DelauneyTiangulation);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(215, 383);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Flip skaičius";
            // 
            // Flip_Count
            // 
            this.Flip_Count.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Flip_Count.Location = new System.Drawing.Point(218, 403);
            this.Flip_Count.Name = "Flip_Count";
            this.Flip_Count.Size = new System.Drawing.Size(100, 20);
            this.Flip_Count.TabIndex = 10;
            this.Flip_Count.Text = "3";
            // 
            // CB_Apskritimai
            // 
            this.CB_Apskritimai.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.CB_Apskritimai.AutoSize = true;
            this.CB_Apskritimai.Location = new System.Drawing.Point(358, 405);
            this.CB_Apskritimai.Name = "CB_Apskritimai";
            this.CB_Apskritimai.Size = new System.Drawing.Size(76, 17);
            this.CB_Apskritimai.TabIndex = 11;
            this.CB_Apskritimai.Text = "Apskritimai";
            this.CB_Apskritimai.UseVisualStyleBackColor = true;
            // 
            // CB_SpalvLinijos
            // 
            this.CB_SpalvLinijos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.CB_SpalvLinijos.AutoSize = true;
            this.CB_SpalvLinijos.Location = new System.Drawing.Point(358, 383);
            this.CB_SpalvLinijos.Name = "CB_SpalvLinijos";
            this.CB_SpalvLinijos.Size = new System.Drawing.Size(102, 17);
            this.CB_SpalvLinijos.TabIndex = 12;
            this.CB_SpalvLinijos.Text = "SpalvotosLinijos";
            this.CB_SpalvLinijos.UseVisualStyleBackColor = true;
            // 
            // MonteKA
            // 
            this.MonteKA.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.MonteKA.Location = new System.Drawing.Point(482, 357);
            this.MonteKA.Name = "MonteKA";
            this.MonteKA.Size = new System.Drawing.Size(141, 23);
            this.MonteKA.TabIndex = 13;
            this.MonteKA.Text = "Monte Karlo Aproksimacija";
            this.MonteKA.UseVisualStyleBackColor = true;
            this.MonteKA.Click += new System.EventHandler(this.MonteKA_Click);
            // 
            // MonteKATB
            // 
            this.MonteKATB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.MonteKATB.Location = new System.Drawing.Point(482, 403);
            this.MonteKATB.Name = "MonteKATB";
            this.MonteKATB.Size = new System.Drawing.Size(100, 20);
            this.MonteKATB.TabIndex = 15;
            this.MonteKATB.Text = "100000";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(479, 383);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Approx=";
            // 
            // Tikslumas
            // 
            this.Tikslumas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Tikslumas.AutoSize = true;
            this.Tikslumas.Location = new System.Drawing.Point(519, 384);
            this.Tikslumas.Name = "Tikslumas";
            this.Tikslumas.Size = new System.Drawing.Size(54, 13);
            this.Tikslumas.TabIndex = 16;
            this.Tikslumas.Text = "Tikslumas";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Tikslumas);
            this.Controls.Add(this.MonteKATB);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.MonteKA);
            this.Controls.Add(this.CB_SpalvLinijos);
            this.Controls.Add(this.CB_Apskritimai);
            this.Controls.Add(this.Flip_Count);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.DelauneyTriangulation);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.Amount);
            this.Controls.Add(this.Generate);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Generate;
        private System.Windows.Forms.TextBox Amount;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button DelauneyTriangulation;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Flip_Count;
        private System.Windows.Forms.CheckBox CB_Apskritimai;
        private System.Windows.Forms.CheckBox CB_SpalvLinijos;
        private System.Windows.Forms.Button MonteKA;
        private System.Windows.Forms.TextBox MonteKATB;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label Tikslumas;
    }
}

