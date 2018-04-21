using System;
using System.Collections;
using System.Linq;

namespace Calculations
{
    public class Calculator
    {
        int calculationResult;
        string[] delimeters;
        string[] parameters;
        string errorMessage;


        public Calculator()
        {
            calculationResult = 0;
            delimeters = new string[] { "," };
        }

        public void DisplayResult()
        {
            if(String.IsNullOrEmpty(errorMessage))
            {
                string result = calculationResult.ToString();
                Console.WriteLine(result);
            }
            else
            {
                Console.WriteLine(errorMessage);
            }
        }

        /// <summary>
        /// Add 0 numbers
        /// </summary>
        public int Add(string numbers)
        {
            Reset();
            parameters = GetParameters(numbers);

            calculationResult = ProcessAdd(parameters);

            return calculationResult;
        }

        private int ProcessAdd(string[] parameters)
        {
            string resultString1;
            string resultString2;
            int result1;
            int result2;

            if (parameters.Length == 0)
                return 0;
            else if (parameters.Length == 1)
            {
                resultString1 = parameters[0];
                result1 = Convert.ToInt32(resultString1);
                return result1;
            }
            else if (parameters.Length == 2)
            {
                resultString1 = parameters[0];
                resultString2 = parameters[1];
                result1 = Convert.ToInt32(resultString1);
                result2 = Convert.ToInt32(resultString2);

                return result1 + result2;
            }
            else
            {
                errorMessage = "More than 2 Parameters";
                return 0;
            }
        }

        private string[] GetParameters(string parametersString)
        {
            string[] parameterArray = parametersString.Split(delimeters, 3, StringSplitOptions.RemoveEmptyEntries);
            return parameterArray;
        }

        public void Reset()
        {
            calculationResult = 0;
        }
    }
}
