using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public bool[] isEmpty;
    public GameObject[] slots;

    private void Start()
    {
        for(int i =0; i<slots.Length; i++)
        {
            isEmpty[i] = true;
        }
    }

    private void Update()
    {
        for(int i =0; i<slots.Length; i++)
        {
            if (slots[i].transform.childCount <= 0)
                isEmpty[i] = true;
        }
    }

}
