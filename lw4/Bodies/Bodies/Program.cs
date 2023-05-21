using System;
using System.IO;
using System.Collections.Generic;

namespace Bodies
{
    class Program
    {
        static void Main(string[] args)
        {
            List<CBody> bodies = new();

            System.IO.TextReader input = Console.In;
            System.IO.TextWriter output = Console.Out;

            RemoteControl controller = new RemoteControl(input, output, ref bodies);
            controller.StartProgram();

            output.Flush();
            input.Close();
            output.Close();
        }
    }
}
