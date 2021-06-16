using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WPFBasic_FirstPrismEx
{
    public class Calculator : ICalculator
    {
        public  int Add(Arguments args)
        {
            return (args.X + args.Y);
        }

        public int Sub(Arguments args)
        {
            return (args.X - args.Y);
        }


        public int Mul(Arguments args)
        {
            return (args.X * args.Y);
        }

        public int Div(Arguments args)
        {
            return (args.X / args.Y);
        }

        public int Execute(CommandTypes commandType, Arguments args)
        {
            switch (commandType)
            {
                        
                case CommandTypes.Add:
                    return Add(args);
                    
                case CommandTypes.Sub:
                    return Sub(args);
                    
                case CommandTypes.Mul:
                    return Mul(args);
                    
                case CommandTypes.Div:
                    return Div(args);
                    
                 default:
                    break;
                    throw new InvalidOperationException();
            }
            return 0;
        }
    }
}
