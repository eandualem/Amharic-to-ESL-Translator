using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class AnimationMapper : MonoBehaviour
{
    private AnimationBiulder biulder;
    private Data data;
    private List<UnitAnimation> units;

    public Result mapper(string text, string originalTetx)
    {
        units = new List<UnitAnimation>();
        data = new Data();
        biulder = new AnimationBiulder();

        string[] stringArray = text.Split(' ');

        foreach (string word in stringArray)
        {
            string[,,] foundValue = new string[ 2, 3, 3];

            if (data.words.TryGetValue(word, out foundValue))
            {
                units.Add(mapper(foundValue));
            }
            else
            {
                // finger spell
                char[] ca = word.ToCharArray();
                foreach (var c in ca)
                {
                    if (data.characters.TryGetValue(c, out foundValue))
                    {
                        units.Add(mapper(foundValue));
                    }
                }
            }
        }
        return new Result(originalTetx, text, units);
    }

    // symbol = new string[,,] { { { "AAAAA", "A", "31" }, { "A", null, null }, { "AAAAA", "B", "20" } }, { { "CCCCC", "A", "09" }, { "A", null, null }, { "CCCCC", "A", "09" } } });
    public UnitAnimation mapper(string[,,] symbol)
    {
        // split the string
        string[] temp = new string[18];
        int place = 0;
        
        for (int i = 0; i < symbol.GetLength(0); i++)
        {
            for (int j = 0; j < symbol.GetLength(1); j++)
            {
                for (int k = 0; k < symbol.GetLength(2); k++)
                {
                    temp[place] = symbol[i, j, k];
                    place++;
                }
            }
        }

        if (temp[0] != null)
        {
            char[] ca = temp[0].ToCharArray();
            string str = "";

            foreach (var c in ca)
            {
                str += GetConf(c);
            }
            biulder = biulder.RightHandConfigration(str);
        }
        if (temp[1] != null)
        {
            biulder = biulder.RightHandOrientation(temp[1]);
        }
        if (temp[2] != null)
        {
            biulder = biulder.RightArmPosition(GetPos(temp[2]));
        }
        if (temp[3] != null)
        {
            biulder = biulder.RightHandTransition(temp[3]);
        }
        if (temp[6] != null)
        {
            char[] ca = temp[6].ToCharArray();
            string str = "";
            foreach (var c in ca)
            {
                str += GetConf(c);
            }
            biulder = biulder.RightHandConfigrationFinal(str);
        }
        if (temp[7] != null)
        {
            biulder = biulder.RightHandOrientationFinal(temp[7]);
        }
        if (temp[8] != null)
        {
            biulder = biulder.RightArmPositionFinal(GetPos(temp[8]));
        }
        if (temp[9] != null)
        {
            char[] ca = temp[9].ToCharArray();
            string str = "";
            foreach (var c in ca)
            {
                str += GetConf(c);
            }
            biulder = biulder.LeftHandConfigration(str);
        }
        if (temp[10] != null)
        {
            biulder = biulder.LeftHandOrientation(temp[10]);
        }
        if (temp[11] != null)
        {
            biulder = biulder.LeftArmPosition(GetPos(temp[11]));
        }
        if (temp[12] != null)
        {
            biulder = biulder.LeftHandTransition(temp[12]);
        }
        if (temp[15] != null)
        {
            char[] ca = temp[15].ToCharArray();
            string str = "";
            foreach (var c in ca)
            {
                str += GetConf(c);
            }
            biulder = biulder.LeftHandConfigrationFinal(str);
        }
        if (temp[16] != null)
        {
            biulder = biulder.LeftHandOrientationFinal(temp[16]);
        }
        if (temp[17] != null)
        {
            biulder = biulder.LeftArmPositionFinal(GetPos(temp[17]));
        }

        return biulder.Build();
    }

    private string GetConf(char c)
    {
        switch (c)
        {
            case 'A': return "X0Y0";
            case 'B': return "X0Y1";
            case 'C': return "X1Y0";
            case 'D': return "X1Y1";
            case 'E': return "X2Y0";
            case 'F': return "X2Y1";
            case 'G': return "X3Y0";
            case 'H': return "X3Y1";
            case 'I': return "X4Y0";
            case 'J': return "X4Y1";
            case 'K': return "X5Y0";
            case 'L': return "X5Y1";
            case 'M': return "X0Y2";
            case 'N': return "X1Y2";
            case 'O': return "X2Y2";
            case 'P': return "X3Y2";
            case 'Q': return "X4Y2";
            case 'R': return "X5Y2";
            default:  throw new Exception("Invalid Letter");
        }
    }

    private Vector3 GetPos(string poseString)
    {
        switch (poseString)
        {
            case "00": return new Vector3( 0.30f, 1.0f, 0.3f);
            case "01": return new Vector3( 0.30f, 1.2f, 0.3f);
            case "02": return new Vector3( 0.30f, 1.4f, 0.3f);
            case "03": return new Vector3( 0.30f, 1.6f, 0.3f);
            case "04": return new Vector3( 0.15f, 1.0f, 0.3f);
            case "05": return new Vector3( 0.15f, 1.2f, 0.3f);
            case "06": return new Vector3( 0.15f, 1.4f, 0.3f);
            case "07": return new Vector3( 0.15f, 1.6f, 0.3f);
            case "08": return new Vector3( 0.00f, 1.0f, 0.3f);
            case "09": return new Vector3( 0.00f, 1.2f, 0.3f);
            case "10": return new Vector3( 0.00f, 1.4f, 0.3f);
            case "11": return new Vector3( 0.00f, 1.6f, 0.3f);
            case "12": return new Vector3(-0.15f, 1.0f, 0.3f);
            case "13": return new Vector3(-0.15f, 1.2f, 0.3f);
            case "14": return new Vector3(-0.15f, 1.4f, 0.3f);
            case "15": return new Vector3(-0.15f, 1.6f, 0.3f);
            case "16": return new Vector3(-0.30f, 1.0f, 0.3f);
            case "17": return new Vector3(-0.30f, 1.2f, 0.3f);
            case "18": return new Vector3(-0.30f, 1.4f, 0.3f);
            case "19": return new Vector3(-0.30f, 1.6f, 0.3f);
            // On body
            case "20": return new Vector3( 0.000f,  1.700f,  0.200f);
            case "21": return new Vector3( 0.000f,  1.625f,  0.200f);
            case "22": return new Vector3(-0.100f,  1.575f,  0.200f);
            case "23": return new Vector3( 0.100f,  1.575f,  0.200f);
            case "24": return new Vector3(-0.150f,  1.550f,  0.100f);
            case "25": return new Vector3( 0.150f,  1.550f,  0.100f);
            case "26": return new Vector3( 0.000f,  1.525f,  0.200f);
            case "27": return new Vector3( 0.000f,  1.475f,  0.200f);
            case "28": return new Vector3( 0.000f,  1.450f,  0.200f);
            case "29": return new Vector3(-0.150f,  1.350f,  0.100f);
            case "30": return new Vector3( 0.150f,  1.350f,  0.100f);
            case "31": return new Vector3( 0.000f,  1.375f,  0.150f);
            case "32": return new Vector3(-0.050f,  1.200f,  0.200f);
            case "33": return new Vector3( 0.050f,  1.200f,  0.200f);
            case "34": return new Vector3( 0.150f,  1.010f,  0.200f);
            case "35": return new Vector3(-0.050f,  0.890f,  0.200f);
            case "36": return new Vector3( 0.050f,  0.890f,  0.200f);

            default:   throw new Exception("Invalid Number");
        }
    }

}
