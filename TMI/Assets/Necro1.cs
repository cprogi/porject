using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Necro1 : MonoBehaviour
{
    public Inventory inven;
    public Player player;

    public GameObject[] page;

    int pageIdx = 0;

    private void Update()
    {
        ShowPage(pageIdx);
        for(int i = 0; i < page.Length; i++)
        {
            if(i!=pageIdx)
                page[i].SetActive(false);
        }
    }

    public void BeforePage()
    {
        if (pageIdx <= 0)
            return;
        else
            pageIdx--;
    }

    public void NextPage()
    {
        if (pageIdx >= page.Length - 1)
            return;
        else
            pageIdx++;
    }
    void ShowPage(int index)
    {
        page[index].SetActive(true);
    }

    public void Smallize()
    {
        int countG = 0;
        int countP = 0;
        int countR = 0;

        int GIdx = 0;
        int PIdx = 0;
        int RIdx = 0;

        for(int i = 0; i < inven.slots.Length; i++)
        {
            if (inven.slots[i].transform.childCount > 1)
            {
                Transform proc = inven.slots[i].transform.GetChild(1);
                if (proc.gameObject.tag == "Goldscale")
                {
                    countG = inven.slots[i].transform.childCount - 1;
                    GIdx = i;
                    Debug.Log(countG);
                }
                else if (proc.gameObject.tag == "JewelyB")
                {
                    countP = inven.slots[i].transform.childCount - 1;
                    PIdx = i;
                    Debug.Log(countP);
                }
                else if (proc.gameObject.tag == "Radrock")
                {
                    countR = inven.slots[i].transform.childCount - 1;
                    RIdx = i;
                    Debug.Log(countR);
                }
            }
        }

        if(countG>=1 && countP>=2 && countR >= 3)
        {
            Debug.Log("ok");
            for(int i = 0; i < 1; i++)
            {
                Destroy(inven.slots[GIdx].transform.GetChild(1).gameObject);
            }
            for(int j = 0; j < 2; j++)
            {
                GameObject child = inven.slots[PIdx].transform.GetChild(1).gameObject;
                Destroy(child);
                Debug.Log("삭제");
            }

            for(int k = 0; k<3; k++)
            {
                Destroy(inven.slots[RIdx].transform.GetChild(1).gameObject);
            }
            player.transform.localScale = new Vector3(transform.localScale.x * 0.05f,
                transform.localScale.y * 0.05f, 0);
            player.isSmall = true;
        }
    }

    public void GetPower()
    {
        int countG = 0;
        int countP = 0;
        int countR = 0;

        int GIdx = 0;
        int PIdx = 0;
        int RIdx = 0;

        for (int i = 0; i < inven.slots.Length; i++)
        {
            if (inven.slots[i].transform.childCount > 1)
            {
                Transform proc = inven.slots[i].transform.GetChild(1);
                if (proc.gameObject.tag == "Prickle")
                {
                    countG = inven.slots[i].transform.childCount - 1;
                    GIdx = i;
                    Debug.Log(countG);
                }
                else if (proc.gameObject.tag == "JewelyB")
                {
                    countP = inven.slots[i].transform.childCount - 1;
                    PIdx = i;
                    Debug.Log(countP);
                }
                else if (proc.gameObject.tag == "Radrock")
                {
                    countR = inven.slots[i].transform.childCount - 1;
                    RIdx = i;
                    Debug.Log(countR);
                }
            }
        }

        if (countG >= 1 && countP >= 1 && countR >= 1)
        {
            Debug.Log("ok");
            for (int i = 0; i < 1; i++)
            {
                Destroy(inven.slots[GIdx].transform.GetChild(1).gameObject);
            }
            for (int j = 0; j < 1; j++)
            {
                GameObject child = inven.slots[PIdx].transform.GetChild(1).gameObject;
                Destroy(child);
                Debug.Log("삭제");
            }

            for (int k = 0; k < 1; k++)
            {
                Destroy(inven.slots[RIdx].transform.GetChild(1).gameObject);
            }
            player.isStrong = true;
        }
    }
}
