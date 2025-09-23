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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Paint));
            this.pnToolBox = new System.Windows.Forms.Panel();
            this.lbSize = new System.Windows.Forms.Label();
            this.flpWidth = new System.Windows.Forms.FlowLayoutPanel();
            this.btnLine_Dashed = new System.Windows.Forms.Button();
            this.btnLine_1px = new System.Windows.Forms.Button();
            this.btnLine_3px = new System.Windows.Forms.Button();
            this.btnLine_5px = new System.Windows.Forms.Button();
            this.btnNewFile = new System.Windows.Forms.Button();
            this.btnUngroup = new System.Windows.Forms.Button();
            this.btnGroup = new System.Windows.Forms.Button();
            this.ColorPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.lbColors = new System.Windows.Forms.Label();
            this.flpShapes = new System.Windows.Forms.FlowLayoutPanel();
            this.btnLine = new System.Windows.Forms.Button();
            this.btnCurve = new System.Windows.Forms.Button();
            this.btnOval = new System.Windows.Forms.Button();
            this.btnRectangle = new System.Windows.Forms.Button();
            this.btnTriangle = new System.Windows.Forms.Button();
            this.btnDiamond = new System.Windows.Forms.Button();
            this.btnPentagon = new System.Windows.Forms.Button();
            this.btnHexagon = new System.Windows.Forms.Button();
            this.btnStar = new System.Windows.Forms.Button();
            this.btnPolygon = new System.Windows.Forms.Button();
            this.lbShapes = new System.Windows.Forms.Label();
            this.btnBrush = new System.Windows.Forms.Button();
            this.btnEraser = new System.Windows.Forms.Button();
            this.btnFill = new System.Windows.Forms.Button();
            this.btnPencil = new System.Windows.Forms.Button();
            this.lbTools = new System.Windows.Forms.Label();
            this.lbClipboard = new System.Windows.Forms.Label();
            this.pbMain = new System.Windows.Forms.PictureBox();
            this.ttMain = new System.Windows.Forms.ToolTip(this.components);
            this.pnToolBox.SuspendLayout();
            this.flpWidth.SuspendLayout();
            this.flpShapes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbMain)).BeginInit();
            this.SuspendLayout();
            // 
            // pnToolBox
            // 
            this.pnToolBox.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.pnToolBox.Controls.Add(this.lbSize);
            this.pnToolBox.Controls.Add(this.flpWidth);
            this.pnToolBox.Controls.Add(this.btnNewFile);
            this.pnToolBox.Controls.Add(this.btnUngroup);
            this.pnToolBox.Controls.Add(this.btnGroup);
            this.pnToolBox.Controls.Add(this.ColorPanel);
            this.pnToolBox.Controls.Add(this.lbColors);
            this.pnToolBox.Controls.Add(this.flpShapes);
            this.pnToolBox.Controls.Add(this.lbShapes);
            this.pnToolBox.Controls.Add(this.btnBrush);
            this.pnToolBox.Controls.Add(this.btnEraser);
            this.pnToolBox.Controls.Add(this.btnFill);
            this.pnToolBox.Controls.Add(this.btnPencil);
            this.pnToolBox.Controls.Add(this.lbTools);
            this.pnToolBox.Controls.Add(this.lbClipboard);
            this.pnToolBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnToolBox.Location = new System.Drawing.Point(0, 0);
            this.pnToolBox.Name = "pnToolBox";
            this.pnToolBox.Size = new System.Drawing.Size(1499, 124);
            this.pnToolBox.TabIndex = 0;
            // 
            // lbSize
            // 
            this.lbSize.AutoSize = true;
            this.lbSize.Location = new System.Drawing.Point(882, 95);
            this.lbSize.Name = "lbSize";
            this.lbSize.Size = new System.Drawing.Size(33, 16);
            this.lbSize.TabIndex = 25;
            this.lbSize.Text = "Size";
            // 
            // flpWidth
            // 
            this.flpWidth.AllowDrop = true;
            this.flpWidth.AutoScroll = true;
            this.flpWidth.Controls.Add(this.btnLine_Dashed);
            this.flpWidth.Controls.Add(this.btnLine_1px);
            this.flpWidth.Controls.Add(this.btnLine_3px);
            this.flpWidth.Controls.Add(this.btnLine_5px);
            this.flpWidth.Location = new System.Drawing.Point(832, 6);
            this.flpWidth.Name = "flpWidth";
            this.flpWidth.Size = new System.Drawing.Size(148, 46);
            this.flpWidth.TabIndex = 24;
            // 
            // btnLine_Dashed
            // 
            this.btnLine_Dashed.Image = ((System.Drawing.Image)(resources.GetObject("btnLine_Dashed.Image")));
            this.btnLine_Dashed.Location = new System.Drawing.Point(3, 3);
            this.btnLine_Dashed.Name = "btnLine_Dashed";
            this.btnLine_Dashed.Size = new System.Drawing.Size(119, 17);
            this.btnLine_Dashed.TabIndex = 22;
            this.btnLine_Dashed.TabStop = false;
            this.btnLine_Dashed.Tag = "dashed";
            this.ttMain.SetToolTip(this.btnLine_Dashed, "Dash");
            this.btnLine_Dashed.UseVisualStyleBackColor = true;
            this.btnLine_Dashed.Click += new System.EventHandler(this.sizeButton_Click);
            // 
            // btnLine_1px
            // 
            this.btnLine_1px.Image = ((System.Drawing.Image)(resources.GetObject("btnLine_1px.Image")));
            this.btnLine_1px.Location = new System.Drawing.Point(3, 26);
            this.btnLine_1px.Name = "btnLine_1px";
            this.btnLine_1px.Size = new System.Drawing.Size(119, 17);
            this.btnLine_1px.TabIndex = 0;
            this.btnLine_1px.TabStop = false;
            this.btnLine_1px.Tag = "1";
            this.ttMain.SetToolTip(this.btnLine_1px, "Small");
            this.btnLine_1px.UseVisualStyleBackColor = true;
            this.btnLine_1px.Click += new System.EventHandler(this.sizeButton_Click);
            // 
            // btnLine_3px
            // 
            this.btnLine_3px.Image = ((System.Drawing.Image)(resources.GetObject("btnLine_3px.Image")));
            this.btnLine_3px.Location = new System.Drawing.Point(3, 49);
            this.btnLine_3px.Name = "btnLine_3px";
            this.btnLine_3px.Size = new System.Drawing.Size(119, 17);
            this.btnLine_3px.TabIndex = 1;
            this.btnLine_3px.TabStop = false;
            this.btnLine_3px.Tag = "5";
            this.ttMain.SetToolTip(this.btnLine_3px, "Medium");
            this.btnLine_3px.UseVisualStyleBackColor = true;
            this.btnLine_3px.Click += new System.EventHandler(this.sizeButton_Click);
            // 
            // btnLine_5px
            // 
            this.btnLine_5px.Image = ((System.Drawing.Image)(resources.GetObject("btnLine_5px.Image")));
            this.btnLine_5px.Location = new System.Drawing.Point(3, 72);
            this.btnLine_5px.Name = "btnLine_5px";
            this.btnLine_5px.Size = new System.Drawing.Size(119, 17);
            this.btnLine_5px.TabIndex = 23;
            this.btnLine_5px.TabStop = false;
            this.btnLine_5px.Tag = "10";
            this.ttMain.SetToolTip(this.btnLine_5px, "Big");
            this.btnLine_5px.UseVisualStyleBackColor = true;
            this.btnLine_5px.Click += new System.EventHandler(this.sizeButton_Click);
            // 
            // btnNewFile
            // 
            this.btnNewFile.Image = ((System.Drawing.Image)(resources.GetObject("btnNewFile.Image")));
            this.btnNewFile.Location = new System.Drawing.Point(88, 6);
            this.btnNewFile.Name = "btnNewFile";
            this.btnNewFile.Size = new System.Drawing.Size(31, 32);
            this.btnNewFile.TabIndex = 20;
            this.btnNewFile.TabStop = false;
            this.ttMain.SetToolTip(this.btnNewFile, "New file");
            this.btnNewFile.UseVisualStyleBackColor = true;
            this.btnNewFile.Click += new System.EventHandler(this.clipboardButton_Click);
            // 
            // btnUngroup
            // 
            this.btnUngroup.Image = ((System.Drawing.Image)(resources.GetObject("btnUngroup.Image")));
            this.btnUngroup.Location = new System.Drawing.Point(50, 6);
            this.btnUngroup.Name = "btnUngroup";
            this.btnUngroup.Size = new System.Drawing.Size(32, 32);
            this.btnUngroup.TabIndex = 19;
            this.btnUngroup.TabStop = false;
            this.ttMain.SetToolTip(this.btnUngroup, "Ungroup");
            this.btnUngroup.UseVisualStyleBackColor = true;
            this.btnUngroup.Click += new System.EventHandler(this.clipboardButton_Click);
            // 
            // btnGroup
            // 
            this.btnGroup.Image = ((System.Drawing.Image)(resources.GetObject("btnGroup.Image")));
            this.btnGroup.Location = new System.Drawing.Point(12, 6);
            this.btnGroup.Name = "btnGroup";
            this.btnGroup.Size = new System.Drawing.Size(32, 32);
            this.btnGroup.TabIndex = 18;
            this.btnGroup.TabStop = false;
            this.ttMain.SetToolTip(this.btnGroup, "Group");
            this.btnGroup.UseVisualStyleBackColor = true;
            this.btnGroup.Click += new System.EventHandler(this.clipboardButton_Click);
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
            // lbColors
            // 
            this.lbColors.AutoSize = true;
            this.lbColors.Location = new System.Drawing.Point(657, 95);
            this.lbColors.Name = "lbColors";
            this.lbColors.Size = new System.Drawing.Size(46, 16);
            this.lbColors.TabIndex = 16;
            this.lbColors.Text = "Colors";
            // 
            // flpShapes
            // 
            this.flpShapes.AutoScroll = true;
            this.flpShapes.Controls.Add(this.btnLine);
            this.flpShapes.Controls.Add(this.btnCurve);
            this.flpShapes.Controls.Add(this.btnOval);
            this.flpShapes.Controls.Add(this.btnRectangle);
            this.flpShapes.Controls.Add(this.btnTriangle);
            this.flpShapes.Controls.Add(this.btnDiamond);
            this.flpShapes.Controls.Add(this.btnPentagon);
            this.flpShapes.Controls.Add(this.btnHexagon);
            this.flpShapes.Controls.Add(this.btnStar);
            this.flpShapes.Controls.Add(this.btnPolygon);
            this.flpShapes.Location = new System.Drawing.Point(298, 6);
            this.flpShapes.Name = "flpShapes";
            this.flpShapes.Size = new System.Drawing.Size(216, 76);
            this.flpShapes.TabIndex = 13;
            // 
            // btnLine
            // 
            this.btnLine.Image = ((System.Drawing.Image)(resources.GetObject("btnLine.Image")));
            this.btnLine.Location = new System.Drawing.Point(3, 3);
            this.btnLine.Name = "btnLine";
            this.btnLine.Size = new System.Drawing.Size(32, 32);
            this.btnLine.TabIndex = 0;
            this.btnLine.TabStop = false;
            this.ttMain.SetToolTip(this.btnLine, "Line");
            this.btnLine.UseVisualStyleBackColor = true;
            this.btnLine.Click += new System.EventHandler(this.shapeButton_Click);
            // 
            // btnCurve
            // 
            this.btnCurve.Image = ((System.Drawing.Image)(resources.GetObject("btnCurve.Image")));
            this.btnCurve.Location = new System.Drawing.Point(41, 3);
            this.btnCurve.Name = "btnCurve";
            this.btnCurve.Size = new System.Drawing.Size(32, 32);
            this.btnCurve.TabIndex = 1;
            this.btnCurve.TabStop = false;
            this.ttMain.SetToolTip(this.btnCurve, "Curve");
            this.btnCurve.UseVisualStyleBackColor = true;
            this.btnCurve.Click += new System.EventHandler(this.shapeButton_Click);
            // 
            // btnOval
            // 
            this.btnOval.Image = ((System.Drawing.Image)(resources.GetObject("btnOval.Image")));
            this.btnOval.Location = new System.Drawing.Point(79, 3);
            this.btnOval.Name = "btnOval";
            this.btnOval.Size = new System.Drawing.Size(32, 32);
            this.btnOval.TabIndex = 2;
            this.btnOval.TabStop = false;
            this.ttMain.SetToolTip(this.btnOval, "Oval");
            this.btnOval.UseVisualStyleBackColor = true;
            this.btnOval.Click += new System.EventHandler(this.shapeButton_Click);
            // 
            // btnRectangle
            // 
            this.btnRectangle.Image = ((System.Drawing.Image)(resources.GetObject("btnRectangle.Image")));
            this.btnRectangle.Location = new System.Drawing.Point(117, 3);
            this.btnRectangle.Name = "btnRectangle";
            this.btnRectangle.Size = new System.Drawing.Size(32, 32);
            this.btnRectangle.TabIndex = 3;
            this.btnRectangle.TabStop = false;
            this.ttMain.SetToolTip(this.btnRectangle, "Rectangle");
            this.btnRectangle.UseVisualStyleBackColor = true;
            this.btnRectangle.Click += new System.EventHandler(this.shapeButton_Click);
            // 
            // btnTriangle
            // 
            this.btnTriangle.Image = ((System.Drawing.Image)(resources.GetObject("btnTriangle.Image")));
            this.btnTriangle.Location = new System.Drawing.Point(155, 3);
            this.btnTriangle.Name = "btnTriangle";
            this.btnTriangle.Size = new System.Drawing.Size(32, 32);
            this.btnTriangle.TabIndex = 4;
            this.btnTriangle.TabStop = false;
            this.ttMain.SetToolTip(this.btnTriangle, "Triangle");
            this.btnTriangle.UseVisualStyleBackColor = true;
            this.btnTriangle.Click += new System.EventHandler(this.shapeButton_Click);
            // 
            // btnDiamond
            // 
            this.btnDiamond.Image = ((System.Drawing.Image)(resources.GetObject("btnDiamond.Image")));
            this.btnDiamond.Location = new System.Drawing.Point(3, 41);
            this.btnDiamond.Name = "btnDiamond";
            this.btnDiamond.Size = new System.Drawing.Size(32, 32);
            this.btnDiamond.TabIndex = 5;
            this.btnDiamond.TabStop = false;
            this.ttMain.SetToolTip(this.btnDiamond, "Diamond");
            this.btnDiamond.UseVisualStyleBackColor = true;
            this.btnDiamond.Click += new System.EventHandler(this.shapeButton_Click);
            // 
            // btnPentagon
            // 
            this.btnPentagon.Image = ((System.Drawing.Image)(resources.GetObject("btnPentagon.Image")));
            this.btnPentagon.Location = new System.Drawing.Point(41, 41);
            this.btnPentagon.Name = "btnPentagon";
            this.btnPentagon.Size = new System.Drawing.Size(32, 32);
            this.btnPentagon.TabIndex = 6;
            this.btnPentagon.TabStop = false;
            this.ttMain.SetToolTip(this.btnPentagon, "Pentagon");
            this.btnPentagon.UseVisualStyleBackColor = true;
            this.btnPentagon.Click += new System.EventHandler(this.shapeButton_Click);
            // 
            // btnHexagon
            // 
            this.btnHexagon.Image = ((System.Drawing.Image)(resources.GetObject("btnHexagon.Image")));
            this.btnHexagon.Location = new System.Drawing.Point(79, 41);
            this.btnHexagon.Name = "btnHexagon";
            this.btnHexagon.Size = new System.Drawing.Size(32, 32);
            this.btnHexagon.TabIndex = 7;
            this.btnHexagon.TabStop = false;
            this.ttMain.SetToolTip(this.btnHexagon, "Hexagon");
            this.btnHexagon.UseVisualStyleBackColor = true;
            this.btnHexagon.Click += new System.EventHandler(this.shapeButton_Click);
            // 
            // btnStar
            // 
            this.btnStar.Image = ((System.Drawing.Image)(resources.GetObject("btnStar.Image")));
            this.btnStar.Location = new System.Drawing.Point(117, 41);
            this.btnStar.Name = "btnStar";
            this.btnStar.Size = new System.Drawing.Size(32, 32);
            this.btnStar.TabIndex = 8;
            this.btnStar.TabStop = false;
            this.ttMain.SetToolTip(this.btnStar, "Star");
            this.btnStar.UseVisualStyleBackColor = true;
            this.btnStar.Click += new System.EventHandler(this.shapeButton_Click);
            // 
            // btnPolygon
            // 
            this.btnPolygon.Image = ((System.Drawing.Image)(resources.GetObject("btnPolygon.Image")));
            this.btnPolygon.Location = new System.Drawing.Point(155, 41);
            this.btnPolygon.Name = "btnPolygon";
            this.btnPolygon.Size = new System.Drawing.Size(32, 32);
            this.btnPolygon.TabIndex = 9;
            this.btnPolygon.TabStop = false;
            this.ttMain.SetToolTip(this.btnPolygon, "Polygon");
            this.btnPolygon.UseVisualStyleBackColor = true;
            this.btnPolygon.Click += new System.EventHandler(this.shapeButton_Click);
            // 
            // lbShapes
            // 
            this.lbShapes.AutoSize = true;
            this.lbShapes.Location = new System.Drawing.Point(373, 95);
            this.lbShapes.Name = "lbShapes";
            this.lbShapes.Size = new System.Drawing.Size(54, 16);
            this.lbShapes.TabIndex = 10;
            this.lbShapes.Text = "Shapes";
            // 
            // btnBrush
            // 
            this.btnBrush.Image = ((System.Drawing.Image)(resources.GetObject("btnBrush.Image")));
            this.btnBrush.Location = new System.Drawing.Point(229, 6);
            this.btnBrush.Name = "btnBrush";
            this.btnBrush.Size = new System.Drawing.Size(32, 32);
            this.btnBrush.TabIndex = 9;
            this.btnBrush.TabStop = false;
            this.ttMain.SetToolTip(this.btnBrush, "Brush");
            this.btnBrush.UseVisualStyleBackColor = true;
            this.btnBrush.Click += new System.EventHandler(this.toolButton_Click);
            // 
            // btnEraser
            // 
            this.btnEraser.Image = ((System.Drawing.Image)(resources.GetObject("btnEraser.Image")));
            this.btnEraser.Location = new System.Drawing.Point(192, 6);
            this.btnEraser.Name = "btnEraser";
            this.btnEraser.Size = new System.Drawing.Size(32, 32);
            this.btnEraser.TabIndex = 8;
            this.btnEraser.TabStop = false;
            this.ttMain.SetToolTip(this.btnEraser, "Eraser");
            this.btnEraser.UseVisualStyleBackColor = true;
            this.btnEraser.Click += new System.EventHandler(this.toolButton_Click);
            // 
            // btnFill
            // 
            this.btnFill.Image = ((System.Drawing.Image)(resources.GetObject("btnFill.Image")));
            this.btnFill.Location = new System.Drawing.Point(155, 47);
            this.btnFill.Name = "btnFill";
            this.btnFill.Size = new System.Drawing.Size(32, 32);
            this.btnFill.TabIndex = 6;
            this.btnFill.TabStop = false;
            this.ttMain.SetToolTip(this.btnFill, "Fill");
            this.btnFill.UseVisualStyleBackColor = true;
            this.btnFill.Click += new System.EventHandler(this.toolButton_Click);
            // 
            // btnPencil
            // 
            this.btnPencil.Image = ((System.Drawing.Image)(resources.GetObject("btnPencil.Image")));
            this.btnPencil.Location = new System.Drawing.Point(155, 6);
            this.btnPencil.Name = "btnPencil";
            this.btnPencil.Size = new System.Drawing.Size(32, 32);
            this.btnPencil.TabIndex = 5;
            this.btnPencil.TabStop = false;
            this.ttMain.SetToolTip(this.btnPencil, "Pencil");
            this.btnPencil.UseVisualStyleBackColor = true;
            this.btnPencil.Click += new System.EventHandler(this.toolButton_Click);
            // 
            // lbTools
            // 
            this.lbTools.AutoSize = true;
            this.lbTools.Location = new System.Drawing.Point(188, 95);
            this.lbTools.Name = "lbTools";
            this.lbTools.Size = new System.Drawing.Size(42, 16);
            this.lbTools.TabIndex = 4;
            this.lbTools.Text = "Tools";
            // 
            // lbClipboard
            // 
            this.lbClipboard.AutoSize = true;
            this.lbClipboard.Location = new System.Drawing.Point(33, 93);
            this.lbClipboard.Name = "lbClipboard";
            this.lbClipboard.Size = new System.Drawing.Size(66, 16);
            this.lbClipboard.TabIndex = 3;
            this.lbClipboard.Text = "Clipboard";
            // 
            // pbMain
            // 
            this.pbMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbMain.Location = new System.Drawing.Point(0, 124);
            this.pbMain.Name = "pbMain";
            this.pbMain.Size = new System.Drawing.Size(1499, 666);
            this.pbMain.TabIndex = 1;
            this.pbMain.TabStop = false;
            this.pbMain.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbMain_MouseDown);
            this.pbMain.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pbMain_MouseMove);
            this.pbMain.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pbMain_MouseUp);
            // 
            // ttMain
            // 
            this.ttMain.AutoPopDelay = 5000;
            this.ttMain.InitialDelay = 300;
            this.ttMain.ReshowDelay = 100;
            // 
            // Paint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1499, 790);
            this.Controls.Add(this.pbMain);
            this.Controls.Add(this.pnToolBox);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Name = "Paint";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Paint";
            this.Load += new System.EventHandler(this.Paint_Load);
            this.pnToolBox.ResumeLayout(false);
            this.pnToolBox.PerformLayout();
            this.flpWidth.ResumeLayout(false);
            this.flpShapes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbMain)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnToolBox;
        private System.Windows.Forms.Label lbClipboard;
        private System.Windows.Forms.Button btnFill;
        private System.Windows.Forms.Button btnPencil;
        private System.Windows.Forms.Label lbTools;
        private System.Windows.Forms.Button btnEraser;
        private System.Windows.Forms.Label lbShapes;
        private System.Windows.Forms.Button btnBrush;
        private System.Windows.Forms.FlowLayoutPanel flpShapes;
        private System.Windows.Forms.Button btnLine;
        private System.Windows.Forms.Button btnCurve;
        private System.Windows.Forms.Button btnOval;
        private System.Windows.Forms.Button btnRectangle;
        private System.Windows.Forms.Button btnTriangle;
        private System.Windows.Forms.Button btnDiamond;
        private System.Windows.Forms.Button btnPentagon;
        private System.Windows.Forms.Button btnHexagon;
        private System.Windows.Forms.Button btnStar;
        private System.Windows.Forms.Label lbColors;
        private System.Windows.Forms.FlowLayoutPanel ColorPanel;
        private System.Windows.Forms.Button btnGroup;
        private System.Windows.Forms.Button btnUngroup;
        private System.Windows.Forms.PictureBox pbMain;
        private System.Windows.Forms.Button btnPolygon;
        private System.Windows.Forms.ToolTip ttMain;
        private System.Windows.Forms.Button btnNewFile;
        private System.Windows.Forms.Button btnLine_1px;
        private System.Windows.Forms.Button btnLine_3px;
        private System.Windows.Forms.Button btnLine_Dashed;
        private System.Windows.Forms.Button btnLine_5px;
        private System.Windows.Forms.FlowLayoutPanel flpWidth;
        private System.Windows.Forms.Label lbSize;
    }
}

