using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBridgeAssessment.Common
{
    public class Validation
    {
        public static void RequiredParameter(string ParmName, object ParmValue)
        {
            string _errMsg = "";
            if (RequiredParameter(ParmName, ParmValue, ref _errMsg))
                return;
            else
                throw new ArgumentNullException(ParmName);
        }

        /// <summary>
        /// Mthod to validate the required  parameter.
        /// </summary>
        /// <param name="ParmName"></param>
        /// <param name="ParmValue"></param>
        public static bool RequiredParameter(string ParmName, object ParmValue, ref string errMsg)
        {
            if (ParmValue == null)
            {
                errMsg = ParmName + " is Required";
                return false;
            }

            System.Type _ParmType = ParmValue.GetType();

            if (_ParmType == typeof(string))
            {
                if (string.IsNullOrEmpty((string)ParmValue))
                {
                    errMsg = ParmName + " is Required";
                    return false;
                }
                else
                    return true;
            }

            return true;
        }
    }
}
