using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;

namespace CodingChallenge
{
    public static class ParsingExtensionMethod
    {
        public static string ParseLetters(this string str){
            StringBuilder stringBuilder = new StringBuilder();//to build the string that will be return
            StringBuilder tmp = new StringBuilder();//temporal to catch string between special characters or numbers
            var OnlyLetters = new Regex("^[a-zA-Z]+$");//Regex to identify when its a character
            
            
            for(int i = 0; i < str.Length; i++)
            {
                var flag = OnlyLetters.Match(str[i].ToString());// boolean flag that triggers where append count of letters and special characters

                if (!flag.Success)
                {
                    if(tmp.Length > 0)
                    {
                        stringBuilder.Append(GetDistincts(tmp));
                        tmp.Clear();
                    }
                    stringBuilder.Append(str[i]);
                }                    
                else
                {
                    tmp.Append(str[i]);
                }
                    
            }
            if (tmp.Length > 0)// append the rest of the text when we can't find any specialCharacter/ number else
                stringBuilder.Append(GetDistincts(tmp)); tmp.Clear();

            return stringBuilder.ToString();

        }
        private static string GetDistincts(StringBuilder tmp)
        {
            int distinct = tmp.ToString().Substring(1, tmp.Length - 2).Distinct().Count();
            
            return string.Concat(tmp[0], distinct, tmp[tmp.Length - 1]);
        }
    }
}
