using System;

namespace TypeConversionDEMO
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
}
