using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Box2DX.Common;
using Box2DX.Dynamics;
using Box2DX.Collision;
using Box2DX.Dynamics.Controllers;
using System.Windows.Forms;

namespace Gizmo
{
    /// <summary>
    /// 物理环境和显示环境相差smallerTimes倍
    /// </summary>
    class PhysicalManager
    {
        private static PhysicalManager Instance;
        public static PhysicalManager GetInstance()
        {
            if (Instance == null)
            {
                Instance = new PhysicalManager();
            }
            return Instance;
        }
        private PhysicalManager()
        {

        }

        private bool IsStarted = false;
        protected Timer timer;
        protected GraphicManager graphicManager;
        
        //protected AABB worldAABB;
        protected DebugDraw debugDraw = new MyDebugDraw();
        protected MyContactListener contactListener = new MyContactListener();
        protected World world;
        protected List<Body> leftFlipper = new List<Body>();
        protected List<Body> rightFlipper = new List<Body>();
        protected List<Body> allMoveableGizmoBody = new List<Body>();
        protected List<Body> allBallGizmoBody = new List<Body>();
        public List<Body> allDeletedGizmoBody = new List<Body>();


        public void StartPhysicalSystem(Scene nowScene)
        {
            //test();
            
            PhysicalSystemInitialize();

            timer = new Timer();
            timer.Interval = 1000 / 60;
            timer.Tick += OnTimerTick;
            timer.Start();

            foreach (MyGizmo gizmo in nowScene.area.AreaGizmoList)
            {
                BodyDef bodyDef = new BodyDef();
                bodyDef.UserData = gizmo;
                Body gizmoBody = world.CreateBody(bodyDef);

                if (MyShape.AbsorptionShape == gizmo.shape)
                {
                    Absorption absorption = (Absorption)gizmo;
                    Vec2[] vec = PointFToVec2(absorption.Points);
                    vec = SmallerVec2(vec);
                    PolygonDef polygonDef = new PolygonDef();
                    polygonDef.VertexCount = vec.Count();
                    polygonDef.Vertices = vec;
                    polygonDef.Density = Setting.Density;
                    polygonDef.Friction = Setting.Friction;
                    polygonDef.IsSensor = true;
                    gizmoBody.CreateFixture(polygonDef);
                }
                else if (MyShape.BallShape == gizmo.shape)
                {
                    Ball ball = (Ball)gizmo;
                    CircleDef circleDef = new CircleDef();
                    circleDef.Radius = ball.Radius / Setting.SmallerTimes;
                    Vec2[] vec = new Vec2[1];
                    vec[0] = new Vec2(ball.Center.X, ball.Center.Y);
                    vec = SmallerVec2(vec);
                    circleDef.LocalPosition = vec[0];
                    circleDef.Density = Setting.Density;
                    circleDef.Friction = Setting.Friction;
                    circleDef.Restitution = Setting.Restitution;
                    gizmoBody.CreateFixture(circleDef);
                    gizmoBody.SetMassFromShapes();
                    gizmoBody.SetBullet(true);
                    allBallGizmoBody.Add(gizmoBody);
                }
                else if (MyShape.CircleShape == gizmo.shape)
                {
                    Circle circle = (Circle)gizmo;
                    CircleDef circleDef = new CircleDef();
                    circleDef.Radius = circle.Radius / Setting.SmallerTimes;
                    Vec2[] vec = new Vec2[1];
                    vec[0] = new Vec2(circle.Center.X, circle.Center.Y);
                    vec = SmallerVec2(vec);
                    circleDef.LocalPosition = vec[0];
                    circleDef.Density = Setting.Density;
                    circleDef.Friction = Setting.Friction;
                    gizmoBody.CreateFixture(circleDef);
                    //用于后续平衡重力
                    if (gizmo.Moveable && !gizmo.isRail)
                    {
                        gizmoBody.SetMassFromShapes();
                        allMoveableGizmoBody.Add(gizmoBody);
                    }
                }
                else if (MyShape.FlipperShape == gizmo.shape)
                {
                    Flipper flipper = (Flipper)gizmo;
                    Vec2[] vec = PointFToVec2(flipper.Points);
                    vec = SmallerVec2(vec);
                    PolygonDef polygonDef = new PolygonDef();
                    polygonDef.VertexCount = vec.Count();
                    polygonDef.Vertices = vec;
                    polygonDef.Density = Setting.Density;
                    polygonDef.Friction = Setting.Friction;
                    gizmoBody.CreateFixture(polygonDef);
                    gizmoBody.SetMassFromShapes();
                    CreateJoint(gizmo, gizmoBody, flipper.rotation);
                }
                else if (MyShape.FlipperBiasShape == gizmo.shape)
                {
                    FlipperBias flipper = (FlipperBias)gizmo;
                    Vec2[] vec = PointFToVec2(flipper.Points);
                    vec = SmallerVec2(vec);
                    PolygonDef polygonDef = new PolygonDef();
                    polygonDef.VertexCount = vec.Count();
                    polygonDef.Vertices = vec;
                    polygonDef.Density = Setting.Density;
                    polygonDef.Friction = Setting.Friction;
                    gizmoBody.CreateFixture(polygonDef);
                    gizmoBody.SetMassFromShapes();
                    CreateJoint(gizmo, gizmoBody, flipper.rotation);
                }
                else if (MyShape.FlipperShape1 == gizmo.shape)
                {
                    Flipper1 flipper = (Flipper1)gizmo;
                    Vec2[] vec = PointFToVec2(flipper.Points);
                    vec = SmallerVec2(vec);
                    PolygonDef polygonDef = new PolygonDef();
                    polygonDef.VertexCount = vec.Count();
                    polygonDef.Vertices = vec;
                    polygonDef.Density = Setting.Density;
                    polygonDef.Friction = Setting.Friction;
                    gizmoBody.CreateFixture(polygonDef);
                    gizmoBody.SetMassFromShapes();
                    CreateJoint(gizmo, gizmoBody, flipper.rotation);
                }
                else if (MyShape.FlipperBiasShape1 == gizmo.shape)
                {
                    FlipperBias1 flipper = (FlipperBias1)gizmo;
                    Vec2[] vec = PointFToVec2(flipper.Points);
                    vec = SmallerVec2(vec);
                    PolygonDef polygonDef = new PolygonDef();
                    polygonDef.VertexCount = vec.Count();
                    polygonDef.Vertices = vec;
                    polygonDef.Density = Setting.Density;
                    polygonDef.Friction = Setting.Friction;
                    gizmoBody.CreateFixture(polygonDef);
                    gizmoBody.SetMassFromShapes();
                    CreateJoint(gizmo, gizmoBody, flipper.rotation);
                }
                else if (MyShape.IsoscelesTrapezoidShape == gizmo.shape)
                {
                    IsoscelesTrapezoid it = (IsoscelesTrapezoid)gizmo;
                    Vec2[] vec = PointFToVec2(it.Points);
                    vec = SmallerVec2(vec);
                    PolygonDef polygonDef = new PolygonDef();
                    polygonDef.VertexCount = vec.Count();
                    polygonDef.Vertices = vec;
                    polygonDef.Density = Setting.Density;
                    polygonDef.Friction = Setting.Friction;
                    gizmoBody.CreateFixture(polygonDef);
                    //用于后续平衡重力
                    if (gizmo.Moveable && !gizmo.isRail)
                    {
                        gizmoBody.SetMassFromShapes();
                        allMoveableGizmoBody.Add(gizmoBody);
                    }
                }
                else if (MyShape.RailShape == gizmo.shape)
                {
                }
                else if (MyShape.RTShape == gizmo.shape)
                {
                    RT rt = (RT)gizmo;
                    Vec2[] vec = PointFToVec2(rt.Points);
                    vec = SmallerVec2(vec);
                    PolygonDef polygonDef = new PolygonDef();
                    polygonDef.VertexCount = vec.Count();
                    polygonDef.Vertices = vec;
                    polygonDef.Density = Setting.Density;
                    polygonDef.Friction = Setting.Friction;
                    gizmoBody.CreateFixture(polygonDef);
                    //用于后续平衡重力
                    if (gizmo.Moveable && !gizmo.isRail)
                    {
                        gizmoBody.SetMassFromShapes();
                        allMoveableGizmoBody.Add(gizmoBody);
                    }
                }
                else if (MyShape.SquareShape == gizmo.shape)
                {
                    Square square = (Square)gizmo;
                    Vec2[] vec = PointFToVec2(square.Points);
                    vec = SmallerVec2(vec);
                    PolygonDef polygonDef = new PolygonDef();
                    polygonDef.VertexCount = vec.Count();
                    polygonDef.Vertices = vec;
                    polygonDef.Density = Setting.Density;
                    polygonDef.Friction = Setting.Friction;
                    gizmoBody.CreateFixture(polygonDef);
                    //用于后续平衡重力
                    if (gizmo.Moveable && !gizmo.isRail)
                    {
                        gizmoBody.SetMassFromShapes();
                        allMoveableGizmoBody.Add(gizmoBody);
                    }
                }
                else if (MyShape.WallShape == gizmo.shape)
                {
                }
            }
            IsStarted = true;
        }

