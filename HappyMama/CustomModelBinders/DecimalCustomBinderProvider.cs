using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace HappyMama.CustomModelBinders
{
    public class DecimalCustomBinderProvider : IModelBinderProvider
    {
        public IModelBinder? GetBinder(ModelBinderProviderContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));

            }

            if(context.Metadata.ModelType == typeof(decimal) ||
                context.Metadata.ModelType == typeof(decimal?))
            {
                return new DecimalCustomBinder();
            }

            return null;
        }
    }
}
