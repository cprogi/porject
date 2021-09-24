using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gas : MonoBehaviour
{
    public Player player;

    private void Update()
    {
        if (transform.childCount == 0)
            player.isRidofGas = true;
    }
}
