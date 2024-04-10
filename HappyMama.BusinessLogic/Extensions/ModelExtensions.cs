using HappyMama.BusinessLogic.Contracts;
using System.Text.RegularExpressions;

namespace HappyMama.BusinessLogic.Extensions
{
    public static class ModelExtensions
    {
        public static string GetInformation (this IEventInfo eventInfo)
        {
            string info = eventInfo.Name.Replace(" ", "-") + GetDescription(eventInfo.Description);
            info = Regex.Replace(info, @"[^a-zA-Z0-9\-]", string.Empty);

            return info;
        }

        public static string GetDescription(string descr)
        {
             descr = string.Join("-",descr.Split(" ").Take(2));

            return descr;
        }

       
    }
}
