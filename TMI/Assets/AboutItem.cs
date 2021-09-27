using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AboutItem : MonoBehaviour
{
    Dictionary<int, string> itemData;
    Dictionary<int, string> itemName;
    public Player player;
    public GameObject Asp;
    public GameObject Map;
    public GameObject Necro;
    public Inventory inven;
    public int itemReady;
    public string useItem;
    public string slotName;
    public int countGas;
    private void Awake()
    {
        itemData = new Dictionary<int, string>();
        itemName = new Dictionary<int, string>();
        GenerateData();
        countGas = 3;
    }

    void GenerateData()
    {
        itemName.Add(1, "��");
        itemName.Add(2, "��ġ");
        itemName.Add(3, "��");
        itemName.Add(4, "��");
        itemName.Add(10,"Ǫ�� ����");
        itemName.Add(20, "����");
        itemName.Add(30, "ġ�� ����");
        itemName.Add(40, "�⸧���Ա� ���Ժ�");
        itemName.Add(50, "�⸧���Ա� ��ü");
        itemName.Add(60, "����");
        itemName.Add(70, "���� ����");
        itemName.Add(80, "�⸧���Ա�");
        itemName.Add(90, "�߱�����");
        itemName.Add(100, "���� ����");
        itemName.Add(200, "��� ����");
        itemName.Add(300, "���� ����");
        itemName.Add(400, "�߱���");
        itemName.Add(500, "�������");
        itemName.Add(600, "�ξ�ž�");
        itemName.Add(700, "���ʳ����");
        itemName.Add(800, "���� ����");
        itemName.Add(900, "�ݺ����");
        itemName.Add(1000, "������");
        itemName.Add(1100, "��ũ�ι���");
        itemName.Add(1200, "û�� ��Ŀ");
        itemName.Add(1300, "�򺣰����� ����");
        itemName.Add(1400, "����");

        itemData.Add(1, "���ʸ� ĳ�� ����");
        itemData.Add(2, "������ ���� ���߸��� ưư�� ��ġ");
        itemData.Add(3, "�𷡸� �۳� �� �ִ� ��");
        itemData.Add(4, "�򵿰����� ���� ������");
        itemData.Add(10,"ü���� ȸ���ϴ� ����");
        itemData.Add(20, "������ ����.������ ���� ���� ������ �𸥴�.");
        itemData.Add(30, "ó�� ġ���ϴ� ����� ����. Ǫ�� ���ʸ� 5�� �Դ� �Ͱ� ȿ���� ���ٰ� �˷��� �ִ�.");
        itemData.Add(40, "�⸧���Ա��� ���Ժ�. ��ü�� ����.");
        itemData.Add(50, "�⸧���Ա��� ��ü. ���Ժΰ� ����.");
        itemData.Add(60, "������ ���� ����");
        itemData.Add(70, "�� �� ���� �׸��� �׷��� ���� ����");
        itemData.Add(80, "�⸧�� �����ϰų� ������ �⸧�� ������ �� �ִ� ����");
        itemData.Add(90, "������ ���� ���� �ź�ο� ����");
        itemData.Add(100, "���� ���� �Ƹ��ٿ� ����.");
        itemData.Add(200, "Ȳ�� ���� �Ƹ��ٿ� ���� ");
        itemData.Add(300, "���� ���� �ź�ο� ����");
        itemData.Add(400, "������ ���� ���� �ź�ο� ��");
        itemData.Add(500, "�갥ġ�� ���");
        itemData.Add(600, "�ξ�� ������ �� �ִ� ��ǰ. ���� �ð��� ������ �ٽ� ����� ������� ���ƿ´�");
        itemData.Add(700, "ü���� ������ ȸ���ϴ� ��");
        itemData.Add(800, "� ������ ������ ���� ���� ����");
        itemData.Add(900, "�ݺ��� ���");
        itemData.Add(1000, "������ǰ�� �۵���ų �� �ִ� ������");
        itemData.Add(1100, "������ ������ ������. �°� �ź�ο� �ּ����� ���� ������ ����� �ΰ��� ������ ���Ĺ�����.");
        itemData.Add(1200, "�Ƹ��ٿ� ����� ���� ��Ŀ. ������ �ε帮�� ���� ������ �𸥴�.");
        itemData.Add(1300, "�򺣰����� ������");
        itemData.Add(1400, "����� ���� �ٴ�� ������� ��� å");
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
                Transform DI = inven.slots[i].transform.GetChild(1);
                Destroy(DI.gameObject);
                itemReady = 0;
                break;
            }
        }
    }

    void CountAspMaterial()
    {
        int batteryIdx=0;
        int bodyIdx=0;
        int headIdx=0;
        int count = 0;
        for(int i =0; i < inven.slots.Length; i++)
        {
            if (inven.slots[i].transform.childCount > 1)
            {
                if (inven.slots[i].transform.GetChild(1).tag == "Battery")
                {
                    batteryIdx = i;
                    count++;
                    continue;
                }

                else if (inven.slots[i].transform.GetChild(1).tag == "Asphead")
                {
                    headIdx = i;
                    count++;
                    continue;
                }
                else if (inven.slots[i].transform.GetChild(1).tag == "Aspbody")
                {
                    bodyIdx = i;
                    count++;
                    continue;

                }
            }
        }

        if (count == 3)
        {
            Destroy(inven.slots[batteryIdx].transform.GetChild(1).gameObject);
            Destroy(inven.slots[headIdx].transform.GetChild(1).gameObject);
            Destroy(inven.slots[bodyIdx].transform.GetChild(1).gameObject);

            for(int j = 0; j < inven.slots.Length; j++)
            {
                if(inven.isEmpty[j] == true)
                {
                    Instantiate(Asp,inven.slots[j].transform,false);
                    break;
                }
            }
        }
    }

    void ShowMap()
    {
        Map.SetActive(true);
    }
    void ShowNecro()
    {
        Necro.SetActive(true);
    }

    public void UseItem()
    {
        switch (itemReady)
        {
            case 1:
                player.equip.GetComponent<SpriteRenderer>().sprite = player.equipList[0];
                break;
            case 2:
                player.equip.GetComponent<SpriteRenderer>().sprite = player.equipList[1];
                break;
            case 3:
                player.equip.GetComponent<SpriteRenderer>().sprite = player.equipList[2];
                break;
            case 10:
                player.playerHp += 10;
                check();
                break;
            case 30:
                player.playerHp += 50;
                check();
                break;
            case 40:
                CountAspMaterial();
                break;
            case 50:
                CountAspMaterial();
                break;
            case 70:
                ShowMap();
                break;
            case 80:
                if (player.isRidofGas)
                {
                    player.readyForAttack = true;
                    check();
                }
                break;
            case 600:
                player.ChangeToMarine();
                check();
                break;
            case 700:
                player.playerHp = 100;
                check();
                break;
            case 1000:
                CountAspMaterial();
                break;
            case 1100:
                ShowNecro();
                break;
            default:
                return;
        }
    }
}
