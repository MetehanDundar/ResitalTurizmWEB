using System;
using System.Collections.Generic;
using System.Text;

namespace ResitalTurizmWEB.MODELS.Common
{
    public class ServiceCallResult
    {
        public ServiceCallResult()
        {
            ErrorMessages = new List<string>();
            WarningMessages = new List<string>();
            SuccessMessages = new List<string>();
        }
        public bool Success { get; set; }
        public object Item { get; set; }

        public IList<string> ErrorMessages { get; set; }
        public IList<string> SuccessMessages { get; set; }
        public IList<string> WarningMessages { get; set; }
    }
}
