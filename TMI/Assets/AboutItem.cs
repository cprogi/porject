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
        itemName.Add(10,"Ǫ�� ����");
        itemName.Add(20, "����");
        itemName.Add(30, "ġ�� ����");
        itemName.Add(50, "�⸧ ���Ժ� �Ӹ�");
        itemName.Add(100, "���� ����");
        itemName.Add(200, "��� ����");
        itemName.Add(1000, "���͸�");

        itemData.Add(10,"ü���� ȸ���ϴ� ����");
        itemData.Add(20, "������ ����.������ ���� ���� ������ �𸥴�.");
        itemData.Add(30, "ó�� ġ���ϴ� ����� ����. Ǫ�� ���ʸ� 5�� �Դ� �Ͱ� ȿ���� ���ٰ� �˷��� �ִ�.");
        itemData.Add(50, "��ü�� ������ �Ѵ�.");
        itemData.Add(100, "���� ���� �Ƹ��ٿ� ����.");
        itemData.Add(200, "���� ���ó ��");
        itemData.Add(1000, "���ó� ��������");
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
