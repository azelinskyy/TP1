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
        public static Dictionary<string, string> ConvertResourceToDictionary(ResourceManager resourceManager, CultureInfo culture)
        {
            return
                resourceManager.GetResourceSet(culture, true, true)
                    .Cast<DictionaryEntry>()
                    .ToDictionary(x => x.Key.ToString(), x => x.Value.ToString());
        }

        public static string GetLanguageJson()
        {
            var languages = new object[3];
            var resourceService = new LocalizationService();
            languages[0] = ConvertResourceToDictionary(resourceService.Manager, new CultureInfo("uk-UA"));
            languages[1] = ConvertResourceToDictionary(resourceService.Manager, CultureInfo.CurrentCulture);
            languages[2] = ConvertResourceToDictionary(resourceService.Manager, new CultureInfo("de-DE"));

            return String.Format("var languages = {0};", JsonConvert.SerializeObject(languages));
        }
    }
}
