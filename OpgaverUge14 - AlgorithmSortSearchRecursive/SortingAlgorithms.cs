using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace OpgaverUge14___AlgorithmSortSearchRecursive
{
    public class SortingAlgorithms
    {

        // My Selection sort algorithm (Pseudo)
        // Iterate through list find lowest value of groupNumber
        // if [0] is not lowest, swap lowest value index with [0]
        // Iterate through array find second lowest value
        // if [1] is not second lowest, swap second lowest with [1]
        // ...

        // Video Selection sort algorithm (Pseudo)
        // for (j=0; j<n-1;j++);
        //  int iMin = j;
        //  for (i=j+1; i<ni;i++)
        //      if(a[i]<a[iMin]);
        //          iMin = j;
        // if (iMin != j);
        //  swap(a[j],a[iMin]);
        public void SelectionSort(List<Student> students)
        {
            // Ser på index[0] til index[list.Count - 1]
            for (int i = 0; i < students.Count - 1; i++)
            {
                // itemMinimum sættes til i (igen)
                int iMin = i;

                // Ser på index[i + 1]
                for (int j = i + 1; j < students.Count; j++)
                {
                    // Hvis j er mindre en i
                    if (students[j].GroupNumber < students[iMin].GroupNumber)
                        iMin = j; // så sættes j til itemMinimum

                }
                // Hvis itemMinimum ikke længere er i, så byt værdierne
                if (iMin != i)
                {
                    // iMin = j, da j > i
                    // Gem lower fra j/iMin og higher value fra i
                    Student lowerValueName = students[iMin];
                    Student higherValueName = students[i];

                    // Swap - sæt i til lower, og j til higher value
                    students[i] = lowerValueName;
                    students[iMin] = higherValueName;
                }

            }
        }


        // My Bubble sort algorithm (Pseudo)
        // Iterate through array
        // Look at index[0] and index[1]
        // if index[1] is lower than index[0] -> swap
        // 
        // Looking at names
        // if index[1] char1 ASCII value = char1 at index[0] -> look at char2...
        // if index[1] char ASCII value > index[0] -> swap
        //...

        // Video Bubble sort algorithm (Pseudo)
        // for i from 1 to N
        //  for j from 0 to N-1
        //      if a[j] > a[j+1]
        //          swap(a[j], a[j+1])
        public void BubbleSort(List<Student> students)
        {
            // bool til at holde styr på om en iteration har lavet et swap eller ej.
            bool swapped;

            // Ser på index[0] til index[List.Count - 1]
            for (int i = 0; i < students.Count - 1; i++)
            {
                // sættes til falsk
                swapped = false;

                // Ser på index[i + 1] til index[List.Count]
                for (int j = i + 1; j < students.Count; j++)
                {

                    if (string.Compare(students[i].FullName.ToLower(), students[j].FullName.ToLower(), StringComparison.OrdinalIgnoreCase) >= 0)
                    {
                        // Gem temp værdier
                        Student lowerValueName = students[j];
                        Student higherValueName = students[i];

                        // Swap - sæt i til lower, og j til higher value
                        students[i] = lowerValueName;
                        students[j] = higherValueName;

                        //sættes til true - Da der er sket et swap i denne iteration (yderste for loop)
                        swapped = true;
                    }

                }

                if (!swapped)
                    break;
            }


        }



        // My Quick sort algorithm (Recursive)
        // Pseudo

        // Make partition method that divide a list in 2 smaller lists

        // OBS: Quick sort = pivot (meets the following 3 conditions after we sorted)
        // 1: Pivot correct position in final, sorted array
        // 2: Items to the left are smaller
        // 3: Items to the right are larger

        // Pick pivot - item with middle value
        //      (Use median-of-three) pick the first, middle and last element, sort them, and use the middle index as pivot (guessing that the value may be close to median)
        //      Always pick first element
        //      Always pick last element
        //      Pick random
        //      Pick the middle element
        //
        // Move pivot to the end of array

        // Look through array from left to right:
        //      Looking for itemFromLeft that is larger than pivot
        // Look through array from right to left:
        //      Looking for itemFromRight that is smaller than pivot
        // When those are found
        //      Swap them
        // Stop when index of ItemFromLeft > index of itemFromRight
        // Swap ItemFromLeft with pivot

        // Pivot is now in the correct spot



        
       


        // Video Quick sort algorithm - QuickSort()
        // Pseudo

        // Quicksort (A as array, low as int, high as int)
        //  if (low<high)
        //      pivot_location = Partition(A,low, high)
        //      Quicksort(A,low,pivot_location)
        //      Quicksort(A,pivot_location + 1, high)

        public void QuickSort(List<Student> students, int low, int high)
        {
            if (low < high)
            {
                int pivot_location = Partition(students, low, high);

                QuickSort(students, low, pivot_location - 1);
                QuickSort(students, pivot_location + 1, high);
            }

        }

        // Video Quick sort algorithm - Partition
        // Pseudo

        // Partition(A as array, low as int, high as int)
        //  pivot = A[low]
        //  leftwall = low
        //
        //  for i = low + 1 to high
        //      if (A[i] < pivot) then
        //          swap (A[i], A[leftwall])
        //          leftwall = leftwall + 1
        //  swap(pivot,A[leftwall])
        //
        //  return (leftwall)        
        public int Partition(List<Student> students, int low, int high)
        {
            Student pivot = students[low];
            int leftwall = low;

            for (int i = low + 1; i <= high; i++)
            {
                // Hvis char i string1 (i) < char i string2 (pivot) = negativt tal, så swap
                // Hvis char i string1 (i) = char i string2 (pivot) = 0
                // Hvis char i string1 (i) > char i string2 (pivot) = positivt tal
                if (string.Compare(students[i].FullName.Trim(), pivot.FullName.Trim(), StringComparison.OrdinalIgnoreCase) <= 0)
                //ignoreCase : true satte Jaathavan Erambamoorthy forkert, fordi ignoreCase tager højde for kultur (dansk aa = å)
                {
                    leftwall++;
                    
                    Student lowerValueName = students[i];
                    Student higherValueName = students[leftwall];

                    students[leftwall] = lowerValueName;
                    students[i] = higherValueName;

                }
            }

            // Swap pivot with element at leftwall
            //Student tempPivot = students[leftwall];
            //students[leftwall] = students[low]; // pivot
            //students[low] = tempPivot;

            // swap
            Student temp1 = students[low];
            Student temp2 = students[leftwall];

            students[leftwall] = temp1;
            students[low] = temp2;

            return leftwall;
        }
















        // CoPilots solutions

        //public int Partition(List<Student> students, int low, int high)
        //{
        //    Student pivot = students[high];  // Choose the last element as the pivot
        //    int i = (low - 1);  // Index of smaller element

        //    for (int j = low; j <= high - 1; j++)
        //    {
        //        // If current element is smaller than or equal to pivot
        //        if (string.Compare(students[j].FullName, pivot.FullName, StringComparison.OrdinalIgnoreCase) <= 0)
        //        {
        //            i++;  // Increment index of smaller element
        //            Swap(students, i, j);  // Swap current element with index
        //        }
        //    }
        //    Swap(students, i + 1, high);
        //    return (i + 1);
        //}
        //private void Swap(List<Student> students, int i, int j)
        //{
        //    Student temp = students[i];
        //    students[i] = students[j];
        //    students[j] = temp;
        //}

        // Median-of-three, doesn't put = strings before pinot like it should

        //public int Partition(List<Student> students, int low, int high)
        //{
        //    // Choose the median of the first, middle, and last elements as the pivot
        //    int mid = low + (high - low) / 2;
        //    if (string.Compare(students[mid].FullName, students[low].FullName) < 0)
        //        Swap(students, low, mid);
        //    if (string.Compare(students[high].FullName, students[low].FullName) < 0)
        //        Swap(students, low, high);
        //    if (string.Compare(students[mid].FullName, students[high].FullName) < 0)
        //        Swap(students, mid, high);

        //    Student pivot = students[mid];
        //    Swap(students, mid, high);  // Move pivot to end

        //    int leftwall = low;

        //    for (int i = low; i < high; i++)  // Note: < high, not <= high
        //    {
        //        if (string.Compare(students[i].FullName.Trim(), pivot.FullName.Trim()) < 0)
        //        {
        //            Swap(students, i, leftwall);
        //            leftwall++;
        //        }
        //    }

        //    // Move pivot to its final place
        //    Swap(students, leftwall, high);

        //    return leftwall;
        //}



    }
}