        private void CreateJoint(MyGizmo gizmo, Body gizmoBody, Rotation flipperRotation)
        {
            BodyDef bodyDef2 = new BodyDef();
            //计算旋转位置
            if (gizmo.shape == MyShape.FlipperShape)
            {
                bodyDef2.Position = new Vec2(gizmo.pointLeftUp.X / 8 + gizmo.pointRightUp.X * 7 / 8, gizmo.pointLeftUp.Y * 3 / 4 + gizmo.pointLeftDown.Y / 4);
            }
            else if (gizmo.shape == MyShape.FlipperShape1)
            {
                bodyDef2.Position = new Vec2(gizmo.pointLeftUp.X * 7 / 8 + gizmo.pointRightUp.X * 1 / 8, gizmo.pointLeftUp.Y * 3 / 4 + gizmo.pointLeftDown.Y / 4);
            }
            else if(gizmo.shape == MyShape.FlipperBiasShape)
            {
                bodyDef2.Position = new Vec2(gizmo.pointLeftUp.X / 8 + gizmo.pointRightUp.X * 7 / 8, gizmo.pointLeftUp.Y * 3 / 4 + gizmo.pointLeftDown.Y / 4);
            }
            else if(gizmo.shape == MyShape.FlipperBiasShape1)
            {
                bodyDef2.Position = new Vec2(gizmo.pointLeftUp.X * 7 / 8 + gizmo.pointRightUp.X * 1 / 8, gizmo.pointLeftUp.Y * 3 / 4 + gizmo.pointLeftDown.Y / 4);
            }
            bodyDef2.Position = new Vec2(bodyDef2.Position.X / Setting.SmallerTimes, bodyDef2.Position.Y / Setting.SmallerTimes);
            Body gizmoBody2 = world.CreateBody(bodyDef2);
            CircleDef circleDef = new CircleDef();
            circleDef.Density = Setting.Density;
            circleDef.Radius = Setting.JointRadius / Setting.SmallerTimes;
            gizmoBody2.CreateFixture(circleDef);

            RevoluteJointDef rjointDef = new RevoluteJointDef();
            rjointDef.Initialize(gizmoBody, gizmoBody2, gizmoBody2.GetWorldCenter());
            if (flipperRotation == Rotation.Left)
            {
                rjointDef.EnableLimit = true;
                rjointDef.LowerAngle = -Setting.PI / 2;
                rjointDef.UpperAngle = 0;
                leftFlipper.Add(gizmoBody);
            }
            else if (flipperRotation == Rotation.Right)
            {
                rjointDef.EnableLimit = true;
                rjointDef.LowerAngle = 0;
                rjointDef.UpperAngle = Setting.PI / 2;
                rightFlipper.Add(gizmoBody);
            }

            world.CreateJoint(rjointDef);
        }

