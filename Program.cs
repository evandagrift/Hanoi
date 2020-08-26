using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tower_of_Hanoi
{
    class Program
    {
        static void Main(string[] args)
        {

            //-1 to check for errors if need be
            int n = -1;


            //tries to get an int input of how many plates the player wants to move
            Console.Write("How many plates would you like to move? ");
            try
            {
                n = Int32.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("inproper input, defaulting at 4 plates");
                n = 4;
            }

            Stack<int> startingPillar = new Stack<int>();
            Stack<int> middlePillar = new Stack<int>();
            Stack<int> finalPillar = new Stack<int>();

            for(int i = n; i > 0; i--)
            {
                startingPillar.Push(i);
            }
            PlatePrinter(startingPillar, finalPillar, middlePillar);
            Console.ReadLine();
        }

        static void MovePlates(int n, Stack<int> start, Stack<int> final, Stack<int> middle)
        {
            //print plates
            if (n >= 1)
            {
                MovePlates(n - 1, start, middle, final);
                final.Push(start.Pop());
                Console.WriteLine("plate ");

                MovePlates(n-1, middle, final, start);
            }
        }

        static void PlatePrinter(Stack<int> start, Stack<int> final, Stack<int> middle)
        {
            Stack<int> tempStart = start;
            Stack<int> tempFinal = final;
            Stack<int> tempMiddle = middle;

            //we figure out the highest stack because that's the number of rows
            int highestStack = 0;
            if (start.Count > highestStack) { highestStack = start.Count; }
            if (middle.Count > highestStack) { highestStack = middle.Count; }
            if (final.Count > highestStack) { highestStack = final.Count; }
           
            //loop going through all the rows that will be printed
            for(int i = highestStack; i > 0; i--)
            {
                string stringToPrint ="";

                //since this prints top down it needs to make sure there's a value in that slot
                if(tempStart.Count >= i)
                {
                    for(int j = spacer; j < 0; j--)
                    {
                        stringToPrint += " ";
                    }

                    stringToPrint += "/";
                    //adds value of plate # of dashes
                    for(int k = listAllPlates[i]; k > 0; k--)
                    {
                        stringToPrint += "-";
                    }

                    stringToPrint += "\\";
                    Console.WriteLine();

                }
                else
                { 
                    //draw a pole


                }

                
            }
            

        }

   
    }
}
