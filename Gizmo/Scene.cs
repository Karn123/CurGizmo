using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gizmo
{
    [Serializable]
    class Scene
    {
        public Area area;
        public Setting setting;

        public Scene()
        {
            area = new Area();
            setting = new Setting();
        }
        public void SetGizmoInArea(MyGizmo gizmo, int x, int y)
        {
            area.addGizmoInArea(gizmo, x, y);
        }
        public void SetSetting(Setting setting)
        {

        }
        public void ClearScene()
        {
            area.AreaGizmoList.Clear();
            for(int i= 0;i < Setting.MaxMesh; i++)
            {
                for (int j = 0; j < Setting.MaxMesh; j++)
                {
                    area.IsHavingGizmo[i, j] = false;
                }
            }
            setting.KeyToFunctionHashtableClear();
        }
    }
    [Serializable]
    class Area
    {
        /// <summary>
        /// 记录区域中的物体
        /// </summary>
        private List<MyGizmo> areaGizmoList;
        private bool[,] isHavingGizmo;
        public Area()
        {
            areaGizmoList = new List<MyGizmo>();
            IsHavingGizmo = new bool[Setting.MaxMesh, Setting.MaxMesh];
            for (int i = 0; i < Setting.MaxMesh; i++)
                for (int j = 0; j < Setting.MaxMesh; j++)
                {
                    IsHavingGizmo[i, j] = false;
                }
        }

        public List<MyGizmo> AreaGizmoList
        {
            get
            {
                return areaGizmoList;
            }

            set
            {
                areaGizmoList = value;
            }
        }

        public bool[,] IsHavingGizmo
        {
            get
            {
                return isHavingGizmo;
            }

            set
            {
                isHavingGizmo = value;
            }
        }
        /// <summary>
        /// 将gizmo添加到area中
        /// </summary>
        public void addGizmoInArea(MyGizmo gizmo,int x ,int y)
        {
            areaGizmoList.Add(gizmo);
            gizmo.coverIndex = new Point[gizmo.size * gizmo.size];
            int curCount = 0;
            int gizmoSize = gizmo.size;
            for (int i = 0; i < gizmoSize; i++)
            {
                for (int j = 0; j < gizmoSize; j++)
                {
                    gizmo.coverIndex[curCount] = new Point(x, y);
                    IsHavingGizmo[x, y] = true;
                    y += 1;
                    curCount += 1;
                }
                y -= gizmo.size;
                x += 1;
            }
        }
        /// <summary>
        /// 移除area中的一个gizmo
        /// </summary>
        public void removeGizmoInArea(MyGizmo gizmo,int x,int y)
        {
            int curCount = 0;
            int gizmoSize = gizmo.size;
            areaGizmoList.Remove(gizmo);
            for (int i = 0; i < gizmoSize; i++)
            {
                for (int j = 0; j < gizmoSize; j++)
                {
                    IsHavingGizmo[x, y] = false;
                    y += 1;
                    curCount += 1;
                }
                y -= gizmo.size;
                x += 1;
            }
        }
    }
    [Serializable]
    public class Setting
    {
        private Hashtable keyToFunctionHashtable;
        public Setting()
        {
            keyToFunctionHashtable = new Hashtable();
        }
        public Hashtable KeyToFunctionHashtable
        {
            get
            {
                return keyToFunctionHashtable;
            }

            set
            {
                keyToFunctionHashtable = value;
            }
        }
        public void KeyToFunctionHashtableClear()
        {
            if (keyToFunctionHashtable != null)
                keyToFunctionHashtable.Clear();
        }

        public static Color ColorLine = MyColor.ColorLine;
        public static Color ColorBackground = MyColor.ColorBackground;
        public static Color ColorBall = MyColor.ColorBall;
        public static Color Colorflipper = MyColor.Colorflipper;
        public static Color ColorRail = MyColor.ColorRail;
        public static Color ColorAbsorption = MyColor.ColorAbsorption;
        public static Color ColorWall = MyColor.ColorWall;
        public static Color ColorPolygenThree = MyColor.ColorPolygenThree;
        public static Color ColorCircle = MyColor.ColorCircle;
        public static Color ColorPolygenFour = MyColor.ColorPolygenFour;
        public static readonly int MaxMesh = MyConst.MaxMesh;
        public static readonly float Density = MyConst.Density;
        public static readonly float Friction = MyConst.Friction;
        public static readonly float GravityX = MyConst.GravityX;
        public static readonly float GravityY = MyConst.GravityY;
        public static readonly float MoreGravityY = MyConst.MoreGravityY;
        public static readonly float Restitution = MyConst.Restitution;
        public static readonly float Force = MyConst.Force;
        public static readonly float PI = MyConst.PI;
        public static readonly float SmallerTimes = MyConst.SmallerTimes;
        public static readonly float JointRadius = MyConst.JointRadius;
        public static readonly float RailForce = MyConst.RailForce;
        public static readonly bool AllowCollisionTwice = MyConst.AllowCollisionTwice;
        public static readonly bool RailDirection = MyConst.RailDirection;
    }
}