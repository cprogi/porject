using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    Rigidbody2D rigid;
    SpriteRenderer sprite;
    int xpos;
    int ypos;
    
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        Invoke("Think", 7);
    }

    private void FixedUpdate()
    {
        rigid.velocity = new Vector2(xpos, ypos);

    }

    void Think()
    {
        xpos = Random.Range(-1, 2);
        ypos = Random.Range(-1, 2);
        Invoke("Think", 7);
    }
}
