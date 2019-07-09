using System;

namespace CustomStack
{
   public class StartUp
    {
       public static void Main()
        {
            StackOfStrings stack = new StackOfStrings();

            stack.Push("kak");

            StackOfStrings stack2 = new StackOfStrings();

            stack.AddRange(stack2);
        }
    }
}
