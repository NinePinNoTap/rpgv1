using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LootItem : MonoBehaviour
{
    public Image lootImage;
    public Text lootText;
    public BaseItem lootItem;

    public void SetItem(BaseItem item)
    {
        lootItem = item;

        lootImage.sprite = item.icon;
        lootImage.overrideSprite = item.icon;
        lootText.text = item.name;
    }
}
