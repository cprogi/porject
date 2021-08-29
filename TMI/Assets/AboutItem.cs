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
        itemName.Add(10,"푸른 해초");
        itemName.Add(20, "열쇠");
        itemName.Add(30, "치유 해초");
        itemName.Add(50, "기름 흡입부 머리");
        itemName.Add(100, "붉은 보석");
        itemName.Add(200, "노란 보석");
        itemName.Add(1000, "베터리");

        itemData.Add(10,"체력을 회복하는 해초");
        itemData.Add(20, "오래된 열쇠.무엇을 열기 위한 것인지 모른다.");
        itemData.Add(30, "처를 치유하는 희귀한 해초. 푸른 해초를 5개 먹는 것과 효능이 같다고 알려져 있다.");
        itemData.Add(50, "몸체와 만나야 한다.");
        itemData.Add(100, "붉은 빛의 아름다운 보석.");
        itemData.Add(200, "역시 사용처 모름");
        itemData.Add(1000, "역시나 마찬가지");
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
            case 30:
                player.playerHp += 50;
                check();
                break;
            default:
                return;
        }
    }
}
