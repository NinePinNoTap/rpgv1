using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using System.Text;

public class ItemDatabase : Singleton<ItemDatabase>
{
    public List<BaseItem> itemDB = new List<BaseItem>();

    void Start()
    {
        // Load Items
        Load("assets/Resources/itemdatabase.txt");
    }

    private bool Load(string fileName)
    {
        try
        {
            string line;
            StreamReader theReader = new StreamReader(fileName, Encoding.Default);
            using (theReader)
            {
                do
                {
                    line = theReader.ReadLine();

                    if (line != null)
                    {
                        string[] entries = line.Split(',');
                        if (entries.Length > 0)
                        {
                            LoadItem(entries);
                        }
                    }
                }
                while (line != null);

                theReader.Close();

                return true;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("{0}\n", e.Message);
            return false;
        }
    }

    void LoadItem(string[] itemInfo)
    {
        BaseItem loadItem;

        loadItem = new BaseItem();

        loadItem.itemID = int.Parse(itemInfo[0]);
        loadItem.itemName = itemInfo[1];
        loadItem.itemDescription = itemInfo[2];
        loadItem.itemIcon = Resources.Load<Sprite>("Icons/" + itemInfo[3]);
        loadItem.itemRarity = (Rarity)Enum.Parse(typeof(Rarity), itemInfo[4]);
        loadItem.itemLevel = int.Parse(itemInfo[5]);
        loadItem.requiredLevel = int.Parse(itemInfo[6]);
        loadItem.mainClass = (BaseItem.ItemMainClass)Enum.Parse(typeof(BaseItem.ItemMainClass), itemInfo[7]);
        loadItem.subClass = (BaseItem.ItemSubClass)Enum.Parse(typeof(BaseItem.ItemSubClass), itemInfo[8]);
        loadItem.buyPrice = int.Parse(itemInfo[9]);
        loadItem.sellPrice = int.Parse(itemInfo[10]);
        loadItem.maxCount = int.Parse(itemInfo[11]);
        loadItem.stackSize = int.Parse(itemInfo[12]);
        loadItem.remainingCharges = int.Parse(itemInfo[13]);

        itemDB.Add(loadItem);
    }
}