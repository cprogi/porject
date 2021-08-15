using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public int questId;
    public int questActionIndex;

    Dictionary<int, QuestData> questList;
    
    void Awake()
    {
        questList = new Dictionary<int, QuestData>();
        GenerateData();

    }

    void GenerateData()
    {
        questList.Add(10, new QuestData("쓰레기에 갇혀 있는 흰동가리 구해주기",
                                         new int[] { 1000 }));
        questList.Add(20, new QuestData("청색양쥐돔에게 안전한 서식지 찾아주기",
                                         new int[] { 1001 }));
    }

    public int GetQuestTalkIndex(int id)
    {
        return questId + questActionIndex;
    }

    public string CheckQuest(int id)
    {
        if(id == questList[questId].npcId[questActionIndex])
            questActionIndex++;

        if (questActionIndex == questList[questId].npcId.Length)
            NextQuest();

        return questList[questId].questName;
    }

    void NextQuest()
    {
        questId += 10;
        questActionIndex = 0;
    }
}
