using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSGizmoBox.LocalCache
{
    public class LCacheExample
    {
        static void Main(string[] args) {

            LCache.Set("1", "11");

            var content = LCache.Get("1");
            Console.WriteLine($"Get(1): {content}");


            content = LCache.Get("2");
            Console.WriteLine($"Get(2): {content}");


            content = LCache.Get("3", defaultValue:"3>>3", addIfNotFound:true);
            Console.WriteLine($"Get(3): {content}");


            LCache.Set("4", "4 >> 1 second", 1);

            content = LCache.Get("4");
            Console.WriteLine($"Get(4): {content}");


            Console.WriteLine(">> Dump <<");
            Console.WriteLine(LCache.Dump());



            Console.WriteLine("Sleeping 2 seconds..................................");
            Thread.Sleep(2000);



            content = LCache.Get("4");
            Console.WriteLine($"Get(4): {content}");


            Console.WriteLine(">> Dump <<");
            Console.WriteLine(LCache.Dump());



        }
    }
}
