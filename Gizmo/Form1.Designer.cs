namespace Gizmo
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.ButtonSwitchModel = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.选项ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NewSceneMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenSceneMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveSceneMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RemindBindOperation = new System.Windows.Forms.Label();
            this.BindLeft = new System.Windows.Forms.Button();
            this.BindRight = new System.Windows.Forms.Button();
            this.ButtonFlipperBias1 = new System.Windows.Forms.Button();
            this.ButtonflipperLeft = new System.Windows.Forms.Button();
            this.DeleteGizmoButton = new System.Windows.Forms.Button();
            this.ReduceButton = new System.Windows.Forms.Button();
            this.EnlargeButton = new System.Windows.Forms.Button();
            this.rotateRightButton = new System.Windows.Forms.Button();
            this.ButtonBall = new System.Windows.Forms.Button();
            this.ButtonIsoscelesTrapezoid = new System.Windows.Forms.Button();
            this.ButtonflipperRight = new System.Windows.Forms.Button();
            this.ButtonAbsorption = new System.Windows.Forms.Button();
            this.ButtonRT = new System.Windows.Forms.Button();
            this.Buttonflipper1 = new System.Windows.Forms.Button();
            this.rotateLeftButton = new System.Windows.Forms.Button();
            this.ButtonCircle = new System.Windows.Forms.Button();
            this.ButtonSquare = new System.Windows.Forms.Button();
            this.MainArea = new System.Windows.Forms.PictureBox();
            this.railButton = new System.Windows.Forms.RadioButton();
            this.gizmoButton1 = new System.Windows.Forms.RadioButton();
            this.labelRemindModel = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainArea)).BeginInit();
            this.SuspendLayout();
            // 
            // ButtonSwitchModel
            // 
            this.ButtonSwitchModel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonSwitchModel.Location = new System.Drawing.Point(614, 486);
            this.ButtonSwitchModel.Name = "ButtonSwitchModel";
            this.ButtonSwitchModel.Size = new System.Drawing.Size(65, 31);
            this.ButtonSwitchModel.TabIndex = 13;
            this.ButtonSwitchModel.Text = "切换模式";
            this.ButtonSwitchModel.UseVisualStyleBackColor = true;
            this.ButtonSwitchModel.Click += new System.EventHandler(this.ButtonSwitchModel_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.选项ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(780, 25);
            this.menuStrip1.TabIndex = 14;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 选项ToolStripMenuItem
            // 
            this.选项ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NewSceneMenuItem,
            this.OpenSceneMenuItem,
            this.SaveSceneMenuItem,
            this.退出ToolStripMenuItem});
            this.选项ToolStripMenuItem.Name = "选项ToolStripMenuItem";
            this.选项ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.选项ToolStripMenuItem.Text = "选项";
            // 
            // NewSceneMenuItem
            // 
            this.NewSceneMenuItem.Name = "NewSceneMenuItem";
            this.NewSceneMenuItem.Size = new System.Drawing.Size(152, 22);
            this.NewSceneMenuItem.Text = "新建场景";
            this.NewSceneMenuItem.Click += new System.EventHandler(this.NewSceneMenuItem_Click);
            // 
            // OpenSceneMenuItem
            // 
            this.OpenSceneMenuItem.Name = "OpenSceneMenuItem";
            this.OpenSceneMenuItem.Size = new System.Drawing.Size(152, 22);
            this.OpenSceneMenuItem.Text = "打开场景";
            this.OpenSceneMenuItem.Click += new System.EventHandler(this.OpenSceneMenuItem_Click);
            // 
            // SaveSceneMenuItem
            // 
            this.SaveSceneMenuItem.Name = "SaveSceneMenuItem";
            this.SaveSceneMenuItem.Size = new System.Drawing.Size(152, 22);
            this.SaveSceneMenuItem.Text = "保存场景";
            this.SaveSceneMenuItem.Click += new System.EventHandler(this.SaveSceneMenuItem_Click);
            // 
            // 退出ToolStripMenuItem
            // 
            this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            this.退出ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.退出ToolStripMenuItem.Text = "退出";
            this.退出ToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // RemindBindOperation
            // 
            this.RemindBindOperation.AutoSize = true;
            this.RemindBindOperation.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.RemindBindOperation.ForeColor = System.Drawing.Color.Red;
            this.RemindBindOperation.Location = new System.Drawing.Point(616, 552);
            this.RemindBindOperation.Name = "RemindBindOperation";
            this.RemindBindOperation.Size = new System.Drawing.Size(0, 14);
            this.RemindBindOperation.TabIndex = 15;
            // 
            // BindLeft
            // 
            this.BindLeft.BackColor = System.Drawing.SystemColors.HighlightText;
            this.BindLeft.BackgroundImage = global::Gizmo.Properties.Resources.attach1;
            this.BindLeft.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.BindLeft.Location = new System.Drawing.Point(661, 423);
            this.BindLeft.Name = "BindLeft";
            this.BindLeft.Size = new System.Drawing.Size(34, 32);
            this.BindLeft.TabIndex = 16;
            this.BindLeft.UseVisualStyleBackColor = false;
            this.BindLeft.Click += new System.EventHandler(this.BindRight_Click);
            // 
            // BindRight
            // 
            this.BindRight.BackColor = System.Drawing.SystemColors.HighlightText;
            this.BindRight.BackgroundImage = global::Gizmo.Properties.Resources.attach;
            this.BindRight.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.BindRight.Location = new System.Drawing.Point(614, 423);
            this.BindRight.Name = "BindRight";
            this.BindRight.Size = new System.Drawing.Size(35, 32);
            this.BindRight.TabIndex = 17;
            this.BindRight.UseVisualStyleBackColor = false;
            this.BindRight.Click += new System.EventHandler(this.BindLeft_Click);
            // 
            // ButtonFlipperBias1
            // 
            this.ButtonFlipperBias1.BackgroundImage = global::Gizmo.Properties.Resources.FlipperBias1;
            this.ButtonFlipperBias1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ButtonFlipperBias1.Location = new System.Drawing.Point(732, 181);
            this.ButtonFlipperBias1.Name = "ButtonFlipperBias1";
            this.ButtonFlipperBias1.Size = new System.Drawing.Size(35, 36);
            this.ButtonFlipperBias1.TabIndex = 23;
            this.ButtonFlipperBias1.UseVisualStyleBackColor = true;
            this.ButtonFlipperBias1.Click += new System.EventHandler(this.buttonFlipperBias1_Click);
            // 
            // ButtonflipperLeft
            // 
            this.ButtonflipperLeft.BackgroundImage = global::Gizmo.Properties.Resources.LeftFlipper;
            this.ButtonflipperLeft.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ButtonflipperLeft.Location = new System.Drawing.Point(611, 180);
            this.ButtonflipperLeft.Name = "ButtonflipperLeft";
            this.ButtonflipperLeft.Size = new System.Drawing.Size(35, 37);
            this.ButtonflipperLeft.TabIndex = 22;
            this.ButtonflipperLeft.UseVisualStyleBackColor = true;
            this.ButtonflipperLeft.Click += new System.EventHandler(this.Buttonflipper1_Click);
            // 
            // DeleteGizmoButton
            // 
            this.DeleteGizmoButton.BackColor = System.Drawing.SystemColors.HighlightText;
            this.DeleteGizmoButton.BackgroundImage = global::Gizmo.Properties.Resources.delete;
            this.DeleteGizmoButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.DeleteGizmoButton.Location = new System.Drawing.Point(615, 364);
            this.DeleteGizmoButton.Name = "DeleteGizmoButton";
            this.DeleteGizmoButton.Size = new System.Drawing.Size(37, 32);
            this.DeleteGizmoButton.TabIndex = 21;
            this.DeleteGizmoButton.UseVisualStyleBackColor = false;
            this.DeleteGizmoButton.Click += new System.EventHandler(this.DeleteGizmoButton_Click);
            // 
            // ReduceButton
            // 
            this.ReduceButton.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ReduceButton.BackgroundImage = global::Gizmo.Properties.Resources.zoom_out;
            this.ReduceButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ReduceButton.Location = new System.Drawing.Point(660, 315);
            this.ReduceButton.Name = "ReduceButton";
            this.ReduceButton.Size = new System.Drawing.Size(35, 33);
            this.ReduceButton.TabIndex = 20;
            this.ReduceButton.UseVisualStyleBackColor = false;
            this.ReduceButton.Click += new System.EventHandler(this.ReduceButton_Click);
            // 
            // EnlargeButton
            // 
            this.EnlargeButton.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.EnlargeButton.BackgroundImage = global::Gizmo.Properties.Resources.gtk_zoom_in;
            this.EnlargeButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.EnlargeButton.FlatAppearance.BorderSize = 0;
            this.EnlargeButton.Location = new System.Drawing.Point(614, 315);
            this.EnlargeButton.Name = "EnlargeButton";
            this.EnlargeButton.Size = new System.Drawing.Size(37, 33);
            this.EnlargeButton.TabIndex = 19;
            this.EnlargeButton.UseVisualStyleBackColor = false;
            this.EnlargeButton.Click += new System.EventHandler(this.EnlargeButton_Click);
            // 
            // rotateRightButton
            // 
            this.rotateRightButton.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.rotateRightButton.BackgroundImage = global::Gizmo.Properties.Resources.object_rotate_right;
            this.rotateRightButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.rotateRightButton.Location = new System.Drawing.Point(701, 315);
            this.rotateRightButton.Name = "rotateRightButton";
            this.rotateRightButton.Size = new System.Drawing.Size(32, 31);
            this.rotateRightButton.TabIndex = 18;
            this.rotateRightButton.UseVisualStyleBackColor = false;
            this.rotateRightButton.Click += new System.EventHandler(this.rotateRightButton_Click);
            // 
            // ButtonBall
            // 
            this.ButtonBall.BackgroundImage = global::Gizmo.Properties.Resources.Ball;
            this.ButtonBall.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ButtonBall.Location = new System.Drawing.Point(652, 234);
            this.ButtonBall.Name = "ButtonBall";
            this.ButtonBall.Size = new System.Drawing.Size(35, 36);
            this.ButtonBall.TabIndex = 11;
            this.ButtonBall.UseVisualStyleBackColor = true;
            this.ButtonBall.Click += new System.EventHandler(this.ButtonBall_Click);
            // 
            // ButtonIsoscelesTrapezoid
            // 
            this.ButtonIsoscelesTrapezoid.BackgroundImage = global::Gizmo.Properties.Resources.IsoscelesTrapezoid;
            this.ButtonIsoscelesTrapezoid.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ButtonIsoscelesTrapezoid.Location = new System.Drawing.Point(732, 129);
            this.ButtonIsoscelesTrapezoid.Name = "ButtonIsoscelesTrapezoid";
            this.ButtonIsoscelesTrapezoid.Size = new System.Drawing.Size(35, 37);
            this.ButtonIsoscelesTrapezoid.TabIndex = 8;
            this.ButtonIsoscelesTrapezoid.UseVisualStyleBackColor = true;
            this.ButtonIsoscelesTrapezoid.Click += new System.EventHandler(this.ButtonIsoscelesTrapezoid_Click);
            // 
            // ButtonflipperRight
            // 
            this.ButtonflipperRight.BackgroundImage = global::Gizmo.Properties.Resources.RightFlipper;
            this.ButtonflipperRight.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ButtonflipperRight.Location = new System.Drawing.Point(651, 180);
            this.ButtonflipperRight.Name = "ButtonflipperRight";
            this.ButtonflipperRight.Size = new System.Drawing.Size(36, 37);
            this.ButtonflipperRight.TabIndex = 7;
            this.ButtonflipperRight.UseVisualStyleBackColor = true;
            this.ButtonflipperRight.Click += new System.EventHandler(this.Buttonflipper_Click);
            // 
            // ButtonAbsorption
            // 
            this.ButtonAbsorption.BackgroundImage = global::Gizmo.Properties.Resources.Absorber;
            this.ButtonAbsorption.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ButtonAbsorption.Location = new System.Drawing.Point(611, 234);
            this.ButtonAbsorption.Name = "ButtonAbsorption";
            this.ButtonAbsorption.Size = new System.Drawing.Size(35, 36);
            this.ButtonAbsorption.TabIndex = 6;
            this.ButtonAbsorption.UseVisualStyleBackColor = true;
            this.ButtonAbsorption.Click += new System.EventHandler(this.ButtonAbsorption_Click);
            // 
            // ButtonRT
            // 
            this.ButtonRT.BackgroundImage = global::Gizmo.Properties.Resources.RT;
            this.ButtonRT.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ButtonRT.Location = new System.Drawing.Point(651, 129);
            this.ButtonRT.Name = "ButtonRT";
            this.ButtonRT.Size = new System.Drawing.Size(36, 37);
            this.ButtonRT.TabIndex = 5;
            this.ButtonRT.UseVisualStyleBackColor = true;
            this.ButtonRT.Click += new System.EventHandler(this.ButtonRT_Click);
            // 
            // Buttonflipper1
            // 
            this.Buttonflipper1.BackgroundImage = global::Gizmo.Properties.Resources.FlipperBias;
            this.Buttonflipper1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Buttonflipper1.Location = new System.Drawing.Point(690, 180);
            this.Buttonflipper1.Name = "Buttonflipper1";
            this.Buttonflipper1.Size = new System.Drawing.Size(36, 37);
            this.Buttonflipper1.TabIndex = 4;
            this.Buttonflipper1.UseVisualStyleBackColor = true;
            this.Buttonflipper1.Click += new System.EventHandler(this.ButtonflipperBias_Click);
            // 
            // rotateLeftButton
            // 
            this.rotateLeftButton.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.rotateLeftButton.BackgroundImage = global::Gizmo.Properties.Resources.object_rotate_left;
            this.rotateLeftButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.rotateLeftButton.Location = new System.Drawing.Point(739, 313);
            this.rotateLeftButton.Name = "rotateLeftButton";
            this.rotateLeftButton.Size = new System.Drawing.Size(34, 33);
            this.rotateLeftButton.TabIndex = 3;
            this.rotateLeftButton.UseVisualStyleBackColor = false;
            this.rotateLeftButton.Click += new System.EventHandler(this.rotateLeftButton_Click);
            // 
            // ButtonCircle
            // 
            this.ButtonCircle.BackgroundImage = global::Gizmo.Properties.Resources.圆;
            this.ButtonCircle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ButtonCircle.Location = new System.Drawing.Point(690, 129);
            this.ButtonCircle.Name = "ButtonCircle";
            this.ButtonCircle.Size = new System.Drawing.Size(37, 37);
            this.ButtonCircle.TabIndex = 2;
            this.ButtonCircle.UseVisualStyleBackColor = true;
            this.ButtonCircle.Click += new System.EventHandler(this.ButtonCircle_Click);
            // 
            // ButtonSquare
            // 
            this.ButtonSquare.BackgroundImage = global::Gizmo.Properties.Resources.Square;
            this.ButtonSquare.Location = new System.Drawing.Point(611, 129);
            this.ButtonSquare.Name = "ButtonSquare";
            this.ButtonSquare.Size = new System.Drawing.Size(34, 35);
            this.ButtonSquare.TabIndex = 1;
            this.ButtonSquare.UseVisualStyleBackColor = true;
            this.ButtonSquare.Click += new System.EventHandler(this.ButtonSquare_Click);
            // 
            // MainArea
            // 
            this.MainArea.Location = new System.Drawing.Point(2, 27);
            this.MainArea.Name = "MainArea";
            this.MainArea.Size = new System.Drawing.Size(600, 600);
            this.MainArea.TabIndex = 0;
            this.MainArea.TabStop = false;
            this.MainArea.Click += new System.EventHandler(this.MainArea_Click);
            this.MainArea.MouseLeave += new System.EventHandler(this.MainArea_MouseLeave);
            this.MainArea.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MainArea_MouseMove);
            // 
            // railButton
            // 
            this.railButton.AutoSize = true;
            this.railButton.BackColor = System.Drawing.SystemColors.HighlightText;
            this.railButton.Location = new System.Drawing.Point(692, 89);
            this.railButton.Name = "railButton";
            this.railButton.Size = new System.Drawing.Size(47, 16);
            this.railButton.TabIndex = 1;
            this.railButton.TabStop = true;
            this.railButton.Text = "轨道";
            this.railButton.UseVisualStyleBackColor = false;
            this.railButton.CheckedChanged += new System.EventHandler(this.railButton_CheckedChanged);
            // 
            // gizmoButton1
            // 
            this.gizmoButton1.AutoSize = true;
            this.gizmoButton1.BackColor = System.Drawing.SystemColors.HighlightText;
            this.gizmoButton1.Location = new System.Drawing.Point(612, 89);
            this.gizmoButton1.Name = "gizmoButton1";
            this.gizmoButton1.Size = new System.Drawing.Size(53, 16);
            this.gizmoButton1.TabIndex = 0;
            this.gizmoButton1.TabStop = true;
            this.gizmoButton1.Text = "gizmo";
            this.gizmoButton1.UseVisualStyleBackColor = false;
            this.gizmoButton1.CheckedChanged += new System.EventHandler(this.gizmoButton1_CheckedChanged);
            // 
            // labelRemindModel
            // 
            this.labelRemindModel.AutoSize = true;
            this.labelRemindModel.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelRemindModel.ForeColor = System.Drawing.Color.Red;
            this.labelRemindModel.Location = new System.Drawing.Point(615, 529);
            this.labelRemindModel.Name = "labelRemindModel";
            this.labelRemindModel.Size = new System.Drawing.Size(63, 14);
            this.labelRemindModel.TabIndex = 24;
            this.labelRemindModel.Text = "编辑模式";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(780, 629);
            this.Controls.Add(this.labelRemindModel);
            this.Controls.Add(this.railButton);
            this.Controls.Add(this.gizmoButton1);
            this.Controls.Add(this.ButtonFlipperBias1);
            this.Controls.Add(this.ButtonflipperLeft);
            this.Controls.Add(this.DeleteGizmoButton);
            this.Controls.Add(this.ReduceButton);
            this.Controls.Add(this.EnlargeButton);
            this.Controls.Add(this.rotateRightButton);
            this.Controls.Add(this.BindRight);
            this.Controls.Add(this.BindLeft);
            this.Controls.Add(this.RemindBindOperation);
            this.Controls.Add(this.ButtonSwitchModel);
            this.Controls.Add(this.ButtonBall);
            this.Controls.Add(this.ButtonIsoscelesTrapezoid);
            this.Controls.Add(this.ButtonflipperRight);
            this.Controls.Add(this.ButtonAbsorption);
            this.Controls.Add(this.ButtonRT);
            this.Controls.Add(this.Buttonflipper1);
            this.Controls.Add(this.rotateLeftButton);
            this.Controls.Add(this.ButtonCircle);
            this.Controls.Add(this.ButtonSquare);
            this.Controls.Add(this.MainArea);
            this.Controls.Add(this.menuStrip1);
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GizmoGame";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainArea)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox MainArea;
        private System.Windows.Forms.Button ButtonSquare;
        private System.Windows.Forms.Button ButtonCircle;
        private System.Windows.Forms.Button rotateLeftButton;
        private System.Windows.Forms.Button Buttonflipper1;
        private System.Windows.Forms.Button ButtonRT;
        private System.Windows.Forms.Button ButtonAbsorption;
        private System.Windows.Forms.Button ButtonflipperRight;
        private System.Windows.Forms.Button ButtonIsoscelesTrapezoid;
        private System.Windows.Forms.Button ButtonBall;
        private System.Windows.Forms.Button ButtonSwitchModel;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 选项ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OpenSceneMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SaveSceneMenuItem;
        private System.Windows.Forms.ToolStripMenuItem NewSceneMenuItem;
        private System.Windows.Forms.Label RemindBindOperation;
        private System.Windows.Forms.Button BindLeft;
        private System.Windows.Forms.Button BindRight;
        private System.Windows.Forms.Button rotateRightButton;
        private System.Windows.Forms.Button EnlargeButton;
        private System.Windows.Forms.Button ReduceButton;
        private System.Windows.Forms.Button DeleteGizmoButton;
        private System.Windows.Forms.Button ButtonflipperLeft;
        private System.Windows.Forms.Button ButtonFlipperBias1;
        private System.Windows.Forms.RadioButton railButton;
        private System.Windows.Forms.RadioButton gizmoButton1;
        private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem;
        private System.Windows.Forms.Label labelRemindModel;
    }
}

