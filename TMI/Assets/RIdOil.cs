using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RIdOil : MonoBehaviour
{
    public Inventory inven;
    bool check;

    private void Awake()
    {
        check = false;
    }

    private void OnMouseDown()
    {
        for(int i =0; i < inven.slots.Length; i++)
        {
            if (inven.slots[i].transform.childCount > 1)
            {
                if (inven.slots[i].transform.GetChild(1).tag == "Asp")
                {
                    check = true;
                    break;
                }
            }   
        }

        if (check == true)
            Destroy(gameObject);
        else
            return;
    }
}
