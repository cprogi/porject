using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed;
    public float playerHp;
    Rigidbody2D rigid;
    Vector3 touchPos;
    Vector2 dir;
    SpriteRenderer sprite;
    
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    void HealthDown()
    {
        playerHp -= Time.deltaTime;
    }

    
    void Update()
    {
        HealthDown();
        if (Input.GetMouseButton(0))
            touchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        transform.position = Vector2.MoveTowards(transform.position, touchPos, Time.deltaTime * moveSpeed);
        dir = touchPos - transform.position;

        sprite.flipX = dir.x > 0;

    }
}
