using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AboutItem : MonoBehaviour
{
    Dictionary<int, string> itemData;
    Dictionary<int, string> itemName;
    public Player player;
    public Inventory inven;
    public int itemReady;
    public string useItem;
    public string slotName;
    private void Awake()
    {
        itemData = new Dictionary<int, string>();
        itemName = new Dictionary<int, string>();
        GenerateData();
    }

    void GenerateData()
    {
        itemName.Add(10,"����");
        itemName.Add(20, "����");
        itemName.Add(100, "����");
        itemData.Add(10,"HP�� 5 ȸ�� �����ִ� �������̴�.");
        itemData.Add(20, "�������ڸ� ���µ� ���ȴ�.");
        itemData.Add(100, "���ó ��");
    }

    public string ShowItemData(int id)
    {
        return itemData[id];
    }
    public string ShowItemName(int id)
    {
        return itemName[id];
    }

    public void check()
    {
        for(int i = 0; i<inven.slots.Length; i++)
        {
            if(slotName == inven.slots[i].name)
            {
                Transform DI = inven.slots[i].transform.GetChild(0);
                Destroy(DI.gameObject);
                break;
            }
        }
    }

    public void UseItem()
    {
        switch (itemReady)
        {
            case 10:
                player.playerHp += 10;
                check();
                break;
            case 20:
                player.isUsedKey = true;
                break;
            default:
                return;
        }
    }
}
