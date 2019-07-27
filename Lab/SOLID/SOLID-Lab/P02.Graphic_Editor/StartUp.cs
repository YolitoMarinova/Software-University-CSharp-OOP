namespace P02.Graphic_Editor
{
    public class StartUp
    {
        public static void Main()
        {
            Rectangle rectangle = new Rectangle();

            GraphicEditor graphicEditor = new GraphicEditor();

            graphicEditor.DrawShape(rectangle);
        }
    }
}
