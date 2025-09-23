namespace Paint
{
    partial class Paint
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Paint));
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.ColorPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSelect = new System.Windows.Forms.Button();
            this.ShapePanel = new System.Windows.Forms.FlowLayoutPanel();
            this.btnLine = new System.Windows.Forms.Button();
            this.btnCurve = new System.Windows.Forms.Button();
            this.btnOval = new System.Windows.Forms.Button();
            this.btnRectangle = new System.Windows.Forms.Button();
            this.btnTriangle = new System.Windows.Forms.Button();
            this.btnDiamond = new System.Windows.Forms.Button();
            this.btnPentagon = new System.Windows.Forms.Button();
            this.btnHexagon = new System.Windows.Forms.Button();
            this.btnStar = new System.Windows.Forms.Button();
            this.btnColorPicker = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnBrush = new System.Windows.Forms.Button();
            this.btnErase = new System.Windows.Forms.Button();
            this.btnText = new System.Windows.Forms.Button();
            this.btnFill = new System.Windows.Forms.Button();
            this.btnPencil = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCopy = new System.Windows.Forms.Button();
            this.btnCut = new System.Windows.Forms.Button();
            this.btnPaste = new System.Windows.Forms.Button();
            this.plMain = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.ShapePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.ColorPanel);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.btnSelect);
            this.panel1.Controls.Add(this.ShapePanel);
            this.panel1.Controls.Add(this.btnColorPicker);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.btnBrush);
            this.panel1.Controls.Add(this.btnErase);
            this.panel1.Controls.Add(this.btnText);
            this.panel1.Controls.Add(this.btnFill);
            this.panel1.Controls.Add(this.btnPencil);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnCopy);
            this.panel1.Controls.Add(this.btnCut);
            this.panel1.Controls.Add(this.btnPaste);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1260, 124);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.plMain_Paint);
            // 
            // button1
            // 
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(58, 47);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(32, 32);
            this.button1.TabIndex = 18;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // ColorPanel
            // 
            this.ColorPanel.AutoScroll = true;
            this.ColorPanel.Location = new System.Drawing.Point(557, 6);
            this.ColorPanel.Name = "ColorPanel";
            this.ColorPanel.Size = new System.Drawing.Size(248, 61);
            this.ColorPanel.TabIndex = 17;
            this.ColorPanel.Click += new System.EventHandler(this.ColorPanel_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(657, 95);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 16);
            this.label4.TabIndex = 16;
            this.label4.Text = "Colors";
            // 
            // btnSelect
            // 
            this.btnSelect.Image = ((System.Drawing.Image)(resources.GetObject("btnSelect.Image")));
            this.btnSelect.Location = new System.Drawing.Point(22, 47);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(32, 32);
            this.btnSelect.TabIndex = 14;
            this.btnSelect.UseVisualStyleBackColor = true;
            // 
            // ShapePanel
            // 
            this.ShapePanel.AutoScroll = true;
            this.ShapePanel.Controls.Add(this.btnLine);
            this.ShapePanel.Controls.Add(this.btnCurve);
            this.ShapePanel.Controls.Add(this.btnOval);
            this.ShapePanel.Controls.Add(this.btnRectangle);
            this.ShapePanel.Controls.Add(this.btnTriangle);
            this.ShapePanel.Controls.Add(this.btnDiamond);
            this.ShapePanel.Controls.Add(this.btnPentagon);
            this.ShapePanel.Controls.Add(this.btnHexagon);
            this.ShapePanel.Controls.Add(this.btnStar);
            this.ShapePanel.Location = new System.Drawing.Point(298, 6);
            this.ShapePanel.Name = "ShapePanel";
            this.ShapePanel.Size = new System.Drawing.Size(214, 76);
            this.ShapePanel.TabIndex = 13;
            // 
            // btnLine
            // 
            this.btnLine.Image = ((System.Drawing.Image)(resources.GetObject("btnLine.Image")));
            this.btnLine.Location = new System.Drawing.Point(3, 3);
            this.btnLine.Name = "btnLine";
            this.btnLine.Size = new System.Drawing.Size(32, 32);
            this.btnLine.TabIndex = 0;
            this.btnLine.UseVisualStyleBackColor = true;
            this.btnLine.Click += new System.EventHandler(this.btnLine_Click);
            // 
            // btnCurve
            // 
            this.btnCurve.Image = ((System.Drawing.Image)(resources.GetObject("btnCurve.Image")));
            this.btnCurve.Location = new System.Drawing.Point(41, 3);
            this.btnCurve.Name = "btnCurve";
            this.btnCurve.Size = new System.Drawing.Size(32, 32);
            this.btnCurve.TabIndex = 1;
            this.btnCurve.UseVisualStyleBackColor = true;
            this.btnCurve.Click += new System.EventHandler(this.btnCurve_Click);
            // 
            // btnOval
            // 
            this.btnOval.Image = ((System.Drawing.Image)(resources.GetObject("btnOval.Image")));
            this.btnOval.Location = new System.Drawing.Point(79, 3);
            this.btnOval.Name = "btnOval";
            this.btnOval.Size = new System.Drawing.Size(32, 32);
            this.btnOval.TabIndex = 2;
            this.btnOval.UseVisualStyleBackColor = true;
            this.btnOval.Click += new System.EventHandler(this.btnOval_Click);
            // 
            // btnRectangle
            // 
            this.btnRectangle.Image = ((System.Drawing.Image)(resources.GetObject("btnRectangle.Image")));
            this.btnRectangle.Location = new System.Drawing.Point(117, 3);
            this.btnRectangle.Name = "btnRectangle";
            this.btnRectangle.Size = new System.Drawing.Size(32, 32);
            this.btnRectangle.TabIndex = 3;
            this.btnRectangle.UseVisualStyleBackColor = true;
            this.btnRectangle.Click += new System.EventHandler(this.btnRectangle_Click);
            // 
            // btnTriangle
            // 
            this.btnTriangle.Image = ((System.Drawing.Image)(resources.GetObject("btnTriangle.Image")));
            this.btnTriangle.Location = new System.Drawing.Point(155, 3);
            this.btnTriangle.Name = "btnTriangle";
            this.btnTriangle.Size = new System.Drawing.Size(32, 32);
            this.btnTriangle.TabIndex = 4;
            this.btnTriangle.UseVisualStyleBackColor = true;
            this.btnTriangle.Click += new System.EventHandler(this.btnTriangle_Click);
            // 
            // btnDiamond
            // 
            this.btnDiamond.Image = ((System.Drawing.Image)(resources.GetObject("btnDiamond.Image")));
            this.btnDiamond.Location = new System.Drawing.Point(3, 41);
            this.btnDiamond.Name = "btnDiamond";
            this.btnDiamond.Size = new System.Drawing.Size(32, 32);
            this.btnDiamond.TabIndex = 5;
            this.btnDiamond.UseVisualStyleBackColor = true;
            this.btnDiamond.Click += new System.EventHandler(this.btnDiamond_Click);
            // 
            // btnPentagon
            // 
            this.btnPentagon.Image = ((System.Drawing.Image)(resources.GetObject("btnPentagon.Image")));
            this.btnPentagon.Location = new System.Drawing.Point(41, 41);
            this.btnPentagon.Name = "btnPentagon";
            this.btnPentagon.Size = new System.Drawing.Size(32, 32);
            this.btnPentagon.TabIndex = 6;
            this.btnPentagon.UseVisualStyleBackColor = true;
            this.btnPentagon.Click += new System.EventHandler(this.btnPentagon_Click);
            // 
            // btnHexagon
            // 
            this.btnHexagon.Image = ((System.Drawing.Image)(resources.GetObject("btnHexagon.Image")));
            this.btnHexagon.Location = new System.Drawing.Point(79, 41);
            this.btnHexagon.Name = "btnHexagon";
            this.btnHexagon.Size = new System.Drawing.Size(32, 32);
            this.btnHexagon.TabIndex = 7;
            this.btnHexagon.UseVisualStyleBackColor = true;
            this.btnHexagon.Click += new System.EventHandler(this.btnHexagon_Click);
            // 
            // btnStar
            // 
            this.btnStar.Image = ((System.Drawing.Image)(resources.GetObject("btnStar.Image")));
            this.btnStar.Location = new System.Drawing.Point(117, 41);
            this.btnStar.Name = "btnStar";
            this.btnStar.Size = new System.Drawing.Size(32, 32);
            this.btnStar.TabIndex = 8;
            this.btnStar.UseVisualStyleBackColor = true;
            this.btnStar.Click += new System.EventHandler(this.btnStar_Click);
            // 
            // btnColorPicker
            // 
            this.btnColorPicker.Image = ((System.Drawing.Image)(resources.GetObject("btnColorPicker.Image")));
            this.btnColorPicker.Location = new System.Drawing.Point(231, 47);
            this.btnColorPicker.Name = "btnColorPicker";
            this.btnColorPicker.Size = new System.Drawing.Size(32, 32);
            this.btnColorPicker.TabIndex = 12;
            this.btnColorPicker.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(374, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 16);
            this.label3.TabIndex = 10;
            this.label3.Text = "Shapes";
            // 
            // btnBrush
            // 
            this.btnBrush.Image = ((System.Drawing.Image)(resources.GetObject("btnBrush.Image")));
            this.btnBrush.Location = new System.Drawing.Point(230, 6);
            this.btnBrush.Name = "btnBrush";
            this.btnBrush.Size = new System.Drawing.Size(32, 32);
            this.btnBrush.TabIndex = 9;
            this.btnBrush.UseVisualStyleBackColor = true;
            // 
            // btnErase
            // 
            this.btnErase.Image = ((System.Drawing.Image)(resources.GetObject("btnErase.Image")));
            this.btnErase.Location = new System.Drawing.Point(191, 6);
            this.btnErase.Name = "btnErase";
            this.btnErase.Size = new System.Drawing.Size(32, 32);
            this.btnErase.TabIndex = 8;
            this.btnErase.UseVisualStyleBackColor = true;
            // 
            // btnText
            // 
            this.btnText.Image = ((System.Drawing.Image)(resources.GetObject("btnText.Image")));
            this.btnText.Location = new System.Drawing.Point(155, 47);
            this.btnText.Name = "btnText";
            this.btnText.Size = new System.Drawing.Size(32, 32);
            this.btnText.TabIndex = 7;
            this.btnText.UseVisualStyleBackColor = true;
            // 
            // btnFill
            // 
            this.btnFill.Image = ((System.Drawing.Image)(resources.GetObject("btnFill.Image")));
            this.btnFill.Location = new System.Drawing.Point(191, 47);
            this.btnFill.Name = "btnFill";
            this.btnFill.Size = new System.Drawing.Size(32, 32);
            this.btnFill.TabIndex = 6;
            this.btnFill.UseVisualStyleBackColor = true;
            // 
            // btnPencil
            // 
            this.btnPencil.Image = ((System.Drawing.Image)(resources.GetObject("btnPencil.Image")));
            this.btnPencil.Location = new System.Drawing.Point(155, 6);
            this.btnPencil.Name = "btnPencil";
            this.btnPencil.Size = new System.Drawing.Size(32, 32);
            this.btnPencil.TabIndex = 5;
            this.btnPencil.UseVisualStyleBackColor = true;
            this.btnPencil.Click += new System.EventHandler(this.btnPencil_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(188, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Tools";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(55, 95);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Clipboard";
            // 
            // btnCopy
            // 
            this.btnCopy.FlatAppearance.BorderSize = 0;
            this.btnCopy.Image = ((System.Drawing.Image)(resources.GetObject("btnCopy.Image")));
            this.btnCopy.Location = new System.Drawing.Point(58, 6);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(32, 32);
            this.btnCopy.TabIndex = 2;
            this.btnCopy.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCopy.UseVisualStyleBackColor = true;
            // 
            // btnCut
            // 
            this.btnCut.FlatAppearance.BorderSize = 0;
            this.btnCut.Image = ((System.Drawing.Image)(resources.GetObject("btnCut.Image")));
            this.btnCut.Location = new System.Drawing.Point(94, 6);
            this.btnCut.Name = "btnCut";
            this.btnCut.Size = new System.Drawing.Size(32, 32);
            this.btnCut.TabIndex = 1;
            this.btnCut.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCut.UseVisualStyleBackColor = true;
            // 
            // btnPaste
            // 
            this.btnPaste.FlatAppearance.BorderSize = 0;
            this.btnPaste.Image = ((System.Drawing.Image)(resources.GetObject("btnPaste.Image")));
            this.btnPaste.Location = new System.Drawing.Point(22, 6);
            this.btnPaste.Name = "btnPaste";
            this.btnPaste.Size = new System.Drawing.Size(32, 32);
            this.btnPaste.TabIndex = 0;
            this.btnPaste.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnPaste.UseVisualStyleBackColor = true;
            // 
            // plMain
            // 
            this.plMain.BackColor = System.Drawing.SystemColors.Window;
            this.plMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plMain.Location = new System.Drawing.Point(0, 124);
            this.plMain.Name = "plMain";
            this.plMain.Size = new System.Drawing.Size(1260, 666);
            this.plMain.TabIndex = 1;
            this.plMain.Paint += new System.Windows.Forms.PaintEventHandler(this.plMain_Paint);
            this.plMain.MouseDown += new System.Windows.Forms.MouseEventHandler(this.plMain_MouseDown);
            this.plMain.MouseMove += new System.Windows.Forms.MouseEventHandler(this.plMain_MouseMove);
            this.plMain.MouseUp += new System.Windows.Forms.MouseEventHandler(this.plMain_MouseUp);
            // 
            // Paint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1260, 790);
            this.Controls.Add(this.plMain);
            this.Controls.Add(this.panel1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Name = "Paint";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Paint";
            this.Load += new System.EventHandler(this.Paint_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ShapePanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.Button btnCut;
        private System.Windows.Forms.Button btnPaste;
        private System.Windows.Forms.Button btnText;
        private System.Windows.Forms.Button btnFill;
        private System.Windows.Forms.Button btnPencil;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnErase;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnBrush;
        private System.Windows.Forms.Button btnColorPicker;
        private System.Windows.Forms.FlowLayoutPanel ShapePanel;
        private System.Windows.Forms.Button btnLine;
        private System.Windows.Forms.Button btnCurve;
        private System.Windows.Forms.Button btnOval;
        private System.Windows.Forms.Button btnRectangle;
        private System.Windows.Forms.Button btnTriangle;
        private System.Windows.Forms.Button btnDiamond;
        private System.Windows.Forms.Button btnPentagon;
        private System.Windows.Forms.Button btnHexagon;
        private System.Windows.Forms.Button btnStar;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.FlowLayoutPanel ColorPanel;
        private System.Windows.Forms.Panel plMain;
        private System.Windows.Forms.Button button1;
    }
}

