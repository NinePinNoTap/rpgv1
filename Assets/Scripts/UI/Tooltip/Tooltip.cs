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

    public void AddText(string tooltipLine)
    {
        tooltipStrings.Add(tooltipLine);
    }

    public void AddText(string tooltipLine, int lineSize, Color lineColor)
    {
        tooltipLine = TextFormat.Format(tooltipLine, lineSize, lineColor);
        tooltipStrings.Add(tooltipLine);
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
            tooltipText.text += str;
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