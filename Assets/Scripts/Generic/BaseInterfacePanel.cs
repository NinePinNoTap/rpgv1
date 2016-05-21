using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class BaseInterfacePanel : MonoBehaviour
{
	[Header("Configuration")]
	public int columnCount = 1;
	public int rowCount = 1;
	public float slotPadding = 10;
	public float slotSize = 100;
	public GameObject slotPrefab;
	protected List<GameObject> panelSlots = new List<GameObject>();
	protected RectTransform panelBackground;
	protected Vector2 panelSize;

    void Start()
    {
        CreatePanel();
        CreateSlots();
    }

	protected void CreatePanel()
	{
		// Calculate size of inventory window
        panelSize = new Vector2();
		panelSize.x = columnCount * (slotSize + slotPadding) + slotPadding;
		panelSize.y = rowCount * (slotSize + slotPadding) + slotPadding;
		
		// Set up the inventory background
		panelBackground = GetComponent<RectTransform>();
		panelBackground.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, panelSize.x);
		panelBackground.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, panelSize.y);
	}

	protected void CreateSlots()
	{
		for (int y = 0; y < rowCount; y++)
		{
			for (int x = 0; x < columnCount; x++)
			{
				CreateSlot(x,y);
			}
		}
	}
	
	protected void CreateSlot(int x, int y)
	{
		GameObject slotObj;
		RectTransform slotRect;
		Vector2 slotPosition;
		
		// Create a new slot gameobject
		slotObj = (GameObject)Instantiate(slotPrefab);
		slotObj.name = "Slot " + (panelSlots.Count+1).ToString();
		slotObj.transform.SetParent(transform);
		slotObj.transform.localScale = new Vector3(1,1,1);
		
		// Define slot transform
		slotRect = slotObj.GetComponent<RectTransform>();
		slotRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, slotSize);
		slotRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, slotSize);
        slotPosition.x = slotPadding * (x + 1) + (slotSize * x) - (panelBackground.sizeDelta.x * panelBackground.pivot.x);
        slotPosition.y = -slotPadding * (y + 1) - (slotSize * y) + (panelBackground.sizeDelta.y * (1-panelBackground.pivot.y));
		slotRect.localPosition = slotPosition;
		
		// Add to our array
		panelSlots.Add(slotObj);
  	}
}