using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasBox : MonoBehaviour
{
    public Inventory inven;
    public Player player;
    public GameObject JewelyA;


    public void GetItem()
    {
        for (int i = 0; i < inven.slots.Length; i++)
        {
            if (inven.isEmpty[i])
            {
                Instantiate(JewelyA, inven.slots[i].transform, false);
                inven.isEmpty[i] = false;
                break;
            }
        }
    }
}

