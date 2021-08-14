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
    public AboutItem aboutItem;
    public Text itemText;
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

}
