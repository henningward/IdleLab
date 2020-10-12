using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using BreakInfinity;
using static BreakInfinity.BigDouble;

public class Notation
{
    // 1: 1000 = k, 1000000 = m osv...
    public int CurrentNotation;
    private string[] sufficies;

    public Notation(){
        // Set default notation
        CurrentNotation = 1;
        sufficies = Constants.suffices;
    }

    private string PrettifySub(BigDouble number, int decimals){
        float numberfloat = float.Parse(number.ToString(), CultureInfo.InvariantCulture);
        BigDouble floor = Mathf.Floor(numberfloat);
        if (number == floor){
            return number.ToString();
        }
        BigDouble precision = 3 - floor.ToString().Length; // Use right number of digits
        //Debug.Log("Debug num: " + precision);
        //return (Round(number*3)/3).ToString();
        return number.ToString("F" + decimals);
    }

    // inspirert av trimps sin algoritme:
    // https://github.com/Trimps/Trimps.github.io/blob/c77873999cc7a94773e0f4b2ce16483223db1503/updates.js#L3200
    public string Prettify(BigDouble number, int decimals){
        string suffix = "";
        BigDouble tempNumber = number;
        if (number >= 1000 && number < 10000){
            return Floor(number).ToString();};
        if (number == 0){return Floor(number).ToString();};
        if (number < 0){return "-" + Prettify(-number, decimals);};
        if (number < 0.005){return number.ToString("G2");};

        BigDouble basenum = Floor(Ln(number)/Ln(1000));
        if (basenum <= 0) return PrettifySub(number, decimals);

        number /= Pow(1000, basenum);
        
        if (CurrentNotation == 1){
            if (basenum > sufficies.Length){
                return number.ToString("G2");
            } else if(basenum <= sufficies.Length) {
                //Debug.Log("XX " + ((int)basenum.ToDouble()-1).ToString());
                suffix = sufficies[(int)basenum.ToDouble() - 1];
            } else{
                return number.ToString("G" + decimals);
            }
        } else if (CurrentNotation == 2){
            return tempNumber.ToString("G2");
            // andre notasjonsformer kommer her!

        } else { //(CurrentNotation == 3)
            string[] sufficies = {"a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z"};
            if (basenum <= sufficies.Length) suffix = sufficies[(int)basenum.ToDouble() -1];
            else{
                BigDouble suf2 = (basenum.ToDouble() % (double)sufficies.Length)-1;
                if (suf2 < 0) suf2 = sufficies.Length - 1;
                BigDouble suffIndex = Ceiling(basenum / sufficies.Length);

                suffix = (sufficies[ (int)suffIndex.ToDouble() -2] + sufficies[(int) suf2.ToDouble()]);
                }

        }
        
        return PrettifySub(number, decimals) + suffix;
    }

    public int GetTotalNotationTypes(){
        return 3;
    }

}

