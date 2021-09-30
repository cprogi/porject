using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    Rigidbody2D rigid;
    SpriteRenderer sprite;
    Vector2 dir_x;
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
        dir_x.x = xpos - transform.position.x;
        sprite.flipX = dir_x.x > 0;
    }

    void Think()
    {
        xpos = Random.Range(-1, 2);
        ypos = Random.Range(-1, 2);
        Invoke("Think", 7);
    }
}
