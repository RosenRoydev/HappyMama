using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.Specialized;
using System.Globalization;

namespace HappyMama.CustomModelBinders
{
    public class DecimalCustomBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            ValueProviderResult valueResult = bindingContext.ValueProvider
                                             .GetValue(bindingContext.ModelName);

            if (valueResult != ValueProviderResult.None && string.IsNullOrEmpty(valueResult.FirstValue))
            {
                decimal result = 0M;
                bool success = false;

                try
                {
                    string decValue = valueResult.FirstValue;

                    decValue = decValue.Replace("," ,CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);
                    decValue = decValue.Replace(".", CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);

                    result = Convert.ToDecimal(decValue,CultureInfo.CurrentCulture);

                }
                catch (FormatException ex)
                {
                    bindingContext.ModelState.AddModelError(bindingContext.ModelName,ex,bindingContext.ModelMetadata);
                    
                }
                if (success)
                {
                    ModelBindingResult.Success(result);
                }
            }
            return Task.CompletedTask;
        }
    }
}
