using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Paint
{
    public partial class Paint : Form
    {
        // Khai báo bitmap và graphics
        private Bitmap drawingBitmap;
        private Graphics bitmapGraphics;

        // Khai báo danh sách các đối tượng vẽ
        private List<clsDrawObject> lstObject = new List<clsDrawObject>();
        private List<Point> pencilPoints = new List<Point>();

        // Khai báo thông tin màu sắc và bút vẽ
        private Color myColor = Color.Black;
        private static int myWidth = 2;
        private Pen myPen;

        // Khai báo thông tin các nút shapes và tools
        private ShapeType currentShape = ShapeType.None;
        private ToolType currentTool = ToolType.None;

        // Khai báo các biến trạng thái (VD: đang vẽ, đang chọn, đang resize, vẽ Polygon)
        private bool isStart = false;
        private bool isResizing = false;
        private bool isSelectingGroupArea = false;
        private clsPolygon currentFreePolygon = null;
        private bool isDrawingPolygon = false;
        private bool justGrouped = false;



        // Khai báo các biến trạng thái khác (VD: đang chọn màu, đối tượng được chọn, các nút được chọn)
        private Panel selectedColorPanel = null;
        private clsDrawObject selectedObject = null;
        private Button currentShapeButton = null;
        private Button currentToolButton = null;

        // Khai báo các biến lưu vị trí của chuột (Dùng để vẽ, resize, chọn)
        private Point startMousePosition, lastMousePosition;
        private Point selectStart, selectEnd;
        private Point initialP1, initialP2;

        // Khai báo biến lưu vị trí của các nút resize
        private int resizingHandleIndex = -1;

        // Lưu thông tin các nút shapes
        private enum ShapeType
        {
            None, Line, Curve, Oval,
            Rectangle, Triangle, Diamond,
            Pentagon, Hexagon, Star, Polygon
        }

        // Lưu thông tin các nút clipboard
        private enum ClipboardType
        {
            None, NewFile, Group, Ungroup
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
            KeyPreview = true;
            myPen = new Pen(Color.Black);
            myPen = (Pen)myPen.Clone();

            drawingBitmap = new Bitmap(pbMain.Width, pbMain.Height);
            bitmapGraphics = Graphics.FromImage(drawingBitmap);
            bitmapGraphics.Clear(Color.White);

            pbMain.Image = drawingBitmap;
        }

        // Khai báo màu sắc khi load form
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

        /*
            - Dùng để vẽ khung bao quanh các hình vẽ
            - Kiểm tra xem có nằm trong vùng chọn hay không
         */
        public static class DrawHelper
        {
            // Lấy khung bao quanh 2 điểm
            public static Rectangle GetBounds(Point p1, Point p2)
            {
                return new Rectangle(
                    Math.Min(p1.X, p2.X),
                    Math.Min(p1.Y, p2.Y),
                    Math.Abs(p2.X - p1.X),
                    Math.Abs(p2.Y - p1.Y)
                );
            }

            // Vẽ khung bao quanh hình vẽ
            public static void DrawBoundingBox(Graphics g, Rectangle bounds)
            {
                using (Pen dashPen = new Pen(Color.Gray))
                {
                    dashPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                    g.DrawRectangle(dashPen, bounds);
                }

                int size = 6;
                Brush handleBrush = Brushes.Blue;

                Point[] handles =
                {
                    new Point(bounds.Left, bounds.Top),
                    new Point(bounds.Left + bounds.Width / 2, bounds.Top),
                    new Point(bounds.Right, bounds.Top),
                    new Point(bounds.Left, bounds.Top + bounds.Height / 2),
                    new Point(bounds.Right, bounds.Top + bounds.Height / 2),
                    new Point(bounds.Left, bounds.Bottom),
                    new Point(bounds.Left + bounds.Width / 2, bounds.Bottom),
                    new Point(bounds.Right, bounds.Bottom)
                };

                foreach (var pt in handles)
                {
                    g.FillRectangle(handleBrush, pt.X - size / 2, pt.Y - size / 2, size, size);
                }
            }
        }

        // Lớp cha cho các đối tượng vẽ
        public abstract class clsDrawObject
        {
            public Point p1, p2;
            public Pen myPen;

            public abstract void Draw(Graphics myGp);

            public virtual void DrawBoundingBox(Graphics g)
            {
                Rectangle bounds = DrawHelper.GetBounds(p1, p2);
                DrawHelper.DrawBoundingBox(g, bounds);
            }

            public virtual bool Contains(Point pt)
            {
                return DrawHelper.GetBounds(p1, p2).Contains(pt);
            }

            private bool isSelected = false;

            public bool IsSelected
            {
                get
                {
                    return isSelected;
                }
                set
                {
                    isSelected = value;
                }
            }

            public Color? FillColor { get; set; } = null;
            public virtual void DrawFill(Graphics g) { }
        }

        // Lớp con cho các đối tượng vẽ - Vẽ đường thẳng (clsLine)
        public class clsLine : clsDrawObject
        {
            public override void Draw(Graphics myGp)
            {
                using (var pen = (Pen)myPen.Clone())
                {
                    myGp.DrawLine(pen, p1, p2);
                }

                if (IsSelected)
                {
                    DrawBoundingBox(myGp);
                }
            }
        }

        // Lớp con cho các đối tượng vẽ - Vẽ đường cong (clsCurve)
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
                    double t = (double)i / (numPoints - 1);
                    int px = x + (int)(t * width);
                    int py = y + (int)(height / 2 * Math.Sin(t * 2 * Math.PI) + height / 2);
                    points[i] = new Point(px, py);
                }

                using (var pen = (Pen)myPen.Clone())
                {
                    myGp.DrawCurve(pen, points);
                }

                if (IsSelected)
                {
                    DrawBoundingBox(myGp);
                }
            }
        }

        // Lớp con cho các đối tượng vẽ - Vẽ hình oval (clsOval)
        public class clsOval : clsDrawObject
        {
            public override void DrawFill(Graphics g)
            {
                if (FillColor.HasValue)
                {
                    int x = Math.Min(p1.X, p2.X);
                    int y = Math.Min(p1.Y, p2.Y);
                    int width = Math.Abs(p2.X - p1.X);
                    int height = Math.Abs(p2.Y - p1.Y);

                    using (Brush brush = new SolidBrush(FillColor.Value))
                    {
                        g.FillEllipse(brush, x, y, width, height);
                    }
                }
            }

            public override void Draw(Graphics myGp)
            {
                DrawFill(myGp);
                int x = Math.Min(this.p1.X, this.p2.X);
                int y = Math.Min(this.p1.Y, this.p2.Y);
                int width = Math.Abs(this.p2.X - this.p1.X);
                int height = Math.Abs(this.p2.Y - this.p1.Y);

                using (var pen = (Pen)myPen.Clone())
                {
                    myGp.DrawEllipse(pen, x, y, width, height);
                }

                if (IsSelected)
                {
                    DrawBoundingBox(myGp);
                }
            }
        }

        // Lớp con cho các đối tượng vẽ - Vẽ hình chữ nhật (clsRectangle)
        public class clsRectangle : clsDrawObject
        {
            public override void DrawFill(Graphics g)
            {
                if (FillColor.HasValue)
                {
                    int x = Math.Min(p1.X, p2.X);
                    int y = Math.Min(p1.Y, p2.Y);
                    int width = Math.Abs(p2.X - p1.X);
                    int height = Math.Abs(p2.Y - p1.Y);

                    using (Brush brush = new SolidBrush(FillColor.Value))
                    {
                        g.FillRectangle(brush, x, y, width, height);
                    }
                }
            }

            public override void Draw(Graphics g)
            {
                DrawFill(g);
                int x = Math.Min(p1.X, p2.X);
                int y = Math.Min(p1.Y, p2.Y);
                int width = Math.Abs(p2.X - p1.X);
                int height = Math.Abs(p2.Y - p1.Y);

                using (var pen = (Pen)myPen.Clone())
                {
                    g.DrawRectangle(pen, x, y, width, height);
                }
                if (IsSelected) DrawBoundingBox(g);
            }
        }

        // Lớp con cho các đối tượng vẽ - Vẽ hình tam giác (clsTriangle)
        public class clsTriangle : clsDrawObject
        {
            public override void DrawFill(Graphics g)
            {
                if (FillColor.HasValue)
                {
                    Point[] points = new Point[]
                    {
                    new Point(p1.X, p2.Y),
                    new Point(p2.X, p2.Y),
                    new Point((p1.X + p2.X) / 2, p1.Y)
                    };

                    using (Brush brush = new SolidBrush(FillColor.Value))
                    {
                        g.FillPolygon(brush, points);
                    }
                }
            }

            public override void Draw(Graphics myGp)
            {
                DrawFill(myGp);
                Point[] points = new Point[3];
                points[0] = new Point(p1.X, p2.Y);
                points[1] = new Point(p2.X, p2.Y);
                points[2] = new Point((p1.X + p2.X) / 2, p1.Y);

                using (var pen = (Pen)myPen.Clone())
                {
                    myGp.DrawPolygon(pen, points);
                }

                if (IsSelected)
                {
                    DrawBoundingBox(myGp);
                }
            }
        }

        // Lớp con cho các đối tượng vẽ - Vẽ hình thoi (clsDiamond)
        public class clsDiamond : clsDrawObject
        {
            public override void DrawFill(Graphics g)
            {
                if (FillColor.HasValue)
                {
                    Point[] points = new Point[]
                    {
                    new Point((p1.X + p2.X) / 2, p1.Y),
                    new Point(p2.X, (p1.Y + p2.Y) / 2),
                    new Point((p1.X + p2.X) / 2, p2.Y),
                    new Point(p1.X, (p1.Y + p2.Y) / 2)
                    };

                    using (Brush brush = new SolidBrush(FillColor.Value))
                    {
                        g.FillPolygon(brush, points);
                    }
                }
            }

            public override void Draw(Graphics myGp)
            {
                DrawFill(myGp);
                Point[] points = new Point[4];
                points[0] = new Point((p1.X + p2.X) / 2, p1.Y);
                points[1] = new Point(p2.X, (p1.Y + p2.Y) / 2);
                points[2] = new Point((p1.X + p2.X) / 2, p2.Y);
                points[3] = new Point(p1.X, (p1.Y + p2.Y) / 2);

                using (var pen = (Pen)myPen.Clone())
                {
                    myGp.DrawPolygon(pen, points);
                }

                if (IsSelected)
                {
                    DrawBoundingBox(myGp);
                }
            }
        }

        // Lớp con cho các đối tượng vẽ - Vẽ hình ngũ giác (clsPentagon)
        public class clsPentagon : clsDrawObject
        {
            public override void DrawFill(Graphics g)
            {
                if (FillColor.HasValue)
                {
                    int x = Math.Min(p1.X, p2.X);
                    int y = Math.Min(p1.Y, p2.Y);
                    int width = Math.Abs(p2.X - p1.X);
                    int height = Math.Abs(p2.Y - p1.Y);

                    Point[] points = new Point[]
                    {
                    new Point(x + width / 2, y),
                    new Point(x + width, y + height / 3),
                    new Point(x + 3 * width / 4, y + height),
                    new Point(x + width / 4, y + height),
                    new Point(x, y + height / 3)
                    };

                    using (Brush brush = new SolidBrush(FillColor.Value))
                    {
                        g.FillPolygon(brush, points);
                    }
                }
            }

            public override void Draw(Graphics myGp)
            {
                DrawFill(myGp);
                int x = Math.Min(p1.X, p2.X);
                int y = Math.Min(p1.Y, p2.Y);
                int width = Math.Abs(p2.X - p1.X);
                int height = Math.Abs(p2.Y - p1.Y);

                Point[] points = new Point[5];

                points[0] = new Point(x + width / 2, y);       
                points[1] = new Point(x + width, y + height / 3);    
                points[2] = new Point(x + 3 * width / 4, y + height);   
                points[3] = new Point(x + width / 4, y + height);
                points[4] = new Point(x, y + height / 3);

                using (var pen = (Pen)myPen.Clone())
                {
                    myGp.DrawPolygon(pen, points);
                }

                if (IsSelected)
                {
                    DrawBoundingBox(myGp);
                }
            }
        }

        // Lớp con cho các đối tượng vẽ - Vẽ hình lục giác (clsHexagon)
        public class clsHexagon : clsDrawObject
        {
            public override void DrawFill(Graphics g)
            {
                if (FillColor.HasValue)
                {
                    int x = Math.Min(p1.X, p2.X);
                    int y = Math.Min(p1.Y, p2.Y);
                    int width = Math.Abs(p2.X - p1.X);
                    int height = Math.Abs(p2.Y - p1.Y);

                    Point[] points = new Point[]
                    {
                    new Point(x + width / 4, y),
                    new Point(x + 3 * width / 4, y),
                    new Point(x + width, y + height / 2),
                    new Point(x + 3 * width / 4, y + height),
                    new Point(x + width / 4, y + height),
                    new Point(x, y + height / 2)
                    };

                    using (Brush brush = new SolidBrush(FillColor.Value))
                    {
                        g.FillPolygon(brush, points);
                    }
                }
            }

            public override void Draw(Graphics myGp)
            {
                DrawFill(myGp);
                int x = Math.Min(p1.X, p2.X);
                int y = Math.Min(p1.Y, p2.Y);
                int width = Math.Abs(p2.X - p1.X);
                int height = Math.Abs(p2.Y - p1.Y);

                Point[] points = new Point[6];

                points[0] = new Point(x + width / 4, y);
                points[1] = new Point(x + 3 * width / 4, y);
                points[2] = new Point(x + width, y + height / 2);
                points[3] = new Point(x + 3 * width / 4, y + height);
                points[4] = new Point(x + width / 4, y + height);
                points[5] = new Point(x, y + height / 2);

                using (var pen = (Pen)myPen.Clone())
                {
                    myGp.DrawPolygon(pen, points);
                }

                if (IsSelected)
                {
                    DrawBoundingBox(myGp);
                }
            }
        }

        // Lớp con cho các đối tượng vẽ - Vẽ hình ngôi sao (clsStar)
        public class clsStar : clsDrawObject
        {
            public override void DrawFill(Graphics g)
            {
                if (FillColor.HasValue)
                {
                    int x = Math.Min(p1.X, p2.X);
                    int y = Math.Min(p1.Y, p2.Y);
                    int width = Math.Abs(p2.X - p1.X);
                    int height = Math.Abs(p2.Y - p1.Y);

                    Point center = new Point(x + width / 2, y + height / 2);
                    float outerRadius = Math.Min(width, height) / 2f;
                    float innerRadius = outerRadius * 0.5f;

                    PointF[] points = new PointF[10];
                    for (int i = 0; i < 10; i++)
                    {
                        double angle = -Math.PI / 2 + i * Math.PI / 5;
                        float radius = (i % 2 == 0) ? outerRadius : innerRadius;

                        points[i] = new PointF(
                            center.X + (float)(radius * Math.Cos(angle)),
                            center.Y + (float)(radius * Math.Sin(angle))
                        );
                    }

                    using (Brush brush = new SolidBrush(FillColor.Value))
                    {
                        g.FillPolygon(brush, points);
                    }
                }
            }

            public override void Draw(Graphics myGp)
            {
                DrawFill(myGp);
                int x = Math.Min(p1.X, p2.X);
                int y = Math.Min(p1.Y, p2.Y);
                int width = Math.Abs(p2.X - p1.X);
                int height = Math.Abs(p2.Y - p1.Y);

                Point center = new Point(x + width / 2, y + height / 2);
                float outerRadius = Math.Min(width, height) / 2f;
                float innerRadius = outerRadius * 0.5f;

                PointF[] points = new PointF[10];
                for (int i = 0; i < 10; i++)
                {
                    double angle = -Math.PI / 2 + i * Math.PI / 5;
                    float radius = (i % 2 == 0) ? outerRadius : innerRadius;

                    points[i] = new PointF(
                        center.X + (float)(radius * Math.Cos(angle)),
                        center.Y + (float)(radius * Math.Sin(angle))
                    );
                }

                using (var pen = (Pen)myPen.Clone())
                {
                    myGp.DrawPolygon(pen, points);
                }

                if (IsSelected)
                {
                    DrawBoundingBox(myGp);
                }
            }
        }

        // Lớp con cho các đối tượng vẽ - Vẽ hình đa giác (clsPolygon)
        public class clsPolygon : clsDrawObject
        {
            public List<Point> Points { get; set; } = new List<Point>();

            public override void Draw(Graphics g)
            {
                if (Points.Count > 1)
                {
                    DrawFill(g);
                    using (var pen = (Pen)myPen.Clone())
                    {
                        g.DrawLines(pen, Points.ToArray());
                    }

                    if (IsSelected)
                    {
                        DrawBoundingBox(g);
                    }
                }
            }
            public override bool Contains(Point pt)
            {
                using (GraphicsPath path = new GraphicsPath())
                {
                    if (Points.Count > 2)
                    {
                        path.AddPolygon(Points.ToArray());
                        return path.IsVisible(pt);
                    }
                }
                return false;
            }

            public override void DrawFill(Graphics g)
            {
                if (FillColor.HasValue && Points.Count > 2)
                {
                    using (Brush b = new SolidBrush(FillColor.Value))
                    {
                        g.FillPolygon(b, Points.ToArray());
                    }
                }
            }

            public bool IsCloseToFirst(Point p)
            {
                if (Points.Count == 0) return false;

                Point first = Points[0];
                double distance = Math.Sqrt(Math.Pow(first.X - p.X, 2) + Math.Pow(first.Y - p.Y, 2));
                return distance < 10;
            }
            public void UpdateBounds()
            {
                if (Points.Count == 0) return;

                int minX = Points.Min(p => p.X);
                int minY = Points.Min(p => p.Y);
                int maxX = Points.Max(p => p.X);
                int maxY = Points.Max(p => p.Y);

                p1 = new Point(minX, minY);
                p2 = new Point(maxX, maxY);
            }
            public void ResizePolygon(Point oldP1, Point oldP2, Point newP1, Point newP2)
            {
                Rectangle oldRect = new Rectangle(
                    Math.Min(oldP1.X, oldP2.X),
                    Math.Min(oldP1.Y, oldP2.Y),
                    Math.Abs(oldP2.X - oldP1.X),
                    Math.Abs(oldP2.Y - oldP1.Y));

                Rectangle newRect = new Rectangle(
                    Math.Min(newP1.X, newP2.X),
                    Math.Min(newP1.Y, newP2.Y),
                    Math.Abs(newP2.X - newP1.X),
                    Math.Abs(newP2.Y - newP1.Y));

                float scaleX = (float)newRect.Width / oldRect.Width;
                float scaleY = (float)newRect.Height / oldRect.Height;

                for (int i = 0; i < Points.Count; i++)
                {
                    int relativeX = Points[i].X - oldRect.X;
                    int relativeY = Points[i].Y - oldRect.Y;

                    Points[i] = new Point(
                        (int)(relativeX * scaleX) + newRect.X,
                        (int)(relativeY * scaleY) + newRect.Y
                    );
                }

                UpdateBounds();
            }

        }

        // Lớp con cho các đối tượng vẽ - Vẽ bút chì (clsPencil)
        public class clsPencil : clsDrawObject
        {
            public List<Point> Points { get; set; } = new List<Point>();
            public override void Draw(Graphics g)
            {
                if (Points.Count > 1)
                {
                    using (var pen = (Pen)myPen.Clone())
                    {
                        g.DrawLines(pen, Points.ToArray());
                    }

                }
                else if (Points.Count == 1)
                {
                    float size = myPen.Width;
                    Point pt = Points[0];
                    g.FillEllipse(new SolidBrush(myPen.Color), pt.X - size / 2, pt.Y - size / 2, size, size);
                }
            }
        }

        // Lớp con cho các đối tượng vẽ - Vẽ brush (clsBrush)
        public class clsBrush : clsDrawObject
        {
            public List<Point> Points { get; set; } = new List<Point>();
            public override void Draw(Graphics g)
            {
                if (Points.Count > 1)
                {
                    using (Pen brushPen = new Pen(myPen.Color, 50))
                    {
                        brushPen.StartCap = brushPen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
                        brushPen.LineJoin = System.Drawing.Drawing2D.LineJoin.Round;
                        g.DrawLines(brushPen, Points.ToArray());
                    }
                }
            }
        }

        // Lớp con cho các đối tượng vẽ - Nhóm các đối tượng vẽ (clsGroupObject)
        public class clsGroupObject : clsDrawObject
        {
            public List<clsDrawObject> Children { get; set; } = new List<clsDrawObject>();
            public override void Draw(Graphics g)
            {
                foreach (var child in Children)
                {
                    child.Draw(g);
                }

                if (IsSelected)
                {
                    DrawBoundingBox(g);
                }
            }
            public override void DrawFill(Graphics g)
            {
                foreach (var child in Children)
                {
                    child.DrawFill(g);
                }
            }

            public override bool Contains(Point pt)
            {
                return Children.Any(child => child.Contains(pt));
            }

            public override void DrawBoundingBox(Graphics g)
            {
                if (Children.Count == 0) return;

                var allPoints = Children.SelectMany(o => new[] { o.p1, o.p2 }).ToList();
                int x1 = allPoints.Min(p => p.X);
                int y1 = allPoints.Min(p => p.Y);
                int x2 = allPoints.Max(p => p.X);
                int y2 = allPoints.Max(p => p.Y);

                p1 = new Point(x1, y1);
                p2 = new Point(x2, y2);
               
                if (g != null)
                {
                    base.DrawBoundingBox(g);
                }
            }
            public void UpdateBounds()
            {
                if (Children.Count == 0) return;

                var allPoints = Children.SelectMany(o => new[] { o.p1, o.p2 }).ToList();
                int x1 = allPoints.Min(p => p.X);
                int y1 = allPoints.Min(p => p.Y);
                int x2 = allPoints.Max(p => p.X);
                int y2 = allPoints.Max(p => p.Y);

                p1 = new Point(x1, y1);
                p2 = new Point(x2, y2);
            }
        }

        // Hàm dùng để xử lý nút trong clipboard
        private void clipboardButton_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            if (btn == btnNewFile) ToogleClipboard(ClipboardType.NewFile, btn);
            else if (btn == btnGroup) ToogleClipboard(ClipboardType.Group, btn);
            else if (btn == btnUngroup) ToogleClipboard(ClipboardType.Ungroup, btn);
        }

        // Hàm dùng để xử lý nút trong shapes
        private void shapeButton_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (btn != null)
            {
                if (btn == btnLine) ToggleShape(ShapeType.Line, btn);
                else if (btn == btnCurve) ToggleShape(ShapeType.Curve, btn);
                else if (btn == btnOval) ToggleShape(ShapeType.Oval, btn);
                else if (btn == btnRectangle) ToggleShape(ShapeType.Rectangle, btn);
                else if (btn == btnTriangle) ToggleShape(ShapeType.Triangle, btn);
                else if (btn == btnDiamond) ToggleShape(ShapeType.Diamond, btn);
                else if (btn == btnPentagon) ToggleShape(ShapeType.Pentagon, btn);
                else if (btn == btnHexagon) ToggleShape(ShapeType.Hexagon, btn);
                else if (btn == btnStar) ToggleShape(ShapeType.Star, btn);
                else if (btn == btnPolygon) ToggleShape(ShapeType.Polygon, btn);
            }
        }

        // Hàm dùng để xử lý nút trong tools
        private void toolButton_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            if (btn == btnPencil) ToggleTool(ToolType.Pencil, btn);
            else if (btn == btnEraser) ToggleTool(ToolType.Eraser, btn);
            else if (btn == btnFill) ToggleTool(ToolType.Fill, btn);
            else if (btn == btnBrush) ToggleTool(ToolType.Brush, btn);
        }

        // Hàm dùng để xử lý nút trong size
        private void sizeButton_Click(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                if (button.Tag?.ToString() == "dashed")
                {
                    myPen.DashStyle = DashStyle.Dash;
                }
                else if (int.TryParse(button.Tag?.ToString(), out int newSize))
                {
                    myWidth = newSize;
                    myPen = new Pen(myColor, myWidth);
                    myPen.DashStyle = DashStyle.Solid;
                }

                foreach (Control control in button.Parent.Controls)
                {
                    if (control is Button sizeButton)
                        sizeButton.BackColor = SystemColors.Control;
                }

                button.BackColor = Color.LightBlue;
            }
        }

        private void ToogleClipboard(ClipboardType type, Button clickedButton)
        {
            if (type == ClipboardType.NewFile)
            {
                lstObject.Clear();
                bitmapGraphics.Clear(Color.White);
                RedrawBitmap();
            }
            else if (type == ClipboardType.Group)
            {
                var selectedObjects = lstObject.Where(o => o.IsSelected).ToList();
                if (selectedObjects.Count >= 2)
                {
                    clsGroupObject newGroup = new clsGroupObject();

                    foreach (var obj in selectedObjects)
                    {
                        if (obj is clsGroupObject oldGroup)
                        {
                            foreach (var child in oldGroup.Children)
                                newGroup.Children.Add(child);
                        }
                        else newGroup.Children.Add(obj);
                        lstObject.Remove(obj);
                    }

                    foreach (var child in newGroup.Children)
                        child.IsSelected = false;

                    newGroup.IsSelected = true;
                    lstObject.Add(newGroup);
                    selectedObject = null;
                    justGrouped = true;

                    RedrawBitmap();
                }
            }
            else if (type == ClipboardType.Ungroup)
            {
                var selectedGroup = lstObject
                    .OfType<clsGroupObject>()
                    .FirstOrDefault(o => o.IsSelected);

                if (selectedGroup != null)
                {
                    lstObject.Remove(selectedGroup);
                    foreach (var child in selectedGroup.Children)
                    {
                        child.IsSelected = false;
                        lstObject.Add(child);
                    }

                    selectedObject = null;
                    RedrawBitmap();
                }
            }
        }


        // Dùng để thực hiện việc chọn các nút tool
        private void ToggleTool(ToolType tool, Button clickedButton)
        {
            if (currentTool == tool)
            {
                currentTool = ToolType.None;
                clickedButton.FlatStyle = FlatStyle.Standard;
                clickedButton.Font = new Font(clickedButton.Font, FontStyle.Regular);
                currentToolButton = null;
            }
            else
            {
                if (currentToolButton != null)
                {
                    currentToolButton.FlatStyle = FlatStyle.Standard;
                    currentToolButton.Font = new Font(currentToolButton.Font, FontStyle.Regular);
                }

                currentTool = tool;
                clickedButton.FlatStyle = FlatStyle.Flat;
                clickedButton.Font = new Font(clickedButton.Font, FontStyle.Bold);
                currentToolButton = clickedButton;

                currentShape = ShapeType.None;
                if (currentShapeButton != null)
                {
                    currentShapeButton.FlatStyle = FlatStyle.Standard;
                    currentShapeButton.Font = new Font(currentShapeButton.Font, FontStyle.Regular);
                    currentShapeButton = null;
                }
            }
        }

        // Dùng để thực hiện việc chọn các nút shape
        private void ToggleShape(ShapeType shape, Button clickedButton)
        {
            if (currentShape == shape)
            {
                currentShape = ShapeType.None;
                clickedButton.FlatStyle = FlatStyle.Standard;
                clickedButton.Font = new Font(clickedButton.Font, FontStyle.Regular);
                currentShapeButton = null;
            }
            else
            {
                if (currentShapeButton != null)
                {
                    currentShapeButton.FlatStyle = FlatStyle.Standard;
                    currentShapeButton.Font = new Font(currentShapeButton.Font, FontStyle.Regular);
                }

                currentShape = shape;
                clickedButton.FlatStyle = FlatStyle.Flat;
                clickedButton.Font = new Font(clickedButton.Font, FontStyle.Bold);
                currentShapeButton = clickedButton;

                currentTool = ToolType.None;
            }
        }

        // Dùng để thực hiện việc resize các đối tượng vẽ
        private bool IsResizing(Point mousePosition, clsDrawObject obj)
        {
            const int handleSize = 10;

            int x = Math.Min(obj.p1.X, obj.p2.X);
            int y = Math.Min(obj.p1.Y, obj.p2.Y);
            int width = Math.Abs(obj.p2.X - obj.p1.X);
            int height = Math.Abs(obj.p2.Y - obj.p1.Y);

            List<Rectangle> resizeHandles = new List<Rectangle>
            {
                new Rectangle(x - handleSize / 2, y - handleSize / 2, handleSize, handleSize),
                new Rectangle(x + width - handleSize / 2, y - handleSize / 2, handleSize, handleSize),
                new Rectangle(x - handleSize / 2, y + height - handleSize / 2, handleSize, handleSize),
                new Rectangle(x + width - handleSize / 2, y + height - handleSize / 2, handleSize, handleSize),

                new Rectangle(x + width / 2 - handleSize / 2, y - handleSize / 2, handleSize, handleSize),
                new Rectangle(x + width / 2 - handleSize / 2, y + height - handleSize / 2, handleSize, handleSize),
                new Rectangle(x - handleSize / 2, y + height / 2 - handleSize / 2, handleSize, handleSize),
                new Rectangle(x + width - handleSize / 2, y + height / 2 - handleSize / 2, handleSize, handleSize)
            };

            for (int i = 0; i < resizeHandles.Count; i++)
            {
                if (resizeHandles[i].Contains(mousePosition))
                {
                    resizingHandleIndex = i;
                    startMousePosition = mousePosition;
                    initialP1 = obj.p1;
                    initialP2 = obj.p2;
                    return true;
                }
            }
            resizingHandleIndex = -1;
            return false;
        }

        // Xử lý sự kiện chuột
        private void pbMain_MouseDown(object sender, MouseEventArgs e)
        {
            if (justGrouped)
            {
                justGrouped = false;
                isStart = false;
                isResizing = false;
                resizingHandleIndex = -1;
                selectedObject = null;
                lastMousePosition = Point.Empty;
                startMousePosition = Point.Empty;
                initialP1 = Point.Empty;
                initialP2 = Point.Empty;
                return;
            }

            if (currentTool != ToolType.None)
            {
                isStart = true;
                pencilPoints.Clear();
                pencilPoints.Add(e.Location);

                if (currentTool == ToolType.Pencil)
                {
                    lstObject.Add(new clsPencil { Points = new List<Point> { e.Location }, myPen = new Pen(myColor, myWidth) });
                    RedrawBitmap();
                }
                else if (currentTool == ToolType.Brush)
                {
                    lstObject.Add(new clsBrush { Points = new List<Point> { e.Location }, myPen = new Pen(myColor, 10) });
                }
                else if (currentTool == ToolType.Eraser)
                {
                    lstObject.Add(new clsPencil { Points = new List<Point> { e.Location }, myPen = new Pen(Color.White, 20) });
                    RedrawBitmap();
                }
                else if (currentTool == ToolType.Fill)
                {
                    foreach (var obj in lstObject.AsEnumerable().Reverse())
                    {
                        if (obj.Contains(e.Location))
                        {
                            obj.FillColor = myColor;
                            RedrawBitmap();
                            break;
                        }
                    }
                }

                if (isSelectingGroupArea)
                {
                    selectStart = selectEnd = e.Location;
                }

                return;
            }

            if (currentShape != ShapeType.None)
            {
                isStart = true;
                clsDrawObject newShape = null;

                switch (currentShape)
                {
                    case ShapeType.Line: newShape = new clsLine(); break;
                    case ShapeType.Curve: newShape = new clsCurve(); break;
                    case ShapeType.Oval: newShape = new clsOval(); break;
                    case ShapeType.Rectangle: newShape = new clsRectangle(); break;
                    case ShapeType.Triangle: newShape = new clsTriangle(); break;
                    case ShapeType.Diamond: newShape = new clsDiamond(); break;
                    case ShapeType.Pentagon: newShape = new clsPentagon(); break;
                    case ShapeType.Hexagon: newShape = new clsHexagon(); break;
                    case ShapeType.Star: newShape = new clsStar(); break;
                    case ShapeType.Polygon:
                        if (!isDrawingPolygon || currentFreePolygon == null)
                        {
                            currentFreePolygon = new clsPolygon { Points = new List<Point>(), myPen = (Pen)myPen.Clone() };
                            currentFreePolygon.Points.Add(e.Location);
                            isDrawingPolygon = true;
                        }
                        else if (currentFreePolygon.Points.Count >= 3 && currentFreePolygon.IsCloseToFirst(e.Location))
                        {
                            currentFreePolygon.Points.Add(currentFreePolygon.Points[0]);
                            currentFreePolygon.UpdateBounds();
                            lstObject.Add(currentFreePolygon);
                            currentFreePolygon = null;
                            isDrawingPolygon = false;
                        }
                        else
                        {
                            currentFreePolygon.Points.Add(e.Location);
                        }
                        RedrawBitmap();
                        return;
                }

                if (newShape != null)
                {
                    newShape.p1 = e.Location;
                    newShape.p2 = e.Location;
                    newShape.myPen = (Pen)myPen.Clone();
                    lstObject.Add(newShape);
                    selectedObject = newShape;
                    RedrawBitmap();
                }

                return;
            }

            bool clickedOnObject = false;
            for (int i = lstObject.Count - 1; i >= 0; i--)
            {
                var obj = lstObject[i];
                if (obj.Contains(e.Location))
                {
                    if (!obj.IsSelected)
                    {
                        if (!ModifierKeys.HasFlag(Keys.Shift))
                        {
                            foreach (var o in lstObject)
                                o.IsSelected = false;
                        }
                        obj.IsSelected = true;
                    }

                    selectedObject = obj;

                    if (IsResizing(e.Location, obj))
                    {
                        isResizing = true;
                        if (obj is clsGroupObject g)
                            g.UpdateBounds();

                        initialP1 = obj.p1;
                        initialP2 = obj.p2;
                        startMousePosition = e.Location;
                    }
                    else
                    {
                        isResizing = false;
                        lastMousePosition = e.Location;
                    }

                    clickedOnObject = true;
                    break;
                }
            }

            if (!clickedOnObject && !ModifierKeys.HasFlag(Keys.Shift))
            {
                foreach (var obj in lstObject)
                    obj.IsSelected = false;

                selectedObject = null;
            }

            if (lstObject.Count(o => o.IsSelected) > 1)
            {
                lastMousePosition = e.Location;
                selectedObject = lstObject.FirstOrDefault(o => o.IsSelected);
            }
            RedrawBitmap();
        }

        private void pbMain_MouseMove(object sender, MouseEventArgs e)
        {
            if (isStart)
            {
                if (currentTool == ToolType.Pencil || currentTool == ToolType.Eraser || currentTool == ToolType.Brush)
                {
                    pencilPoints.Add(e.Location);

                    if (lstObject.LastOrDefault() is clsPencil pencil &&
                        (currentTool == ToolType.Pencil || currentTool == ToolType.Eraser))
                    {
                        pencil.Points = new List<Point>(pencilPoints);
                    }
                    else if (lstObject.LastOrDefault() is clsBrush brush && currentTool == ToolType.Brush)
                    {
                        brush.Points = new List<Point>(pencilPoints);
                    }

                    RedrawBitmap();
                }
                else if (currentShape != ShapeType.None && currentShape != ShapeType.Polygon && lstObject.Count > 0)
                {
                    var lastObj = lstObject.LastOrDefault();
                    if (lastObj != null)
                    {
                        lastObj.p2 = e.Location;
                        RedrawBitmap();
                    }
                }
            }
            else if (isDrawingPolygon && currentFreePolygon != null)
            {
                RedrawBitmap();
                using (Graphics g = Graphics.FromImage(drawingBitmap))
                {
                    currentFreePolygon.Draw(g);
                    if (currentFreePolygon.Points.Count > 0)
                    {
                        g.DrawLine(myPen, currentFreePolygon.Points.Last(), e.Location);
                    }
                }
                pbMain.Invalidate();
            }
            else if (selectedObject != null)
            {
                if (isResizing)
                {
                    if (e.Location == startMousePosition) return;

                    Point delta = new Point(e.X - startMousePosition.X, e.Y - startMousePosition.Y);
                    Point p1 = initialP1;
                    Point p2 = initialP2;

                    switch (resizingHandleIndex)
                    {
                        case 0: p1.X += delta.X; p1.Y += delta.Y; break;
                        case 1: p2.X += delta.X; p1.Y += delta.Y; break;
                        case 2: p1.X += delta.X; p2.Y += delta.Y; break;
                        case 3: p2.X += delta.X; p2.Y += delta.Y; break;
                        case 4: p1.Y += delta.Y; break;
                        case 5: p2.Y += delta.Y; break;
                        case 6: p1.X += delta.X; break;
                        case 7: p2.X += delta.X; break;
                    }

                    if (selectedObject is clsPolygon polygon)
                    {
                        polygon.ResizePolygon(initialP1, initialP2, p1, p2);
                    }
                    else if (selectedObject is clsGroupObject group)
                    {
                        int oldWidth = Math.Abs(initialP2.X - initialP1.X);
                        int oldHeight = Math.Abs(initialP2.Y - initialP1.Y);
                        int newWidth = Math.Abs(p2.X - p1.X);
                        int newHeight = Math.Abs(p2.Y - p1.Y);

                        float scaleX = oldWidth > 0 ? (float)newWidth / oldWidth : 1f;
                        float scaleY = oldHeight > 0 ? (float)newHeight / oldHeight : 1f;

                        scaleX = Math.Max(0.1f, Math.Min(scaleX, 5f));
                        scaleY = Math.Max(0.1f, Math.Min(scaleY, 5f));

                        foreach (var child in group.Children)
                        {
                            child.p1 = new Point(
                                (int)((child.p1.X - initialP1.X) * scaleX + p1.X),
                                (int)((child.p1.Y - initialP1.Y) * scaleY + p1.Y));
                            child.p2 = new Point(
                                (int)((child.p2.X - initialP1.X) * scaleX + p1.X),
                                (int)((child.p2.Y - initialP1.Y) * scaleY + p1.Y));
                        }

                        group.UpdateBounds();
                    }
                    else
                    {
                        selectedObject.p1 = p1;
                        selectedObject.p2 = p2;
                    }

                    RedrawBitmap();
                }
                else
                {
                    int dx = e.X - lastMousePosition.X;
                    int dy = e.Y - lastMousePosition.Y;

                    foreach (var obj in lstObject.Where(o => o.IsSelected))
                    {
                        if (obj is clsPolygon polygon)
                        {
                            for (int i = 0; i < polygon.Points.Count; i++)
                            {
                                polygon.Points[i] = new Point(
                                    polygon.Points[i].X + dx,
                                    polygon.Points[i].Y + dy);
                            }
                            polygon.UpdateBounds();
                        }
                        else if (obj is clsGroupObject group)
                        {
                            foreach (var child in group.Children)
                            {
                                if (child is clsPolygon poly)
                                {
                                    for (int i = 0; i < poly.Points.Count; i++)
                                    {
                                        poly.Points[i] = new Point(
                                            poly.Points[i].X + dx,
                                            poly.Points[i].Y + dy);
                                    }
                                    poly.UpdateBounds();
                                }
                                else
                                {
                                    child.p1 = new Point(child.p1.X + dx, child.p1.Y + dy);
                                    child.p2 = new Point(child.p2.X + dx, child.p2.Y + dy);
                                }
                            }
                        }
                        else
                        {
                            obj.p1 = new Point(obj.p1.X + dx, obj.p1.Y + dy);
                            obj.p2 = new Point(obj.p2.X + dx, obj.p2.Y + dy);
                        }
                    }

                    lastMousePosition = e.Location;
                    RedrawBitmap();
                }
            }
        }


        private void pbMain_MouseUp(object sender, MouseEventArgs e)
        {
            if (currentTool == ToolType.Pencil)
            {
                if (lstObject.LastOrDefault() is clsPencil pencil)
                {
                    pencil.Points = new List<Point>(pencilPoints);
                }
            }
            else if (currentTool == ToolType.Brush)
            {
                if (lstObject.LastOrDefault() is clsBrush brush)
                {
                    brush.Points = new List<Point>(pencilPoints);
                }
            }
            else if (currentShape != ShapeType.None && currentShape != ShapeType.Polygon && lstObject.Count > 0)
            {
                var lastObj = lstObject.LastOrDefault();
                if (lastObj != null)
                {
                    lastObj.p2 = e.Location;
                }
            }
            isStart = false;
            isResizing = false;
            selectedObject = null;
            resizingHandleIndex = -1;
            RedrawBitmap();
        }

        // Dùng để vẽ trên pictureBox bằng bitmap
        private void RedrawBitmap()
        {
            if (drawingBitmap == null || bitmapGraphics == null) return;

            bitmapGraphics.Clear(Color.White);

            foreach (var obj in lstObject)
            {
                obj.Draw(bitmapGraphics);
                if (obj.IsSelected)
                {
                    obj.DrawBoundingBox(bitmapGraphics);
                }
            }

            if (isSelectingGroupArea && isStart)
            {
                int x = Math.Min(selectStart.X, selectEnd.X);
                int y = Math.Min(selectStart.Y, selectEnd.Y);
                int w = Math.Abs(selectEnd.X - selectStart.X);
                int h = Math.Abs(selectEnd.Y - selectStart.Y);

                if (w > 0 && h > 0)
                {
                    Rectangle rect = new Rectangle(x, y, w, h);
                    using (Pen dashed = new Pen(Color.Blue, 1))
                    {
                        dashed.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                        bitmapGraphics.DrawRectangle(dashed, rect);
                    }
                }
            }
            pbMain.Image = drawingBitmap;
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Delete && selectedObject != null)
            {
                // Remove the selected object from the list
                lstObject.Remove(selectedObject);
                selectedObject = null;

                // Redraw the canvas
                RedrawBitmap();
                return true; // Indicate that the key press was handled
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
