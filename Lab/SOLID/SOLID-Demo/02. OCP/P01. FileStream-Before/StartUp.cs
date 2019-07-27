using System;

namespace P01._FileStream_Before
{
    public class StartUp
    {
        public static void Main()
        {
            File file = new File();
            file.Length = 10;
            file.Sent = 10;

            Progress progress = new Progress(file);
            Console.WriteLine(progress.CurrentPercent());
        }
    }
}
