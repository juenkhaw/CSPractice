using System;

namespace IndexerDEMO
{
    public class IndexedNames
    {
        private string[] namelist = new string[size];
        static public int size = 10;

        public IndexedNames()
        {
            for (int i = 0; i < size; i++)
            {
                namelist[i] = "N/A";
            }
        }

        //declaration of behaviour of indexers using get and set accessor and mutator
        public string this[int index]
        {
            get
            {
                if (index >= 0 && index < size) return namelist[index];
                else return "ACCESS FAILED - INDEX OUT OF BOUND";
            }
            set
            {
                if (index >= 0 && index < size) namelist[index] = value;
                else Console.WriteLine("INSERTION FAILED - INDEX OUT OF BOUND");
            }
        }

        //overloaded indexer
        public int this[string name]
        {
            get
            {
                int index = 0;
                foreach (string s in namelist)
                {
                    if (s == name) return index;
                    else index++;
                }
                Console.WriteLine("ACCESS FAILED - NAME IS NOT FOUND");
                return -1;
            }
        }
    }

    public class IndexedNamesDEMO
    {
        public static void IndexerMain()
        {
            IndexedNames indexer = new IndexedNames();
            indexer[2] = "lee Kwang Soo";
            Console.WriteLine(
                "indexer[2] = " + indexer[2] + "\n" 
                + "indexer[0] = " + indexer[0] + "\n"
                + "indexer[11] = " + indexer[11] + "\n"
                + "indexer[leekwangsoo] = " + indexer["lee Kwang Soo"]
                );
        }
    }
}
