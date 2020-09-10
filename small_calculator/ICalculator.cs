using System;
using System.Collections.Generic;
using System.Text;

namespace small_calculator
{
   public interface ICalculator
    {
       
            int Result { get; set; } // property keeping the current result of the calculator
            void Reset(); // resets the current result of the calculator
            void Add(int x); // adds x to the current result
            void Subtract(int x); // subtracts x from the current result
            void Multiply(int x); // multiplies the current result with x
            void Divide(int x); // divides the currents result with x (integer division)
            void Modulus(int x); // divides the current result with x and stores the remainder as
            // the current result 
        
    }
}
