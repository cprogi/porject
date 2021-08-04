using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public GameObject slotItem;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player"))
        {
            Inventory inven = collision.GetComponent<Inventory>();
            for(int i =0; i< inven.slots.Length; i++)
            {
                if (inven.isEmpty[i])
                {
                    slotItem.SetActive(true);
                    Instantiate(slotItem, inven.slots[i].transform, false);
                    inven.isEmpty[i] = false;
                    Destroy(gameObject);
                    break;
                }
            }
        }
    }
}
