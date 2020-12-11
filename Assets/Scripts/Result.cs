using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Result
{
    public string originalText; // Amharic
    public string translatedText;
    public List<UnitAnimation> unit;

    public Result ( string originalText, string translatedText, List<UnitAnimation> unit )
    {
        this.originalText = originalText;
        this.translatedText = translatedText;
        this.unit = unit;
    }
}

