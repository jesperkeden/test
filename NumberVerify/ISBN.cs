using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberVerify
{
    public class ISBN // 978-0-306-40615-7
    {
        public static bool VerifyIsbnNumber(string isbnString)
        {
            bool verified = false;
            isbnString = isbnString.Replace("-", "");
            var controlNumber = int.Parse(isbnString.Substring(isbnString.Length -1 , 1));
            isbnString = isbnString[..^1];

            var individualNumberFromIsbnList = new List<int>();

            foreach (char digitChar in isbnString)
            {
                if (char.IsDigit(digitChar))
                {
                    individualNumberFromIsbnList.Add(int.Parse(digitChar.ToString()));
                }
            }

            if (individualNumberFromIsbnList.Count > 10)
            {
                var multiplier = 1;
                var counter = 0;
                
                foreach(var digit in individualNumberFromIsbnList)
                {
                    counter += digit * multiplier;
                    if (multiplier == 1)
                        multiplier = 3;
                    else
                        multiplier = 1;

                }
                var remainder = counter % 10;
                var compareToControlDigit = 10 - remainder;

                if (compareToControlDigit == controlNumber)
                {
                    verified = true;
                }

            }
            else
            {
                var multiplier = 10;
                var counter = 0;

                foreach (var digit in individualNumberFromIsbnList)
                {
                    counter += digit * multiplier;
                    multiplier--;
                }
                var remainder = counter % 11;
                if (11 - remainder == controlNumber)
                {
                    verified = true;
                }
            }



            return verified;
        }
    }
}
