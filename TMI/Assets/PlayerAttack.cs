using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject bullet;
    public Transform pos;
    public Player player;
    public AboutItem about;
    public float cooltime;
    float curtime;


    void Start()
    {
        
    }

    void Update()
    {

        if (curtime<= 0)
        {
            if (player.readyForAttack && Input.GetMouseButton(0))
            {
                Instantiate(bullet, pos.position, transform.rotation);
            }
            curtime = cooltime;
        }
        curtime -= Time.deltaTime;
    }
}
