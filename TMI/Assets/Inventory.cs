using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public bool[] isEmpty;
    public GameObject[] slots;
    public AboutItem aboutItem;

    private void Start()
    {
        for(int i =0; i<slots.Length; i++)
        {
            isEmpty[i] = true;
        }
    }

    private void Update()
    {
        CheckUseItem();
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].transform.childCount <= 0)
                isEmpty[i] = true;
        }

    }

    void CheckUseItem()
    {
        for(int i =1; i<=slots.Length; i++)
        {
            if(aboutItem.useItem == "slot" + i.ToString())
            {
                Transform Des = slots[i].transform.GetChild(0);
                Destroy(Des);
            }
        }
    }

}
