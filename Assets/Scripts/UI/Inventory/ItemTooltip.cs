using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using ItemConfig;

public class ItemTooltip : MonoBehaviour
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
		SetItemSellPrice(selectedItem);

		tooltipObject.SetActive(true);
	}

	public void HideTooltip()
	{
		tooltipObject.SetActive(false);
	}

	void SetItemInfo(BaseItem item)
	{
		itemTitle.text = item.name;

        switch(item.itemQuality)
		{
			case ItemQuality.Basic:
				itemTitle.color = new Color(0.5f, 0.5f, 0.5f);
				break;

			case ItemQuality.Regular:
				itemTitle.color = new Color(1, 1, 1);
				break;

			case ItemQuality.Inconsistent:
				itemTitle.color = new Color(1, 1, 0.43f);
				break;

			case ItemQuality.Rare:
				itemTitle.color = new Color(0.54f, 0.54f, 1);
				break;

			case ItemQuality.Majestic:
				itemTitle.color = new Color(0, 0, 1);
				break;

			case ItemQuality.Legendary:
				itemTitle.color = new Color(1.0f, 0.25f, 0.25f);
				break;
        }

        itemDescription.text = "\"" + item.description + "\"";
	}

	void SetItemSellPrice(BaseItem item)
	{
        int sellPrice, moneyCopper, moneySilver, moneyGold;

        // Calculate copper, silver and gold
		sellPrice = item.sellPrice;
		moneyCopper = sellPrice % 100;
		sellPrice = (sellPrice - moneyCopper) / 100;
		moneySilver = sellPrice % 100;
		moneyGold = (sellPrice - moneySilver) / 100;

        // Output
		itemSellPrice.text = moneyGold + "<color=yellow>g</color> " +
                             moneySilver + "<color=silver>s</color> " + 
                             moneyCopper + "<color=#CD7F32>c</color>";
	}
}
