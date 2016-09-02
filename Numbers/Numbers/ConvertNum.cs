using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

/**
This Progran can handle numbers from -999,999,999,999 to +999,999,999,999. 
    It can handle unlimited decimal places and will inform you if you have included letters. Numbers can contain commas and still be processed. 
**/

namespace Numbers
{
    public class ConvertNum
    {
        private static string Units(string unit)
        {
            if (unit != null)
            {
                switch (unit)
                {
                    case "1":
                        return "One";
                    case "2":
                        return "Two";
                    case "3":
                        return "Three";
                    case "4":
                        return "Four";
                    case "5":
                        return "Five";
                    case "6":
                        return "Six";
                    case "7":
                        return "Seven";
                    case "8":
                        return "Eight";
                    case "9":
                        return "Nine";
                    default:
                        return null;
                }
            }
            return null;
        }

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

        private static string Hundreds(string hund)
        {
            string HundredWord = " Hundred ";
            string andWord = "and ";

            string h = hund.Substring(0,1);
            string t = hund.Substring(1, 2);

            // e.g. 123
            if (h != "0" & t != "00")
                return Units(h) + HundredWord + andWord + Tens(t);
            // e.g. 100
            if (h != "0" & t == "00")
                return Units(h) + HundredWord;
            // e.g. 024
            if (h == "0")
                return andWord + Tens(t);
            else
            {
                return null;
            }

           
        }
        public void Convert(string input)
        {
            string Minus = null;
            string decim = null;
            
            //remove + or , and process the number as normal
            input = input.Replace(",", string.Empty);
            input = input.Replace("+", string.Empty);
           
            if (input.StartsWith("-"))
            {
                string minus = "Minus ";
                input = input.Substring(1);
                Minus += minus;
            }
            if (input.Contains("."))
            {
                string[] dec = input.Split('.');
                input = dec[0];
                decim = " point ";
                foreach (char w in dec[1])
                {
                    decim += Units(w.ToString());
                    decim += " ";
                }    
            }
            //check for any other non-digits - set input to length 0
            Regex regex = new Regex(@"\D");
            Match match = regex.Match(input);
            if (match.Success)
            {
                input = "";
                Console.WriteLine("Please enter a NUMBER between -999,999,999,999 to 999,999,999,999 to any number of decimal places");
            }
                

            int length = input.Length;
            if (length == 1)
            {
                if (input == "0")
                    Console.WriteLine(Minus + "Zero" + decim);
                else
                    Console.WriteLine(Minus + Units(input) + decim);
            }

            if (length == 2)
                Console.WriteLine(Minus + Tens(input) + decim);

            if (length == 3)
                Console.WriteLine(Minus + Hundreds(input) + decim);

            if (length == 4)
            {
                string th = input.Substring(0, 1);
                string h = input.Substring(1, 3);
                Console.WriteLine(Minus + "{0} Thousand {1}", Units(th), Hundreds(h) + decim);
            }
            if (length == 5)
            {
                string th = input.Substring(0, 2);
                string h = input.Substring(2, 3);
                Console.WriteLine(Minus + "{0} Thousand {1}", Tens(th), Hundreds(h) + decim);
            }
            if (length == 6)  //100,000
            {
                string th = input.Substring(0, 3);
                string h = input.Substring(3, 3);
               Console.WriteLine(Minus + "{0} Thousand, {1}", Hundreds(th), Hundreds(h) + decim);
            }
            if (length == 7) //1,000,000
            {
                string m = input.Substring(0, 1);
                string th = input.Substring(1, 3);
                string h = input.Substring(4, 3);
                Console.WriteLine(Minus + "{0} Million, {1} Thousand, {2}", Units(m), Hundreds(th), Hundreds(h) + decim);
            }
            if (length == 8) //10,000,000
            {
                string m = input.Substring(0, 2);
                string th = input.Substring(2, 3);
                string h = input.Substring(5, 3);
                Console.WriteLine(Minus + "{0} Million, {1} Thousand, {2}", Tens(m), Hundreds(th), Hundreds(h) + decim);
            }
            if (length == 9) //100,000,000
            {
                string m = input.Substring(0, 3);
                string th = input.Substring(3, 3);
                string h = input.Substring(6, 3);
                Console.WriteLine(Minus + "{0} Million, {1} Thousand, {2}", Hundreds(m), Hundreds(th), Hundreds(h) + decim);
            }
            if (length == 10) //1,000,000,000
            {
                string b = input.Substring(0, 1);
                string m = input.Substring(1, 3);
                string th = input.Substring(2, 3);
                string h = input.Substring(5, 3);
                Console.WriteLine(Minus + "{0} Billion {1} Million, {2} Thousand, {3}", Units(b), Hundreds(m), Hundreds(th), Hundreds(h) + decim);
            }
            if (length == 11) //10,000,000,000
            {
                string b = input.Substring(0, 2);
                string m = input.Substring(2, 3);
                string th = input.Substring(5, 3);
                string h = input.Substring(8, 3);
                Console.WriteLine(Minus + "{0} Billion {1} Million, {2} Thousand, {3}", Tens(b), Hundreds(m), Hundreds(th), Hundreds(h) + decim);
            }
            if (length == 12) //100,000,000,000
            {
                string b = input.Substring(0, 3);
                string m = input.Substring(3, 3);
                string th = input.Substring(6, 3);
                string h = input.Substring(9, 3);
                Console.WriteLine(Minus + "{0} Billion {1} Million, {2} Thousand, {3}", Hundreds(b), Hundreds(m), Hundreds(th), Hundreds(h) + decim);
            }

            if (length > 12)
                Console.WriteLine("Too many numbers Pal. Please enter a number between -999,999,999,999 to 999,999,999,999 to any number of decimal places");
        }
    }
}
