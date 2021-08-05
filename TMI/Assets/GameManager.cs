using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public Slider hpBar;
    public Player player;
    public GameObject SetMenu;
    public float maxHp = 100;
    public float curHp;
    
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

  
}
