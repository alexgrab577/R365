using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;


namespace Calculations
{
    /// <summary>
    /// Used to Process a Parameter String
    /// </summary>
    class ParamProcessor
    {
        //private members
        private string splitter;
        private List<string> parameters;
        private List<string> delimeters;
        //private properties
        private string[] DelimeterArray{ get; set; }
        private string ParameterString { get; set; }
        private string DelimeterString { get; set; }

        //public members
        public Result Result;


        public ParamProcessor()
        {
            parameters = new List<string>();
            delimeters = new List<string>();
            Result = new Result();
            DelimeterString = String.Empty;
            ParameterString = String.Empty;

            splitter = "\n";
            delimeters.Add(",");
            DelimeterArray = delimeters.ToArray();
        }

        public void ProcessInput(string ParameterInput)
        {
            ResetProcessParam();

            SplitDelimetersFromParams(ParameterInput);

            UpdateResult();

            UpdateDelimeterArray();

            ConvertParametersToList();

            ConvertParametersToInt();
        }

        public void ResetProcessParam()
        {
            parameters = new List<string>();
            Result = new Result();
            DelimeterString = String.Empty;
            ParameterString = String.Empty;
            delimeters = new List<string>() { "," };
            DelimeterArray = delimeters.ToArray();
        }

        private void SplitDelimetersFromParams(string ParameterInput)
        {
            if (ParameterInput.Contains(splitter))
            {
                int delimeterEndLocation = ParameterInput.IndexOf(splitter, StringComparison.Ordinal);
                int parameterStartLocation = delimeterEndLocation + splitter.Length;

                if (delimeterEndLocation > 0)
                {
                    DelimeterString = ParameterInput.Substring(0, delimeterEndLocation);

                    ParameterString = ParameterInput.Substring(parameterStartLocation, ParameterInput.Length - parameterStartLocation);
                }
                else
                    ParameterString = ParameterInput.Substring(splitter.Length);
            }
            else
                ParameterString = ParameterInput;
        }

        private void UpdateResult()
        {
            bool delimetersFound = false;
            bool parametersFound = false;

            if(DelimeterString.Length > 0)
            {
                delimetersFound = true;
            }
            if(ParameterString.Length > 0)
            {
                parametersFound = true;
            }
            
            if (delimetersFound && parametersFound)
            {
                Result.FinalResult = ParamResult.ParamsAndDelimeter;
            }
            else if (delimetersFound && !parametersFound)
            {
                Result.FinalResult = ParamResult.DelimeterOnly;
            }
            else if (!delimetersFound && parametersFound)
            {
                Result.FinalResult = ParamResult.ParamsOnly;
            }
        }

        //Needs work, compare to delimeters in Calculator Object
        private void UpdateDelimeterArray()
        {
            if(!String.IsNullOrEmpty(DelimeterString))
            {
                delimeters.Add(DelimeterString);
            }

            DelimeterArray = delimeters.ToArray();
        }

        /// <summary>
        /// Converts parameter string into a List of strings
        /// </summary>
        private void ConvertParametersToList()
        {
            string[] parameterArray = ParameterString.Split(DelimeterArray, StringSplitOptions.None);

            foreach (string parameter in parameterArray)
            {
                parameters.Add(parameter);
            }
        }

        /// <summary>
        /// Converts the list of string parameters to a list of integers
        /// </summary>
        private void ConvertParametersToInt()
        {
            List<int> resultList = new List<int>();

            resultList = GetParametersAsInt();

            //Throw an Exception if any negative Numbers Appear
            CheckNegativeNumbers(resultList);

            //Remove any Numbers that are more than 1000
            resultList.RemoveAll(x => x >= 1000);

            if (Result.FinalResult != ParamResult.Error)
            {
                Result.Numbers = resultList;
            }
        }

        private void CheckNegativeNumbers(List<int> numbers)
        {
            StringBuilder negativeNumberList = new StringBuilder();
            string exceptionString;
            try
            {
                var negativeValuesFound = numbers.Where(x => x < 0);

                if (negativeValuesFound.Count() > 0)
                {
                    foreach (var value in negativeValuesFound)
                    {
                        negativeNumberList.Append(value.ToString());
                    }

                    exceptionString = "Negative numbers not allowed: " + negativeNumberList.ToString();

                    throw new Exception(exceptionString);
                }
            }
            catch (Exception ex)
            {
                Result.FinalResult = ParamResult.Error;
                Result.Message = ex.Message;
            }

        }

        private List<int> GetParametersAsInt()
        {
            List<int> returnList = new List<int>();

            foreach (string parameter in parameters)
            {
                try
                {
                    int currentParameter = Convert.ToInt32(parameter);
                    returnList.Add(currentParameter);
                }
                catch (Exception ex)
                {
                    Result.FinalResult = ParamResult.Error;
                    Result.Message = "Improperly formatted string";
                    break;
                }
            }
            return returnList;
        }
    }
}
