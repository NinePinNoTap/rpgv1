using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ItemTooltipWindow : MonoBehaviour
{
	public GameObject tooltipObject;
	public Text itemTitle;
	public Text itemDescription;
	public Text itemSellPrice;

	void Update()
	{
		if(tooltipObject.activeSelf)
		{
			Vector3 mousePos = Input.mousePosition + new Vector3(10,-10,0);
			tooltipObject.transform.position = mousePos;
		}
	}

	public void ShowTooltip(InventorySlot slot)
	{
		BaseItem selectedItem = slot.GetItem();

		// Update UI
		SetItemInfo (selectedItem);
		SetItemRarity(selectedItem);
		SetItemSellPrice(selectedItem);

		tooltipObject.SetActive(true);
	}

	public void HideTooltip()
	{
		if(tooltipObject)
			tooltipObject.SetActive(false);
	}

	void SetItemInfo(BaseItem item)
	{
		itemTitle.text = item.itemName;
		itemDescription.text = item.itemDescription;
	}

	void SetItemRarity(BaseItem item)
	{
		switch(item.itemRarity)
		{
			case 0:
				itemTitle.color = Color.white;
				break;
				
			case 1:
				itemTitle.color = Color.yellow;
				break;
				
			case 2:
				itemTitle.color = Color.blue;
				break;
		}
	}

	void SetItemSellPrice(BaseItem item)
	{
		int sellPrice = item.sellPrice;

		int moneyCopper = sellPrice % 100;
		sellPrice = (sellPrice - moneyCopper) / 100;
		int moneySilver = sellPrice % 100;
		int moneyGold = (sellPrice - moneySilver) / 100;

		itemSellPrice.text = moneyGold + "g " + moneySilver + "s " + moneyCopper;
	}
}
