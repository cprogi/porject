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
        itemData.Add(10,"HP�� 5 ȸ�� �����ִ� �������̴�.");
        itemData.Add(100, "���ʸ� ĳ�µ� ���ȴ�.");
    }

    public string ShowItemData(int id)
    {
        return itemData[id];
    }

}
