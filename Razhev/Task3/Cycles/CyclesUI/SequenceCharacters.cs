using System;
using System.Collections.Generic;
using System.Linq;
class SequenceCharacters
{
    public List<char> GetSequenceCharacters(List<string> allStr, List<int> lenghtStr)
    {
        var symbols = new List<char>();
        for (int i = 0; i < lenghtStr.Count; i++)
        {
            if (lenghtStr[i] % 2 == 0)
            {
                symbols.Add(allStr[i].ToCharArray()[allStr[i].Length - 1]);
            }
            else
            {
                symbols.Add(allStr[i].ToCharArray()[0]);
            }
        }
        return symbols;
    }
}