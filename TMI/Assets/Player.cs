using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    public float moveSpeed;
    public float playerHp;
    public DialogueManager dialogue;
    Rigidbody2D rigid;
    Vector3 touchPos;
    Vector2 dir;
    Vector2 dirVec;
    SpriteRenderer sprite;
    GameObject scanObject;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }


    private void Update()
    {
        HealthDown();
     
        if (Input.GetMouseButton(0))
                touchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        transform.position = Vector2.MoveTowards(transform.position, touchPos,dialogue.isAction ? 0 : Time.deltaTime* moveSpeed);
        dir = touchPos - transform.position;
        sprite.flipX = dir.x > 0;
        dirVec = dir.normalized;

        //Scan Object
        if(Input.GetMouseButton(0)&&scanObject != null)
        {
            dialogue.Action(scanObject);
        }
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
    
    void FixedUpdate()
    {
        Debug.DrawRay(rigid.position, dirVec*3f, new Color(0,1,0));
        RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, dirVec, 3f, LayerMask.GetMask("Object"));
        if (rayHit.collider != null)
        {
            scanObject = rayHit.collider.gameObject;
        }
        else
            scanObject = null;
    }
}
