using UnityEngine;
using System.Collections;

public class UIManager : Singleton<UIManager>
{
    public Inventory inventory;
    public ActionBar actionBar;
    public Tooltip tooltip;

    public void ShowInventory()
    {
        inventory.gameObject.SetActive(true);
    }

    public void HideInventory()
    {
        inventory.gameObject.SetActive(false);
    }
}
