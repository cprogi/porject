using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TreasBox : MonoBehaviour
{
    public Inventory inven;
    public Player player;
    public GameObject[] Item;
    public Text Notice;
    public int[] itemNum;

    bool check;
    int keyIdx;
    private void Awake()
    {
        check = false;
    }

    private void OnMouseDown()
    {
        for(int i =0; i< inven.slots.Length; i++)
        {
            if (inven.slots[i].transform.childCount > 1)
            {
                Transform k = inven.slots[i].transform.GetChild(1);

                if (k.gameObject.name == "Key")
                {
                    check = true;
                    keyIdx = i;
                    break;
                }
            }
        }

        if(check == false)
        {
            Notice.text = "열쇠가 없습니다.";
            Notice.gameObject.SetActive(true);
            Invoke("Close", 1);
        }

        else
        {
            Destroy(inven.slots[keyIdx].transform.GetChild(1).gameObject);
            inven.isEmpty[keyIdx] = true;
            bool overlap = false;
            int overlapIdx = 0;

            for(int i = 0; i < Item.Length; i++)
            {
                //아이템 중복 체크
                for(int j =0; j < inven.slots.Length; j++)
                {
                    if (inven.slots[j].transform.childCount > 1)
                    {
                        Transform n = inven.slots[j].transform.GetChild(1);

                        if (Item[i].name == n.gameObject.name)
                        {
                            overlap = true;
                            overlapIdx = j;
                            break;
                        }
                    }
                }
                //
                if(overlap == false)
                {
                    for(int j = 0; j < inven.slots.Length; j++)
                    {
                        if (inven.isEmpty[j])
                        {
                            for(int k = 0; k < itemNum[i]; k++)
                            {
                                Instantiate(Item[i], inven.slots[j].transform, false);
                            }
                            inven.isEmpty[j] = false;
                            break;
                        }
                    }
                }
                else
                {
                    for(int k = 0; k < itemNum[i]; k++)
                    {
                        Instantiate(Item[i], inven.slots[overlapIdx].transform, false);
                    }
                }
            }
            Destroy(gameObject);
        }
    }

    void Close()
    {
        Notice.gameObject.SetActive(false);
    }



}

