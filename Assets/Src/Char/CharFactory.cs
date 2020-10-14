using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Character
{
    /// <summary>
    /// 临时的生成
    /// </summary>
    public class CharFactory
    {
        public static BaseChar BuildChar()
        {
            BaseChar newChar;

            newChar = new BaseChar();
            return newChar;
        }








    }
}
