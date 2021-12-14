using System;

namespace Deledates
{
    class Program
    {
        public delegate void Operation(int x, int y);
       
        static void Main(string[] args)
        {

            Operation o1 = new Operation((int x, int y) => { Console.WriteLine($"o1: {x} + {y} = {x + y}"); });
            Operation o2 = new Operation((int x, int y) => { Console.WriteLine($"o2: {x} - {y} = {x - y} "); });
            Operation o3 = new Operation((int x, int y) => { Console.WriteLine($"o3: {x} * {y} = {x * y} "); });

            /* Delegate chain */
            Operation oChain = null;

            oChain = (Operation)Delegate.Combine(oChain, o1);
            oChain = (Operation)Delegate.Combine(oChain, o2);
            oChain = (Operation)Delegate.Combine(oChain, o3);

            Console.WriteLine("----- First invoking: -----");
            oChain.Invoke(5, 2);

            oChain = (Operation)Delegate.Remove(oChain, o2);

            Console.WriteLine("----- Second invoking: -----");
            oChain.Invoke(5, 2);

            oChain += o2;
            Console.WriteLine("----- Third invoking: -----");
            oChain.Invoke(5, 2);


            /* Array of Delegates */
            Operation[] delArray =
            {
               new Operation((int x, int y) => { Console.WriteLine($"Some operation with {x} and {y}..."); }),
               new Operation((int x, int y) => { Console.WriteLine($"Another operation with {x} and {y}..."); })
            };

            for (int i = 0; i < delArray.Length; i++)
            {
                delArray[i](2, 5);
                delArray[i](8, 5);
                delArray[i](4, 6);
            }


            /* Anonymous Methods */
            Operation obj = delegate (int a, int b)
            {
                Console.WriteLine($"Anonymous method: {a} + {b} = {a + b}");
            };
            obj(4, 8);




            Console.ReadKey();

        }
    }
}
