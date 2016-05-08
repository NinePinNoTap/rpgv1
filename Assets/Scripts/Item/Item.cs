using UnityEngine;
using System.Collections;

public class Item
{
    [Header("Information")]
    public string ItemName = "";
    public string ItemDescription = "";

    [Header("Attributes")]
    public int BuyPrice = 0;
    public int SellPrice = 0;
}
