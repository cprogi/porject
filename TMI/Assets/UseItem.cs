using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseItem : MonoBehaviour
{
    public CheckUseItem check;
    public void UseHealthItem()
    {
        check.isUseHp = true;
        Destroy(gameObject);
        
    }

    public void UseSpeedUpItem()
    {
        check.isUseSpeed = true;
        Destroy(gameObject);
    }
}
