using NumberVerify;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberVerify
{
    public class SwedishPersonalNumber
    {
        public static bool VerifyPersonalNumber(string personalNumber)
        {
            
            var verifiedPersonalNumber = false;
            int multiplier = 2;
            var controlDigit = int.Parse(personalNumber.Substring(personalNumber.Length - 1, 1));
            personalNumber = personalNumber.Replace("-", "");
            personalNumber = personalNumber[..^1];
            if (personalNumber.Length > 10)
            {
                personalNumber = personalNumber[2..];
            }

            List<int> intList = new();

            foreach (char digitChar in personalNumber)
            {
                if (char.IsDigit(digitChar))
                {
                    intList.Add(int.Parse(digitChar.ToString()));
                }
            }

            for (int i = 0; i < intList.Count; i++)
            {
                intList[i] = intList[i] * multiplier;
                if (multiplier == 2)
                    multiplier = 1;
                else
                    multiplier = 2;
            }

            var countAllDigitsInPersonalNumber = 0;

            foreach (var number in intList)
            {
                if (number >= 10)
                {
                    var numberToString = number.ToString();
                    var firstNumber = numberToString[..1];
                    var secondNumber = numberToString.Substring(1, 1);
                    countAllDigitsInPersonalNumber += int.Parse(firstNumber);
                    countAllDigitsInPersonalNumber += int.Parse(secondNumber);
                }
                else
                    countAllDigitsInPersonalNumber += number;
            }
            var controllNumber = (10 - (countAllDigitsInPersonalNumber % 10)) % 10;

            if (controllNumber == controlDigit)
            {
                verifiedPersonalNumber = true;
            }


            return verifiedPersonalNumber;
        }
    }
}
