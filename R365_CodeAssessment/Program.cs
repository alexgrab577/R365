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
            calc.Add("");
            calc.DisplayResult();
            calc.Add("1");
            calc.DisplayResult();
            calc.Add("1,2");
            calc.DisplayResult();
        }
    }
}
