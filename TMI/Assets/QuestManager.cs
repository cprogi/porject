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
        questList.Add(10, new QuestData("�����⿡ ���� �ִ� �򵿰��� �����ֱ�1", new int[] { 1000 }));
        questList.Add(20, new QuestData("�����⿡ ���� �ִ� �򵿰��� �����ֱ�2", new int[] { 2000 }));
        questList.Add(30, new QuestData("��뵼�� ��ȭ�ϱ�", new int[] { 4000 }));
        questList.Add(40, new QuestData("Ǫ���ٴٰźϰ� ��ȭ�ϱ�", new int[] { 7000 }));
        questList.Add(50, new QuestData("�������ĸ��� ��ȭ�ϱ�", new int[] { 11000 }));
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
        ControlObject();

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

    void ControlObject()
    {
        switch (questId)
        {
            case 10:
                if (questActionIndex == 1)
                    questObject[0].SetActive(false);
                    questObject[1].SetActive(true);
                break;
        }
    }

}
