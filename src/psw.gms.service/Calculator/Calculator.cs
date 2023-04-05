using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSW.GMS.Service.Calculator
{
    public class Calculator
    {
        public int add(int x, int y)
        {
            return x + y;
        }

        public int subtract(int x, int y)
        {
            return x - y;
        }

        public int multiply(int x, int y)
        {
            return x * y;
        }

        public double divide(int x, int y)
        {
            return x / y;
        }
        public double add(double x, double y)
        {
            return x + y;
        }

        public double subtract(double x, double y)
        {
            return x - y;
        }

        public double multiply(double x, double y)
        {
            return Math.Round(x * y, 1);
        }

        public double divide(double x, double y)
        {
            return x / y;
        }
    }
}