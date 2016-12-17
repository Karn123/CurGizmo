using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gizmo
{
    class GizmoFactory
    {
        private MyGizmo gizmo = null;
        public GizmoFactory()
        {

        }
        public MyGizmo returnGizmo(MyShape nowShape)
        {
            switch (nowShape)
            {
                case MyShape.BallShape:
                    gizmo = new Ball();
                    break;
                case MyShape.FlipperShape:
                    gizmo = new Flipper();
                    break;
                case MyShape.FlipperShape1:
                    gizmo = new Flipper1();
                    break;
                case MyShape.FlipperBiasShape:
                    gizmo = new FlipperBias();
                    break;
                case MyShape.FlipperBiasShape1:
                    gizmo = new FlipperBias1();
                    break;
                case MyShape.RailShape:
                    gizmo = new Rail();
                    break;
                case MyShape.AbsorptionShape:
                    gizmo = new Absorption();
                    break;
                case MyShape.WallShape:
                    gizmo = new Wall();
                    break;
                case MyShape.CircleShape:
                    gizmo = new Circle();
                    break;
                case MyShape.RTShape:
                    gizmo = new RT();
                    break;
                case MyShape.IsoscelesTrapezoidShape:
                    gizmo = new IsoscelesTrapezoid();
                    break;
                case MyShape.SquareShape:
                    gizmo = new Square();
                    break;
                default:
                    break;
            }
            return gizmo;
        } 

    }
}