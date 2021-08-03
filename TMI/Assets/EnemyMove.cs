using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    Rigidbody2D rigid;
    SpriteRenderer sprite;
    
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        Invoke("Move", 3);
    }


    void Update()
    {
        Invoke("Move", 3);
    }
    void Move()
    {
        float xpos = Random.Range(-2, 3);
        float ypos = Random.Range(-2, 3);

        Vector2 dirVec = new Vector2(transform.position.x + xpos,transform.position.y+ypos);

        transform.position = Vector2.MoveTowards(transform.position, dirVec, Time.deltaTime);

        Invoke("Move", 3);
    }
}
