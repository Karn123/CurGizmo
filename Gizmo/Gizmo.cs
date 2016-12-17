using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gizmo
{
    [Serializable]
    public class MyGizmo
    {
        /// <summary>
        /// 是否有碰撞位移
        /// </summary>
        public bool Moveable;
        public Rotation rotation;
        public MyShape shape;
        public int size;
        /// <summary>
        ///占据方块的四个顶点
        /// </summary>
        public Point pointLeftUp;
        public Point pointRightUp;
        public Point pointRightDown;
        public Point pointLeftDown;
        public bool isRail;
        /// <summary>
        /// 所占的方格坐标
        /// </summary>
        public Point[] coverIndex;
        /// <summary>
        /// 绘制该gizmo的颜色
        /// </summary>
        public Color myColor;
        public MyGizmo()
        {
            size = GameManager.GetInstance().Size;
            isRail = false;
        }
        /// <summary>
        /// 获得所占方块的四个顶点坐标
        /// </summary>
        /// <param name="position">鼠标点击位置</param>
        public void GetPointForDrawing(Point position)
        {
            int widthPerMesh = GameManager.GetInstance().GraphicManager.WidthPerMesh;
            int HeightPerMesh = GameManager.GetInstance().GraphicManager.HeightPerMesh;
            pointLeftUp = new Point(position.X / widthPerMesh, position.Y / HeightPerMesh);
            pointRightUp = new Point((pointLeftUp.X + size) * widthPerMesh, pointLeftUp.Y * HeightPerMesh);
            pointLeftDown = new Point(pointLeftUp.X * widthPerMesh, (pointLeftUp.Y + size) * HeightPerMesh);
            pointRightDown = new Point((pointLeftUp.X + size) * widthPerMesh, (pointLeftUp.Y + size) * HeightPerMesh);
            pointLeftUp.X = pointLeftUp.X * widthPerMesh;
            pointLeftUp.Y = pointLeftUp.Y * HeightPerMesh;
        }
        /// <summary>
        /// 第一次创建，画图
        /// </summary>
        /// <param name="position">鼠标点击位置</param>
        public virtual void draw(Point position)
        {
            GetPointForDrawing(position);
        }
        /// <summary>
        /// 重绘已保存的gizmo
        /// </summary>
        public virtual void draw()
        {
        }
        /// <summary>
        /// 逆时针旋转90度
        /// </summary>
        public virtual void rotateLeft()
        {
            Point f1 = new Point(pointLeftUp.X, pointLeftUp.Y);
            pointLeftUp = new Point(pointLeftDown.X, pointLeftDown.Y);
            pointLeftDown = new Point(pointRightDown.X, pointRightDown.Y);
            pointRightDown = new Point(pointRightUp.X, pointRightUp.Y);
            pointRightUp = new Point(f1.X, f1.Y);
        }
        /// <summary>
        /// 顺时针旋转90度
        /// </summary>
        public virtual void rotateRight()
        {
            Point f1 = new Point(pointLeftUp.X, pointLeftUp.Y);
            pointLeftUp = new Point(pointRightUp.X, pointRightUp.Y);
            pointRightUp = new Point(pointRightDown.X, pointRightDown.Y);
            pointRightDown = new Point(pointLeftDown.X, pointLeftDown.Y);
            pointLeftDown = new Point(f1.X, f1.Y);
        }
    }
    [Serializable]
    public abstract class NormalShape : MyGizmo
    {

    }
    /// <summary>
    /// 小球
    /// </summary>
    [Serializable]
    public class Ball : MyGizmo
    {
        private PointF center;
        private float radius;
        public Ball()
        {
            shape = MyShape.BallShape;
            Moveable = true;
            size = MySize.sizeX1;
        }
        public PointF Center
        {
            get
            {
                return center;
            }

            set
            {
                center = value;
            }
        }

        public float Radius
        {
            get
            {
                return radius;
            }

            set
            {
                radius = value;
            }
        }
        public override void draw(Point position)
        {
            base.draw(position);
            int widAdd = size * GameManager.GetInstance().GraphicManager.WidthPerMesh / 2;
            int heiAdd = size * GameManager.GetInstance().GraphicManager.HeightPerMesh / 2;
            center = new PointF(pointLeftUp.X + widAdd, pointLeftUp.Y + heiAdd);
            radius = (float)size * GameManager.GetInstance().GraphicManager.WidthPerMesh / 4;
            draw();
        }
        public override void draw()
        {
            PointF pointF = new PointF(pointLeftUp.X + (float)size * GameManager.GetInstance().GraphicManager.WidthPerMesh / 4,
                pointLeftUp.Y + (float)size * GameManager.GetInstance().GraphicManager.WidthPerMesh / 4);
            GameManager.GetInstance().GraphicManager.MyDrawFullCircle(pointF, this.radius);
        }
        public override void rotateLeft()
        {
            
        }
        public override void rotateRight()
        {
            
        }
    }
    [Serializable]
    public class Flipper : MyGizmo
    {
        private PointF[] points;
        public Flipper()
        {
            shape = MyShape.FlipperShape;
            Points = new PointF[4];
            rotation = Rotation.Left;
            Moveable = false;
        }
        public PointF[] Points
        {
            get
            {
                return points;
            }

            set
            {
                points = value;
            }
        }
        public override void draw(Point position)
        {
            base.draw(position);
            float quart = (float)size * 3 * GameManager.GetInstance().GraphicManager.WidthPerMesh / 4;
            Points[0] = new PointF(pointLeftUp.X + quart, pointLeftUp.Y);
            Points[1] = new PointF(pointRightUp.X, pointRightUp.Y);
            Points[2] = new PointF(pointRightDown.X, pointRightDown.Y);
            Points[3] = new PointF(pointLeftDown.X + quart, pointLeftDown.Y);
            draw();
        }
        
        public override void draw()
        {
            GameManager.GetInstance().GraphicManager.MyDrawFullPolygon(new PointF[] { Points[0], Points[1], Points[2], Points[3] }, size);
        }

        public override void rotateLeft()
        {
            
        }

        public override void rotateRight()
        {
            
        }
    }
    [Serializable]
    public class Flipper1 : MyGizmo
    {
        private PointF[] points;
        public Flipper1()
        {
            shape = MyShape.FlipperShape1;
            Points = new PointF[4];
            rotation = Rotation.Right;
            Moveable = false;
        }
        public PointF[] Points
        {
            get
            {
                return points;
            }

            set
            {
                points = value;
            }
        }
        public override void draw(Point position)
        {
            base.draw(position);
            float quart = (float)size * 3 * GameManager.GetInstance().GraphicManager.WidthPerMesh / 4;
            Points[0] = new PointF(pointLeftUp.X, pointLeftUp.Y);
            Points[1] = new PointF(pointRightUp.X - quart, pointRightUp.Y);
            Points[2] = new PointF(pointRightDown.X - quart, pointRightDown.Y);
            Points[3] = new PointF(pointLeftDown.X, pointLeftDown.Y);
            draw();
        }

        public override void draw()
        {
            GameManager.GetInstance().GraphicManager.MyDrawFullPolygon(new PointF[] { Points[0], Points[1], Points[2], Points[3] }, size);
        }

        public override void rotateLeft()
        {

        }

        public override void rotateRight()
        {

        }
    }

    [Serializable]
    public class FlipperBias : MyGizmo
    {
        private PointF[] points;
        public FlipperBias()
        {
            shape = MyShape.FlipperBiasShape;
            Points = new PointF[4];
            Moveable = false;
            rotation = Rotation.Left;
        }
        public PointF[] Points
        {
            get
            {
                return points;
            }

            set
            {
                points = value;
            }
        }
        public override void draw(Point position)
        {
            base.draw(position);
            float inc = (float)size * 3 * GameManager.GetInstance().GraphicManager.WidthPerMesh / 4;
            Points[0] = new PointF(pointLeftUp.X, pointLeftUp.Y + inc);
            Points[1] = new PointF(pointRightUp.X -  inc/(float)3, pointRightUp.Y);
            Points[2] = new PointF(pointRightDown.X, pointRightDown.Y -  inc);
            Points[3] = new PointF(pointLeftDown.X +  inc/(float)3, pointLeftDown.Y);
            draw();
        }
        public override void draw()
        {
            GameManager.GetInstance().GraphicManager.MyDrawFullPolygon(new PointF[] { Points[0], Points[1], Points[2], Points[3] }, size);
        }
        public override void rotateLeft()
        {
        }

        public override void rotateRight()
        {
        }
    }

    [Serializable]
    public class FlipperBias1 : MyGizmo
    {
        private PointF[] points;
        public FlipperBias1()
        {
            shape = MyShape.FlipperBiasShape1;
            Points = new PointF[4];
            Moveable = false;
            rotation = Rotation.Right;
        }
        public PointF[] Points
        {
            get
            {
                return points;
            }

            set
            {
                points = value;
            }
        }
        public override void draw(Point position)
        {
            base.draw(position);
            float inc = (float)size *3*GameManager.GetInstance().GraphicManager.WidthPerMesh / 4;
            Points[0] = new PointF(pointLeftUp.X, pointLeftUp.Y +  inc/(float)3);
            Points[1] = new PointF(pointRightUp.X - inc, pointRightUp.Y);
            Points[2] = new PointF(pointRightDown.X, pointRightDown.Y -  inc/(float)3);
            Points[3] = new PointF(pointLeftDown.X + inc, pointLeftDown.Y);
            draw();
        }
        public override void draw()
        {
            GameManager.GetInstance().GraphicManager.MyDrawFullPolygon(new PointF[] { Points[0], Points[1], Points[2], Points[3] }, size);
        }
        public override void rotateLeft()
        {
        }

        public override void rotateRight()
        {
        }
    }

    [Serializable]
    /// <summary>
    /// 轨道
    /// </summary>
    public class Rail : MyGizmo
    {
        public Rail()
        {
            shape = MyShape.RailShape;
            Moveable = false;
        }
    }
    /// <summary>
    /// 吸收器
    /// </summary>
    [Serializable]
    public class Absorption : MyGizmo
    {
        private PointF[] points;
        private int rotateLeftTime;
        private int rotateRightTime;
        public Absorption()
        {
            shape = MyShape.AbsorptionShape;
            Points = new PointF[4];
            Moveable = false;
            rotateLeftTime = 0;
            rotateRightTime = 0;
        }
        public PointF[] Points
        {
            get
            {
                return points;
            }

            set
            {
                points = value;
            }
        }
        public override void draw(Point position)
        {
            base.draw(position);
            float shift = size * 5 * GameManager.GetInstance().GraphicManager.WidthPerMesh / 12;

            Points[0] = new PointF(pointLeftUp.X , pointLeftUp.Y + shift);
            Points[1] = new PointF(pointRightUp.X, pointRightUp.Y + shift);
            Points[2] = new PointF(pointRightDown.X, pointRightDown.Y - shift);
            Points[3] = new PointF(pointLeftDown.X, pointLeftDown.Y - shift);
            draw();
        }

        public override void draw()
        {
            GameManager.GetInstance().GraphicManager.MyDrawFullPolygon(new PointF[] { Points[0], Points[1], Points[2], Points[3] }, size);
        }

        public override void rotateLeft()
        {
            base.rotateLeft();
            float shift = size * 5 * GameManager.GetInstance().GraphicManager.WidthPerMesh / 12;
            switch(rotateLeftTime%4)
            {
                case 0:
                    Points[0] = new PointF(pointLeftUp.X + shift, pointLeftUp.Y);
                    Points[1] = new PointF(pointRightUp.X + shift, pointRightUp.Y);
                    Points[2] = new PointF(pointRightDown.X - shift, pointRightDown.Y);
                    Points[3] = new PointF(pointLeftDown.X - shift, pointLeftDown.Y);
                    break;
                case 1:
                    Points[0] = new PointF(pointLeftUp.X , pointLeftUp.Y - shift);
                    Points[1] = new PointF(pointRightUp.X , pointRightUp.Y- shift);
                    Points[2] = new PointF(pointRightDown.X, pointRightDown.Y + shift);
                    Points[3] = new PointF(pointLeftDown.X , pointLeftDown.Y +shift);
                    break;
                case 2:
                    Points[0] = new PointF(pointLeftUp.X - shift, pointLeftUp.Y);
                    Points[1] = new PointF(pointRightUp.X - shift, pointRightUp.Y);
                    Points[2] = new PointF(pointRightDown.X + shift, pointRightDown.Y);
                    Points[3] = new PointF(pointLeftDown.X + shift, pointLeftDown.Y);
                    break;
                case 3:
                    Points[0] = new PointF(pointLeftUp.X , pointLeftUp.Y + shift);
                    Points[1] = new PointF(pointRightUp.X , pointRightUp.Y + shift);
                    Points[2] = new PointF(pointRightDown.X , pointRightDown.Y - shift);
                    Points[3] = new PointF(pointLeftDown.X , pointLeftDown.Y - shift);
                    break;
                default:break;
            }
            rotateLeftTime++;
            rotateRightTime += 3;
        }

        public override void rotateRight()
        {
            base.rotateRight();
            float shift = size * 5 * GameManager.GetInstance().GraphicManager.WidthPerMesh / 12;
            switch (rotateRightTime % 4)
            {
                case 0:
                    Points[0] = new PointF(pointLeftUp.X - shift, pointLeftUp.Y);
                    Points[1] = new PointF(pointRightUp.X - shift, pointRightUp.Y);
                    Points[2] = new PointF(pointRightDown.X + shift, pointRightDown.Y );
                    Points[3] = new PointF(pointLeftDown.X + shift, pointLeftDown.Y );
                    break;
                case 1:
                    Points[0] = new PointF(pointLeftUp.X, pointLeftUp.Y - shift);
                    Points[1] = new PointF(pointRightUp.X, pointRightUp.Y - shift);
                    Points[2] = new PointF(pointRightDown.X, pointRightDown.Y + shift);
                    Points[3] = new PointF(pointLeftDown.X, pointLeftDown.Y + shift);
                    break;
                case 2:
                    Points[0] = new PointF(pointLeftUp.X + shift, pointLeftUp.Y);
                    Points[1] = new PointF(pointRightUp.X + shift, pointRightUp.Y);
                    Points[2] = new PointF(pointRightDown.X - shift, pointRightDown.Y);
                    Points[3] = new PointF(pointLeftDown.X - shift, pointLeftDown.Y);
                    break;
                case 3:
                    Points[0] = new PointF(pointLeftUp.X, pointLeftUp.Y + shift);
                    Points[1] = new PointF(pointRightUp.X, pointRightUp.Y + shift);
                    Points[2] = new PointF(pointRightDown.X, pointRightDown.Y - shift);
                    Points[3] = new PointF(pointLeftDown.X, pointLeftDown.Y - shift);
                    break;
                default: break;
            }
            rotateRightTime++;
            rotateLeftTime += 3;
        }
    }
    [Serializable]
    public class Wall : MyGizmo
    {
        public Wall()
        {
            shape = MyShape.WallShape;
            Moveable = false;
        }
    }
    /// <summary>
    /// 正方形
    /// </summary>
    [Serializable]
    public class Square : NormalShape
    {
        private PointF[] points;
        public PointF[] Points
        {
            get
            {
                return points;
            }

            set
            {
                points = value;
            }
        }

        public Square()
        {
            shape = MyShape.SquareShape;
            Moveable = true;
            Points = new PointF[4];
        }
        public override void draw(Point position)
        {
            base.draw(position);
            Points[0] = new PointF(pointLeftUp.X, pointLeftUp.Y);
            Points[1] = new PointF(pointRightUp.X, pointRightUp.Y);
            Points[2] = new PointF(pointRightDown.X, pointRightDown.Y);
            Points[3] = new PointF(pointLeftDown.X, pointLeftDown.Y);
            draw();
        }
        public override void draw()
        {
            GameManager.GetInstance().GraphicManager.MyDrawFullPolygon(new PointF[] { Points[0], Points[1], Points[2], Points[3] }, size);
        }
        public override void rotateLeft()
        {
            
        }

        public override void rotateRight()
        {
            
        }
    }
    /// <summary>
    /// 圆形
    /// </summary>
    [Serializable]
    public class Circle : NormalShape
    {
        private PointF center;
        private float radius;

        public PointF Center
        {
            get
            {
                return center;
            }

            set
            {
                center = value;
            }
        }

        public float Radius
        {
            get
            {
                return radius;
            }

            set
            {
                radius = value;
            }
        }

        public Circle()
        {
            shape = MyShape.CircleShape;
            Moveable = true;
        }
        public override void draw(Point position)
        {
            base.draw(position);
            int widAdd =size * GameManager.GetInstance().GraphicManager.WidthPerMesh / 2;
            int heiAdd =size * GameManager.GetInstance().GraphicManager.HeightPerMesh / 2;
            center = new PointF(pointLeftUp.X + widAdd, pointLeftUp.Y + heiAdd);
            radius = size * GameManager.GetInstance().GraphicManager.WidthPerMesh / 2;
            draw();
        }
        public override void draw()
        {
            GameManager.GetInstance().GraphicManager.MyDrawFullCircle(pointLeftUp, radius);
        }
        public override void rotateLeft()
        {
            
        }

        public override void rotateRight()
        {
            
        }
    }
    /// <summary>
    /// 直角三角形
    /// </summary>
    [Serializable]
    public class RT : NormalShape
    {
        private PointF[] points;

        public PointF[] Points
        {
            get
            {
                return points;
            }

            set
            {
                points = value;
            }
        }

        public RT()
        {
            shape = MyShape.RTShape;
            Moveable = true;
            Points = new PointF[3];
        }
        public override void draw(Point position)
        {
            base.draw(position);
            Points[0] = new PointF(pointLeftUp.X,pointLeftUp.Y);
            Points[1] = new PointF(pointRightDown.X, pointRightDown.Y);
            Points[2] = new PointF(pointLeftDown.X, pointLeftDown.Y);
            draw();
        }
        public void assignPoints()
        {
            Points[0] = pointLeftUp;
            Points[1] = pointRightDown;
            Points[2] = pointLeftDown;
        }
        public override void draw()
        {
            GameManager.GetInstance().GraphicManager.MyDrawFullPolygon(new PointF[] { Points[0], Points[1], Points[2] }, size);
        }
        public override void rotateLeft()
        {
            base.rotateLeft();
            assignPoints();
        }
        public override void rotateRight()
        {
            base.rotateRight();
            assignPoints();
        }
    }
    /// <summary>
    /// 等腰梯形
    /// </summary>
    [Serializable]
    public class IsoscelesTrapezoid : NormalShape
    {
        private PointF[] points;
        private int rotateLeftTime;
        private int rotateRightTime;
        public PointF[] Points
        {
            get
            {
                return points;
            }

            set
            {
                points = value;
            }
        }
        public IsoscelesTrapezoid()
        {
            shape = MyShape.IsoscelesTrapezoidShape;
            Moveable = true;
            Points = new PointF[4];
            rotateLeftTime = 0;
            rotateRightTime = 0;
        }
        
        public override void draw(Point position)
        {
            base.draw(position);
            Points[0] = new PointF(pointLeftUp.X + size * GameManager.GetInstance().GraphicManager.WidthPerMesh / 3, pointLeftUp.Y);
            Points[1] = new PointF(pointRightUp.X - size * GameManager.GetInstance().GraphicManager.WidthPerMesh / 3, pointRightUp.Y);
            Points[2] = new PointF(pointRightDown.X, pointRightDown.Y);
            Points[3] = new PointF(pointLeftDown.X, pointLeftDown.Y);
            draw();
        }

        public void assignPoints()
        {
            Points[0] = pointLeftUp;
            Points[1] = pointRightUp;
            Points[2] = pointRightDown;
            Points[3] = pointLeftDown;
        }
        public override void draw()
        {
            GameManager.GetInstance().GraphicManager.MyDrawFullPolygon(new PointF[] { Points[0], Points[1], Points[2], Points[3] }, size);
        }
        public override void rotateLeft()
        {
            base.rotateLeft();
            assignPoints();
            float shift = size * GameManager.GetInstance().GraphicManager.WidthPerMesh / 3;
            switch(rotateLeftTime%4)
            {
                case 0:
                    Points[0].Y = pointLeftUp.Y - shift;
                    Points[1].Y = pointRightUp.Y + shift;
                    break;
                case 1:
                    Points[0].X = pointLeftUp.X - shift;
                    Points[1].X = pointRightUp.X + shift;
                    break;
                case 2:
                    Points[0].Y = pointLeftUp.Y + shift;
                    Points[1].Y = pointRightUp.Y - shift;
                    break;
                case 3:
                    Points[0].X = pointLeftUp.X + shift;
                    Points[1].X = pointRightUp.X - shift;
                    break;
                default:break;
            }
            rotateLeftTime++;
            rotateRightTime += 3;
        }
        public override void rotateRight()
        {
            base.rotateRight();
            assignPoints();
            float shift = size * GameManager.GetInstance().GraphicManager.WidthPerMesh / 3;
            switch (rotateRightTime % 4)
            {
                case 0:
                    Points[0].Y = pointLeftUp.Y + shift;
                    Points[1].Y = pointRightUp.Y - shift;
                    break;
                case 1:
                    Points[0].X = pointLeftUp.X - shift;
                    Points[1].X = pointRightUp.X + shift;
                    break;
                case 2:
                    Points[0].Y = pointLeftUp.Y - shift;
                    Points[1].Y = pointRightUp.Y + shift;
                    break;
                case 3:
                    Points[0].X = pointLeftUp.X + shift;
                    Points[1].X = pointRightUp.X -  shift;
                    break;
                default: break;
            }
            rotateRightTime++;
            rotateLeftTime += 3;
        }
    }
}