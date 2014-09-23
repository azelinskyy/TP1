namespace Resources
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Resources;

    using Newtonsoft.Json;

    public static class ConvertToJson
    {
        public static Dictionary<string, string> ConvertResourceToDictionary(ResourceManager resourceManager)
        {
            return
                resourceManager.GetResourceSet(CultureInfo.CurrentUICulture, true, true)
                    .Cast<DictionaryEntry>()
                    .ToDictionary(x => x.Key.ToString(), x => x.Value.ToString());
        }

        public static string GetLanguageJson()
        {
            var languages = new object[2];
            languages[0] = ConvertResourceToDictionary(Language_ua.ResourceManager);                       
            languages[1] = ConvertResourceToDictionary(languages_us.ResourceManager);

            return String.Format("var languages = {0};", JsonConvert.SerializeObject(languages));
        }
    }
}
