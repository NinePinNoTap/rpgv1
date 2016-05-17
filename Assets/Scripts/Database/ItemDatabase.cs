using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using System.Text;
using ItemConfig;

public class ItemDatabase : Singleton<ItemDatabase>
{
    public List<BaseItem> itemDB = new List<BaseItem>();

    void Start()
    {
		List<string[]> fileStorage = new List<string[]>();

        FileLoader.Load("assets/Resources/itemdatabase.txt", ref fileStorage);

		foreach(string[] itemInfo in fileStorage)
		{
			LoadItem (itemInfo);
		}
    }

    void LoadItem(string[] itemInfo)
    {
        BaseItem loadItem;

        loadItem = new BaseItem();

        loadItem.ID = int.Parse(itemInfo[0]);
        loadItem.name = itemInfo[1];
        loadItem.description = itemInfo[2];
        loadItem.icon = Resources.Load<Sprite>("Icons/" + itemInfo[3]);
        loadItem.itemQuality = (ItemQuality)Enum.Parse(typeof(ItemQuality), itemInfo[4]);
        loadItem.itemLevel = int.Parse(itemInfo[5]);
        loadItem.requiredLevel = int.Parse(itemInfo[6]);
        loadItem.mainClass = (ItemClass)Enum.Parse(typeof(ItemClass), itemInfo[7]);
        loadItem.subClass = (ItemSubClass)Enum.Parse(typeof(ItemSubClass), itemInfo[8]);
        loadItem.buyPrice = int.Parse(itemInfo[9]);
        loadItem.sellPrice = int.Parse(itemInfo[10]);
        loadItem.maxCount = int.Parse(itemInfo[11]);
        loadItem.stackSize = int.Parse(itemInfo[12]);
        loadItem.spellCharges = int.Parse(itemInfo[13]);

        itemDB.Add(loadItem);
    }
}