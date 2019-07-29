using System;

[Author("Yoana")]
public class StartUp
{
    [Author("Yoana")]
    public static void Main()
    {
        Tracker tracker = new Tracker();
        tracker.PrintMethodsByAuthor();
    }
}

