using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpgaverUge14___AlgorithmSortSearchRecursive
{
    public class SearchAlgorithms
    {

        // For unsorted array
        // Userinput for the search key
        // Iterate through array
        // Search each element in array
        // If element = key
        // Print out element / element.Fullname
        public Student LinearSearch(List<Student> students, string FullName)
        {
            for (int i = 0; i < students.Count; i++)
            {
                if (students[i].FullName == FullName.Trim())
                {
                    return students[i];
                }
            }      
            return null;
        }



        // For sorted array/liste
        // userInput for the search key
        // set int left = index 0
        // set int right = array.Length
        // set int middle = index[ (left + right) / 2 ]   
        // Check if userInput is smaller or bigger than middle index
        // while left er <= right
        //  if userInput = middle
        //      return middle
        //  If userInput > middle 
        //      set left = middle +1
        //  If userInput < middle 
        //      set right = middle -1



        // Video BinarySearch pseudo
        // def binary_search(array, target):
        //  left = 0
        //  right = len(array) - 1
        //  while (left <= right):    
        //      mid = (right + left) // 2
        //      
        //      if array[mid] == target:
        //          return mid
        //      elif array[mid] < target:
        //          left mid + 1
        //      else:
        //          right = mid - 1
        //
        //  return -1
        public Student BinarySearch(List<Student> students, string FullName)
        {
            int left = 0;
            int right = students.Count - 1;
            

            while (left <= right)
            {
                int mid = (left + right) / 2;

                if (string.Compare(students[mid].FullName, FullName, StringComparison.OrdinalIgnoreCase) == 0)
                {
                    return students[mid];
                }
                // Hvis FullName (Key) ligger efter students[mid], så sæt left til mid+1, så vi kun kigger til højre for mid
                // Compare skal returne mindre end 0
                if (string.Compare(students[mid].FullName, FullName, StringComparison.OrdinalIgnoreCase) < 0)
                {                   
                    left = mid + 1;

                }
                // Hvis FullName (Key) ligger før students[mid], så sæt right til mid-1, så vi kun kigger til venstre for mid
                // Compare skal returne større end 0
                if (string.Compare(students[mid].FullName, FullName, StringComparison.OrdinalIgnoreCase) > 0)
                {               
                    right = mid - 1;
                }

            }

            return null;
        }


        // https://www.youtube.com/watch?v=7U7cXEROrGY
        public Student RecursiveBinarySearch(List<Student> students, int left, int right, string FullName)
        {

            while (left <= right)
            {
                int mid = (left + right) / 2;

                //if (string.Compare(students[mid].FullName, FullName, StringComparison.OrdinalIgnoreCase) == 0)
                //{
                //    return students[mid];
                //}

                // Hvis FullName (Key) ligger efter students[mid], så sæt left til mid+1, så vi kun kigger til højre for mid
                // Compare skal returne mindre end 0
                if (string.Compare(students[mid].FullName, FullName, StringComparison.OrdinalIgnoreCase) < 0)
                {
                    //left = mid + 1;
                    return RecursiveBinarySearch(students, mid + 1, right, FullName);
                }
                // Hvis FullName (Key) ligger før students[mid], så sæt right til mid-1, så vi kun kigger til venstre for mid
                // Compare skal returne større end 0
                else if (string.Compare(students[mid].FullName, FullName, StringComparison.OrdinalIgnoreCase) > 0)
                {
                    //right = mid - 1;
                    return RecursiveBinarySearch(students, left, mid - 1, FullName);
                }
                else
                {
                    return students[mid];
                }
            }

            return null;
        }



    }
}
