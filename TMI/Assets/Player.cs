using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    public bool isDead;
    public float moveSpeed;
    public float playerHp;
    public DialogueManager dialogue;
    public bool isEquipped;
    public GameObject sickle;
    Rigidbody2D rigid;
    Vector3 touchPos;
    Vector2 dir;
    Vector2 dirVec;
    SpriteRenderer sprite;
    GameObject scanObject;
    Animator anim;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        isDead = false;
        isEquipped = false;
    }


    private void Update()
    {
        if (playerHp > 100)
            playerHp = 100;
        if (playerHp <= 0)
            isDead = true;
        HealthDown();
     
        if (Input.GetMouseButton(0))
                touchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        transform.position = Vector2.MoveTowards(transform.position, touchPos,dialogue.isAction ? 0 : Time.deltaTime* moveSpeed);
        dir = touchPos - transform.position;
        sprite.flipX = dir.x > 0;
        dirVec = dir.normalized;

        //Scan Object
        if(Input.GetMouseButtonDown(0) && scanObject != null)
        {
            dialogue.Action(scanObject);
        }

        if (sickle.activeSelf == true)
            isEquipped = true;

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

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Seaweed" && isEquipped == true) 
        {
            if (Input.GetMouseButtonDown(0))
            {
                Inventory inven = GetComponent<Inventory>();
                PickUp pickUp = collision.GetComponent<PickUp>();
                GameObject slotItem = pickUp.slotItem;
                
                for (int i = 0; i < inven.slots.Length; i++)
                {
                    if (inven.isEmpty[i])
                    {
                        Instantiate(slotItem, inven.slots[i].transform, false);
                        inven.isEmpty[i] = false;
                        Destroy(collision.gameObject);
                        break;
                    }
                }
            }
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
        Debug.DrawRay(rigid.position, dirVec*6f, new Color(0,1,0));
        RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, dirVec, 6f, LayerMask.GetMask("Object"));

        if (rayHit.collider != null)
        {
            scanObject = rayHit.collider.gameObject;
        }
        else
        {
            scanObject = null;
        }
    }
}
