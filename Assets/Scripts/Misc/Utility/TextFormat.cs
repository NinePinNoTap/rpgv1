using UnityEngine;
using System.Collections;

public static class TextFormat
{
    public static string Format(string textInput, int textSize, Color textColor, bool isBold = false, bool isItalic = false)
    {
        textInput = SetSize(textInput, textSize);
        textInput = SetColor(textInput, textColor);

        if(isBold)
        {
            textInput = SetBold(textInput);
        }

        if(isItalic)
        {
            textInput = SetItalic(textInput);
        }
        
        return textInput;
    }

    public static string SetSize(string textInput, int textSize)
    {
        return "<size=" + textSize + ">" + textInput + "</size>";
    }

    public static string SetColor(string textInput, Color textColor)
    {
        return "<color=" + ToHex(textColor) + ">" + textInput + "</color>";
    }

    public static string SetBold(string textInput)
    {
        return "<b>" + textInput + "</b>";
    }

    public static string SetItalic(string textInput)
    {
        return "<i>" + textInput + "</i>";
    }

    public static string ToHex(Color c)
    {
        return string.Format("#{0:X2}{1:X2}{2:X2}", ToByte(c.r), ToByte(c.g), ToByte(c.b));
    }
    
    private static byte ToByte(float f)
    {
        f = Mathf.Clamp01(f);
        return (byte)(f * 255);
    }
}

