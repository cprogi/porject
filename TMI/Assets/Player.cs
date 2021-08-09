using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    public bool isDead;
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
        isDead = false;
    }


    private void Update()
    {
        if (playerHp <= 0)
            isDead = true;
        HealthDown();
        if (Input.GetMouseButton(0))
            touchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        transform.position = Vector2.MoveTowards(transform.position, touchPos,Time.deltaTime* moveSpeed);
        dir = touchPos - transform.position;

        sprite.flipX = dir.x > 0;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            playerHp -= 10;
            OnDamaged();
            Invoke("OffDamaged", 2);
        }
    }


    void OnDamaged()
    {
        sprite.color = new Color(1, 1, 1, 0.4f);
        gameObject.layer = 6;
    }
    void OffDamaged()
    {
        sprite.color = new Color(1, 1, 1, 1);
        gameObject.layer = 3;
    }
    void HealthDown()
    {
        playerHp -= Time.deltaTime;
    }
    
}
