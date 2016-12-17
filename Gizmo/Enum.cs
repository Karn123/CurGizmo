using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Gizmo
{
    public enum Model { Running, Building };
    public enum SceneFunction { NewScene, LoadScene, SaveScene }
    public enum GizmoFunction { AddGizmo, OnlyDraw, NULL }
    //public enum Rotation { Angle0, Angle90, Angle180, Angle270 }
    public enum MyShape { BallShape, RailShape, AbsorptionShape, WallShape, SquareShape, CircleShape, RTShape, IsoscelesTrapezoidShape, NULL, FlipperShape,FlipperBiasShape,FlipperShape1,FlipperBiasShape1};
    public enum Rotation { Left,Right,NULL }
    public enum RailDirection { Left, Right, NULL }
    public struct MySize
    {
        public static int sizeX1 = 1;
        public static int sizeX2 = 2;
        public static int sizeX3 = 3;
        public static int sizeX4 = 4;
    }
    public class MyColor
    {
        public static Color ColorLine = Color.Silver;
        public static Color ColorBackground= Color.Black;

        public static Color ColorBall = Color.White;
        public static Color Colorflipper = Color.White;
        public static Color ColorRail = Color.White;
        public static Color ColorAbsorption = Color.White;
        public static Color ColorWall = Color.White;

        public static Color ColorPolygenThree = Color.Yellow;
        public static Color ColorCircle = Color.LightBlue;
        public static Color ColorPolygenFour= Color.Red;
    }

    public class MyConst
    {
        //网格大小
        public static readonly int MaxMesh = 20;
        //物体密度
        public static readonly float Density = 1f;
        //物体摩擦力
        public static readonly float Friction = 10f;
        //重力X分量
        public static readonly float GravityX = 0f; 
        //重力Y分量
        public static readonly float GravityY = 100f;
        //额外添加的重力Y分量
        public static readonly float MoreGravityY = 1000000f;
        //物体反弹力
        public static readonly float Restitution = 5f;
        //平衡重力的力
        public static readonly float Force = 100f;
        //PI
        public static readonly float PI = 3.1415926f;
        //物理世界和显示世界间的倍数转换参数 （物理 *  smallerTimes = 显示）
        public static readonly float SmallerTimes = 10f;
        //旋转关节的大小
        public static readonly float JointRadius = 1f;
        //在轨道上受到的力
        public static readonly float RailForce = 50f;
        //是否允许gizmo与gizmo的碰撞产生移动
        public static readonly bool AllowCollisionTwice = false;
        //轨道移动方向，true为右，false为左
        public static readonly bool RailDirection = false;

    }
}