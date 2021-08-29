using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public bool[] isEmpty;
    public GameObject[] slots;
    public Text[] itemCount;
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
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].transform.childCount <= 0)
                isEmpty[i] = true;
            else
                isEmpty[i] = false;
        }

        for(int j = 0; j < slots.Length; j++)
        {
            itemCount[j].text = slots[j].transform.childCount.ToString();
        }
    }
}
