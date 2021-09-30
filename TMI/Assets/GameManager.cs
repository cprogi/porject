using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public GameObject inventory;
    public Slider hpBar;
    public Player player;
    public GameObject SetMenu;
    public GameObject questSet;
    public GameObject BookSet;
    public GameObject Book;
    public GameObject Select;
    public GameObject ClearPop;
    public GameObject DeadPop;
    public Inventory inven;
    public Text Notice;
    public float maxHp = 100;
    public float curHp;
    public int UseItemId;
    public bool clear;
    
    void Start()
    {
        curHp = player.playerHp;
        hpBar.value = curHp / maxHp;
        clear = false;
    }

    // Update is called once per frame
    void Update()
    {
        CheckPlayerDie();
        ItemNotice();
        curHp = player.playerHp;
        hpBar.value = curHp / maxHp;

        if (SetMenu.activeSelf == true || BookSet.activeSelf == true || inventory.activeSelf==true)
            Time.timeScale = 0;
    }

    public void OpenSetMenu()
    {
        SetMenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void ReturnGame()
    {
        SetMenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void ReturnMain()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    void CheckPlayerDie()
    {
        if(player.isDead == true)
        {
            DeadPop.SetActive(true);
            player.isDead = false;
        }
    }

    public void ShowInventory()
    {
        inventory.SetActive(true);
        Time.timeScale = 0;
    }

    public void CloseInventory()
    {
        inventory.SetActive(false);
        Time.timeScale = 1;
    }

    public void Quit()
    {
        Application.Quit();
    }
    
    public void OpenQuest()
    {
        questSet.SetActive(true);
        Time.timeScale = 0;
    }

    public void CloseQuest()
    {
        questSet.SetActive(false);
        Time.timeScale = 1;
    }

    public void OpenBook()
    {
        BookSet.SetActive(true);
        Time.timeScale = 0;
    }

    public void CloseBook()
    {
        BookSet.SetActive(false);
        Time.timeScale = 1;
    }

    void ItemNotice()
    {
        if(player.itemGet == true)
        {
            Notice.text = "아이템을 획득했습니다.";
            OpenNotice();
            Invoke("CloseNotice", 3);
            player.itemGet = false;
        }
    }

    void OpenNotice()
    {
        Notice.gameObject.SetActive(true);
    }

    void CloseNotice()
    {
        Notice.gameObject.SetActive(false);
    }

    public void Pause()
    {
        Time.timeScale = 0;
    }

    public void LastSelect_Y()
    {
        bool isChecked = false;
        for(int i = 0; i<inven.slots.Length; i++)
        {
            if (inven.slots[i].transform.childCount > 1)
            {
                GameObject k = inven.slots[i].transform.GetChild(1).gameObject;
                if (k.tag == "Book")
                {
                    Destroy(k);
                    isChecked = true;
                    break;
                }
            }
        }

        if(isChecked == true)
        {
            Book.SetActive(true);
            clear = true;
            Invoke("ShowClear", 2);
        }
        else
        {
            Notice.text = "도감이 없습니다.";
            Invoke("CloseNotice", 2);
        }
        Select.SetActive(false);
        Time.timeScale = 1;
    }

    public void LastSelect_N()
    {
        Select.SetActive(false);
        Time.timeScale = 1;
    }

    public void ShowClear()
    {
        Time.timeScale = 0;
        ClearPop.SetActive(true);
    }

    public void Again()
    {
        SceneManager.LoadScene("Play");
    }
}
