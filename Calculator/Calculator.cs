using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


namespace Calculations
{
    public class Calculator
    {
        int calculationResult;
        string[] delimeters;
        List<string> parameters;
        List<int> valuesToAdd;
        string errorMessage;


        public Calculator()
        {
            calculationResult = 0;
            delimeters = new string[] { "," };
            parameters = new List<string>();
            valuesToAdd = new List<int>();
        }

        /// <summary>
        /// Display the current calculator result
        /// </summary>
        public void DisplayResult()
        {
            //If there is no error message, display the result
            if(String.IsNullOrEmpty(errorMessage))
            {
                string result = calculationResult.ToString();
                Console.WriteLine(result);
            }
            //Otherwise, display the error message
            else
            {
                Console.WriteLine(errorMessage);
            }
        }

        /// <summary>
        /// Add all of the numbers in the delimited string
        /// </summary>
        public int Add(string numbers)
        {
            //reset the calculator variables
            Reset();
            //calculate the result of the parameters
            ProcessAdd(numbers);
            //return the final result
            return calculationResult;
        }

        /// <summary>
        /// Process the parameters and calculate the add value
        /// </summary>
        private void ProcessAdd(string parameterString)
        {
            ConvertParametersToList(parameterString);
            
            ConvertParametersToInt();

            //If there is no error message, calculate the final result
            if(String.IsNullOrEmpty(errorMessage))
            {
                CalculateFinalAddResult();
            }
        }

        /// <summary>
        /// Converts the list of string parameters to a list of integers
        /// </summary>
        private void ConvertParametersToInt()
        {
            foreach (string parameter in parameters)
            {
                try
                {
                    int currentParameter = Convert.ToInt32(parameter);
                    valuesToAdd.Add(currentParameter);
                }
                catch (Exception ex)
                {
                    errorMessage = "Improperly formatted string";
                    break;
                }
            }
        }

        /// <summary>
        /// Calculates the final Add result into the calculationResult member
        /// </summary>
        private void CalculateFinalAddResult()
        {
            int result = 0;
            foreach (int value in valuesToAdd)
            {
                result += value;
            }
            calculationResult = result;
        }

        /// <summary>
        /// Converts parameter string into a List of strings
        /// </summary>
        /// <param name="parametersString"></param>
        private void ConvertParametersToList(string parametersString)
        {
            string[] parameterArray = parametersString.Split(delimeters, StringSplitOptions.RemoveEmptyEntries);

            foreach(string parameter in parameterArray)
            {
                parameters.Add(parameter);
            }
        }

        /// <summary>
        /// Reset the Calculator
        /// </summary>
        public void Reset()
        {
            calculationResult = 0;
            parameters = new List<string>();
            valuesToAdd = new List<int>();
            errorMessage = string.Empty;
        }
    }
}
