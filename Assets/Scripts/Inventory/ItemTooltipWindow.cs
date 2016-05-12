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
        switch(item.itemRarity)
        {
            case Rarity.Common:
                itemTitle.color = Color.white;
                break;

            case Rarity.Rare:
                itemTitle.color = Color.yellow;
                break;

            case Rarity.Legendary:
                itemTitle.color = Color.blue;
                break;
        }

        itemDescription.text = "\"" + item.itemDescription + "\"";
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
                             moneySilver + "<color=silver>g</color> " + 
                             moneyCopper + "<color=#CD7F32>c</color>";
	}
}
