using System;
using System.IO;

namespace DelegatesDEMO
{
    //delegate can refer to method with same signature as it
    //It can be used like a method pointer
    delegate int NumberOperator(int n);
    class DelegateTest
    {
        static int num = 10;
        static FileStream fs;
        static StreamWriter sw;

        public delegate void printString(string s);

        public static void writeToScreen(string s)
        {
            Console.WriteLine(s);
        }

        public static void writeToFile(string s)
        {
            fs = new FileStream("delegateMsg.txt", FileMode.Append, FileAccess.Write);
            sw = new StreamWriter(fs);
            sw.WriteLine(s);
            sw.Flush();
            sw.Close();
            fs.Close();
        }

        public static int addNum(int n)
        {
            num += n;
            return num;
        }

        public static int mulNum(int n)
        {
            num *= n;
            return num;
        }

        public static int getNum()
        {
            return num;
        }

        //this method takes the delegate as parameter and calls the method as required
        public static void sendString(printString ps)
        {
            ps("Hello World");
        }

        public static void delegatesMain()
        {
            //delegate object must be instantiated with new keyword and a particular method
            NumberOperator n1 = new NumberOperator(addNum);
            NumberOperator n2 = new NumberOperator(mulNum);

            Console.WriteLine("n1(25) = " + n1(25));
            Console.WriteLine("n2(20) = " + n2(20));

            num = 10;
            //delegate objects allows its component composed using '+' and removed using '-'
            //creation of list of invocation of method through multicasting
            NumberOperator multicast;
            multicast = n1;
            multicast += n2;
            multicast -= n1;
            Console.WriteLine("n1+n2-n1(20) = " + multicast(20));

            //pass delegate object into a function which invokes the relevant function
            printString ps1 = new printString(writeToScreen);
            printString ps2 = new printString(writeToFile);
            sendString(ps1);
            sendString(ps2);
        }
    }

    //PUBLISHER
    public delegate string MyDel(string s);

    //SUBSCRIBER
    class EventsTest
    {
        /*
         PUBLISHER-SUBSCRIBER MODEL
         * Events are declared in a class associated with event handlers using delegates
         * The class containing the event is called as the publisher with the definition of event and delegate
         * This class invokes the event
         * Class that accepts the event is called the subscriber class
         * This class provides event handler and invokes the method from itself
         */
        event MyDel MyEvent;
        public EventsTest()
        {
            this.MyEvent += new MyDel(this.welcomeUser);
        }

        public string welcomeUser(string username)
        {
            return "Welcome " + username;
        }

        public static void EventsMain()
        {
            EventsTest obj = new EventsTest();
            string result = obj.MyEvent("Haku");
            Console.WriteLine(result);
        }
    }
}
