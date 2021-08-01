using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseItem : MonoBehaviour
{
    Player player;

    public void UseHealthItem()
    {
        player.playerHp += 5;
        Destroy(gameObject);
    }

    public void UseSpeedUpItem()
    {
        player.moveSpeed *= 2;
        Destroy(gameObject);
    }
}
