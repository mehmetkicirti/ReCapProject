using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Business
{
    public static class BusinessTool
    {
        public static IResult GetFailedLogic(params IResult[] logics)
        {
            foreach (IResult logic in logics)
            {
                if (!logic.IsSuccess)
                {
                    return logic;
                }
            }
            return null;
        }
        public static List<IResult> GetFailedLogics(params IResult[] logics)
        {
            List<IResult> errorResults = new List<IResult>(); 
            foreach (IResult logic in logics)
            {
                if (!logic.IsSuccess)
                {
                    errorResults.Add(logic);
                }
            }
            return errorResults;
        }
    }
}
