using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to HashTable Program");
            MyMapNode<int, string> hash = new MyMapNode<int, string>(15);//creating object and Key and value datatype is string and size is 5


            //creating a string of sentence
            string phrase = "Paranoids are not paranoid because they are paranoid but because they keep putting themselves deliberately into paranoid avoidable situations";

            //adding values into array
            string[] words = phrase.Split(' ');//split method is used 
                                               //split string into substrings

            int a = 1;
            foreach (var element in words)
            {
                hash.Add(a, element);
                a++;

            }

            int index = 18;
            string choice = hash.Get(index);  // getting the specific value from hashtable.

            Console.WriteLine("{0}th index values : is {1}", index, choice);

            int index2 = 15;
            string choice2 = hash.Get(index2);
            Console.WriteLine("{0}th index values : is {1}", index2, choice2);
            hash.Display();
            Console.Read();


        }
    }

}

