using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plank : MonoBehaviour
{
    public Player player;

    private void OnMouseDown()
    {
        if (player.equip.GetComponent<SpriteRenderer>().sprite == player.equipList[1])
        {
            Debug.Log("check");
            Destroy(gameObject);
        }
    }
}
