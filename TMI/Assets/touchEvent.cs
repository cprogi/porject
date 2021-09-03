using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class touchEvent : MonoBehaviour
{
    public GameObject slot;
    public Text itemDescription;
    public Text itemNameText;
    public AboutItem aboutItem;
    public string slotName;

    public void TouchEvent()
    {
        if (slot.transform.childCount > 1)
        {
            Transform item = slot.transform.GetChild(1);
            itemDescription.text = aboutItem.ShowItemData(item.GetComponent<ItemId>().itemId);
            itemNameText.text = aboutItem.ShowItemName(item.GetComponent<ItemId>().itemId);
            aboutItem.itemReady = item.GetComponent<ItemId>().itemId;
            aboutItem.slotName = slot.name;
        }
        else
            aboutItem.itemReady = 0;
    }
}
