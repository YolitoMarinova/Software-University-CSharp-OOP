﻿namespace _03.StudentSystem
{
   public class StartUp
    {
       public static void Main()
        {
            StudentSystem studentSystem = new StudentSystem();

            while (true)
            {
                studentSystem.ParseCommand();
            }
        }
    }
}
