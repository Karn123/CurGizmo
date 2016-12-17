using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Collections;

namespace Gizmo
{
    class GameManager
    {

        #region 单例
        private static GameManager instance = null;
        public static GameManager GetInstance()
        {
            if (instance == null)
            {
                instance = new GameManager();
            }
            return instance;
        }
        #endregion
        private GraphicManager graphicManager;
        private FileManager fileManager;
        private PhysicalManager physicalManager;
        private Model model;
        private Scene scene;
        private MyShape nowShape;
        private bool isRail;
        /// <summary>
        /// 每个物体大小，绘图就按照这个size绘
        /// </summary>
        private int size;

        public GraphicManager GraphicManager
        {
            get
            {
                return graphicManager;
            }
        }

        public int Size
        {
            get
            {
                return size;
            }

            set
            {
                size = value;
            }
        }

        public bool IsRail
        {
            get
            {
                return isRail;
            }

            set
            {
                isRail = value;
            }
        }

        private GameManager()
        {
            graphicManager = new GraphicManager();
            fileManager = new FileManager();
            physicalManager = PhysicalManager.GetInstance();
            scene = new Scene();
            model = Model.Building;
            Size = MySize.sizeX1;
            IsRail = false;
        }

        public Setting GetSetting()
        {
            return scene.setting;
        }
        public MyShape GetNowShape()
        {
            return nowShape;
        }

        public void SetNowShape(MyShape shape)
        {
            nowShape = shape;
        }

        public bool IsBuildingModel()
        {
            return model == Model.Building;
        }
        public bool IsRunningModel()
        {
            return model == Model.Running;
        }

        /// <summary>
        /// 处理鼠标事件
        /// </summary>
        public void DoGizmoFunction(GizmoFunction gizmoFunc, Point mouseLocation)
        {
            graphicManager.ReturnToLastDraw();

            GizmoFactory gizmoFactory = new GizmoFactory();
            //用一个简单工厂创建gizmo,确保此模块是closed for modification.
            MyGizmo gizmo = gizmoFactory.returnGizmo(nowShape);
            gizmo.isRail = IsRail;

            gizmo.draw(mouseLocation);
            //展示鼠标移动的gizmo
            GraphicManager.ShowMovingDraw();
            //若是鼠标点击事件
            if (gizmoFunc.Equals(GizmoFunction.AddGizmo))
            {
                //记录当前gizmo信息
                Point index, nowPositionLeftUp;
                nowPositionLeftUp = gizmo.pointLeftUp;
                GetIndexForArea(nowPositionLeftUp, out index);

                //判断该gizmo所跨越的方格有没有gizmo
                List<MyGizmo> gizmosExistList = scene.area.AreaGizmoList;
                bool flag = false;
                int index_X = index.X;
                int index_Y = index.Y;
                for (int i = 0; i < gizmo.size; i++)
                {
                    if(index_X >= Setting.MaxMesh)
                    {
                        flag = true;
                        break;
                    }
                    for (int j = 0; j < gizmo.size; j++)
                    {
                        if(index_Y >= Setting.MaxMesh)
                        {
                            flag = true;
                            break;
                        }
                        if (scene.area.IsHavingGizmo[index_X, index_Y])
                        {
                            flag = true;
                            break;
                        }
                        index_Y += 1;
                    }
                    index_Y -= gizmo.size;
                    if (flag)
                    {
                        break;
                    }
                    index_X += 1;
                }
                //若没有冲突，则将该gizmo添加到场景中
                if (!flag)
                {
                    scene.SetGizmoInArea(gizmo, index.X, index.Y);
                    showCurrentScene();
                }
            }
        }
        /// <summary>
        /// 绘出场景中的gizmo
        /// </summary>
        internal void showCurrentScene()
        {
            GraphicManager.ClearAllDraw();
            int listSize = scene.area.AreaGizmoList.Count;
            for (int i = 0; i < listSize; i++)
            {
                scene.area.AreaGizmoList[i].draw();
            }
            //把当前画好的图保存下来
            GraphicManager.EndDraw();
        }
        internal void SwitchModel()
        {
            if (model == Model.Building)
            {
                SwitchToRunningModel();
            }
            else
            {
                SwitchToBuildingModel();
            }
        }
        public void SwitchToBuildingModel()
        {
            model = Model.Building;
            physicalManager.StopPhysicalSystem();
            showCurrentScene();
        }
        public void SwitchToRunningModel()
        {
            model = Model.Running;
            physicalManager.StartPhysicalSystem(scene);
        }
        /// <summary>
        /// 载入场景
        /// </summary>
        public void loadScene()
        {
            if (fileManager.LoadScene(ref scene))
                showCurrentScene();
            else
                MessageBox.Show("读取场景失败！");
        }
        /// <summary>
        /// 保存场景
        /// </summary>
        public void SaveScene()
        {
            if (!fileManager.SaveScene(scene))
            {
                MessageBox.Show("保存失败!");
            }
            else
            {
                MessageBox.Show("保存成功！");
            }
        }
        /// <summary>
        /// 清空当前场景，重新绘制
        /// </summary>
        public void NewScene()
        {
            scene.ClearScene();
            GraphicManager.ClearAllDraw();
            GraphicManager.EndDraw();
        }
        
