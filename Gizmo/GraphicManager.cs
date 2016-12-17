using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Gizmo
{
    /// <summary>
    /// 使用方法
    /// GraphicManager.GetInstance().DrawX();
    /// GraphicManager.GetInstance().DrawY();
    /// 使用EndDraw后将存下现在的状态作为初始状态
    /// GraphicManager.GetInstance().EndDraw();
    /// </summary>
    public class GraphicManager
    {
        //private static GraphicManager instance = null;
        private Bitmap originBmp = null;
        private Bitmap LastBmp = null;
        private Bitmap finishingBmp = null;
        private Graphics mainPictureGraphics = null;
        private int boxWidth;
        private int boxHeight;
        private int widthPerMesh;
        private int heightPerMesh;

        public int BoxWidth
        {
            get
            {
                return boxWidth;
            }
        }

        public int BoxHeight
        {
            get
            {
                return boxHeight;
            }
        }

        public int WidthPerMesh
        {
            get
            {
                return widthPerMesh;
            }
        }

        public int HeightPerMesh
        {
            get
            {
                return heightPerMesh;
            }
        }

        //private GraphicManager()
        //{
        //}

        ///// <summary>
        ///// use SetGraphics() after get instance
        ///// </summary>
        ///// <returns></returns>
        //public static GraphicManager GetInstance()
        //{
        //    if (instance == null)
        //    {
        //        instance = new GraphicManager();
        //    }
        //    return instance;
        //}

        public void SetGraphics(Graphics graphics, Bitmap bmp, int boxWidth, int boxHeight)
        {
            mainPictureGraphics = graphics;
            this.boxWidth = boxWidth;
            this.boxHeight = boxHeight;

            //初始化BMP
            {
                Graphics g = Graphics.FromImage(bmp);
                Pen p = new Pen(Setting.ColorLine);
                //画线使得总共有MaxMesh个网格
                for (int i = 0; i < Setting.MaxMesh; i++)
                {
                    int x = boxWidth * i / Setting.MaxMesh;
                    g.DrawLine(p, x, 0, x, boxHeight);
                    int y = boxHeight * i / Setting.MaxMesh;
                    g.DrawLine(p, 0, y, boxHeight, y);
                }
                g.DrawLine(p, boxWidth - 1, 0, boxWidth - 1, boxHeight);
                g.DrawLine(p, 0, boxHeight - 1, boxWidth, boxHeight - 1);
                g.Dispose();
                p.Dispose();
            }
            finishingBmp = (Bitmap)bmp.Clone();
            originBmp = (Bitmap)bmp.Clone();
            LastBmp = (Bitmap)bmp.Clone();

            widthPerMesh = boxWidth / Setting.MaxMesh;
            heightPerMesh = boxHeight / Setting.MaxMesh;
        }
        
        /// <summary>
        /// 画线
        /// </summary>
        /// <param name="x1">x1</param>
        /// <param name="y1">y1</param>
        /// <param name="x2">x2</param>
        /// <param name="y2">y2</param>
        public void MyDrawLine(float x1, float y1, float x2, float y2)
        {
            Graphics g = Graphics.FromImage(finishingBmp);
            Pen p = new Pen(Setting.ColorLine);
            g.DrawLine(p, x1, y1, x2, y2);
            g.Dispose();
            p.Dispose();
        }

        public void MyDrawPolygon(PointF[] points, int size)
        {
            Graphics g = Graphics.FromImage(finishingBmp);
            Color myColor = Setting.ColorPolygenFour;
            switch (points.Length)
            {
                case 3:
                    myColor = Setting.ColorPolygenThree;
                    break;
                case 4:
                    myColor = Setting.ColorPolygenFour;
                    break;
                default: break;
            }
            Pen p = new Pen(Setting.ColorPolygenFour);
            g.DrawPolygon(p, points);
            g.Dispose();
            p.Dispose();
        }

        /// <summary>
        /// 画椭圆，size为正整数
        /// </summary>
        /// <param name="size"></param>
        public void MyDrawFullCircle(PointF StartPoint, float radius)
        {
            Graphics g = Graphics.FromImage(finishingBmp);
            Brush b = new SolidBrush(Setting.ColorCircle);
            g.FillEllipse(b, StartPoint.X, StartPoint.Y, radius * 2, radius * 2);
            g.Dispose();
            b.Dispose();

            //Bitmap newBitmap = (Bitmap)LastBmp.Clone();
            //Graphics g = Graphics.FromImage(newBitmap);
            //Brush b = new SolidBrush(MyColor.ColorCircle);
            //g.FillEllipse(b, StartPoint.X, StartPoint.Y, widthPerMesh * size, HeightPerMesh * size);
            //g.Dispose();
            //b.Dispose();
            //g = Graphics.FromImage(finishingBmp);
            //g.DrawImage(newBitmap, new PointF(0, 0));
            //g.Dispose();
            //mainPictureGraphics.DrawImage(newBitmap, new PointF(0, 0));
            //newBitmap.Dispose();
        }

        public void MyDrawFullPolygon(PointF[] points, int size)
        {
            Graphics g = Graphics.FromImage(finishingBmp);
            Color myColor = Setting.ColorPolygenFour;
            switch (points.Length)
            {
                case 3:
                    myColor = Setting.ColorPolygenThree;
                    break;
                case 4:
                    myColor = Setting.ColorPolygenFour;
                    break;
                default: break;
            }
            Brush b = new SolidBrush(myColor);
            g.FillPolygon(b, points);
            g.Dispose();
            b.Dispose();

            //Bitmap newBitmap = (Bitmap)LastBmp.Clone();
            //Graphics g = Graphics.FromImage(newBitmap);
            //Color myColor = MyColor.ColorPolygenFour;
            //switch (points.Length)
            //{
            //    case 3:
            //        myColor = MyColor.ColorPolygenThree;
            //        break;
            //    case 4:
            //        myColor = MyColor.ColorPolygenFour;
            //        break;
            //    default: break;
            //}
            //Brush b = new SolidBrush(myColor);
            //g.FillPolygon(b, points);
            //g.Dispose();
            //b.Dispose();
            //g = Graphics.FromImage(finishingBmp);
            //g.DrawImage(newBitmap, new PointF(0, 0));
            //g.Dispose();
            //mainPictureGraphics.DrawImage(newBitmap, new PointF(0, 0));
            //newBitmap.Dispose();
        }

        /// <summary>
        /// 画正方形
        /// </summary>
        /// <param name="pointLeftUp">左上</param>
        /// <param name="pointRightUp">右下</param>
        /// <param name="pointRightDown">右下</param>
        /// <param name="pointLeftDown">左下</param>
        public void MyDrawFullSquare(PointF pointLeftUp, PointF pointRightUp, PointF pointRightDown, PointF pointLeftDown)
        {
            Graphics g = Graphics.FromImage(finishingBmp);
            Brush b = new SolidBrush(Setting.ColorPolygenThree);
            g.FillPolygon(b, new PointF[4] { pointLeftUp, pointRightUp, pointRightDown, pointLeftDown });
            g.Dispose();
            b.Dispose();
            //Bitmap newBitmap = (Bitmap)LastBmp.Clone();
            //Graphics g = Graphics.FromImage(newBitmap);
            //Brush b = new SolidBrush(MyColor.ColorPolygenFour);
            //g.FillPolygon(b, new PointF[4] { pointLeftUp, pointRightUp, pointRightDown, pointLeftDown });
            //g.Dispose();
            //b.Dispose();
            //g = Graphics.FromImage(finishingBmp);
            //g.DrawImage(newBitmap, new PointF(0, 0));
            //g.Dispose();
            //mainPictureGraphics.DrawImage(newBitmap, new PointF(0, 0));
            //newBitmap.Dispose();
        }

        /// <summary>
        /// 画直角三角形
        /// </summary>
        /// <param name="pointLeftUp">左上</param>
        /// <param name="pointRightDown">右下</param>
        /// <param name="pointLeftDown">左下</param>
        public void MyDrawFullRT(PointF pointLeftUp, PointF pointRightDown, PointF pointLeftDown)
        {
            Graphics g = Graphics.FromImage(finishingBmp);
            Brush b = new SolidBrush(Setting.ColorPolygenThree);
            g.FillPolygon(b, new PointF[3] { pointLeftUp, pointRightDown, pointLeftDown });
            g.Dispose();
            b.Dispose();
            //Bitmap newBitmap = (Bitmap)LastBmp.Clone();
            //Graphics g = Graphics.FromImage(newBitmap);
            //Brush b = new SolidBrush(MyColor.ColorPolygenThree);
            //g.FillPolygon(b, new PointF[3] { pointLeftUp, pointRightDown, pointLeftDown });
            //g.Dispose();
            //b.Dispose();
            //g = Graphics.FromImage(finishingBmp);
            //g.DrawImage(newBitmap, new PointF(0, 0));
            //g.Dispose();
            //mainPictureGraphics.DrawImage(newBitmap, new PointF(0, 0));
            //newBitmap.Dispose();
        }

        /// <summary>
        /// 画等腰梯形
        /// </summary>
        /// <param name="pointLeftUp">左上</param>
        /// <param name="pointRightUp">右上</param>
        /// <param name="pointRightDown">右下</param>
        /// <param name="pointLeftDown">左下</param>
        public void MyDrawFullIsoscelesTrapezoid(PointF pointLeftUp, PointF pointRightUp, PointF pointRightDown, PointF pointLeftDown)
        {
            MyDrawFullSquare(pointLeftUp, pointRightUp, pointRightDown, pointLeftDown);
        }

        /// <summary>
        /// 绘图完成后的保留操作
        /// </summary>
        public void EndDraw()
        {
            //为了让完成后的绘图过程保留下来，要将中间图片绘制到原始画布上
            Graphics tempGraphics = Graphics.FromImage(LastBmp);
            tempGraphics.DrawImage(finishingBmp, 0, 0);
            tempGraphics.Dispose();
            mainPictureGraphics.DrawImage(finishingBmp, new Point(0, 0));
        }

        /// <summary>
        /// 仅仅用于鼠标移动的绘制
        /// </summary>
        public void ShowMovingDraw()
        {
            mainPictureGraphics.DrawImage(finishingBmp, new Point(0, 0));
        }

        /// <summary>
        /// 清除用户生成内容，返回上一个状态
        /// </summary>
        public void ReturnToLastDraw()
        {
            Graphics g = Graphics.FromImage(finishingBmp);
            g.DrawImage(LastBmp, 0, 0);
            //mainPictureGraphics.DrawImage(LastBmp, 0, 0);
            //g.Clear(MyColor.ColorBackground);
            g.Dispose();
        }

        /// <summary>
        /// 清空用户生成内容，返回初始状态
        /// </summary>
        public void ClearAllDraw()
        {
            Graphics g = Graphics.FromImage(finishingBmp);
            g.DrawImage(originBmp, 0, 0);
            g = Graphics.FromImage(LastBmp);
            g.DrawImage(originBmp, 0, 0);
            //mainPictureGraphics.DrawImage(originBmp, 0, 0);
            //g.Clear(MyColor.ColorBackground);
            g.Dispose();
        }
    }
}