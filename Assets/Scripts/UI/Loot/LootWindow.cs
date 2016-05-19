using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class LootWindow : BaseInterfacePanel
{
    public List<GameObject> lootList = new List<GameObject>();
    public GameObject contentObject;
    public float heightOffset = 50;
    public float padding = 10;
    public Image lootImage;

    void Start()
    {
        lootImage = GetComponent<Image>();
        lootImage.enabled = false;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            AddItem(ItemDatabase.Instance.itemDB[Random.Range(0,4)]);
        }
    }

    void AddItem(BaseItem item)
    {
        GameObject lootObject;
        RectTransform lootRect;
        LootItem lootItem;
        float yPos;

        yPos = -35;
        yPos -= heightOffset * lootList.Count;
        yPos -= (padding * lootList.Count);

        lootObject = GameObject.Instantiate(slotPrefab);
        lootObject.transform.SetParent(contentObject.transform);
        lootObject.transform.localScale = new Vector3(1,1,1);
        lootObject.name = "Loot Item " + (lootList.Count + 1);
        lootList.Add(lootObject);

        lootRect = lootObject.GetComponent<RectTransform>();
        lootRect.localPosition = new Vector3(0, yPos, 0);

        lootItem = lootObject.GetComponent<LootItem>();
        lootItem.SetItem(item);

        lootImage.enabled = true;
    }

    public void RemoveLoot(GameObject obj)
    {
        lootList.Remove(obj);
        Destroy(obj);

        if(lootList.Count == 0)
        {
            lootImage.enabled = false;
        }
        else
        {
            RefreshWindow();
        }
    }

    public void RefreshWindow()
    {
        float yPos;
        RectTransform lootRect;

        for(int i = 0; i < lootList.Count; i++)
        {
            yPos = -35;
            yPos -= heightOffset * i;
            yPos -= (padding * i);

            lootRect = lootList[i].GetComponent<RectTransform>();
            lootRect.localPosition = new Vector3(0, yPos, 0);
        }
    }
}
