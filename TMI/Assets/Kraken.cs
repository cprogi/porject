using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kraken : MonoBehaviour
{
    int hitCount;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
            hitCount++;
    }

    private void Start()
    {
        if (hitCount >= 3)
        {
            Destroy(gameObject);
            Debug.Log("Destroy");
        }
    }
}
