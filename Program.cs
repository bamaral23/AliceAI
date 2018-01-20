using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AliceAI
{
    class Program
    {
        static void Main(string[] args)
        {
            Alice alice = new Alice(new State("23232222"));
            alice.learn(new State(""));
            Console.WriteLine("Success!");
            foreach (Action action in alice.actionList){
                Console.WriteLine(action.ToString());
            }
            Console.ReadLine();

        }
        
    }

}
