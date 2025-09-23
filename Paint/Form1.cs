using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Paint
{
    public partial class Paint : Form
    {
        private List<clsDrawObject> lstObject = new List<clsDrawObject>();
        private List<Point> pencilPoints = new List<Point>();

        private clsDrawObject selectedObject = null;
        private Point lastMousePosition;
        private bool isResizing = false;

        private Panel selectedColorPanel = null;
        private Button currentShapeButton = null;


        private ShapeType currentShape = ShapeType.None;
        private ToolType currentTool = ToolType.None;

        Pen myPen = new Pen(Color.Black, 5);
        Brush myBrush;
        Color myColor;

        bool isStart = false;

        // Lưu thông tin các nút shapes
        private enum ShapeType
        {
            None, Line, Curve, Oval,
            Rectangle, Triangle, Diamond,
            Pentagon, Hexagon, Star
        }

        // Lưu thông tin các nút tools
        private enum ToolType
        {
            None, Pencil, Eraser, Brush,
            Fill, Text, ColorPicker
        }

        public Paint()
        {
            InitializeComponent();
            myColor = Color.Black;
            myBrush = new SolidBrush(Color.Black);
        }

        public abstract class clsDrawObject
        {
            public Point p1, p2;
            public Pen myPen = new Pen(Color.Black, 2);

            public abstract void Draw(Graphics myGp);

            public virtual void DrawBoundingBox(Graphics g)
            {
                int x = Math.Min(p1.X, p2.X);
                int y = Math.Min(p1.Y, p2.Y);
                int width = Math.Abs(p2.X - p1.X);
                int height = Math.Abs(p2.Y - p1.Y);

                // Vẽ khung nét đứt
                using (Pen dashPen = new Pen(Color.Gray))
                {
                    dashPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                    g.DrawRectangle(dashPen, x, y, width, height);
                }

                // Vẽ các chấm tại 8 điểm
                int size = 6;
                Brush handleBrush = Brushes.Blue;

                Point[] handles =
                {
                    new Point(x, y),
                    new Point(x + width / 2, y),
                    new Point(x + width, y),
                    new Point(x, y + height / 2),
                    new Point(x + width, y + height / 2),
                    new Point(x, y + height),
                    new Point(x + width / 2, y + height),
                    new Point(x + width, y + height)
                };

                foreach (var pt in handles)
                {
                    g.FillRectangle(handleBrush, pt.X - size / 2, pt.Y - size / 2, size, size);
                }
            }
            public bool IsSelected { get; set; } = false;

            public virtual bool Contains(Point pt)
            {
                Rectangle rect = new Rectangle(
                    Math.Min(p1.X, p2.X),
                    Math.Min(p1.Y, p2.Y),
                    Math.Abs(p2.X - p1.X),
                    Math.Abs(p2.Y - p1.Y)
                );
                return rect.Contains(pt);
            }
        }

        public class clsLine : clsDrawObject
        {
            public override void Draw(Graphics myGp)
            {
                myGp.DrawLine(myPen, p1, p2);
                if (IsSelected)
                {
                    DrawBoundingBox(myGp);
                }
            }
        }

        public class clsCurve : clsDrawObject
        {
            public override void Draw(Graphics myGp)
            {
                if (p1 == p2) return;

                int x = Math.Min(p1.X, p2.X);
                int y = Math.Min(p1.Y, p2.Y);
                int width = Math.Abs(p2.X - p1.X);
                int height = Math.Abs(p2.Y - p1.Y);

                int numPoints = 50;
                Point[] points = new Point[numPoints];

                for (int i = 0; i < numPoints; i++)
                {
                    double t = (double)i / (numPoints - 1); // từ 0 đến 1
                    int px = x + (int)(t * width);
                    int py = y + (int)(height / 2 * Math.Sin(t * 2 * Math.PI) + height / 2);
                    points[i] = new Point(px, py);
                }

                myGp.DrawCurve(myPen, points);

                if (IsSelected)
                {
                    DrawBoundingBox(myGp);
                }
            }
        }


        public class clsOval : clsDrawObject
        {
            public override void Draw(Graphics myGp)
            {
                int x = Math.Min(this.p1.X, this.p2.X);
                int y = Math.Min(this.p1.Y, this.p2.Y);
                int width = Math.Abs(this.p2.X - this.p1.X);
                int height = Math.Abs(this.p2.Y - this.p1.Y);
                myGp.DrawEllipse(myPen, x, y, width, height);

                if (IsSelected)
                {
                    DrawBoundingBox(myGp);
                }
            }
        }

        public class clsRectangle : clsDrawObject
        {
            public override void Draw(Graphics myGp)
            {
                int x = Math.Min(this.p1.X, this.p2.X);
                int y = Math.Min(this.p1.Y, this.p2.Y);
                int width = Math.Abs(this.p2.X - this.p1.X);
                int height = Math.Abs(this.p2.Y - this.p1.Y);
                myGp.DrawRectangle(myPen, x, y, width, height);

                if (IsSelected)
                {
                    DrawBoundingBox(myGp);
                }
            }
        }

        public class clsTriangle : clsDrawObject
        {
            public override void Draw(Graphics myGp)
            {
                Point[] points = new Point[3];
                points[0] = new Point(p1.X, p2.Y);
                points[1] = new Point(p2.X, p2.Y);
                points[2] = new Point((p1.X + p2.X) / 2, p1.Y);
                myGp.DrawPolygon(myPen, points);

                if (IsSelected)
                {
                    DrawBoundingBox(myGp);
                }
            }
        }

        public class clsDiamond : clsDrawObject
        {
            public override void Draw(Graphics myGp)
            {
                Point[] points = new Point[4];
                points[0] = new Point((p1.X + p2.X) / 2, p1.Y);
                points[1] = new Point(p2.X, (p1.Y + p2.Y) / 2);
                points[2] = new Point((p1.X + p2.X) / 2, p2.Y);
                points[3] = new Point(p1.X, (p1.Y + p2.Y) / 2);
                myGp.DrawPolygon(myPen, points);

                if (IsSelected)
                {
                    DrawBoundingBox(myGp);
                }
            }
        }

        public class clsPentagon : clsDrawObject
        {
            public override void Draw(Graphics myGp)
            {
                int x = Math.Min(p1.X, p2.X);
                int y = Math.Min(p1.Y, p2.Y);
                int width = Math.Abs(p2.X - p1.X);
                int height = Math.Abs(p2.Y - p1.Y);

                Point[] points = new Point[5];

                // Các điểm được tính để vừa khít với khung hình chữ nhật p1 - p2
                points[0] = new Point(x + width / 2, y);                  // Đỉnh trên giữa
                points[1] = new Point(x + width, y + height / 3);         // Phải trên
                points[2] = new Point(x + 3 * width / 4, y + height);      // Phải dưới
                points[3] = new Point(x + width / 4, y + height);          // Trái dưới
                points[4] = new Point(x, y + height / 3);                 // Trái trên

                myGp.DrawPolygon(myPen, points);

                if (IsSelected)
                {
                    DrawBoundingBox(myGp);
                }
            }
        }


        public class clsHexagon : clsDrawObject
        {
            public override void Draw(Graphics myGp)
            {
                int x = Math.Min(p1.X, p2.X);
                int y = Math.Min(p1.Y, p2.Y);
                int width = Math.Abs(p2.X - p1.X);
                int height = Math.Abs(p2.Y - p1.Y);

                Point[] points = new Point[6];

                // Tính các điểm sao cho hình lục giác nằm gọn trong bounding box
                points[0] = new Point(x + width / 4, y);                  // Đỉnh trên trái
                points[1] = new Point(x + 3 * width / 4, y);              // Đỉnh trên phải
                points[2] = new Point(x + width, y + height / 2);         // Phải giữa
                points[3] = new Point(x + 3 * width / 4, y + height);     // Đáy phải
                points[4] = new Point(x + width / 4, y + height);         // Đáy trái
                points[5] = new Point(x, y + height / 2);                 // Trái giữa

                myGp.DrawPolygon(myPen, points);

                if (IsSelected)
                {
                    DrawBoundingBox(myGp);
                }
            }
        }
        public class clsStar : clsDrawObject
        {
            public override void Draw(Graphics myGp)
            {
                int x = Math.Min(p1.X, p2.X);
                int y = Math.Min(p1.Y, p2.Y);
                int width = Math.Abs(p2.X - p1.X);
                int height = Math.Abs(p2.Y - p1.Y);

                Point center = new Point(x + width / 2, y + height / 2);
                float outerRadius = Math.Min(width, height) / 2f;
                float innerRadius = outerRadius * 0.5f; // Tùy chỉnh tỉ lệ ngôi sao

                PointF[] points = new PointF[10];
                for (int i = 0; i < 10; i++)
                {
                    double angle = -Math.PI / 2 + i * Math.PI / 5; // Bắt đầu từ đỉnh
                    float radius = (i % 2 == 0) ? outerRadius : innerRadius;

                    points[i] = new PointF(
                        center.X + (float)(radius * Math.Cos(angle)),
                        center.Y + (float)(radius * Math.Sin(angle))
                    );
                }

                myGp.DrawPolygon(myPen, points);

                if (IsSelected)
                {
                    DrawBoundingBox(myGp);
                }
            }
        }


        public class clsPencil : clsDrawObject
        {
            public List<Point> Points { get; set; } = new List<Point>();

            public override void Draw(Graphics myGp)
            {
                if (Points.Count > 1)
                {
                    myGp.DrawLines(myPen, Points.ToArray());
                }
            }
        }

        private void Paint_Load(object sender, EventArgs e)
        {
            Color[] colors =
            {
                Color.Black, Color.White, Color.Red, Color.Green, Color.Blue,
                Color.Yellow, Color.Orange, Color.Purple, Color.Pink,
                Color.Brown, Color.Gray, Color.Cyan, Color.Magenta, Color.Lime,
                Color.Teal, Color.Navy, Color.Olive, Color.Maroon, Color.Aqua,
                Color.Silver, Color.Gold, Color.Indigo, Color.Turquoise, Color.Violet,
                Color.Wheat, Color.Tomato, Color.Tan, Color.Snow, Color.Salmon,
                Color.SeaShell, Color.SlateBlue, Color.SlateGray, Color.SpringGreen, Color.SteelBlue,
                Color.SkyBlue, Color.RosyBrown, Color.PowderBlue, Color.Plum, Color.PaleTurquoise,
                Color.PaleVioletRed, Color.PapayaWhip, Color.PeachPuff, Color.Peru, Color.PaleGreen,
                Color.Orchid, Color.OldLace, Color.OliveDrab, Color.Moccasin, Color.MistyRose,
                Color.MintCream, Color.MediumVioletRed, Color.MediumSpringGreen, Color.MediumSlateBlue, Color.MediumTurquoise,
                Color.MediumOrchid, Color.MediumPurple, Color.MediumSeaGreen, Color.MediumAquamarine,
            };

            foreach (Color color in colors)
            {
                Panel colorPanel = new Panel();
                colorPanel.BackColor = color;
                colorPanel.Width = 20;
                colorPanel.Height = 20;
                colorPanel.Margin = new Padding(2);
                colorPanel.BorderStyle = BorderStyle.FixedSingle;
                colorPanel.Click += ColorPanel_Click;
                ColorPanel.Controls.Add(colorPanel);
            }
        }

        private void ColorPanel_Click(object sender, EventArgs e)
        {
            Panel selectedPanel = sender as Panel;
            myColor = selectedPanel.BackColor;
            myPen.Color = myColor;

            if (selectedColorPanel != null)
            {
                selectedColorPanel.BorderStyle = BorderStyle.FixedSingle;
            }

            selectedPanel.BorderStyle = BorderStyle.Fixed3D;
            selectedColorPanel = selectedPanel;
        }

        //Shapes
        private void btnLine_Click(object sender, EventArgs e)
        {
            ToggleShapeTool(ShapeType.Line, (Button)sender);
        }

        private void btnCurve_Click(object sender, EventArgs e)
        {
            ToggleShapeTool(ShapeType.Curve, (Button)sender);
        }

        private void btnOval_Click(object sender, EventArgs e)
        {
            ToggleShapeTool(ShapeType.Oval, (Button)sender);
        }

        private void btnRectangle_Click(object sender, EventArgs e)
        {
            ToggleShapeTool(ShapeType.Rectangle, (Button)sender);
        }

        private void btnTriangle_Click(object sender, EventArgs e)
        {
            ToggleShapeTool(ShapeType.Triangle, (Button)sender);
        }

        private void btnDiamond_Click(object sender, EventArgs e)
        {
            ToggleShapeTool(ShapeType.Diamond, (Button)sender);
        }

        private void btnPentagon_Click(object sender, EventArgs e)
        {
            ToggleShapeTool(ShapeType.Pentagon, (Button)sender);
        }

        private void btnHexagon_Click(object sender, EventArgs e)
        {
            ToggleShapeTool(ShapeType.Hexagon, (Button)sender);
        }

        private void btnStar_Click(object sender, EventArgs e)
        {
            ToggleShapeTool(ShapeType.Star, (Button)sender);
        }

        private void ToggleShapeTool(ShapeType shape, Button clickedButton)
        {
            if (currentShape == shape)
            {
                // Bấm lại nút đang chọn -> bỏ chọn
                currentShape = ShapeType.None;

                clickedButton.FlatStyle = FlatStyle.Standard;
                clickedButton.Font = new Font(clickedButton.Font, FontStyle.Regular);

                currentShapeButton = null;
            }
            else
            {
                currentShape = shape;

                // Bỏ định dạng nút cũ (nếu có)
                if (currentShapeButton != null)
                {
                    currentShapeButton.FlatStyle = FlatStyle.Standard;
                    currentShapeButton.Font = new Font(currentShapeButton.Font, FontStyle.Regular);
                }

                // Tô đậm nút mới
                clickedButton.FlatStyle = FlatStyle.Flat;
                clickedButton.Font = new Font(clickedButton.Font, FontStyle.Bold);

                currentShapeButton = clickedButton;
            }
        }



        //Tools
        private void btnPencil_Click(object sender, EventArgs e)
        {
            if (currentTool == ToolType.Pencil)
            {
                currentTool = ToolType.None;
            }
            else
            {
                currentTool = ToolType.Pencil;
                currentShape = ShapeType.None;
            }
        }

        private void plMain_MouseDown(object sender, MouseEventArgs e)
        {
            if (currentTool == ToolType.Pencil)
            {
                isStart = true;
                pencilPoints.Clear();
                pencilPoints.Add(e.Location);
                clsPencil myPencil = new clsPencil { Points = new List<Point> { e.Location }, myPen = new Pen(myColor, 5) };
                lstObject.Add(myPencil);
            }
            else if (currentShape != ShapeType.None)
            {
                isStart = true;
                clsDrawObject newShape = null;

                switch (currentShape)
                {
                    case ShapeType.Line:
                        newShape = new clsLine { p1 = e.Location, p2 = e.Location, myPen = new Pen(myColor, 5) };
                        break;
                    case ShapeType.Curve:
                        newShape = new clsCurve { p1 = e.Location, p2 = e.Location, myPen = new Pen(myColor, 5) };
                        break;
                    case ShapeType.Oval:
                        newShape = new clsOval { p1 = e.Location, p2 = e.Location, myPen = new Pen(myColor, 5) };
                        break;
                    case ShapeType.Rectangle:
                        newShape = new clsRectangle { p1 = e.Location, p2 = e.Location, myPen = new Pen(myColor, 5) };
                        break;
                    case ShapeType.Triangle:
                        newShape = new clsTriangle { p1 = e.Location, p2 = e.Location, myPen = new Pen(myColor, 5) };
                        break;
                    case ShapeType.Diamond:
                        newShape = new clsDiamond { p1 = e.Location, p2 = e.Location, myPen = new Pen(myColor, 5) };
                        break;
                    case ShapeType.Pentagon:
                        newShape = new clsPentagon { p1 = e.Location, p2 = e.Location, myPen = new Pen(myColor, 5) };
                        break;
                    case ShapeType.Hexagon:
                        newShape = new clsHexagon { p1 = e.Location, p2 = e.Location, myPen = new Pen(myColor, 5) };
                        break;
                    case ShapeType.Star:
                        newShape = new clsStar { p1 = e.Location, p2 = e.Location, myPen = new Pen(myColor, 5) };
                        break;
                    default:
                        break;
                }

                if (newShape != null)
                {
                    lstObject.Add(newShape);
                    selectedObject = newShape;
                }
            }
            else
            {
                foreach (var obj in lstObject)
                    obj.IsSelected = false;

                for (int i = lstObject.Count - 1; i >= 0; i--)
                {
                    if (lstObject[i].Contains(e.Location))
                    {
                        selectedObject = lstObject[i];
                        selectedObject.IsSelected = true;

                        if (IsResizing(e.Location, selectedObject))
                        {
                            isResizing = true;
                        }
                        else
                        {
                            isResizing = false;
                            lastMousePosition = e.Location;
                        }
                        break;
                    }
                }
            }

            plMain.Refresh();
        }

        private void plMain_MouseMove(object sender, MouseEventArgs e)
        {
            if (isStart)
            {
                if (currentTool == ToolType.Pencil)
                {
                    pencilPoints.Add(e.Location);
                    ((clsPencil)lstObject[lstObject.Count - 1]).Points = new List<Point>(pencilPoints);
                }
                else if (currentShape != ShapeType.None)
                {
                    lstObject[lstObject.Count - 1].p2 = e.Location;
                }
                plMain.Refresh();
            }
            else if (selectedObject != null)
            {
                if (isResizing)
                {
                    // Resize the selected shape
                    selectedObject.p2 = e.Location;
                }
                else
                {
                    // Move the selected shape
                    int dx = e.X - lastMousePosition.X;
                    int dy = e.Y - lastMousePosition.Y;
                    selectedObject.p1 = new Point(selectedObject.p1.X + dx, selectedObject.p1.Y + dy);
                    selectedObject.p2 = new Point(selectedObject.p2.X + dx, selectedObject.p2.Y + dy);
                    lastMousePosition = e.Location;
                }
                plMain.Refresh();
            }
        }

        private void plMain_MouseUp(object sender, MouseEventArgs e)
        {
            isStart = false;
            if (currentTool == ToolType.Pencil)
            {
                ((clsPencil)lstObject[lstObject.Count - 1]).Points = new List<Point>(pencilPoints);
            }
            else if (currentShape != ShapeType.None)
            {
                lstObject[lstObject.Count - 1].p2 = e.Location;
            }
            selectedObject = null;
            isResizing = false;
            plMain.Refresh();
        }

        private void plMain_Paint(object sender, PaintEventArgs e)
        {
            Graphics gp = e.Graphics;
            for (int i = 0; i < lstObject.Count; i++)
            {
                lstObject[i].Draw(gp);
                if (lstObject[i] == selectedObject)
                {
                    lstObject[i].DrawBoundingBox(gp);
                }
            }
        }

        private bool IsResizing(Point mousePosition, clsDrawObject obj)
        {
            const int handleSize = 10;

            // Lấy tọa độ góc trái trên và kích thước hình
            int x = Math.Min(obj.p1.X, obj.p2.X);
            int y = Math.Min(obj.p1.Y, obj.p2.Y);
            int width = Math.Abs(obj.p2.X - obj.p1.X);
            int height = Math.Abs(obj.p2.Y - obj.p1.Y);

            // Tạo các điểm resize (chấm) cho các góc và giữa các cạnh
            List<Rectangle> resizeHandles = new List<Rectangle>
            {
                new Rectangle(x - handleSize / 2, y - handleSize / 2, handleSize, handleSize), // Góc trên trái
                new Rectangle(x + width - handleSize / 2, y - handleSize / 2, handleSize, handleSize), // Góc trên phải
                new Rectangle(x - handleSize / 2, y + height - handleSize / 2, handleSize, handleSize), // Góc dưới trái
                new Rectangle(x + width - handleSize / 2, y + height - handleSize / 2, handleSize, handleSize), // Góc dưới phải

                // Các điểm giữa các cạnh
                new Rectangle(x + width / 2 - handleSize / 2, y - handleSize / 2, handleSize, handleSize), // Giữa trên
                new Rectangle(x + width / 2 - handleSize / 2, y + height - handleSize / 2, handleSize, handleSize), // Giữa dưới
                new Rectangle(x - handleSize / 2, y + height / 2 - handleSize / 2, handleSize, handleSize), // Giữa trái
                new Rectangle(x + width - handleSize / 2, y + height / 2 - handleSize / 2, handleSize, handleSize)  // Giữa phải
            };

            // Kiểm tra nếu mousePosition nằm trong một trong các điểm resize
            foreach (var handle in resizeHandles)
            {
                if (handle.Contains(mousePosition))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
