using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class Tooltip : MonoBehaviour
{
    [Header("Components")]
    public Text tooltipText;
    public HorizontalLayoutGroup layoutGroup;

    [Header("Configuration")]
    public RectOffset textPadding;
    public Vector3 tooltipOffset = new Vector3(0,0,0);

    [Header("Tooltip")]
    public List<string> tooltipStrings;
    public bool showTooltip = false;

	void Start ()
    {
        layoutGroup.padding = textPadding;
        HideTooltip();
	}

	void Update ()
    {
	    if(!showTooltip)
        {
            return;
        }

        Vector3 mousePos = Input.mousePosition + tooltipOffset;
        transform.position = mousePos;
	}

    //==========================
    // Adds Text to the Tooltip
    //==========================

    public void AddText(string textInput)
    {
        tooltipStrings.Add(textInput);
    }

    public void AddText(string textInput, int textSize, Color textColor, bool isBold = false, bool isItalic = false)
    {
        textInput = TextFormat.Format(textInput, textSize, textColor, isBold, isItalic);
        tooltipStrings.Add(textInput);
    }

    //==========================
    // Create / Destroy Tooltip
    //==========================

    public void ClearTooltip()
    {
        tooltipStrings.Clear();
        tooltipText.text = "";
    }
    
    public void Build()
    {
        tooltipText.text = "";
        
        // Add strings
        foreach(string str in tooltipStrings)
        {
            if(tooltipText.text.Length > 0)
            {
                tooltipText.text += "\n";
            }

            if(str.Length > 0)
            {
                tooltipText.text += str;
            }
        }
    }

    //====================
    // Tooltip Management
    //====================

    public void ShowTooltip()
    {
        showTooltip = true;
        gameObject.SetActive(true);
    }

    public void HideTooltip()
    {
        showTooltip = false;
        gameObject.SetActive(false);
    }
}