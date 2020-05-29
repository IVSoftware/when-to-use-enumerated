using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static IVSoftware.Window;
using Console = IVSoftware.Console;

namespace wpf_window_ex
{
    class Program
    {
        class MyPrioritizedObject : IComparable<MyPrioritizedObject>
        {
            public MyPrioritizedObject(string name, int priority)
            {
                Name = name;
                Level = priority;
            }
            public int Level { get; set; }
            public string Name { get; }

            // This gives you fine control over how a list of your object will sort.
            public int CompareTo(MyPrioritizedObject other)
            {
                return this.Level.CompareTo(other.Level);
            }
            // This gives you the ability to display the Priority property however you want.
            public override string ToString()
            {
                return "LEVEL " + Level.ToString() + ": " + Name;
            }
        }

        public static void Main(string[] args)
        {
            List<MyPrioritizedObject> someList = new List<MyPrioritizedObject>();

            someList.Add(new MyPrioritizedObject("Apple", 3));
            someList.Add(new MyPrioritizedObject("Orange", 2));
            someList.Add(new MyPrioritizedObject("Grape", 1));

            someList.Sort();

            foreach (var someObject in someList)
            {
                Console.WriteLine(someObject);
            }

            // Pause to see output
            // Console.ReadKey();
        }
    }
}
