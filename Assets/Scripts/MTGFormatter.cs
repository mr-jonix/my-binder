using UnityEngine;
using System.Collections;

public static class MTGFormatter
{

    public static string FormatManaCost(string inputString)
    {
        if (inputString == string.Empty) { return ""; }
        else
        {
            string resultString = inputString;
            // Generic mana symbols
            resultString = inputString.Replace("{0}", "<sprite=0>");
            resultString = resultString.Replace("{1}", "<sprite=1>");
            resultString = resultString.Replace("{2}", "<sprite=2>");
            resultString = resultString.Replace("{3}", "<sprite=3>");
            resultString = resultString.Replace("{4}", "<sprite=4>");
            resultString = resultString.Replace("{5}", "<sprite=5>");
            resultString = resultString.Replace("{6}", "<sprite=6>");
            resultString = resultString.Replace("{7}", "<sprite=7>");
            resultString = resultString.Replace("{8}", "<sprite=8>");
            resultString = resultString.Replace("{9}", "<sprite=9>");
            resultString = resultString.Replace("{10}", "<sprite=10>");
            resultString = resultString.Replace("{11}", "<sprite=11>");
            resultString = resultString.Replace("{12}", "<sprite=12>");
            resultString = resultString.Replace("{13}", "<sprite=13>");
            resultString = resultString.Replace("{14}", "<sprite=14>");
            resultString = resultString.Replace("{15}", "<sprite=15>");
            resultString = resultString.Replace("{16}", "<sprite=16>");
            resultString = resultString.Replace("{17}", "<sprite=17>");
            resultString = resultString.Replace("{18}", "<sprite=18>");
            resultString = resultString.Replace("{19}", "<sprite=19>");
            resultString = resultString.Replace("{20}", "<sprite=20>");
            // X, Y, Z symbols
            resultString = resultString.Replace("{X}", "<sprite=21>");
            resultString = resultString.Replace("{Y}", "<sprite=22>");
            resultString = resultString.Replace("{Z}", "<sprite=23>");
            // Color mana symbols
            resultString = resultString.Replace("{W}", "<sprite=24>");
            resultString = resultString.Replace("{U}", "<sprite=25>");
            resultString = resultString.Replace("{B}", "<sprite=26>");
            resultString = resultString.Replace("{R}", "<sprite=27>");
            resultString = resultString.Replace("{G}", "<sprite=28>");
            resultString = resultString.Replace("{C}", "<sprite=57>");
            // Hybrid  mana symbols
            resultString = resultString.Replace("{W/U}", "<sprite=30>");
            resultString = resultString.Replace("{W/B}", "<sprite=31>");
            resultString = resultString.Replace("{U/B}", "<sprite=32>");
            resultString = resultString.Replace("{U/R}", "<sprite=33>");
            resultString = resultString.Replace("{B/R}", "<sprite=34>");
            resultString = resultString.Replace("{B/G}", "<sprite=35>");
            resultString = resultString.Replace("{R/G}", "<sprite=37>");
            resultString = resultString.Replace("{R/W}", "<sprite=36>");
            resultString = resultString.Replace("{G/W}", "<sprite=38>");
            resultString = resultString.Replace("{G/U}", "<sprite=39>");
            resultString = resultString.Replace("{2/W}", "<sprite=40>");
            resultString = resultString.Replace("{2/U}", "<sprite=41>");
            resultString = resultString.Replace("{2/B}", "<sprite=42>");
            resultString = resultString.Replace("{2/R}", "<sprite=43>");
            resultString = resultString.Replace("{2/G}", "<sprite=44>");
            // Phyrexian mana symbols
            resultString = resultString.Replace("{W/P}", "<sprite=45>");
            resultString = resultString.Replace("{U/P}", "<sprite=46>");
            resultString = resultString.Replace("{B/P}", "<sprite=47>");
            resultString = resultString.Replace("{R/P}", "<sprite=48>");
            resultString = resultString.Replace("{G/P}", "<sprite=49>");

            return resultString;
        }
    }


}
