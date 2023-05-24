using System;
using System.Collections.Generic;
using System.Text;

namespace MakeItHAppen
{
    public class CreatePhoneNumbers
    {
        public static string CreatePhoneNumber(int[] numbers)
        {
            int[] firstThre = new int[3];
            for (int i = 0; i < 3; i++)
            {
                firstThre[i] = numbers[i];
            }
            int[] secondThree = new int[3];
            int counter = 3;
            for (int i = 0; i < 3; i++)
            {
                secondThree[i] = numbers[counter];
                counter++;
            }
            int[] lastDigits = new int[4];
            int counterForLast = 6;
            for (int i = 0; i < 4; i++)
            {
                lastDigits[i] = numbers[counterForLast];
                counterForLast++;
            }
            string phoneNumber = $"({string.Join("", firstThre)}) {string.Join("", secondThree)}-{string.Join("", lastDigits)}";
            return phoneNumber;
        }
    }
}
