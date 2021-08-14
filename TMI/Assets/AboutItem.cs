using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AboutItem : MonoBehaviour
{
    Dictionary<int, string> itemData;

    private void Awake()
    {
        itemData = new Dictionary<int, string>();
        GenerateData();
    }

    void GenerateData()
    {
        itemData.Add(10,"HP를 5 회복 시켜주는 아이템이다.");
        itemData.Add(100, "해초를 캐는데 사용된다.");
    }

    public string ShowItemData(int id)
    {
        return itemData[id];
    }

}