        public void StopPhysicalSystem()
        {
            timer.Stop();
            world.Dispose();
            IsStarted = false;
            debugDraw = null;
            contactListener = null;
            leftFlipper = null;
            rightFlipper = null;
            allMoveableGizmoBody = null;
            allBallGizmoBody = null;
            allDeletedGizmoBody = null;
    }

        public void PhysicalSystemInitialize()
        {
            debugDraw = new MyDebugDraw();
            contactListener = new MyContactListener();
            leftFlipper = new List<Body>();
            rightFlipper = new List<Body>();
            allMoveableGizmoBody = new List<Body>();
            allBallGizmoBody = new List<Body>();
            allDeletedGizmoBody = new List<Body>();

            graphicManager = GameManager.GetInstance().GraphicManager;
            AABB worldAABB = new AABB();
            worldAABB.LowerBound.Set(0,0);
            worldAABB.UpperBound.Set(graphicManager.BoxWidth, graphicManager.BoxHeight);
            Vec2 gravity = new Vec2();
            gravity.Set(Setting.GravityX, Setting.GravityY);
            bool doSleep = true;
            world = new World(worldAABB, gravity, doSleep);
            
            //_contactListener.test = this;
            //_world.SetContactListener(_contactListener);
            world.SetDebugDraw(debugDraw);
            world.SetContactListener(contactListener);
            // Define the ground body.
            BoardInitialize(new Vec2(0, 0), new Vec2(0, graphicManager.BoxHeight));
            BoardInitialize(new Vec2(0, 0), new Vec2(graphicManager.BoxWidth, 0));
            BoardInitialize(new Vec2(graphicManager.BoxWidth, 0), new Vec2(graphicManager.BoxWidth, graphicManager.BoxHeight));
            BoardInitialize(new Vec2(0, graphicManager.BoxHeight), new Vec2(graphicManager.BoxWidth, graphicManager.BoxHeight));
            
            uint flags = 0;
            flags += (uint)DebugDraw.DrawFlags.Shape;
            //flags += (uint)DebugDraw.DrawFlags.Joint;
            flags += (uint)DebugDraw.DrawFlags.CoreShape;
            //flags += (uint)DebugDraw.DrawFlags.Aabb;
            //flags += (uint)DebugDraw.DrawFlags.Obb;
            //flags += (uint)DebugDraw.DrawFlags.Pair;
            flags += (uint)DebugDraw.DrawFlags.CenterOfMass;
            flags += (uint)DebugDraw.DrawFlags.Controller;
            debugDraw.Flags = (DebugDraw.DrawFlags)flags;
        }

