using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GetItem : MonoBehaviour
{
    public PickUp pick;
    public Inventory inven;
    public Text Notice;

    bool checkEmpty;
    int idx;
    bool checkOverlap;
    int overlapIdx;

    private void Start()
    {
        checkEmpty = false;
        checkOverlap = false;
    }

    private void OnMouseDown()
    {
        for(int i = 0; i < inven.slots.Length; i++)
        {
            if (inven.isEmpty[i])
            {
                checkEmpty = true;
                idx = i;
                Debug.Log(idx);
                break;
            }
            else
            {
                if (inven.slots[i].transform.GetChild(1).tag == pick.slotItem.tag)
                {
                    checkOverlap = true;
                    overlapIdx = i;
                    Debug.Log("?ߺ?");
                    break;
                }
            }
        }

        if (checkEmpty)
        {
            Instantiate(pick.slotItem, inven.slots[idx].transform, false);
            Destroy(gameObject);
            Debug.Log("ok");
        }
        else if (checkOverlap == true)
        {
            Instantiate(pick.slotItem, inven.slots[overlapIdx].transform, false);
            Destroy(gameObject);
            Debug.Log("ok");
        }
        else
        {
            Notice.text = "?????? ???? á???ϴ?.";
            SHow();
            Invoke("Close", 1);
        }

    }

    void SHow()
    {
        Notice.gameObject.SetActive(true);
    }
    void Close()
    {
        Notice.gameObject.SetActive(false);
    }
}
