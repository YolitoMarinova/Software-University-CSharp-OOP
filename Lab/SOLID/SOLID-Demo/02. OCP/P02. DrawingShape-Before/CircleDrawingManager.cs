using P02._DrawingShape_Before.Contracts;

namespace P02._DrawingShape_Before
{
    public class CircleDrawingManager : DrawingManager
    {
        protected override void DrawFigure(IShape shape)
        {
            var circle = shape as Circle;

            //Draw Circle
        }
    }
}