        public void BoardInitialize(Vec2 vertex1 , Vec2 vertex2)
        {
            //BodyDef groundBodyDef = new BodyDef();
            //groundBodyDef.Position.Set(graphicManager.BoxWidth / 2 - 100, graphicManager.BoxHeight / 2 - 100);

            //// Call the body factory which creates the ground box shape.
            //// The body is also added to the world.
            //Body groundBody = _world.CreateBody(groundBodyDef);
            //// Define the ground box shape.

            //PolygonDef groundShapeDef = new PolygonDef();
            //// The extents are the half-widths of the box.
            //groundShapeDef.SetAsBox(graphicManager.BoxWidth / 2 - 100, graphicManager.BoxHeight / 2 - 100);
            //// Add the ground shape to the ground body.
            //groundBody.CreateFixture(groundShapeDef);

            Vec2[] vec = new Vec2[2];
            vec[0] = new Vec2(vertex1.X, vertex1.Y);
            vec[1] = new Vec2(vertex2.X, vertex2.Y);
            vec = SmallerVec2(vec);

            BodyDef groundBodyDef = new BodyDef();
            groundBodyDef.Position.Set(0,0);
            Body groundBody = world.CreateBody(groundBodyDef);
            EdgeDef groundShapeDef = new EdgeDef();
            groundShapeDef.Vertex1 = vec[0];
            groundShapeDef.Vertex2 = vec[1];
            groundBody.CreateFixture(groundShapeDef);
        }

        public void OnTimerTick(object sender, EventArgs e)
        {
            // Prepare for simulation. Typically we use a time step of 1/60 of a
            // second (60Hz) and 10 iterations. This provides a high quality simulation
            // in most game scenarios.
            float timeStep = 1.0f / 60.0f;
            int velocityIterations = 8;
            int positionIterations = 1;

            // Instruct the world to perform a single step of simulation. It is
            // generally best to keep the time step and iterations fixed.
            GameManager.GetInstance().GraphicManager.ClearAllDraw();

            foreach (Body body in allMoveableGizmoBody)
            {
                body.ApplyForce(body.GetMass() * -world.Gravity, body.GetWorldCenter());
                //if (body.GetLinearVelocity().X <= 0.5 && body.GetLinearVelocity().Y <= 0.5)
                //{
                //    body.PutToSleep();
                //}
            }
            foreach (Body body in allDeletedGizmoBody)
            {
                MyGizmo gizmo = (MyGizmo)body.GetUserData();
                if (gizmo.shape == MyShape.BallShape)
                {
                    allBallGizmoBody.Remove(body);
                }
                try
                {
                    world.DestroyBody(body);
                }
                catch
                {

                }
                if (allBallGizmoBody.Count == 0)
                {
                    GameManager.GetInstance().SwitchModel();
                    return;
                }
            }
            allDeletedGizmoBody.Clear();
            world.Step(timeStep, velocityIterations, positionIterations);
            GameManager.GetInstance().GraphicManager.EndDraw();

        }

