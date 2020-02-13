using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Midterm 
{ 
    public class OddOrPosClass 
    {        
        //Count each element that is either odd or positive        
        //Parameter "searchArray" is the array to process        
        //Returns the count of all elements that are either odd or positive        
        //Throws NullReferenceException if searchArray is null        
        public static int OddOrPos(int[] searchArray)        
        {            
            int count = 0;            
            for (int i = 0; i < searchArray.Length; i++)            
            {                
               if (searchArray[i] % 2 == 1 || searchArray[i] > 0)
               //if (searchArray[i] % 2 != 0 || searchArray[i] > 0)
               {
                    count++;
               }            
            }            
            return count;
        }    
    }
}