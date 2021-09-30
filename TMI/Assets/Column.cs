using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Column : MonoBehaviour
{
    public Player player;
    public GameObject select;
    public GameManager gameManager;

    private void OnMouseDown()
    {
        if (gameManager.clear == true)
            return;
        else
        {
            select.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
