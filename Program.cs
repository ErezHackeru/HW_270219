using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW270219_operator_Overloading
{
    class Program
    {
        static void Main(string[] args)
        {
            Camp c1 = new Camp(345, 256, 5, 20, 25);
            Camp c2 = new Camp(439, 654, 40, 4, 23);

            if (c1 > c2)
                Console.WriteLine("c1 is bigger");
            else
                Console.WriteLine("c2 is bigger");

            Camp c3 = c1 + c2;
            Console.WriteLine($"c3 is : {c3}");

            string filename = @"D:\Temppp\CampSer.xml";
            Camp2 c4 = new Camp2(4, 456, 123, 56, 102, 500, 4);
            Camp2.SerializeACamp(filename, c4);

            Camp2 ca1 = Camp2.DeserializeACamp(filename);
            Camp2 ca2 = Camp2.DeserializeACamp(filename);

            Console.WriteLine($"Is Equal == {ca1==ca2}");
            int a = ca1.GetHashCode();
            int b = ca2.GetHashCode();
            Console.WriteLine($"camp1 Hashcode: {a}, camp2 Hashcode: {b}");

            Console.ReadKey();
        }
    }
}
