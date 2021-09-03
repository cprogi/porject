using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Door : MonoBehaviour
{
    public Inventory inven;
    public Text Notice;

    bool check;
    int handleIdx;

    private void Start()
    {
        check = false;
    }

    private void OnMouseDown()
    {
        for(int i = 0; i < inven.slots.Length; i++)
        {
            if (inven.slots[i].transform.childCount > 0)
            {
                Transform k = inven.slots[i].transform.GetChild(0);

                if(k.gameObject.name == "Handle")
                {
                    check = true;
                    handleIdx = i;
                    break;
                }
            }
        }

        if (check == false)
        {
            Notice.text = "문고리가 없어 열 수 없습니다.";
            Notice.gameObject.SetActive(true);
            Invoke("Close", 1);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Close()
    {
        Notice.gameObject.SetActive(false);
    }
}
