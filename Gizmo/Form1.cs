using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gizmo
{
    public partial class Form1 : Form
    {
        private Point MainAreaLocation;
        private GizmoFunction gizmoFunc;
        private Rotation curRotation;
        private bool isBindMode;
        //private Shape nowShape = Shape.NULL;

        #region 初始化
        public Form1()
        {
            InitializeComponent();
            GraphicInitialize();
            MainAreaLocation.X = MainArea.Location.X;
            MainAreaLocation.Y = MainArea.Location.Y;
            gizmoFunc = GizmoFunction.NULL;
            curRotation = Rotation.NULL;
            isBindMode = false;
        }
        private void GraphicInitialize()
        {
            Bitmap bmp = new Bitmap(MainArea.Width, MainArea.Height);
            Graphics g = Graphics.FromImage(bmp);
            g.Clear(Setting.ColorBackground);
            g.Dispose();
            GameManager.GetInstance().GraphicManager.SetGraphics(MainArea.CreateGraphics(), bmp, MainArea.Width, MainArea.Height);
        }
        #endregion

        #region UI事件
        private void MainArea_Click(object sender, EventArgs e)
        {
            if (GameManager.GetInstance().IsBuildingModel() && gizmoFunc != GizmoFunction.NULL)
            {
                MouseEventArgs me = (MouseEventArgs)e;
                GameManager.GetInstance().DoGizmoFunction(gizmoFunc, me.Location);
            }
        }
        
        private void MainArea_MouseMove(object sender, MouseEventArgs e)
        {
            if (GameManager.GetInstance().IsBuildingModel() && gizmoFunc != GizmoFunction.NULL && GameManager.GetInstance().GetNowShape() != MyShape.NULL)
            {
                GameManager.GetInstance().DoGizmoFunction(GizmoFunction.OnlyDraw, e.Location);
            }
        }
        private void SetShape(MyShape shape)
        {
            GameManager.GetInstance().GraphicManager.ReturnToLastDraw();
            gizmoFunc = GizmoFunction.AddGizmo;
            GameManager.GetInstance().SetNowShape(shape);
        }
        private void ButtonSquare_Click(object sender, EventArgs e)
        {
            if (GameManager.GetInstance().IsBuildingModel())
            {
                SetShape(MyShape.SquareShape);
            }
        }
        
        private void ButtonCircle_Click(object sender, EventArgs e)
        {
            if (GameManager.GetInstance().IsBuildingModel())
            {
                SetShape(MyShape.CircleShape);
            }
        }

        private void ButtonBall_Click(object sender, EventArgs e)
        {
            if (GameManager.GetInstance().IsBuildingModel())
            {
                SetShape(MyShape.BallShape);
            }
        }
        /// <summary>
        /// 纵向挡板,靠右，向左旋转
        /// </summary>
        private void Buttonflipper_Click(object sender, EventArgs e)
        {
            if (GameManager.GetInstance().IsBuildingModel())
            {
                SetShape(MyShape.FlipperShape);
            }
        }
        /// <summary>
        /// 斜向挡板，向左旋转
        /// </summary>
        private void ButtonflipperBias_Click(object sender, EventArgs e)
        {
            if(GameManager.GetInstance().IsBuildingModel())
            {
                SetShape(MyShape.FlipperBiasShape);
            }
        }
        /// <summary>
        /// 表示之后拖出来的gizmo都是轨道
        /// </summary>
        private void ButtonRail_Click(object sender, EventArgs e)
        {
            if (GameManager.GetInstance().IsBuildingModel())
            {
                GameManager.GetInstance().IsRail = true;
            }
        }

        private void ButtonAbsorption_Click(object sender, EventArgs e)
        {
            if (GameManager.GetInstance().IsBuildingModel())
            {
                SetShape(MyShape.AbsorptionShape);
            }
        }

        private void ButtonWall_Click(object sender, EventArgs e)
        {
            if (GameManager.GetInstance().IsBuildingModel())
            {
                SetShape(MyShape.WallShape);
            }
        }
        /// <summary>
        /// 直角三角形
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonRT_Click(object sender, EventArgs e)
        {
            if (GameManager.GetInstance().IsBuildingModel())
            {
                SetShape(MyShape.RTShape);
            }
        }

        private void ButtonIsoscelesTrapezoid_Click(object sender, EventArgs e)
        {
            if (GameManager.GetInstance().IsBuildingModel())
            {
                SetShape(MyShape.IsoscelesTrapezoidShape);
            }
        }
        #endregion

        #region UI事件驱动
        private void OnKeyClick()
        {

        }
        private void OnDoingSceneFunction(SceneFunction sceneFunction)
        {
            switch (sceneFunction)
            {
                case SceneFunction.LoadScene:
                    GameManager.GetInstance().loadScene();
                    //LoadScene();
                    break;
                case SceneFunction.NewScene:
                    GameManager.GetInstance().NewScene();
                    //NewScene();
                    break;
                case SceneFunction.SaveScene:
                    GameManager.GetInstance().SaveScene();
                    //SaveScene();
                    break;
                default:
                    break;
            }
        }
        #endregion

        private void ButtonTriangle_Click(object sender, EventArgs e)
        {

        }

        private void ButtonSwitchModel_Click(object sender, EventArgs e)
        {
            GameManager.GetInstance().SwitchModel();
            if(GameManager.GetInstance().IsBuildingModel())
            {
                labelRemindModel.Text = "编辑模式";
            }
            else
            {
                labelRemindModel.Text = "运行模式";
            }
        }

        private void MainTimer_Tick(object sender, EventArgs e)
        {
            
        }

        private void MainArea_MouseLeave(object sender, EventArgs e)
        {
            //用于清除最后留下的鼠标痕迹
            GameManager.GetInstance().GraphicManager.ReturnToLastDraw();
            GameManager.GetInstance().GraphicManager.ShowMovingDraw();
        }
        /// <summary>
        /// 打开场景
        /// </summary>
        private void OpenSceneMenuItem_Click(object sender, EventArgs e)
        {
            GameManager.GetInstance().loadScene();
        }
        /// <summary>
        /// 保存当前场景
        /// </summary>
        private void SaveSceneMenuItem_Click(object sender, EventArgs e)
        {
            GameManager.GetInstance().SaveScene();
        }
        /// <summary>
        /// 新建场景
        /// </summary>
        private void NewSceneMenuItem_Click(object sender, EventArgs e)
        {
            GameManager.GetInstance().NewScene();
        }

        /// <summary>
        /// 绑定逆时针旋转
        /// </summary>
        private void BindRight_Click(object sender, EventArgs e)
        {
            if (GameManager.GetInstance().IsBuildingModel())
            {
                isBindMode = true;
                curRotation = Rotation.Right;
                RemindBindOperation.Text = "请按下键盘的一个\n按键来绑定逆时针\n旋转挡板操作";
            }
        }
        /// <summary>
        /// 绑定顺时针旋转
        /// </summary>
        private void BindLeft_Click(object sender, EventArgs e)
        {
            if(GameManager.GetInstance().IsBuildingModel())
            {
                isBindMode = true;
                curRotation = Rotation.Left;
                RemindBindOperation.Text = "请按下键盘的一个\n按键来绑定顺时针\n旋转挡板操作";
            }
        }
        /// <summary>
        /// 键盘监听事件
        /// </summary>
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (GameManager.GetInstance().IsBuildingModel())
            {
                if (isBindMode)
                {
                    MessageBox.Show("绑定成功！");
                    RemindBindOperation.Text = "";
                    if (curRotation == Rotation.Left)
                    {
                        GameManager.GetInstance().BindRotation(e.KeyCode, Rotation.Left);
                        curRotation = Rotation.NULL;
                    }
                    if (curRotation == Rotation.Right)
                    {
                        GameManager.GetInstance().BindRotation(e.KeyCode, Rotation.Right);
                        curRotation = Rotation.NULL;
                    }
                    isBindMode = false;
                }
                else
                {
                    MessageBox.Show("请按下绑定键再绑定挡板.");
                }
            }
            //运行模式下，旋转gizmo
            else
            {
                GameManager.GetInstance().Rotate(e.KeyCode);
            }
        }
        /// <summary>
        /// 编辑模式下顺时针旋转选择的gizmo
        /// </summary>
        private void rotateRightButton_Click(object sender, EventArgs e)
        {
            GameManager.GetInstance().RotateRightInBuildingModel();
        }
        /// <summary>
        /// 编辑模式下逆时针旋转选择的gizmo
        /// </summary>
        private void rotateLeftButton_Click(object sender, EventArgs e)
        {
            GameManager.GetInstance().RotateLeftInBuildingModel();
        }
        /// <summary>
        /// 放大
        /// </summary>
        private void EnlargeButton_Click(object sender, EventArgs e)
        {
            if(GameManager.GetInstance().Size < MySize.sizeX4)
            {
                GameManager.GetInstance().Size += 1;
            }
        }
        /// <summary>
        /// 缩小
        /// </summary>
        private void ReduceButton_Click(object sender, EventArgs e)
        {
            if(GameManager.GetInstance().Size > MySize.sizeX1)
            {
                GameManager.GetInstance().Size -= 1;
            }
        }

        private void DeleteGizmoButton_Click(object sender, EventArgs e)
        {
            GameManager.GetInstance().DeleteGizmo();
        }
        /// <summary>
        /// 左挡板向右旋转
        /// </summary>
        private void Buttonflipper1_Click(object sender, EventArgs e)
        {
            if (GameManager.GetInstance().IsBuildingModel())
            {
                SetShape(MyShape.FlipperShape1);
            }
        }
        /// <summary>
        /// 斜向挡板，向右旋转
        /// </summary>
        private void buttonFlipperBias1_Click(object sender, EventArgs e)
        {
            if (GameManager.GetInstance().IsBuildingModel())
            {
                SetShape(MyShape.FlipperBiasShape1);
            }
        }
        /// <summary>
        /// 表示放入的是gizmo
        /// </summary>
        private void GizmoButton_Click(object sender, EventArgs e)
        {
            if (GameManager.GetInstance().IsBuildingModel())
            {
                GameManager.GetInstance().IsRail = false;
            }
        }

        private void gizmoButton1_CheckedChanged(object sender, EventArgs e)
        {
            GameManager.GetInstance().IsRail = false;
        }

        private void railButton_CheckedChanged(object sender, EventArgs e)
        {
             GameManager.GetInstance().IsRail = true;
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }

        
    }
}