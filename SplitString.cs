using System;
using System.Collections.Generic;
using System.Text;

namespace MakeItHAppen
{
    class SplitString
    {
        public static string[] Solution(string str)
        {
            // 'abc' =>  ['ab', 'c_']
            // *'abcdef' => ['ab', 'cd', 'ef']
            if (str.Length % 2 == 1)
            {
                str = $"{str}_";
            }
            string[] result = new string[str.Length / 2];
            char[] charArr = str.ToCharArray();
            int index = 0;
            for (int i = 0; i < charArr.Length; i += 2)
            {
                result[index] = $"{charArr[i]}{charArr[i + 1]}";
                index++;
            }
            return result;
        }
    }
}
