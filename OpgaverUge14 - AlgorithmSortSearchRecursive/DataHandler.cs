using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace OpgaverUge14___AlgorithmSortSearchRecursive
{
    public class DataHandler
    {

        internal List<Student> _students = new List<Student>();


        public string DataFileName { get; }


        public DataHandler(string dataFileName)
        {
            DataFileName = dataFileName;
        }

        public DataHandler() 
        {
        }


        public void SaveStudents(List<Student> students)
        {
            using (StreamWriter sw = new StreamWriter(DataFileName))
            {
                foreach (Student student in students)
                {
                    sw.WriteLine(student.MakeTitle());
                }
            }
            //sw.Close();
        }


        public List<Student> LoadStudents()
        {
            _students.Clear();

            using (StreamReader sr = new StreamReader(DataFileName))
            {
                //List<Student> students = new List<Student>();
                List<string> lines = new List<string>();

                string readLine;
                int groupNumber;

                while ((readLine = sr.ReadLine()) != null)
                {
                    lines.Add(readLine);
                }

                foreach (string line in lines)
                {
                    var splitLineArr = line.Split(',');
                    // index[0] string fullName
                    // index[1] int groupNumber

                    splitLineArr[1] = splitLineArr[1].Trim();
                    groupNumber = int.Parse(splitLineArr[1]);

                    _students.Add(new Student(splitLineArr[0], groupNumber));
                }

                return _students;
            }
        }


        public void ShowStudents()
        {

            ConsoleColor[] groupColors = new ConsoleColor[]
            {
                ConsoleColor.White,
                ConsoleColor.Yellow,
                ConsoleColor.Blue,
                ConsoleColor.Green,
                ConsoleColor.Gray,
                ConsoleColor.Red,
                ConsoleColor.Cyan,
                ConsoleColor.Magenta,
                ConsoleColor.DarkYellow,
                ConsoleColor.DarkBlue,
                ConsoleColor.DarkGreen,
                ConsoleColor.DarkGray,
                ConsoleColor.DarkRed,
                ConsoleColor.DarkCyan,
                ConsoleColor.DarkMagenta,
                ConsoleColor.White,
                ConsoleColor.Yellow
            };

            Console.WriteLine("{0,-25} {1,-2}", "Studerendes navn", "Team");
            Console.WriteLine();

            foreach (Student student in _students)
            {
                int colorIndex = (student.GroupNumber - 1) % groupColors.Length;

                Console.ForegroundColor = groupColors[colorIndex];

                Console.WriteLine("{0,-25} {1,-2}", student.FullName, student.GroupNumber);

                //if (student.GroupNumber % 2 != 0)
                //{
                //    Console.ForegroundColor = ConsoleColor.DarkGray;
                //    Console.WriteLine("{0,-25} {1,-2}", student.FullName, student.GroupNumber);
                //}
                //else
                //{
                //    Console.ForegroundColor = ConsoleColor.White;
                //    Console.WriteLine("{0,-25} {1,-2}", student.FullName, student.GroupNumber);
                //}
            }
        }





    }
}
