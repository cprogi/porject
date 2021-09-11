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
            if (inven.slots[i].transform.childCount > 1)
            {
                Transform k = inven.slots[i].transform.GetChild(1);

                if(k.gameObject.tag == "Handle")
                {
                    check = true;
                    handleIdx = i;
                    break;
                }
            }
        }

        if (check == false)
        {
            Notice.text = "������ ���� �� �� �����ϴ�.";
            Notice.gameObject.SetActive(true);
            Invoke("Close", 1);
        }
        else
        {
            Destroy(gameObject);
            Destroy(inven.slots[handleIdx].transform.GetChild(1).gameObject);
            Notice.text = "���� �������ϴ�.";
            Notice.gameObject.SetActive(true);
            Invoke("Close", 1);
        }
    }

    void Close()
    {
        Notice.gameObject.SetActive(false);
    }
}
