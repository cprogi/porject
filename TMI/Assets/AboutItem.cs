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
        itemName.Add(10,"해초");
        itemData.Add(10,"HP를 5 회복 시켜주는 아이템이다.");
        itemData.Add(100, "해초를 캐는데 사용된다.");
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
