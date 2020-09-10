using System;
using System.IO;

namespace small_calculator
{
    public class Calculator : ICalculator

    {
        public int Result { get; set; }

        public void Reset()
        {
            Result = 0;
        }

        public void Add(int x)
        {
            if (x > 0 && x + Result < Result)
            {
                throw new OverflowException("Overflow");
            }
            else if (x < 0 && x + Result > Result)
            {
                throw new OverflowException("Underflow");
            }
            Result += x;

        }

        public void Subtract(int x)
        {
            long longResult = Result;

            if (longResult - x < int.MinValue)
            {
                throw new OverflowException("Underflow");
            }
            else if (longResult - x > int.MaxValue)
            {
                throw new OverflowException("Overflow");
            }

            Result = Result - x;

        }

        public void Multiply(int x)
        {
            long longResult = Result;

            if (longResult * x > int.MaxValue)
            {
                throw new OverflowException("Overflow");
            }
            else if (longResult * x < int.MinValue)
            {
                throw new OverflowException("Underflow");
            }
            Result *= x;
        }

        public void Divide(int x)
        {
            if (x == 0 || Result == 0)
            {
                throw new InvalidDataException("Cant divide by 0");
            }
            else
            {
                Result /= x;
            }

        }

        public void Modulus(int x)
        {
            var m = Result % x;
            Result = m;
        }
    }
}
