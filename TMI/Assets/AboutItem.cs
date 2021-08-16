using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AboutItem : MonoBehaviour
{
    Dictionary<int, string> itemData;
    Dictionary<int, string> itemName;
    public Player player;
    public int itemReady;

    private void Awake()
    {
        itemData = new Dictionary<int, string>();
        itemName = new Dictionary<int, string>();
        GenerateData();
    }

    void GenerateData()
    {
        itemName.Add(10,"����");
        itemData.Add(10,"HP�� 5 ȸ�� �����ִ� �������̴�.");
        itemData.Add(100, "���ʸ� ĳ�µ� ���ȴ�.");
    }

    public string ShowItemData(int id)
    {
        return itemData[id];
    }
    public string ShowItemName(int id)
    {
        return itemName[id];
    }

    public void UseItem()
    {
        switch (itemReady)
        {
            case 10:
                player.playerHp += 20;
                break;
            default:
                return;
        }
    }
}
