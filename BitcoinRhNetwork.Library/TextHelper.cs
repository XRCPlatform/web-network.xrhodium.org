using System;

namespace BitCoinRhNetwork.Library
{
    public static class TextHelper
    {
        public static string GetShorterText(string longText, int maximalLength)
        {
            string output = longText;

            if (longText.Length > maximalLength)
            {
                output = longText.Substring(0, maximalLength - 3);
                return output + "...";
            }
            else
            {
                return output;
            }
        }

        public static string StripHtml(string htmlString)
        {
            char[] array = new char[htmlString.Length];
            int arrayIndex = 0;
            bool inside = false;

            for (int i = 0; i < htmlString.Length; i++)
            {
                char let = htmlString[i];
                if (let == '<')
                {
                    inside = true;
                    continue;
                }
                if (let == '>')
                {
                    inside = false;
                    continue;
                }
                if (!inside)
                {
                    array[arrayIndex] = let;
                    arrayIndex++;
                }
            }

            return new string(array, 0, arrayIndex);
        }

        public static string GenerateUrlLinkPassword()
        {
            var newGuid = Guid.NewGuid();
            return newGuid.ToString();
        }
    }
}
