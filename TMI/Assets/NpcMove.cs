using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcMove : MonoBehaviour
{
    Rigidbody2D rigid;
    SpriteRenderer sprite;
    Vector2 dir_x;
    float xpos;
    float ypos;
    float moveSpeed = 1;
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        Invoke("Think", 7);
    }

    
    void Update()
    {
        rigid.velocity = new Vector2(xpos, ypos);
        dir_x.x = xpos;
        sprite.flipX = dir_x.x > 0;
    }

    void Think()
    {
        xpos = Random.Range(-1.5f, 1.6f);
        ypos = Random.Range(-1.5f, 1.6f);
        Invoke("Think", 7);
    }
}
