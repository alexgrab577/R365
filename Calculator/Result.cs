using System;
using System.Collections.Generic;
using System.Text;

namespace Calculations
{
    class Result
    {
        public List<int> Numbers { get; set; }
        public ParamResult FinalResult { get; set; }
        public bool HasParams
        {
            get
            {
                if (FinalResult == ParamResult.ParamsAndDelimeter || FinalResult == ParamResult.ParamsOnly)
                    return true;
                else
                    return false;
            }
        }

        public bool HasDelimeters
        {
            get
            {
                if (FinalResult == ParamResult.ParamsAndDelimeter || FinalResult == ParamResult.DelimeterOnly)
                    return true;
                else
                    return false;
            }
        }

        public String Message { get; set; }
    }
    enum ParamResult
    {
        Undefined, ParamsOnly, DelimeterOnly, ParamsAndDelimeter, Error
    }
}
