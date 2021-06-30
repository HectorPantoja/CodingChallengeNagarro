using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;

namespace CodingChallenge
{
    public class ParsingClass
    {
        public string ParseLetters(string str){
            StringBuilder stringBuilder = new StringBuilder();//to build the string that will be return
            StringBuilder tmp = new StringBuilder();//temporal to catch string between special characters or numbers
            var regexCharacters = new Regex("^[a-zA-Z]+$");//Regex to identify when its a character
            
            
            for(int i = 0; i < str.Length; i++)
            {
                var flag = regexCharacters.Match(str[i].ToString());// boolean flag that triggers where append count of letters and special characters

                if (!flag.Success)
                {
                    if(tmp.Length > 0)
                    {
                        stringBuilder.Append(GetDistincts(tmp)); // get the count of different characters
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
        private string GetDistincts(StringBuilder tmp)
        {
            if (tmp.Length == 1)// if length of tmp is 1 that means is just a letter which it'll keep the same position in the original text
                return tmp.ToString();

            int distinct = tmp.ToString().Substring(1, tmp.Length - 2).Distinct().Count(); // get the count of different characters
            
            return string.Concat(tmp[0], distinct, tmp[tmp.Length - 1]);
        }
    }
}
