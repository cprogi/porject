using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Segment : MonoBehaviour
{
    public Player player;

    private void OnMouseDown()
    {
        if (player.equip.GetComponent<SpriteRenderer>().sprite == player.equipList[1])
        {
            Debug.Log("ok");
            Destroy(gameObject);
        }
    }
}
