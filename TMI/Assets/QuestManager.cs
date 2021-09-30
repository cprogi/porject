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
        questList.Add(10, new QuestData("�򵿰����� ��ȭ", new int[] { 1000}));
        questList.Add(20, new QuestData("û�����㵼�� ��ȭ", new int[] { 2000 }));
        questList.Add(30, new QuestData("�ظ� Ǫ�� ���� �ֱ�", new int[] { 5000 }));
        questList.Add(40, new QuestData("Ǫ���ٴٰź� ġ�� ���� �ֱ�", new int[] { 6000 }));
        questList.Add(50, new QuestData("�������ط� �ʷ� �ط� ã��", new int[] { 7000 }));
        questList.Add(60, new QuestData("Ű�ٸ��� �Ҷ��� �ֱ�", new int[] { 000 }));
        questList.Add(70, new QuestData("�ſ�¡�� �߱� ���� ĳ��", new int[] { 000 }));
        questList.Add(80, new QuestData("�ξ���� ���� �ֱ�", new int[] { 000 }));
        questList.Add(90, new QuestData("�ٴٵ��� ģ�� ã��", new int[] { 000 }));
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
                    Debug.Log("�ߺ� " + j.ToString());
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
        talkText.text = "�������� ȹ���Ͽ����ϴ�.";
        Invoke("CloseText", 1);
    }
}
