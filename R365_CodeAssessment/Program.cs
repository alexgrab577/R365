using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calculations;
namespace R365_CodeAssessment
{
    class Program
    {
        static void Main(string[] args)
        {
            Calculator calc = new Calculator();
            /*
            //Step 1
            calc.AddNumbers("");
            calc.AddNumbers("1");
            calc.AddNumbers("1,2");

            //Step 2
            calc.AddNumbers("1,2,3,4,5,50");

            //Step 3
            calc.AddNumbers("1\n2,3");
            calc.AddNumbers("1,\n");


            //Step 4
            calc.AddNumbers(";\n1;2;3;4;5");
            calc.AddNumbers("\n1,2,3,4,5");
            calc.AddNumbers("1,2,3,4,5");


            //Step 5
            calc.AddNumbers("-1,2,3,4, 5");
            calc.AddNumbers("-1,-2,-3,4, 5");
            */

            //Step 6
            calc.AddNumbers("1,2,3,4,5,1000,100000000,6");
            /*
            //Error Handling
            calc.AddNumbers("1,2^");
            */
        }
    }
}
