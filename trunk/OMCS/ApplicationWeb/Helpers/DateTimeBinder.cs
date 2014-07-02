using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OMCS.Web
{
    public class DateTimeBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var value = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
            Debug.WriteLine("BindModel: " + value.AttemptedValue);
            Debug.WriteLine("BindModel: " + value.RawValue.ToString());
            
            //var date = value.ConvertTo(typeof(DateTime), CultureInfo.CurrentCulture);
            DateTime date;
            try
            {
                date = DateTime.ParseExact(value.AttemptedValue, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            }
            catch
            {
                date = DateTime.Now;
            }
            
            return date;
        }
    }
}