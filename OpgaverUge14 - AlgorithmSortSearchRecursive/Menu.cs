using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace OpgaverUge14___AlgorithmSortSearchRecursive
{
    public class Menu
    {

        DataHandler handler = new DataHandler("Students.txt");
        DataHandler handlerBubbleSorted = new DataHandler("StudentsBubbleSortedByName.txt");
        DataHandler handlerSelectionSorted = new DataHandler("StudentsSelectionSortedByTeamNum.txt");
        DataHandler handlerQuickSorted = new DataHandler("StudentsQuickSortedByName.txt");

        SortingAlgorithms sortingAlgorithms = new SortingAlgorithms();
        SearchAlgorithms searchAlgorithms = new SearchAlgorithms();

        //Øvelse 4.4: Skriv sorteret data i en tekstfil
        //  Nu efter du har implementeret sortering algoritmer skal du benytte dem i dit program.
        //  Udfør følgende:
        //	    •  I Program.cs skal du vise en menu for brugeren for at vælge sortering på Group Number eller på Navn og gemme valg i en variabel.
        //	    • Hvis valg er på Group Number, indkald selection sort metode. 
        //	    • Hvis valg er på Navn, vis en ny menu for brugeren for at vælge Bubble sort eller Quick sort og indkald den tilsvarende metode.
        //	    • På baggrund af valget, skal du nu benytte DataHandler klasse for at skrive sorteret data i en separat tekstfil.
        //  Vis en besked til brugeren, hvis skrivning er lykkedes, ellers vis en fejl besked.
        public void MainMenu()
        {
            bool exit = false;

            do
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Clear();

                Console.WriteLine("Sorterings- og søgningsalgoritmer");
                Console.WriteLine();
                Console.WriteLine("1. Vis en liste");
                Console.WriteLine("2. Sorter liste");
                Console.WriteLine("3. Søg i liste");
                Console.WriteLine();
                Console.WriteLine("Vælg et menupunkt, eller tryk 0 for at afslutte");

                string input = Console.ReadLine();
                int inputMenu;

                if (string.IsNullOrEmpty(input) || !int.TryParse(input, out inputMenu))
                {
                    inputMenu = -1;  // Set to -1 if input is empty or can't be parsed
                }

                switch (inputMenu)
                {
                    case -1:
                        goto default;
                    case 0:
                        exit = true;
                        break;
                    case 1:
                        MenuShowingSortedLists();
                        break;
                    case 2:
                        MenuForSorting();
                        break;
                    case 3:
                        MenuForSearching();
                        break;
                    default:
                        Console.Write("Forkert input, prøv igen!");
                        Console.ReadKey();
                        break;
                }

            } while (!exit);

        }

        /// <summary>
        /// Show menu for the different sorted lists (User input = 1 in MainMenu)
        /// </summary>
        public void MenuShowingSortedLists()
        {
            bool exit = false;

            do
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Clear();

                Console.WriteLine("Hvilken liste vil have vist?");
                Console.WriteLine();
                Console.WriteLine("1. Vis den usorterede liste");
                Console.WriteLine("2. Vis BubbleSorted efter navn");
                Console.WriteLine("3. Vis SelectionSorted efter Team nummer");
                Console.WriteLine("4. Vis QuickSorted efter navn");
                Console.WriteLine();
                Console.WriteLine("Vælg et menupunkt, eller tryk 0 for at vende tilbage til Main menuen");

                string input = Console.ReadLine();
                int inputMenu;

                if (string.IsNullOrEmpty(input) || !int.TryParse(input, out inputMenu))
                {
                    inputMenu = -1;  // Set to -1 if input is empty or can't be parsed
                }

                switch (inputMenu)
                {
                    case -1:
                        goto default;
                    case 0:
                        exit = true;
                        break;
                    case 1:
                        handler.LoadStudents();
                        handler.ShowStudents();
                        Console.ReadKey();
                        break;
                    case 2:
                        handlerBubbleSorted.LoadStudents();
                        handlerBubbleSorted.ShowStudents();
                        Console.ReadKey();
                        break;
                    case 3:
                        handlerSelectionSorted.LoadStudents();
                        handlerSelectionSorted.ShowStudents();
                        Console.ReadKey();
                        break;
                    case 4:
                        handlerQuickSorted.LoadStudents();
                        handlerQuickSorted.ShowStudents();
                        Console.ReadKey();
                        break;
                    default:
                        Console.Write("Forkert input, prøv igen!");
                        Console.ReadKey();
                        break;
                }



            } while (!exit);
        }



        public void MenuForSorting()
        {
            bool exit = false;

            do
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Clear();
                
                Console.WriteLine("Hvordan vil du sorterer listen");
                Console.WriteLine();
                Console.WriteLine("1. Bubble sort");
                Console.WriteLine("2. Selection sort");
                Console.WriteLine("3. Quick sort");
                Console.WriteLine();
                Console.WriteLine("Vælg et menupunkt, eller tryk 0 for at vende tilbage til Main menuen");

                string input = Console.ReadLine();
                int inputMenu;

                if (string.IsNullOrEmpty(input) || !int.TryParse(input, out inputMenu))
                {
                    inputMenu = -1;  // Set to -1 if input is empty or can't be parsed
                }

                switch (inputMenu)
                {
                    case -1:
                        goto default;
                    case 0:
                        exit = true;
                        break;
                    case 1:
                        handler.LoadStudents();
                        sortingAlgorithms.BubbleSort(handler._students);
                        handlerBubbleSorted.SaveStudents(handler._students);
                        Console.WriteLine("Du har sorteret listen med BubbleSort efter navn");
                        Console.ReadKey();
                        break;
                    case 2:
                        handler.LoadStudents();
                        sortingAlgorithms.SelectionSort(handler._students);
                        handlerSelectionSorted.SaveStudents(handler._students);
                        Console.WriteLine("Du har sorteret listen med SelectionSort efter Team Nummer");
                        Console.ReadKey();
                        break;
                    case 3:
                        handler.LoadStudents();
                        sortingAlgorithms.QuickSort(handler._students, 0, (handler._students.Count - 1));
                        handlerQuickSorted.SaveStudents(handler._students);
                        Console.WriteLine("Du har sorteret listen med QuickSort efter navn");
                        Console.ReadKey();
                        break;
                    default:
                        Console.Write("Forkert input, prøv igen!");
                        Console.ReadKey();
                        break;
                }


            } while (!exit);
        }


        public void MenuForSearching()
        {
            bool exit = false;

            do
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Clear();

                Console.WriteLine("Hvordan vil du sorterer listen");
                Console.WriteLine();
                Console.WriteLine("1. Lineær Søgning");
                Console.WriteLine("2. Binær Søgning");
                Console.WriteLine("3. Rekursiv Binær Søgning");
                Console.WriteLine();
                Console.WriteLine("Vælg et menupunkt, eller tryk 0 for at vende tilbage til Main menuen");

                string input = Console.ReadLine();
                int inputMenu;

                if (string.IsNullOrEmpty(input) || !int.TryParse(input, out inputMenu))
                {
                    inputMenu = -1;  // Set to -1 if input is empty or can't be parsed
                }

                switch (inputMenu)
                {
                    case -1:
                        goto default;
                    case 0:
                        exit = true;
                        break;
                    case 1:
                        // Loader den usorterede liste (til lineær søgning)
                        handler.LoadStudents();
                        
                        Console.Write("\nIndtast navnet på den person du vil søge efter: ");
                        string userInputLinearKey = Console.ReadLine();
                        
                        if (searchAlgorithms.LinearSearch(handler._students, userInputLinearKey) != null)
                        {
                            Console.WriteLine("Fundet på listen! \nNavn: {0} \nTeamnummer: {1}"
                                , searchAlgorithms.LinearSearch(handler._students, userInputLinearKey).FullName 
                                , searchAlgorithms.LinearSearch(handler._students, userInputLinearKey).GroupNumber);
                        }
                        else
                        {
                            Console.WriteLine("Navnet findes ikke på listen");
                        }
                        Console.ReadKey();
                        break;
                    case 2:
                        // Loader en sorteret liste - (til binær søgning)
                        handlerQuickSorted.LoadStudents();

                        Console.Write("\nIndtast navnet på den person du vil søge efter: ");
                        string userInputBinaryKey = Console.ReadLine();

                        if (searchAlgorithms.BinarySearch(handlerQuickSorted._students, userInputBinaryKey) != null)
                        {
                            Console.WriteLine("Fundet på listen! \nNavn: {0} \nTeamnummer: {1}"
                                , searchAlgorithms.BinarySearch(handlerQuickSorted._students, userInputBinaryKey).FullName
                                , searchAlgorithms.BinarySearch(handlerQuickSorted._students, userInputBinaryKey).GroupNumber);
                        }
                        else
                        {
                            Console.WriteLine("Navnet findes ikke på listen");
                        }
                        Console.ReadKey();
                        break;
                    case 3:
                        // Loader en sorteret liste - (til rekursiv binær søgning)
                        handlerQuickSorted.LoadStudents();

                        Console.Write("\nIndtast navnet på den person du vil søge efter: ");
                        string userInputRecursiveBinaryKey = Console.ReadLine();

                        if (searchAlgorithms.RecursiveBinarySearch(handlerQuickSorted._students, 0, handlerQuickSorted._students.Count -1, userInputRecursiveBinaryKey) != null)
                        {
                            Console.WriteLine("Fundet på listen! \nNavn: {0} \nTeamnummer: {1}"
                                , searchAlgorithms.RecursiveBinarySearch(handlerQuickSorted._students, 0, handlerQuickSorted._students.Count - 1, userInputRecursiveBinaryKey).FullName
                                , searchAlgorithms.RecursiveBinarySearch(handlerQuickSorted._students, 0, handlerQuickSorted._students.Count - 1, userInputRecursiveBinaryKey).GroupNumber);
                        }
                        else
                        {
                            Console.WriteLine("Navnet findes ikke på listen");
                        }
                        Console.ReadKey();
                        break;
                    default:
                        Console.Write("Forkert input, prøv igen!");
                        Console.ReadKey();
                        break;
                }


            } while (!exit);
        }


    }
}
