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
        questList.Add(10, new QuestData("흰동가리와 대화", new int[] { 1000, 2000 }));
        questList.Add(20, new QuestData("청색양쥐돔과 대화", new int[] { 3000 }));
        questList.Add(30, new QuestData("해마 푸른해초 주기", new int[] { 6000 }));
        questList.Add(40, new QuestData("푸른바다거북 치유해초 주기", new int[] { 7000 }));
        questList.Add(50, new QuestData("혹등고래와 대화", new int[] { 8000 }));
        questList.Add(60, new QuestData("나뭇잎해룡 초록 해룡 찾기", new int[] { 11000, 12000, 13000 }));
        questList.Add(70, new QuestData("쏠배감펭과 대화", new int[] { 14000, 15000 }));
        questList.Add(80, new QuestData("키다리게 소라껍질 주기", new int[] { 16000 }));
        questList.Add(90, new QuestData("매오징어 발광해초 캐기", new int[] { 17000 }));
        questList.Add(100, new QuestData("산갈치와 대화", new int[] { 18000, 19000 }));
        questList.Add(110, new QuestData("인어 문지기 진주 주기", new int[] { 21000 }));
        questList.Add(120, new QuestData("인어 수장과 대화", new int[] { 22000 }));
        questList.Add(130, new QuestData("바다돼지 친구 찾기", new int[] { 2000, 24000, 25000 }));
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
            //낫
            case 10:
                if (questActionIndex == 1)
                    questObject[0].SetActive(true);
                break;
            case 20:
                if (questActionIndex == 1)
                    questObject[0].SetActive(false);
                break;

            //거북이 길 비켜주기
            case 40:
                if (questActionIndex == 2)
                    questObject[2].SetActive(false);
                break;

            //가시
            case 70:
                if (questActionIndex == 2)
                    questObject[1].SetActive(true);
                break;
            case 80:
                if (questActionIndex == 1)
                    questObject[1].SetActive(false);
                break;
                
            //산갈치 비늘
            case 100:
                if (questActionIndex == 1)
                    questObject[3].SetActive(true);
                break;
            case 110:
                if (questActionIndex == 1)
                    questObject[3].SetActive(false);
                break;

            //바다돼지 친구 + 해초
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
