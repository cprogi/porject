using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Octopus : MonoBehaviour
{
    public Shop shop;

    private void OnMouseDown()
    {
        shop.Enter();
    }
}
