using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    
    public int questId;
    public int questActionIndex;
    public GameObject[] questObject;

    Dictionary<int, QuestData> questList;
    
    void Awake()
    {
        questList = new Dictionary<int, QuestData>();
        GenerateData();

    }

    void GenerateData()
    {
        questList.Add(10, new QuestData("�򵿰����� ��ȭ", new int[] { 1000, 2000 }));
        questList.Add(20, new QuestData("û�����㵼�� ��ȭ", new int[] { 3000 }));
        questList.Add(30, new QuestData("�ظ� Ǫ������ �ֱ�", new int[] { 6000 }));
        questList.Add(40, new QuestData("Ǫ���ٴٰź� ġ������ �ֱ�", new int[] { 7000 }));
        questList.Add(50, new QuestData("Ȥ����� ��ȭ", new int[] { 8000 }));
        questList.Add(60, new QuestData("�������ط� �ʷ� �ط� ã��", new int[] { 11000, 12000, 13000 }));
        questList.Add(70, new QuestData("��谨��� ��ȭ", new int[] { 14000, 15000 }));
        questList.Add(80, new QuestData("Ű�ٸ��� �Ҷ��� �ֱ�", new int[] { 16000 }));
        questList.Add(90, new QuestData("�ſ�¡�� �߱����� ĳ��", new int[] { 17000 }));
        questList.Add(100, new QuestData("�갥ġ�� ��ȭ", new int[] { 18000, 19000 }));
        questList.Add(110, new QuestData("�ξ� ������ ���� �ֱ�", new int[] { 21000 }));
        questList.Add(120, new QuestData("�ξ� ����� ��ȭ", new int[] { 22000 }));
        questList.Add(130, new QuestData("�ٴٵ��� ģ�� ã��", new int[] { 2000, 24000, 25000 }));
    }

    public int GetQuestTalkIndex(int id)
    {
        return questId + questActionIndex;
    }

    public void CheckQuest(int id)
    {
        if (id == questList[questId].npcId[questActionIndex])
        {
            questActionIndex++;
        }

        questreward();

        if (questActionIndex == questList[questId].npcId.Length)
        {
            NextQuest();
        }
    }

    void NextQuest()
    {
        questId += 10;
        questActionIndex = 0;
    }

    void questreward()
    {
        switch (questId)
        {
            //��
            case 10:
                if (questActionIndex == 1)
                    questObject[0].SetActive(true);
                break;
            case 20:
                if (questActionIndex == 1)
                    questObject[0].SetActive(false);
                break;

            //�ź��� �� �����ֱ�
            case 40:
                if (questActionIndex == 2)
                    questObject[2].SetActive(false);
                break;

            //����
            case 70:
                if (questActionIndex == 2)
                    questObject[1].SetActive(true);
                break;
            case 80:
                if (questActionIndex == 1)
                    questObject[1].SetActive(false);
                break;
                
            //�갥ġ ���
            case 100:
                if (questActionIndex == 1)
                    questObject[3].SetActive(true);
                break;
            case 110:
                if (questActionIndex == 1)
                    questObject[3].SetActive(false);
                break;

            //�ٴٵ��� ģ�� + ����
            case 130:
                if (questActionIndex == 2)
                    questObject[4].SetActive(false);
                if (questActionIndex == 3)
                    questObject[5].SetActive(true);
                    questObject[6].SetActive(true);
                break;
        }
    }

}
