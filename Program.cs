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

            for (int i = n; i > 0; i--)
            {
                startingPillar.Push(i);

            }


            MovePlates(startingPillar.Count, startingPillar, finalPillar, middlePillar, startingPillar, finalPillar, middlePillar);
            PlatePrinter(startingPillar, finalPillar, middlePillar);
            Console.WriteLine("the end");
            Console.ReadLine();
        }

        static void MovePlates(int n, Stack<int> start, Stack<int> final, Stack<int> middle, Stack<int> s, Stack<int> f, Stack<int> m)
        {

            Console.ForegroundColor = ConsoleColor.Green;
            PlatePrinter(s, f, m);
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.White;
            PlatePrinter(start, final, middle);
            Console.WriteLine("n = " + n);
            Console.WriteLine();
            Console.WriteLine();

            //print plates
            if (n >= 1)
            {
                MovePlates(n - 1, start, middle, final, s, f, m);


                Console.ForegroundColor = ConsoleColor.Green;
                PlatePrinter(s, f, m);
                Console.WriteLine();

                Console.ForegroundColor = ConsoleColor.White;
                PlatePrinter(start, final, middle);
                Console.WriteLine("n = " + n);
                Console.WriteLine();
                Console.WriteLine();
                

                final.Push(start.Pop());

                Console.ForegroundColor = ConsoleColor.Green;
                PlatePrinter(s, f, m);
                Console.WriteLine();

                Console.ForegroundColor = ConsoleColor.White;
                PlatePrinter(start, final, middle);
                Console.WriteLine("n = " + n);
                Console.WriteLine();
                Console.WriteLine();


                MovePlates(n - 1, middle, final, start, s, f, m);



                Console.ForegroundColor = ConsoleColor.Green;
                PlatePrinter(s, f, m);
                Console.WriteLine();

                Console.ForegroundColor = ConsoleColor.White;
                PlatePrinter(start, final, middle);
                Console.WriteLine("n = " + n);
                Console.WriteLine();
                Console.WriteLine();


            }
        }

        static void PlatePrinter(Stack<int> start, Stack<int> final, Stack<int> middle)
        {

            Stack<int> tempStart = new Stack<int>(start.Reverse());

            Stack<int> tempFinal = new Stack<int>(final.Reverse());
            Stack<int> tempMiddle = new Stack<int>(middle.Reverse());
            //we figure out the highest stack because that's the number of rows
            int highestStack = 0;
            if (start.Count > highestStack) { highestStack = start.Count; }
            if (middle.Count > highestStack) { highestStack = middle.Count; }
            if (final.Count > highestStack) { highestStack = final.Count; }
            int temp;
            //int numPlates = tempStart.Count;
            int numPlates = tempStart.Count + tempMiddle.Count + tempFinal.Count;

            //loop going through all the rows that will be printed
            for (int i = numPlates; i > 0; i--)
            {
                string stringToPrint = "";


                //Console.WriteLine(stringToPrint.Count());
                //since this prints top down it needs to make sure there's a value in that slot
                if (tempStart.Count >= i)
                {
                    temp = tempStart.Pop();
                    for (int j = numPlates - temp; j > 0; j--)
                    {
                        stringToPrint += " ";
                    }
                    stringToPrint += "/";
                    int spaceCounter = 0;
                    //adds value of plate # of dashes
                    for (int k = temp; k > 0; k--)
                    {
                        if (spaceCounter < temp) stringToPrint += " ";
                        stringToPrint += "-";
                    }
                    stringToPrint += "\\";

                    for (int m = numPlates - temp; m > 0; m--)
                    {
                        stringToPrint += " ";
                    }
                }
                else
                {
                    for (int l = numPlates; l > 0; l--)
                    {
                        stringToPrint += " ";
                    }
                    //Console.WriteLine(stringToPrint.Count());
                    stringToPrint += "|";
                    stringToPrint += " ";
                    for (int l = numPlates; l > 0; l--)
                    {
                        stringToPrint += " ";
                    }
                    //draw a pole
                }


                //Console.WriteLine("end of block one");
                //Console.WriteLine(stringToPrint.Count());

                if (tempMiddle.Count >= i)
                {
                    temp = tempMiddle.Pop();
                    for (int j = numPlates - temp; j > 0; j--)
                    {
                        stringToPrint += " ";
                    }
                    stringToPrint += "/";
                    int spaceCounter = 0;
                    //adds value of plate # of dashes
                    for (int k = temp; k > 0; k--)
                    {
                        if (spaceCounter <= temp - 1) stringToPrint += " ";
                        stringToPrint += "-";
                    }
                    stringToPrint += "\\";

                    for (int m = numPlates - temp; m > 0; m--)
                    {
                        stringToPrint += " ";
                    }
                }
                else
                {
                    for (int l = numPlates; l > 0; l--)
                    {
                        stringToPrint += " ";
                    }
                    //Console.WriteLine(stringToPrint.Count());
                    stringToPrint += "|";
                    stringToPrint += " ";
                    for (int l = numPlates; l > 0; l--)
                    {
                        stringToPrint += " ";
                    }
                    //draw a pole
                }

                // Console.WriteLine("end of block two");
                //Console.WriteLine(stringToPrint.Count());

                if (tempFinal.Count >= i)
                {
                    temp = tempFinal.Pop();
                    for (int j = numPlates - temp; j > 0; j--)
                    {
                        stringToPrint += " ";
                    }
                    stringToPrint += "/";
                    int spaceCounter = 0;
                    //adds value of plate # of dashes
                    for (int k = temp; k > 0; k--)
                    {
                        if (spaceCounter <= temp - 1) stringToPrint += " ";
                        stringToPrint += "-";
                    }
                    stringToPrint += "\\";

                    for (int m = numPlates - temp; m > 0; m--)
                    {
                        stringToPrint += " ";
                    }
                }
                else
                {
                    for (int l = numPlates; l > 0; l--)
                    {
                        stringToPrint += " ";
                    }
                    //Console.WriteLine(stringToPrint.Count());
                    stringToPrint += "|";
                    stringToPrint += " ";
                    for (int l = numPlates; l > 0; l--)
                    {
                        stringToPrint += " ";
                    }
                    //draw a pole
                }
                //Console.WriteLine("end of block three");
                //Console.WriteLine(stringToPrint.Count());
                Console.WriteLine(stringToPrint);

            }


        }


    }
}
