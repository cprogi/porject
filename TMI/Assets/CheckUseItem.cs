using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckUseItem : MonoBehaviour
{
    public Player player;

    public void UseHP()
    {
        player.playerHp += 5;
        Destroy(gameObject);
    }

    public void UseSpeed()
    {
        player.moveSpeed *= 2;
        Destroy(gameObject);
    }


}