        public void OnButtonClick(Rotation rotation)
        {
            switch (rotation)
            {
                //顺时针
                case Rotation.Left:
                    foreach (Body body in leftFlipper)
                    {
                        //body.ApplyImpulse(new Vec2(-10000, 0), new Vec2(0, 0));
                        //body.ApplyImpulse(new Vec2(-10000 * body.GetMass(), 0), new Vec2(0, 0));
                        body.SetAngularVelocity(100);
                    }
                    break;
                //逆时针
                case Rotation.Right:
                    foreach (Body body in rightFlipper)
                    {
                        //body.ApplyImpulse(new Vec2(10000, 0), new Vec2(0, 0));
                        //body.ApplyImpulse(new Vec2(10000 * body.GetMass(), 0), new Vec2(0, 0));
                        body.SetAngularVelocity(-100);
                    }
                    break;
                default:
                    break;
            }
        }

        protected System.Drawing.PointF[] Vec2ToPointF(Vec2[] vertices)
        {
            int vertexCount = vertices.Count();
            System.Drawing.PointF[] pointf = new System.Drawing.PointF[vertexCount];
            for (int i = 0; i < vertexCount; i++)
            {
                pointf[i] = new System.Drawing.PointF(vertices[i].X, vertices[i].Y);
            }
            return pointf;
        }

        protected Vec2[] PointFToVec2(System.Drawing.PointF[] pointF)
        {
            int pointCount = pointF.Count();
            Vec2[] vec = new Vec2[pointCount];
            for (int i = 0; i < pointCount; i++)
            {
                vec[i] = new Vec2(pointF[i].X, pointF[i].Y);
            }
            return vec;
        }
        
