using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace MtcForTrainCrew
{
    public class RoundButton : Button
    {
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            GraphicsPath grPath = new GraphicsPath();
            grPath.AddEllipse(0, 0, ClientSize.Width, ClientSize.Height);
            this.Region = new System.Drawing.Region(grPath);
            base.OnPaint(e);
        }
    }
    public class TriangleButton : Button
    {
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            GraphicsPath grPath = new GraphicsPath();
            PointF[] drawPoint = new PointF[3];
            switch (TRIANGLE_DIRECTION)
            {
                case TriangleDirection.Up:
                    drawPoint[0] = new PointF(ClientSize.Width / 2.0f, 0); //上
                    drawPoint[1] = new PointF(ClientSize.Width, ClientSize.Height); //右下
                    drawPoint[2] = new PointF(0, ClientSize.Height); //左下
                    break;
                case TriangleDirection.Down:
                    drawPoint[0] = new PointF(0, 0); //左上
                    drawPoint[1] = new PointF(ClientSize.Width, 0); //右上
                    drawPoint[2] = new PointF(ClientSize.Width / 2.0f, ClientSize.Height); //下
                    break;
                case TriangleDirection.Left:
                    drawPoint[0] = new PointF(ClientSize.Width, 0); //右上
                    drawPoint[1] = new PointF(ClientSize.Width, ClientSize.Height); //右下
                    drawPoint[2] = new PointF(0, ClientSize.Height / 2.0f); //左
                    break;
                case TriangleDirection.Right:
                    drawPoint[0] = new PointF(0, 0); //左上
                    drawPoint[1] = new PointF(ClientSize.Width, ClientSize.Height / 2.0f); //右
                    drawPoint[2] = new PointF(0, ClientSize.Height); //左下
                    break;
            }
            grPath.AddPolygon(drawPoint);
            this.Region = new System.Drawing.Region(grPath);
            base.OnPaint(e);


        }

        //三角形の方向指定用列挙体
        public enum TriangleDirection
        {
            Up = 1,
            Down = 2,
            Left = 4,
            Right = 8,
        }

        //三角形の方向指定プロパティ
        private TriangleDirection TRIANGLE_DIRECTION = TriangleDirection.Left;
        public TriangleDirection Direction
        {
            get { return this.TRIANGLE_DIRECTION; }
            set
            {
                this.TRIANGLE_DIRECTION = value;
                this.Invalidate();
            }
        }
        //三角形の塗りつぶし色プロパティ
        private Color TRIANGLE_COLOR = System.Drawing.SystemColors.ControlText;
        public Color TriangleColor
        {
            get { return this.TRIANGLE_COLOR; }
            set
            {
                this.TRIANGLE_COLOR = value;
                this.Invalidate();
            }
        }
    }
}
