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
    public bool curse;
    public bool isSmall;
    Rigidbody2D rigid;
    Vector3 touchPos;
    Vector2 dir;
    Vector2 dirVec;
    Vector2 reverseVec;
    SpriteRenderer sprite;
    GameObject scanObject;
    Animator anim;
    public Sprite[] equipList;
    public Sprite Marine;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        isDead = false;
        isEquipped = false;
        itemGet = false;
        curse = false;
        isSmall = true;
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
        dir = touchPos - transform.position;
        if (curse == false)
        {
            transform.position = Vector2.MoveTowards(transform.position, touchPos, dialogue.isAction ? 0 : Time.deltaTime * moveSpeed);
            sprite.flipX = dir.x > 0;
            equip.GetComponent<SpriteRenderer>().flipX = dir.x > 0;
        }
        else
        {
            reverseVec = new Vector2(touchPos.x - 2 * dir.x, touchPos.y - 2 * dir.y);
            transform.position = Vector2.MoveTowards(transform.position, reverseVec, dialogue.isAction ? 0 : Time.deltaTime * moveSpeed);
            sprite.flipX = dir.x < 0;
            equip.GetComponent<SpriteRenderer>().flipX = dir.x < 0;
        }
        dirVec = dir.normalized;

        //Scan Object
        if(Input.GetMouseButtonDown(0) && scanObject != null)
        {
            dialogue.Action(scanObject);
        }

        if (equip.activeSelf == true)
            isEquipped = true;
        else
            isEquipped = false;

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

                //������ �ߺ� üũ
                for (int k = 0; k < inven.slots.Length; k++)
                {
                    if (inven.slots[k].transform.childCount > 1)
                    {
                        if (inven.slots[k].transform.GetChild(1).gameObject.tag == slotItem.gameObject.tag)
                        {
                            checkOverlap = true;
                            overlapIdx = k;
                            Debug.Log("�ߺ� " + overlapIdx.ToString());
                            break;
                        }
                    }
                }

                //������ �ߺ�x
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

                //�ߺ�o
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

        else if (collision.gameObject.tag == "3rd stage")
        {
            curse = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "3rd stage")
        {
            curse = false;
        }
        else if(collision.gameObject.tag == "4th stage" && isSmall)
        {
            anim.SetBool("change", false);
            transform.localScale = new Vector3(transform.localScale.x * 5,
                transform.localScale.y * 5, 0);
            isSmall = false;
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

    public void ChangeToMarine()
    {
        sprite.sprite = Marine;
        anim.SetBool("change", true);
        equip.SetActive(false);
        Debug.Log("ok");
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
