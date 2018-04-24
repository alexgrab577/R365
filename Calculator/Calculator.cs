using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Calculations
{
    public class Calculator
    {
        int calculationResult;
        ParamProcessor ParamProcessor = new ParamProcessor();

        public Calculator()
        {
            calculationResult = 0;
        }

        /// <summary>
        /// Display the current calculator result
        /// </summary>
        private void DisplayResult()
        {
            //If there is no error, display the result
            if(ParamProcessor.Result.FinalResult != ParamResult.Error)
            {
                string result = calculationResult.ToString();
                Console.WriteLine(result);
            }
            //Otherwise, display the error message
            else
            {
                Result result = ParamProcessor.Result;
                Console.WriteLine(result.Message);
            }
        }
        /// <summary>
        /// Add all of the numbers in a Delimited String and pass it to the Console.
        /// </summary>
        /// <param name="parameters"></param>
        public void AddNumbers(string parameters)
        {
            calculationResult = Add(parameters);
            DisplayResult();
        }
        /// <summary>
        /// The method required for this exercise
        /// </summary>
        private int Add(string parameters)
        {
            ResetCalculator();

            ParamProcessor.ProcessInput(parameters);

            //If there is no error message, calculate the final result
            if (ParamProcessor.Result.FinalResult != ParamResult.Error)
                return CalculateFinalAddResult();
            else
                return 0;
        }


        /// <summary>
        /// Calculates the final Add result into the calculationResult member
        /// </summary>
        private int CalculateFinalAddResult()
        {
            int result = 0;
            foreach (int value in ParamProcessor.Result.Numbers)
            {
                result += value;
            }
            return result;
        }

        /// <summary>
        /// Reset the Calculator
        /// </summary>
        private void ResetCalculator()
        {
            calculationResult = 0;
        }
    }
}
