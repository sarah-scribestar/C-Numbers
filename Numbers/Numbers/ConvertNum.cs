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

        static Dictionary<string, string> _teensDict = new Dictionary<string, string>
            {
                {"0", "Ten"}, 
                {"1", "Eleven"},
                {"2", "Twelve"},
                {"3", "Thirteen"},
                {"4", "Fourteen"},
                {"5", "Fifteen"},
                {"6", "Sixteen"},
                {"7", "Seventeen"},
                {"8", "Eighteen"},
                {"9", "Nineteen"}
            };
        static Dictionary<string, string> _tensDict = new Dictionary<string, string>
        {
            {"2", "Twenty"},
            {"3", "Thirty"},
            {"4", "Forty"},
            {"5", "Fifty"},
            {"6", "Sixty"},
            {"7", "Seventy"},
            {"8", "Eighty"},
            {"9", "Nintey"}
        };

        private static string Tens(string tens) // split this into two, create and access
        {
            string ten = tens[tens.Length - 2].ToString();
            string unit = tens[tens.Length - 1].ToString();

            if (ten == "0")
                Units(unit);
            if (ten == "1")
            {
                string value = _teensDict[unit];
                return value;
            }
            if (_tensDict.ContainsKey(ten))
            {
                string value = _tensDict[ten];
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
            if (hund == "000")
                return null;
            if (t != "00")
                return Tens(t);
            else
                return null;
        }

        private static string BigNum(string bignum)
        {
            string ThousWord = " Thousand, ";
            string MilWord = " Million, ";
            string BilWord = " Billion, ";
            string h = bignum.Substring(bignum.Length - 3);

            if (bignum.Length < 5) // e.g. 3,000
            {
                string t = bignum.Substring(0, 1);
                return Units(t) + ThousWord + Hundreds(h);
            }
            if (bignum.Length < 6) // e.g. 13,000
            {
                string t = bignum.Substring(0, 2);
                return Tens(t) + ThousWord + Hundreds(h);
            }
            if (bignum.Length < 7) // e.g. 123,000
            {
                string t = bignum.Substring(0, 3);
                return Hundreds(t) + ThousWord + Hundreds(h);
            }
            if (bignum.Length < 8) //1,000,000
            {
                string ht = bignum.Substring(bignum.Length - 6, bignum.Length - 4);
                string m = bignum.Substring(0, 1);
                if (ht != "000")
                {
                    return Units(m) + MilWord + Hundreds(ht) + ThousWord + Hundreds(h);
                }
                if (ht == "000")
                {
                    return Units(m) + MilWord + Hundreds(h);
                }
            }
            if (bignum.Length < 9) //10,100,000
            {
                string ht = bignum.Substring(bignum.Length - 6, bignum.Length - 4);
                string m = bignum.Substring(0, 2);

                if (ht != "000")
                {
                    return Tens(m) + MilWord + Hundreds(ht) + ThousWord + Hundreds(h);
                }
                if (ht == "000")
                {
                    return Tens(m) + MilWord + Hundreds(h);
                }
            }
            if (bignum.Length < 10) //100,100,000
            {
                string ht = bignum.Substring(bignum.Length - 6, bignum.Length - 4);
                string m = bignum.Substring(0, 3);
                if (ht != "000")
                    return Hundreds(m) + MilWord + Hundreds(ht) + ThousWord + Hundreds(h);
                if (ht == "000")
                {
                    return Hundreds(m) + MilWord + Hundreds(h);
                }
            }
            if (bignum.Length < 11) //1,100,100,000
            {
                string ht = bignum.Substring(bignum.Length - 6, bignum.Length - 4);
                string m = bignum.Substring(1, 3);
                string b = bignum.Substring(0, 1);
                if (m != "000")
                {
                    if (ht != "000")
                        return Units(b) + BilWord + Hundreds(m) + MilWord + Hundreds(ht) + ThousWord + Hundreds(h);
                    if (ht == "000")
                        return Units(b) + BilWord + Hundreds(m) + MilWord + Hundreds(h);
                }
                if (m == "000")
                {
                    if (ht != "000")
                        return Units(b) + BilWord + Hundreds(m) + MilWord + Hundreds(ht) + ThousWord + Hundreds(h);
                    if (ht == "000")
                        return Units(b) + BilWord + Hundreds(h);
                }
            }
            if (bignum.Length < 12) //11,100,100,000
            {
                string ht = bignum.Substring(5,3);
                string m = bignum.Substring(2, 3);
                string b = bignum.Substring(0, 2);
                if (m != "000")
                {
                    if (ht != "000")
                        return Tens(b) + BilWord + Hundreds(m) + MilWord + Hundreds(ht) + ThousWord + Hundreds(h);
                    if (ht == "000")
                        return Tens(b) + BilWord + Hundreds(m) + MilWord + Hundreds(h);
                }

                if (m == "000")
                {
                    if (ht != "000")
                        return Tens(b) + Hundreds(m) + MilWord + Hundreds(ht) + ThousWord + Hundreds(h);
                    if (ht == "000")
                        return Tens(b) + Hundreds(h);
                }
            }
            return null;
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
            if (length > 3)
                Console.WriteLine(Minus + BigNum(input) + decim);
            if (length > 12)
                Console.WriteLine("Too many numbers Pal. Please enter a number between -999,999,999,999 to 999,999,999,999 to any number of decimal places");
        }
    }
}
