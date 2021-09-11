using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sand : MonoBehaviour
{
    public Inventory inven;

    private void OnMouseDown()
    {
        for(int i = 0; i<inven.slots.Length; i++)
        {
            if (inven.slots[i].transform.childCount > 1 && inven.slots[i].transform.GetChild(1).gameObject.tag == "Shovel")
                Destroy(gameObject);
        }
    }
}
