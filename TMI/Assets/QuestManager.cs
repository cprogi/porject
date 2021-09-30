using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestManager : MonoBehaviour
{

    public int questId;
    public int questActionIndex;
    public GameObject[] questObject;
    public GameObject itemObj;
    public int itemNum;
    public Inventory inven;
    public Text talkText;

    Dictionary<int, QuestData> questList;

    void Awake()
    {
        questList = new Dictionary<int, QuestData>();
        GenerateData();
    }

    void GenerateData()
    {
        questList.Add(10, new QuestData("흰동가리와 대화", new int[] { 1000}));
        questList.Add(20, new QuestData("청색양쥐돔과 대화", new int[] { 2000 }));
        questList.Add(30, new QuestData("해마 푸른 해초 주기", new int[] { 5000 }));
        questList.Add(40, new QuestData("푸른바다거북 치유 해초 주기", new int[] { 6000 }));
        questList.Add(50, new QuestData("나뭇잎해룡 초록 해룡 찾기", new int[] { 7000 }));
        questList.Add(60, new QuestData("키다리게 소라껍질 주기", new int[] { 000 }));
        questList.Add(70, new QuestData("매오징어 발광 해초 캐기", new int[] { 000 }));
        questList.Add(80, new QuestData("인어문지기 진주 주기", new int[] { 000 }));
        questList.Add(90, new QuestData("바다돼지 친구 찾기", new int[] { 000 }));
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

    void OpenText()
    {
        talkText.gameObject.SetActive(true);
    }

    void CloseText()
    {
        talkText.gameObject.SetActive(false);
    }

    public void reward()
    {
        int count = 0;
        bool checkOverlap = false;
        int overlapIdx = 0;

        for(int j = 0; j<inven.slots.Length; j++)
        {
            if (inven.slots[j].transform.childCount > 1)
            {
                Transform go = inven.slots[j].transform.GetChild(1);

                if(go.gameObject.tag == itemObj.tag)
                {
                    checkOverlap = true;
                    overlapIdx = j;
                    Debug.Log("중복 " + j.ToString());
                    break;
                }
            }
        }

        if (checkOverlap == false)
        {
            for (int k = 0; k < inven.slots.Length; k++)
            {
                if (inven.isEmpty[k])
                {
                    inven.isEmpty[k] = false;
                    for (int l = 0; l < itemNum; l++)
                    {
                        if (count == itemNum)
                            break;
                        Instantiate(itemObj, inven.slots[k].transform, false);
                        count++;
                    }
                    break;
                }
            }
        }
        else
        {
            for (int l = 0; l < itemNum; l++)
            {
                if (count == itemNum)
                    break;
                Instantiate(itemObj, inven.slots[overlapIdx].transform, false);
                count++;
                Debug.Log("ok");
            }
        }

        OpenText();
        talkText.text = "아이템을 획득하였습니다.";
        Invoke("CloseText", 1);
    }
}
