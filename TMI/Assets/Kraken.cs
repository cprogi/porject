using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kraken : MonoBehaviour
{
    public int hitCount;
    public int HP;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bullet")
        {
            Debug.Log("Hp °¨¼Ò");
            HP -= 8;
        }
    }

    private void Update()
    {
        if (HP<=0)
        {
            Destroy(gameObject);
            Debug.Log("Destroy");
        }
    }
}
