using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//WRITTEN BY NATHAN HILL

namespace Library
{
    public class ExtraFunctions
    {
        //hash function for passwords
        public static int HashFunction(String input)
        {
            char[] inputFormatted = input.ToCharArray();
            int returnValue = 0;
            for(int i = 0; i < input.Length; i++)
            {
                //arbitrary hash function
                returnValue += inputFormatted[i] * i * (2 * i);
            }

            return returnValue;
        }
    }
}
