using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task1.BL
{
    internal class Calculator
    {
        public double num1;
        public double num2;

        public Calculator() 
        { 

        }
        public Calculator(double value1, double value2)
        {
            value1 = num1;
            value2 = num2;
        }
        public Calculator(double value1)
        {
            value1 = num1;
        }
        public double Add(double value1, double value2)
        {
            return value1 + value2;
        }


        public double Sub(double value1, double value2)
        {
            return value1 - value2;
        }

        public double Mul(double value1, double value2)
        {
            return value1 * value2;
        }

        public double Div(double value1, double value2)
        {
            return value1 / value2;
        }

        public double Mod(double value1, double value2)
        {
            return value1 % value2;
        }
        public double SqRoot(double value1)
        {
            return Math.Sqrt(value1);
        }
        public double Exp(double value1)
        {
            return Math.Exp(value1);
        }
        public double Log(double value1)
        {
            return Math.Log(value1);
        }
        public double Sin(double value1)
        {
            return Math.Sin(value1);
        }
        public double Cos(double value1)
        {
            return Math.Cos(value1);
        }
        public double Tan(double value1)
        {
            return Math.Tan(value1);
        }
    }
}
