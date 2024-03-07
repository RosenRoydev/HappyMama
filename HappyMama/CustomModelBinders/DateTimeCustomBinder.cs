using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Globalization;

namespace HappyMama.CustomModelBinders
{
    public class DateTimeCustomBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            ValueProviderResult result = bindingContext.ValueProvider
                .GetValue(bindingContext.ModelName);

            if (result != ValueProviderResult.None && !string.IsNullOrEmpty(result.FirstValue))
            {
                DateTime time = DateTime.MinValue;
                bool success = false;

                try
                {
                    string strValue = result.FirstValue.Trim();
                    strValue = strValue.Replace(".",CultureInfo.CurrentCulture.DateTimeFormat.DateSeparator);
                    strValue = strValue.Replace("/", CultureInfo.CurrentCulture.DateTimeFormat.DateSeparator);
                    strValue = strValue.Replace(",", CultureInfo.CurrentCulture.DateTimeFormat.DateSeparator);

                    time = Convert.ToDateTime(strValue,CultureInfo.CurrentCulture);
                    success = true;
                }

                catch (FormatException ex)
                {

                    bindingContext.ModelState.AddModelError(bindingContext.ModelName,ex,bindingContext.ModelMetadata);
                }

                if (success)
                {
                    bindingContext.Result = ModelBindingResult.Success(time);
                }
            }

            return Task.CompletedTask;
        }
    }
}
