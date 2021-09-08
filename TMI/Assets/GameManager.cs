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
    public Text Notice;
    public float maxHp = 100;
    public float curHp;
    public int UseItemId;
    
    void Start()
    {
        curHp = player.playerHp;
        hpBar.value = curHp / maxHp;
    }

    // Update is called once per frame
    void Update()
    {
        CheckPlayerDie();
        ItemNotice();
        curHp = player.playerHp;
        hpBar.value = curHp / maxHp;
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
        SceneManager.LoadScene(0);
    }

    void CheckPlayerDie()
    {
        if(player.isDead == true)
        {
            SceneManager.LoadScene(0);
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
            Notice.text = "æ∆¿Ã≈€¿ª »πµÊ«ﬂΩ¿¥œ¥Ÿ.";
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
}
