using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public RectTransform shopUi;

    public GameObject[] itemObj;
    public GameObject[] require;
    public int[] requireNum;
    public int[] itemNum;
    public Inventory inven;
    public Text talkText;

   

    public void Enter()
    {
        shopUi.anchoredPosition = Vector2.zero;
        Time.timeScale = 0;
    }

    public void Exit()
    {
        shopUi.anchoredPosition = Vector2.down * 1000;
        Time.timeScale = 1;
    }
    
    public void Buy(int index)
    {
        int count = 0;
        int materialIdx = 0;
        for(int i = 0; i < inven.slots.Length; i++)
        {
            if (inven.slots[i].transform.childCount > 1)
            {
                Transform c = inven.slots[i].transform.GetChild(1);
                if(c.gameObject.tag == require[index].gameObject.tag)
                {
                    count = inven.slots[i].transform.childCount - 1;
                    materialIdx = i;
                    break;
                }
            }
        }

        if (count >= requireNum[index])
        {
            int cnt = 0;
            while (cnt < requireNum[index])
            {
                Transform k = inven.slots[materialIdx].transform.GetChild(1);
                Destroy(k.gameObject);
                cnt++;
            }

            int ct = 0;
            bool checkOverlap = false;
            int overlapIdx = 0;

            for(int j = 0; j<inven.slots.Length; j++)
            {
                if (inven.slots[j].transform.childCount > 1)
                {
                    Transform go = inven.slots[j].transform.GetChild(1);

                    if(go.gameObject.tag == itemObj[index].tag)
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
                        for (int l = 0; l < itemNum[index]; l++)
                        {
                            if (ct == itemNum[index])
                                break;
                            Instantiate(itemObj[index], inven.slots[k].transform, false);
                            ct++;
                        }
                        break;
                    }
                }
            }
            else
            {
                for (int l = 0; l < itemNum[index]; l++)
                {
                    if (ct == itemNum[index])
                        break;
                    Instantiate(itemObj[index], inven.slots[overlapIdx].transform, false);
                    ct++;
                    Debug.Log("ok");
                }
            }

            OpenText();
            talkText.text = "아이템을 구입하셨습니다.";
            Invoke("CloseText", 1);
        }
        else
        {
            OpenText();
            talkText.text = "개수가 부족합니다.";
            Invoke("CloseText", 1);
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
}