        /// <summary>
        /// 运行模式下旋转
        /// </summary>
        /// <param name="keyCode">按键值</param>
        internal void Rotate(Keys keyCode)
        {
            if(scene.setting.KeyToFunctionHashtable.Contains(keyCode))
            {
                Rotation curRotation = (Rotation)scene.setting.KeyToFunctionHashtable[keyCode];
                physicalManager.OnButtonClick(curRotation);
            }
        }
        /// <summary>
        /// 根据方格左上角顶点位置获取该方格坐标编号
        /// </summary>
        public void GetIndexForArea(Point position, out Point areaIndex)
        {
            int widthPerMesh = graphicManager.WidthPerMesh;
            int HeightPerMesh = graphicManager.HeightPerMesh;
            areaIndex = new Point(position.X / widthPerMesh, position.Y / HeightPerMesh);
        }
        /// <summary>
        /// 为运行模式下绑定旋转方向
        /// </summary>
        /// <param name="key">键盘按键值</param>
        /// <param name="curRotation">绑定的旋转方向</param>
        public void BindRotation(System.Windows.Forms.Keys key,Rotation curRotation)
        {
            Setting setting = scene.setting;
            if(setting.KeyToFunctionHashtable.Contains(key))
            {
                setting.KeyToFunctionHashtable.Remove(key);
            }
            setting.KeyToFunctionHashtable.Add(key, curRotation);
        }
      
        /// <summary>
        /// 编辑模式下逆时针旋转gizmo
        /// </summary>
        public void RotateLeftInBuildingModel()
        {
            int listSize = scene.area.AreaGizmoList.Count;
            if (listSize > 0)
            {
                scene.area.AreaGizmoList[listSize - 1].rotateLeft();
                showCurrentScene();
            }
        }

        /// <summary>
        /// 编辑模式下顺时针旋转gizmo
        /// </summary>
        public void RotateRightInBuildingModel()
        {
            int listSize = scene.area.AreaGizmoList.Count;
            //这是旋转所有形状相同的gizmo
            //for (int i = 0; i<listSize; i += scene.area.AreaGizmoList[i].size * scene.area.AreaGizmoList[i].size)
            //{
            //    //if (scene.area.AreaGizmoList[i].shape == nowShape)
            //    //    scene.area.AreaGizmoList[i].rotateRight();
            //}
            if (listSize > 0)
            {
                scene.area.AreaGizmoList[listSize - 1].rotateRight();
                showCurrentScene();
            }
        }
        /// <summary>
        /// 删除一个gizmo
        /// </summary>
        public void DeleteGizmo()
        {
            int listSize = scene.area.AreaGizmoList.Count;
            if (listSize > 0)
            {
                MyGizmo curGizmo = scene.area.AreaGizmoList[listSize - 1];
                scene.area.removeGizmoInArea(curGizmo, curGizmo.coverIndex[0].X, curGizmo.coverIndex[0].Y);
                showCurrentScene();
            }
        }
    }
}