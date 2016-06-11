
package Package;

public class SortingMethods
{   
    public void sort(int[] array)
    {
        mergeSort(array,0,array.length - 1);
    }
    
    private void mergeSort(int[] array, int left, int right)
    {
        if(left < right)
        {
            //Split the array into two
            int center = (left + right)/2;
            
            //Sort the left and right array
            mergeSort(array, left, center);
            mergeSort(array, center + 1, right);
            
            //merge the result
            merge(array, left, center + 1, right);
        }
    }
    
    private void merge(int[] array, int leftArrayBegin, int rightArrayBegin, int rightArrayEnd)
    {
        int leftArrayEnd = rightArrayBegin - 1;
        
        int numElements = rightArrayEnd - leftArrayBegin + 1;
        int[] resultArray = new int[numElements];
        int resultArrayBegin = 0;
        
        while(leftArrayBegin <= leftArrayEnd && rightArrayBegin <= rightArrayEnd)
        {
            if(array[leftArrayBegin] <= array[rightArrayBegin])
            {
                resultArray[resultArrayBegin++] = array[leftArrayBegin++];
            }
            else
            {
                resultArray[resultArrayBegin++] = array[rightArrayBegin++];
            }
        } 
        
        while(leftArrayBegin <= leftArrayEnd)
        {
            resultArray[resultArrayBegin++] = array[leftArrayBegin++];
        }
        
        while(rightArrayBegin <= rightArrayEnd)
        {
            resultArray[resultArrayBegin++] = array[rightArrayBegin++];
        }
        
        for(int i = numElements - 1; i >=0; i--, rightArrayEnd--)
        {
            array[rightArrayEnd] = resultArray[i];
        }
    }
    
    int[] sampleMerge(int[] leftArray, int[] rightArray)
    {
        int leftArrayEnd = leftArray.length - 1;
        int rightArrayEnd = rightArray.length - 1;   
        int leftArrayBegin = 0;     //the current position on leftArray
        int rightArrayBegin = 0;    //the current position on rightArray
        //but both left/right Array start at [0]
        
        int numElements = leftArray.length + rightArray.length;
        int[] resultArray = new int[numElements];
        int resultArrayBegin = 0;
        //Everytime two values are compared (one from left array and one from right array)
        //It will either find a smaller value or a equal value to the one it's being compared to
        //This will move that array value[x] to the resultArray and increment the left/right ArrayBegin index
        
        /*For example, current leftArrayBegin(2)(leftArray[0], its compared to rightArraybegin 
        * and it's the smaller value, the leftArrayBegin index increments 1. (Moves to the next value in array) 
        Now the leftArrayBegin(4) or (leftArray[1]
        */
        
        //The leftArrayBegin and rightArrayBegin increment individually with its own index
        
        /*If leftarrayBegin has incremented once, and rightArrayBegin incremented twice.
        * Then that means three values have been sorted and in resultArray.
        */
        
        while(leftArrayBegin <= leftArrayEnd && rightArrayBegin <= rightArrayEnd)
        {
            if(leftArray[leftArrayBegin] <= rightArray[rightArrayBegin])
            {
                resultArray[resultArrayBegin++] = leftArray[leftArrayBegin++];
            }
            
            else
            {
                resultArray[resultArrayBegin++] = rightArray[rightArrayBegin++];
            }
        }
        
        while(leftArrayBegin <= leftArrayEnd)
        {
            resultArray[resultArrayBegin++] = leftArray[leftArrayBegin++];
        }
        
        while(rightArrayBegin <= rightArrayEnd)
        {
            resultArray[resultArrayBegin++] = rightArray[rightArrayBegin++];
        }
        return resultArray;
    }
    
        public static void main(String args[]) { 
        System.out.println("Running mergeSort...."); 
        System.out.println("Running merge sort on..{7, 1, 8, 2, 0, 12, 10, 7, 5, 3}.."); 
        int array[] = {7, 1, 8, 2, 0, 12, 10, 7, 5, 3}; 
        SortingMethods mergeSort = new SortingMethods(); 
        mergeSort.sort(array); 
        dumpArray(array);
        
        
        
        System.out.println("Now demo a simple merge routine....");        
        System.out.println("Merging..{1, 3, 5, 7} and ..{2, 4, 6, 8, 10}.."); 
        int leftArray[] = {1, 3, 5, 7}; 
        int rightArray[] = {2, 4, 6, 8, 10}; 
        int[] mergedArray = mergeSort.sampleMerge(leftArray, rightArray); 
        dumpArray(mergedArray); 
    } 
    
    public static void dumpArray(int[] array) { 
        for (int value : array) 
        { 
            System.out.println(value); 
        } 
    } 

}
