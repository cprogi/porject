using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Slider hpBar;
    public Player player;
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

  
}
