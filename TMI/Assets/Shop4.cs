using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop4 : MonoBehaviour
{
    public GameObject[] itemObj;
    public int[] requireNum;
    public int[] itemNum;
    public Inventory inven;

    public void Buy(int index)
    {
        Trade(index);
    }

    public void Trade(int idx)
    {
        if (idx == 0)
        {
            int count = 0;
            int materialIdx = 0;
            for (int i = 0; i < inven.slots.Length; i++)
            {
                if (inven.slots[i].transform.childCount > 1)
                {
                    Transform c = inven.slots[i].transform.GetChild(1);
                    if (c.gameObject.tag == "JewelyA")
                    {
                        count = inven.slots[i].transform.childCount - 1;
                        materialIdx = i;
                        Debug.Log(count);
                        break;
                    }
                }
            }

            if (count >= 2)
            {
                int cnt = 0;
                while (cnt < 2)
                {
                    Transform proc = inven.slots[materialIdx].transform.GetChild(1);
                    Destroy(proc.gameObject);
                    Debug.Log("del");
                    cnt++;
                }
                int ct = 0;
                bool checkOverlap = false;
                int overlapIdx = 0;

                for (int j = 0; j < inven.slots.Length; j++)
                {
                    if (inven.slots[j].transform.childCount > 1)
                    {
                        Transform go = inven.slots[j].transform.GetChild(1);

                        if (go.gameObject.tag == "JewelyC")
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
                            for (int l = 0; l < itemNum[idx]; l++)
                            {
                                Instantiate(itemObj[idx], inven.slots[k].transform, false);
                                ct++;
                            }
                            break;
                        }
                    }
                }
                else
                {
                    for (int l = 0; l < itemNum[idx]; l++)
                    {
                        if (ct == itemNum[idx])
                            break;
                        Instantiate(itemObj[idx], inven.slots[overlapIdx].transform, false);
                        ct++;
                        Debug.Log("ok");
                    }
                }
            }
        }





        //
        else if (idx == 1)
        {
            int count = 0;
            for (int i = 0; i < inven.slots.Length; i++)
            {
                if (inven.slots[i].transform.childCount > 1)
                {
                    Transform c = inven.slots[i].transform.GetChild(1);
                    for (int j = 0; j < 2; j++)
                    {
                        if (c.gameObject.tag == "JewelyC")
                        {
                            count++;
                        }
                    }
                }
            }

            if (count >= 2)
            {
                int cnt = 0;
                for (int i = 0; i < inven.slots.Length; i++)
                {
                    if (cnt >= 2)
                        break;
                    if (inven.slots[i].transform.childCount > 1)
                    {
                        Transform k = inven.slots[i].transform.GetChild(1);
                        if (k.gameObject.tag == "JewelyC")
                        {
                            for (int j = 0; j < 2; j++)
                            {
                                Destroy(k.gameObject);
                                cnt++;
                            }
                        }
                    }
                }
                int ct = 0;
                bool checkOverlap = false;
                int overlapIdx = 0;

                for (int j = 0; j < inven.slots.Length; j++)
                {
                    if (inven.slots[j].transform.childCount > 1)
                    {
                        Transform go = inven.slots[j].transform.GetChild(1);

                        if (go.gameObject.tag == "JewelyB")
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
                            for (int l = 0; l < 1; l++)
                            {
                                if (ct == 1)
                                    break;
                                Instantiate(itemObj[idx], inven.slots[k].transform, false);
                                ct++;
                            }
                            break;
                        }
                    }
                }
                else
                {
                    for (int l = 0; l < itemNum[idx]; l++)
                    {
                        if (ct == itemNum[idx])
                            break;
                        Instantiate(itemObj[idx], inven.slots[overlapIdx].transform, false);
                        ct++;
                        Debug.Log("ok");
                    }
                }

            }
        }
        //
        else if (idx == 2)
        {
            int JewelyC = 0;
            int silver = 0;

            for (int i = 0; i < inven.slots.Length; i++)
            {
                if (inven.slots[i].transform.childCount > 1)
                {
                    Transform c = inven.slots[i].transform.GetChild(1);
                    for (int j = 0; j < 1; j++)
                    {
                        if (c.gameObject.tag == "JewelyC")
                        {
                            JewelyC++;
                        }
                    }
                }
            }

            for (int i = 0; i < inven.slots.Length; i++)
            {
                if (inven.slots[i].transform.childCount > 1)
                {
                    Transform c = inven.slots[i].transform.GetChild(1);
                    for (int j = 0; j < 1; j++)
                    {
                        if (c.gameObject.tag == "Silverscale")
                        {
                            silver++;
                        }
                    }
                }
            }

            if (JewelyC >= 1 && silver >= 1)
            {
                int cntJ = 0;
                for (int i = 0; i < inven.slots.Length; i++)
                {
                    if (cntJ >= 1)
                        break;
                    if (inven.slots[i].transform.childCount > 1)
                    {
                        Transform k = inven.slots[i].transform.GetChild(1);
                        if (k.gameObject.tag == "JewelyC")
                        {
                            for (int j = 0; j < 1; j++)
                            {
                                Destroy(k.gameObject);
                                cntJ++;
                            }
                        }
                    }
                }

                int cntS = 0;
                for (int i = 0; i < inven.slots.Length; i++)
                {
                    if (cntS >= 1)
                        break;
                    if (inven.slots[i].transform.childCount > 1)
                    {
                        Transform k = inven.slots[i].transform.GetChild(1);
                        if (k.gameObject.tag == "Silverscale")
                        {
                            for (int j = 0; j < 1; j++)
                            {
                                Destroy(k.gameObject);
                                cntS++;
                            }
                        }
                    }
                }

                int ct = 0;
                bool checkOverlap = false;
                int overlapIdx = 0;

                for (int j = 0; j < inven.slots.Length; j++)
                {
                    if (inven.slots[j].transform.childCount > 1)
                    {
                        Transform go = inven.slots[j].transform.GetChild(1);

                        if (go.gameObject.tag == "Goldscale")
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
                            for (int l = 0; l < 1; l++)
                            {
                                if (ct == 1)
                                    break;
                                Instantiate(itemObj[idx], inven.slots[k].transform, false);
                                ct++;
                            }
                            break;
                        }
                    }
                }
                else
                {
                    for (int l = 0; l < itemNum[idx]; l++)
                    {
                        if (ct == itemNum[idx])
                            break;
                        Instantiate(itemObj[idx], inven.slots[overlapIdx].transform, false);
                        ct++;
                        Debug.Log("ok");
                    }
                }
            }
        }

        //
        else if (idx == 3)
        {
            int JewelyB = 0;
            int seaweed = 0;

            for (int i = 0; i < inven.slots.Length; i++)
            {
                if (inven.slots[i].transform.childCount > 1)
                {
                    Transform c = inven.slots[i].transform.GetChild(1);
                    for (int j = 0; j < 1; j++)
                    {
                        if (c.gameObject.tag == "JewelyB")
                        {
                            JewelyB++;
                        }
                    }
                }
            }

            for (int i = 0; i < inven.slots.Length; i++)
            {
                if (inven.slots[i].transform.childCount > 1)
                {
                    Transform c = inven.slots[i].transform.GetChild(1);
                    for (int j = 0; j < 2; j++)
                    {
                        if (c.gameObject.tag == "Radweed")
                        {
                            seaweed++;
                        }
                    }
                }
            }

            if (JewelyB >= 1 && seaweed >= 2)
            {
                int cntJ = 0;
                for (int i = 0; i < inven.slots.Length; i++)
                {
                    if (cntJ >= 1)
                        break;
                    if (inven.slots[i].transform.childCount > 1)
                    {
                        Transform k = inven.slots[i].transform.GetChild(1);
                        if (k.gameObject.tag == "JewelyB")
                        {
                            for (int j = 0; j < 1; j++)
                            {
                                Destroy(k.gameObject);
                                cntJ++;
                            }
                        }
                    }
                }

                int cntS = 0;
                for (int i = 0; i < inven.slots.Length; i++)
                {
                    if (cntS >= 1)
                        break;
                    if (inven.slots[i].transform.childCount > 1)
                    {
                        Transform k = inven.slots[i].transform.GetChild(1);
                        if (k.gameObject.tag == "Radweed")
                        {
                            for (int j = 0; j < 1; j++)
                            {
                                Destroy(k.gameObject);
                                cntS++;
                            }
                        }
                    }
                }

                int ct = 0;
                bool checkOverlap = false;
                int overlapIdx = 0;

                for (int j = 0; j < inven.slots.Length; j++)
                {
                    if (inven.slots[j].transform.childCount > 1)
                    {
                        Transform go = inven.slots[j].transform.GetChild(1);

                        if (go.gameObject.tag == "Radrock")
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
                            for (int l = 0; l < 1; l++)
                            {
                                Instantiate(itemObj[idx], inven.slots[k].transform, false);
                                ct++;
                            }
                            break;
                        }
                    }
                }
                else
                {
                    for (int l = 0; l < itemNum[idx]; l++)
                    {
                        Instantiate(itemObj[idx], inven.slots[overlapIdx].transform, false);
                        ct++;
                        Debug.Log("ok");
                    }
                }
            }
        }
    }
}
