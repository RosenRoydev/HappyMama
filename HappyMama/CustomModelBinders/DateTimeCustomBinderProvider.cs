using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace HappyMama.CustomModelBinders
{
    public class DateTimeCustomBinderProvider : IModelBinderProvider
    {
        public IModelBinder? GetBinder(ModelBinderProviderContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));


            }

            if (context.Metadata.ModelType == typeof(DateTime) 
                ||  context.Metadata.ModelType == typeof(DateTime?))
            {
                return new DateTimeCustomBinder();
            }

            return null;
        }
    }
}
