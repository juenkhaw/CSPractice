#define CONDITION1

using System;
using System.Diagnostics;
using System.Reflection;

/*
 * Attributes are used as metadata, which conveys runtime information of the behaviour of elements
 * Metadata such as compiler instruction, comment, and description
 * [attribute_name (positional_parameters, name_parameter = value, ...)]
 * element
*/

namespace AttributesDEMO

    //Creation of custom attributes allows to store declarative information and retrieve it at runtime
{
    //AttributeUsage describes how a custom attribute class can be used
    [DebugInfo(1, "Haku", "5/1/2018", Message = "Bug 1")]
    [DebugInfo(1, "Lycanroc", "5/1/2018", Message = "Bug 1 fixed")]
    [AttributeUsage(
        AttributeTargets.Class | //parameter validation specifies which elements can be placed
        AttributeTargets.Constructor | //default = AttributeTargets.All
        AttributeTargets.Field |
        AttributeTargets.Method |
        AttributeTargets.Property,
        AllowMultiple = true, //if true, the attribute is multiuse
        Inherited = false //if true, the attribute is inherited by derived class
        )]
    public class DebugInfo : System.Attribute
    {
        private int bugNo;
        private string developer, lastReview;
        public string message;

        public DebugInfo(int bugNo, string developer, string lastReview)
        {
            this.bugNo = bugNo;
            this.developer = developer;
            this.lastReview = lastReview;
        }

        public int BugNo
        {
            get {
                return bugNo;
            }
        }

        public string Developer
        {
            get
            {
                return developer;
            }
        }

        public string LastReview
        {
            get
            {
                return lastReview;
            }
        }

        public string Message
        {
            get
            {
                return message;
            }
            set
            {
                message = value;
            }
        }
        public override string ToString()
        {
            return string.Format("{0} - {1} - {2} - {3}", bugNo, developer, lastReview, message);
        }
    }

    [DebugInfo(2, "Princess Leia", "6/1/2018", Message = "Bug 2")]
    public class Class1
    {
        [DebugInfo(3, "Nakayama", "6/1/2018", Message = "Bug 3")]
        [DebugInfo(3, "Princess Leia", "6/1/2018", Message = "Bug 3 fixed")]
        public static void printMsg(string msg)
        {
            Console.WriteLine(msg);
        }
    }

    public class TestClass
    {
        //Conditional attributes use as #IF which the element below it will run if the condition is defined
        [Conditional("CONDITION1")]
        static void testF1()
        {
            Class1.printMsg("Inside function1");
        }
        //As CONDITION2 is not defined, so the element below it will not run
        [Conditional("CONDITION2")]
        static void testF2()
        {
            Class1.printMsg("Inside function2");
        }

        /*
         * There is reason to use Conditional attributes than #IF, which affects the readability
         * #IF DEBUG
         * doSomething();
         * #ENDIF
         * main() {
         *  #IFDEBUG
         *  doSomething();
         *  #ENDIF
         * }
         * The code will run but looks ugly
        */

        //Obsolete attributes mark an entity that should not be used by informing compiler to discard it or displaying warning message
        [Obsolete(
            "Do not use old method, please check for new method",  //message to be displayed
            false)]  //isError which if true, using the targeted entity will be an error, default is false
        static void oldTestF1()
        {
            Class1.printMsg("Inside old function1");
        }

        static void testReflection()
        {
            //retrieve metadata about attributes associated with the targeted element
            Type type = typeof(Class1);

            //retrieve attributes information from the element itself
            Console.WriteLine(type.Name);
            foreach (object attr in type.GetCustomAttributes(false))
            { //bool indicates whether to retrieve attributes from its ancestor
                DebugInfo dbi = (DebugInfo)attr;
                if(dbi!=null)
                    Console.WriteLine(dbi);
            }

            //iterate through each method associated with the targeted element
            foreach (MethodInfo mdi in type.GetMethods())
            {
                Console.WriteLine(mdi.Name);
                //retrieve method attribute from each method info
                foreach (Attribute attr in mdi.GetCustomAttributes(true))
                {
                    DebugInfo dbi;
                    try
                    {
                        //conversion of attribute to the custom user-defined attribute might not applicable for built-in methods
                        //ToString(), GetHashCode()
                        dbi = (DebugInfo)attr;
                    } catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        continue;
                    }
                    if (dbi != null)
                        Console.WriteLine(dbi);
                }
            }
        }

        public static void AttributesMain()
        {
            Class1.printMsg("Inside main function");
            testF1();
            testF2();
            testF1();
            //oldTestF1();
            testReflection();
        }
    }
}
