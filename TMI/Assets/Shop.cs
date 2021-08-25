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
        for(int i = 0; i < inven.slots.Length; i++)
        {
            if (inven.slots[i].transform.childCount > 0)
            {
                Transform c = inven.slots[i].transform.GetChild(0);
                if (require[index].gameObject.name == c.gameObject.name)
                {
                    count++;
                }
            }
        }

        if (count >= requireNum[index])
        {
            int cnt = 0;
            for(int i =0; i < inven.slots.Length; i++)
            {
                if (inven.slots[i].transform.childCount > 0)
                {
                    Transform k = inven.slots[i].transform.GetChild(0);
                    if (cnt == requireNum[index])
                        break;
                    if (require[index].gameObject.name == k.gameObject.name)
                    {
                        Destroy(k.gameObject);
                        inven.isEmpty[i] = true;
                        cnt++;
                    }
                }
            }

            int ct = 0;

            for(int j = 0; j<inven.slots.Length; j++)
            {
                if (ct == itemNum[index])
                    break;
                
                if(inven.isEmpty[j] == true)
                {
                    Instantiate(itemObj[index], inven.slots[j].transform, false);
                    inven.isEmpty[j] = false;
                    ct++;
                }
            }

            OpenText();
            talkText.text = "아이템을 구입하셨습니다.";
            Invoke("CloseText", 3);
        }
        else
        {
            OpenText();
            talkText.text = "개수가 부족합니다.";
            Invoke("CloseText", 3);
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