        protected Vec2[] SmallerVec2(Vec2[] vec2)
        {
            int vertexCount = vec2.Count();
            for (int i = 0; i < vertexCount; i++)
            {
                vec2[i] = new Vec2(vec2[i].X / Setting.SmallerTimes, vec2[i].Y / Setting.SmallerTimes);
            }
            return vec2;
        }
        protected Vec2[] BiggerVec2(Vec2[] vec2)
        {
            int vertexCount = vec2.Count();
            for (int i = 0; i < vertexCount; i++)
            {
                vec2[i] = new Vec2(vec2[i].X * Setting.SmallerTimes, vec2[i].Y * Setting.SmallerTimes);
            }
            return vec2;
        }
        public void test()
        {
            graphicManager = GameManager.GetInstance().GraphicManager;
            AABB worldAABB = new AABB();
            worldAABB.LowerBound.Set(0, 0);
            worldAABB.UpperBound.Set(graphicManager.BoxWidth, graphicManager.BoxHeight);
            Vec2 gravity = new Vec2();
            gravity.Set(Setting.GravityX, Setting.GravityY);
            bool doSleep = true;
            world = new World(worldAABB, gravity, doSleep);

            //_contactListener.test = this;
            //_world.SetContactListener(_contactListener);
            world.SetDebugDraw(debugDraw);

            
                    PolygonDef shape = new PolygonDef();
                    shape.SetAsBox(5f, 20.0f);

                    BodyDef bd = new BodyDef();
                    bd.Position = new Box2DX.Common.Vec2(300.0f, 40.0f);
                    Body body = world.CreateBody(bd);
                    shape.Density = 2f;
                    body.CreateFixture(shape);
            //body.SetMassFromShapes();

            PolygonDef shape2 = new PolygonDef();
            shape2.SetAsBox(5f, 20.0f);

            BodyDef bd2 = new BodyDef();
            bd2.Position = new Box2DX.Common.Vec2(300.0f, 100.0f);
            Body body2 = world.CreateBody(bd2);
            shape2.Density = 2f;
            body2.CreateFixture(shape2);
            body2.SetMassFromShapes();

            RevoluteJointDef rjd = new RevoluteJointDef();
            Vec2 c = body2.GetWorldCenter();
            c.Y += 20;
            rjd.Initialize(body2, body, c);
                    rjd.MotorSpeed = 100.0f * Setting.PI;
                    rjd.MaxMotorTorque = 10000.0f;
            rjd.EnableMotor = false; 
            
             world.CreateJoint(rjd);
            
                
            uint flags = 0;
            flags += (uint)DebugDraw.DrawFlags.Shape;
            flags += (uint)DebugDraw.DrawFlags.Joint;
            flags += (uint)DebugDraw.DrawFlags.CoreShape;
            flags += (uint)DebugDraw.DrawFlags.Aabb;
            flags += (uint)DebugDraw.DrawFlags.Obb;
            flags += (uint)DebugDraw.DrawFlags.Pair;
            flags += (uint)DebugDraw.DrawFlags.CenterOfMass;
            flags += (uint)DebugDraw.DrawFlags.Controller;
            debugDraw.Flags = (DebugDraw.DrawFlags)flags;

            float timeStep = 1.0f / 60.0f;
            int velocityIterations = 8;
            int positionIterations = 1;

            //Vec2 c = body.GetWorldCenter();
            body2.ApplyImpulse(new Vec2(0, 100), new Vec2(0, 0));
            //body2.ApplyImpulse(new Vec2(0, 100), new Vec2(300, 100));
            for (int i =0; i<120; i++)
            {
                // Instruct the world to perform a single step of simulation. It is
                // generally best to keep the time step and iterations fixed.
                GameManager.GetInstance().GraphicManager.ClearAllDraw();
                //leftFlipper.ApplyForce(leftFlipper., leftFlipper.GetWorldCenter());
                world.Step(timeStep, velocityIterations, positionIterations);
                GameManager.GetInstance().GraphicManager.EndDraw();
            }
        }
    }
    

    public class MyDebugDraw : DebugDraw
    {
        private float SmallerTimes;

        public MyDebugDraw()
        {
            //物理环境和显示环境相差的倍数
            SmallerTimes = Setting.SmallerTimes;
        }
        public override void DrawCircle(Vec2 center, float radius, Color color)
        {
            Console.WriteLine(center.X + " " + center.Y + " " + radius);
            GameManager.GetInstance().GraphicManager.MyDrawFullCircle(new System.Drawing.PointF(center.X * SmallerTimes, center.Y * SmallerTimes), radius * SmallerTimes);
        }

        public override void DrawPolygon(Vec2[] vertices, int vertexCount, Color color)
        {
            System.Drawing.PointF[] pointf = new System.Drawing.PointF[vertexCount];
            for (int i = 0; i < vertexCount; i++)
            {
                pointf[i] = new System.Drawing.PointF(vertices[i].X * SmallerTimes, vertices[i].Y * SmallerTimes);
            }
            GameManager.GetInstance().GraphicManager.MyDrawPolygon(pointf, MySize.sizeX1);
        }

        public override void DrawSegment(Vec2 p1, Vec2 p2, Color color)
        {
            GameManager.GetInstance().GraphicManager.MyDrawLine(p1.X * SmallerTimes, p1.Y * SmallerTimes, p2.X * SmallerTimes, p2.Y * SmallerTimes);
        }

        public override void DrawSolidCircle(Vec2 center, float radius, Vec2 axis, Color color)
        {
            GameManager.GetInstance().GraphicManager.MyDrawFullCircle(new System.Drawing.PointF((center.X - radius) * SmallerTimes, (center.Y - radius) * SmallerTimes), radius * SmallerTimes);
        }

        public override void DrawSolidPolygon(Vec2[] vertices, int vertexCount, Color color)
        {
            System.Drawing.PointF[] pointf = new System.Drawing.PointF[vertexCount];
            for (int i = 0; i < vertexCount; i++)
            {
                pointf[i] = new System.Drawing.PointF(vertices[i].X * SmallerTimes, vertices[i].Y * SmallerTimes);
            }
            GameManager.GetInstance().GraphicManager.MyDrawFullPolygon(pointf, MySize.sizeX1);
        }

