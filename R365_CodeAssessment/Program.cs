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
            //Step 1
            calc.Add("");
            calc.DisplayResult();
            calc.Add("1");
            calc.DisplayResult();
            calc.Add("1,2");
            calc.DisplayResult();

            //Step 2
            calc.Add("1,2,3,4,5,50");
            calc.DisplayResult();

            //Step 3


            //Error Handling
            calc.Add("1,2^");
            calc.DisplayResult();
        }
    }
}
