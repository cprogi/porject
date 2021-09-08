using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    public bool isDead;
    public float moveSpeed;
    public float playerHp;
    public DialogueManager dialogue;
    public TreasBox treas;
    public AboutItem aboutItem;
    public bool isEquipped;
    public GameObject equip;
    public bool itemGet;
    Rigidbody2D rigid;
    Vector3 touchPos;
    Vector2 dir;
    Vector2 dirVec;
    SpriteRenderer sprite;
    GameObject scanObject;
    Animator anim;
    public Sprite[] equipList;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        isDead = false;
        isEquipped = false;
        itemGet = false;
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
        if(touchPos!=null)
            transform.position = Vector2.MoveTowards(transform.position, touchPos,dialogue.isAction ? 0 : Time.deltaTime* moveSpeed);
        dir = touchPos - transform.position;
        sprite.flipX = dir.x > 0;
        equip.GetComponent<SpriteRenderer>().flipX = dir.x > 0;
        dirVec = dir.normalized;

        //Scan Object
        if(Input.GetMouseButtonDown(0) && scanObject != null)
        {
            dialogue.Action(scanObject);
        }

        if (equip.activeSelf == true)
            isEquipped = true;

    }


    private void OnCollisionEnter2D(Collision2D collision)
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
        if (collision.gameObject.tag == "SeaweedA" && isEquipped == true && equip.GetComponent<SpriteRenderer>().sprite == equipList[0])
        {
            if (Input.GetMouseButtonDown(0))
            {
                Inventory inven = GetComponent<Inventory>();
                PickUp pickUp = collision.GetComponent<PickUp>();
                GameObject slotItem = pickUp.slotItem;
                bool checkOverlap = false;
                int overlapIdx = 0;

                //아이템 중복 체크
                for (int k = 0; k < inven.slots.Length; k++)
                {
                    if (inven.slots[k].transform.childCount > 1)
                    {
                        if (inven.slots[k].transform.GetChild(1).gameObject.tag == slotItem.gameObject.tag)
                        {
                            checkOverlap = true;
                            overlapIdx = k;
                            Debug.Log("중복 " + overlapIdx.ToString());
                            break;
                        }
                    }
                }

                //아이템 중복x
                if (checkOverlap == false)
                {
                    for (int i = 0; i < inven.slots.Length; i++)
                    {
                        if (inven.isEmpty[i] == true)
                        {
                            Instantiate(slotItem, inven.slots[i].transform, false);
                            inven.isEmpty[i] = false;
                            Destroy(collision.gameObject);
                            break;
                        }
                    }
                }

                //중복o
                else
                {
                    Instantiate(slotItem, inven.slots[overlapIdx].transform, false);
                    Destroy(collision.gameObject);
                }
            }
        }

        else if (collision.gameObject.tag == "item")
        {
            if (Input.GetMouseButtonDown(0))
            {
                Inventory inven = GetComponent<Inventory>();
                PickUp pickUp = collision.GetComponent<PickUp>();
                GameObject slotItem = pickUp.slotItem;
                bool checkOverlap = false;
                int overlapIdx = 0;

                for (int k = 0; k < inven.slots.Length; k++)
                {
                    if (inven.slots[k].transform.childCount > 1)
                    {
                        if (inven.slots[k].transform.GetChild(1).tag == slotItem.tag)
                        {
                            checkOverlap = true;
                            overlapIdx = k;
                            break;
                        }
                    }
                }

                if (checkOverlap == false)
                {
                    for (int i = 0; i < inven.slots.Length; i++)
                    {
                        if (inven.isEmpty[i] == true)
                        {
                            Instantiate(slotItem, inven.slots[i].transform, false);
                            inven.isEmpty[i] = false;
                            Destroy(collision.gameObject);
                            break;
                        }
                    }
                }
                else
                {
                    Instantiate(slotItem, inven.slots[overlapIdx].transform, false);
                    Destroy(collision.gameObject);
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
