using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LootItem : BaseInterfaceSlot
{
    public void SetItem(BaseItem item)
    {
        AddToSlot(item);
        SetSlotText(item.name);
    }

    public void AddToPlayerInventory()
    {
        if(IsEmpty())
        {
            Debug.Log("Error - Stack Empty");
            return;
        }

        if(UIManager.Instance.inventory.HasEmptySlots())
        {
            HideTooltip();
            UIManager.Instance.inventory.AddItem(slotStack.Peek() as BaseItem);
            UIManager.Instance.lootWindow.RemoveLoot(gameObject);
        }
    }
}
