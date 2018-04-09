using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Scenario.Core.Helpers
{
    public static class ExceptionHelper
    {
        public static List<string> InterpretException(Exception ex)
        {
            var messages = new List<string>();

            Exception iterator = ex;

            while (iterator != null)
            {
                messages.Add(string.Format("DB_ERROR {0}: \"{1}\"", "Error", iterator.Message));
                iterator = iterator.InnerException;
            }

            //var entityException = ex as DbEntityValidationException;
            //if (entityException != null)
            //{
            //    foreach (var eve in entityException.EntityValidationErrors)
            //    {
            //        foreach (var ve in eve.ValidationErrors)
            //        {
            //            messages.Add(string.Format("{0}: \"{1}\", {2}: \"{3}\"", "Attribute", ve.PropertyName, "Error", ve.ErrorMessage));
            //        }
            //    }
            //}

            return messages;
        }
    }
}
