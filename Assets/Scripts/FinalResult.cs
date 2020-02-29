using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalResult : MonoBehaviour
{
    public readonly string originalText; // Amharic
    public readonly string translatedText;
    public readonly List<UnitAnimation> unit;

    public FinalResult( string originalText,
                        string translatedText,
                        List<UnitAnimation> unit )
    {
        this.originalText = originalText;
        this.translatedText = translatedText;
        this.unit = unit;
    }
}

