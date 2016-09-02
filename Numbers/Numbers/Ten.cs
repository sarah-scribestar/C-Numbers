using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Numbers
{
    class Ten
    {
        private static string Tens(string tens)
        {
            string ten = tens[tens.Length - 2].ToString();
            string unit = tens[tens.Length - 1].ToString();
            Dictionary<string, string> teensDict = new Dictionary<string, string>();
            teensDict.Add("0", "Ten");
            teensDict.Add("1", "Eleven");
            teensDict.Add("2", "Twelve");
            teensDict.Add("3", "Thirteen");
            teensDict.Add("4", "Fourteen");
            teensDict.Add("5", "Fifteen");
            teensDict.Add("6", "Sixteen");
            teensDict.Add("7", "Seventeen");
            teensDict.Add("8", "Eighteen");
            teensDict.Add("9", "Nineteen");

            Dictionary<string, string> tensDict = new Dictionary<string, string>();
            tensDict.Add("2", "Twenty");
            tensDict.Add("3", "Thirty");
            tensDict.Add("4", "Forty");
            tensDict.Add("5", "Fifty");
            tensDict.Add("6", "Sixty");
            tensDict.Add("7", "Seventy");
            tensDict.Add("8", "Eighty");
            tensDict.Add("9", "Nintey");

            if (ten == "0")
                Units(unit);
            if (ten == "1")
            {
                string value = teensDict[unit];
                return value;
            }
            if (tensDict.ContainsKey(ten))
            {
                string value = tensDict[ten];
                if (unit != "0")
                    return value + "-" + Units(unit);
                else
                    return value;
            }
            else
                return Units(unit);
        }
    }
}