        public override void DrawXForm(XForm xf)
        {
            //throw new NotImplementedException();
        }

        
    }

    public class MyContactListener : ContactListener
    {
        public void BeginContact(Contact contact)
        {
            OnCollisionEnter(contact.FixtureA, contact.FixtureB);
            OnCollisionEnter(contact.FixtureB, contact.FixtureA);
        }

        public void EndContact(Contact contact)
        {
            OnCollisionExit(contact.FixtureA, contact.FixtureB);
            OnCollisionExit(contact.FixtureB, contact.FixtureA);
        }

        public void PreSolve(Contact contact, Manifold oldManifold)
        {
            //throw new NotImplementedException();
        }

        public void PostSolve(Contact contact, ContactImpulse impulse)
        {
            //throw new NotImplementedException();
        }


        /// <summary>
        /// A 为Ball
        /// </summary>
        /// <param name="bodyA"></param>
        /// <param name="bodyB"></param>
        private void OnCollisionEnter(Fixture FixtureA, Fixture FixtureB)
        {
            Body bodyA = FixtureA.Body;
            Body bodyB = FixtureB.Body;
            MyGizmo gizmoA = (MyGizmo)bodyA.GetUserData();
            MyGizmo gizmoB = (MyGizmo)bodyB.GetUserData();
            //防止非用户定义物体导致出错
            if (gizmoB == null || gizmoA == null)
            {
                return;
            }
            //BodyA不是球则直接返回
            if (gizmoA.shape != MyShape.BallShape)
            {
                if (gizmoB.shape != MyShape.BallShape && !Setting.AllowCollisionTwice)
                {
                    bodyB.PutToSleep();
                }
                return;
            }
            //一般情况
            switch (gizmoB.shape)
            {
                case MyShape.AbsorptionShape:
                    PhysicalManager.GetInstance().allDeletedGizmoBody.Add(bodyA);
                    break;
                case MyShape.BallShape:
                    break;
                case MyShape.CircleShape:
                    if (gizmoB.isRail)
                    {
                        FixtureA.Restitution = 0;
                    }
                    break;
                case MyShape.FlipperBiasShape:
                    break;
                case MyShape.FlipperShape:
                    break;
                case MyShape.IsoscelesTrapezoidShape:
                    if (gizmoB.isRail)
                    {
                        FixtureA.Restitution = 0;
                        int temp = 1;
                        if (!Setting.RailDirection)
                        {
                            temp = -1 * temp;
                        }
                        bodyA.ApplyImpulse(new Vec2(Setting.RailForce * temp, 0), bodyA.GetWorldCenter());
                    }
                    break;
                case MyShape.RailShape:
                    break;
                case MyShape.RTShape:
                    if (gizmoB.isRail)
                    {
                        FixtureA.Restitution = 0;
                    }
                    break;
                case MyShape.SquareShape:
                    if (gizmoB.isRail)
                    {
                        FixtureA.Restitution = 0;
                        int temp = 1;
                        if (!Setting.RailDirection)             
                        {                
                            temp = -1 * temp;
                        }                
                        bodyA.ApplyImpulse(new Vec2(Setting.RailForce * temp, 0), bodyA.GetWorldCenter());
                    }
                    break;
                case MyShape.WallShape:
                    break;
                default:
                    break;
            }
        }

        private void OnCollisionExit(Fixture FixtureA, Fixture FixtureB)
        {
            Body bodyA = FixtureA.Body;
            Body bodyB = FixtureB.Body;
            MyGizmo gizmoA = (MyGizmo)bodyA.GetUserData();
            MyGizmo gizmoB = (MyGizmo)bodyB.GetUserData();
            //防止非用户定义物体导致出错
            if (gizmoB == null || gizmoA == null)
            {
                return;
            }
            //BodyA不是球则直接返回
            if (gizmoA.shape != MyShape.BallShape)
            {
                return;
            }
            //轨道特殊情况
            if (gizmoB.isRail)
            {
                FixtureA.Restitution = Setting.Restitution;
            }
        }
    };

    
}

