using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrainFuck;

namespace BrainFK
{
    class Program
    {
        static void Main(string[] args)
        {
            var v = new BrainFuck.BrainFuck(0);
            v.LoadProgram(@">++++++++++
[>++++++++>+++++++++++>+++++++++++>++++++++++>+++++++++++>+++++++++++>+++++++++++>++++++++++++>++++++++++++>+++++++++++>++++++++++>+++++++++++>+++++++++++>+++++++++++>+++++++++++>++++++++++++>+++++++++++>++++++++++++>++++++++++>+++++++++++>++++++++++>++++++++++++><<<<<<<<<<<<<<<<<<<<<<<-]
>---->+>++++>+>->----->++>----->--->->>+>-->+>++++>----->----->---->--->->+>---->
<<<<<<<<<<<<<<<<<<<<<<<
>.>.>.>.>.>.>.>.>.>.>.>.>.>.>.>.>.>.>.>.>.>.\\".ToArray());
            v.OnDot += ( a, b ) => Console.Write(b);
            v.OnEnd += ( a, b ) => Console.ReadKey();
            v.Start();

        }
    }
}
