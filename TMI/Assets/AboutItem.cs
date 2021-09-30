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
        itemName.Add(1, "낫");
        itemName.Add(2, "망치");
        itemName.Add(3, "삽");
        itemName.Add(4, "컵");
        itemName.Add(10,"푸른 해초");
        itemName.Add(20, "열쇠");
        itemName.Add(30, "치유 해초");
        itemName.Add(40, "기름흡입기 흡입부");
        itemName.Add(50, "기름흡입기 몸체");
        itemName.Add(60, "진주");
        itemName.Add(70, "낡은 지도");
        itemName.Add(80, "기름흡입기");
        itemName.Add(90, "발광해초");
        itemName.Add(100, "붉은 보석");
        itemName.Add(200, "노란 보석");
        itemName.Add(300, "보라 보석");
        itemName.Add(400, "발광석");
        itemName.Add(500, "은빛비늘");
        itemName.Add(600, "인어변신약");
        itemName.Add(700, "해초농축액");
        itemName.Add(800, "낡은 문고리");
        itemName.Add(900, "금빛비늘");
        itemName.Add(1000, "건전지");
        itemName.Add(1100, "네크로미콘");
        itemName.Add(1200, "청록 노커");
        itemName.Add(1300, "쏠베감펭의 가시");
        itemName.Add(1400, "도감");

        itemData.Add(1, "해초를 캐는 도구");
        itemData.Add(2, "딱딱한 것을 깨뜨리는 튼튼한 망치");
        itemData.Add(3, "모래를 퍼낼 수 있는 삽");
        itemData.Add(4, "흰동가리가 갇힌 쓰레기");
        itemData.Add(10,"체력을 회복하는 해초");
        itemData.Add(20, "오래된 열쇠.무엇을 열기 위한 것인지 모른다.");
        itemData.Add(30, "처를 치유하는 희귀한 해초. 푸른 해초를 5개 먹는 것과 효능이 같다고 알려져 있다.");
        itemData.Add(40, "기름흡입기의 흡입부. 몸체가 없다.");
        itemData.Add(50, "기름흡입기의 몸체. 흡입부가 없다.");
        itemData.Add(60, "영롱한 빛의 진주");
        itemData.Add(70, "알 수 없는 그림이 그려진 낡은 지도");
        itemData.Add(80, "기름을 흡입하거나 흡입한 기름을 방출할 수 있는 도구");
        itemData.Add(90, "영롱한 빛을 내는 신비로운 해초");
        itemData.Add(100, "붉은 빛의 아름다운 보석.");
        itemData.Add(200, "황금 빛의 아름다운 보석 ");
        itemData.Add(300, "보라 빛의 신비로운 보석");
        itemData.Add(400, "영롱한 빛을 내는 신비로운 돌");
        itemData.Add(500, "산갈치의 비늘");
        itemData.Add(600, "인어로 변신할 수 있는 약품. 일정 시간이 지나면 다시 사람의 모습으로 돌아온다");
        itemData.Add(700, "체력을 완전히 회복하는 약");
        itemData.Add(800, "어떤 문에서 떨어져 나온 듯한 문고리");
        itemData.Add(900, "금빛의 비늘");
        itemData.Add(1000, "전자제품을 작동시킬 수 있는 건전지");
        itemData.Add(1100, "금지된 전설의 마도서. 온갖 신비로운 주술들이 적혀 있지만 평범한 인간은 읽으면 미쳐버린다.");
        itemData.Add(1200, "아름다운 모양의 도어 노커. 무엇을 두드리기 위한 것인지 모른다.");
        itemData.Add(1300, "쏠베감펭의 독가시");
        itemData.Add(1400, "당신이 만난 바닷속 생명들이 담긴 책");
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
