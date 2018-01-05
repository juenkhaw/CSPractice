using System;

namespace BasicDEMO
{
    class TypeConversion
    {
        public static void ExplicitConversionMain()
        {
            double d = 3.14572;
            //explicit datatypes conversion
            int i = (int)d;
            Console.WriteLine("(int)d = " + i);
        }

        public static void ImplicitConversionMain()
        {
            double d = 2345.7652;
            bool b = true;
            string s = "54rr";

            Console.WriteLine("Convert.ToString(d) = " + Convert.ToString(d));
            try
            {
                Console.WriteLine("Convert.ToInt32(s) = " + Convert.ToInt32(s));
            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message + '\n' + ex.StackTrace);
            }
            Console.WriteLine("b.ToString() = " + b.ToString());
        }
    }

    class Nuallable
    {
        public static void NullableMain()
        {
            //allow assigning of null value on variable
            int? num1 = null;
            int? num2 = 54;
            double? d1 = new double?();
            Console.WriteLine("num1:{0} - num2:{1} - d1:{2}", num1, num2, d1);

            //if the first value of operand is null, then it returns the second one
            int num3 = num1 ?? 53;
            Console.WriteLine("num3:{0} - d1??3.14:{1}", num3, d1??3.142);
        }
    }
}
