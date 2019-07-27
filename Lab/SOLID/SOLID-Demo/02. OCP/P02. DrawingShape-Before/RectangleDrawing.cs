using P02._DrawingShape_Before.Contracts;

namespace P02._DrawingShape_Before
{
    public class RectangleDrawing : DrawingManager
    {
        protected override void DrawFigure(IShape shape)
        {
            var rectangle = shape as Rectangle;

            //Draw Rectangle
        }
    }
}
