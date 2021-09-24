using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    public Player player;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="Player" && player.isStrong)
        {
            transform.Translate(transform.position.x - 1, transform.position.y, transform.position.z);
        }
    }
}
