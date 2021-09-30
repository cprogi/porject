using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TraderMermaid : MonoBehaviour
{
    public RectTransform shop4Ui;

    void Enter()
    {
        shop4Ui.anchoredPosition = Vector2.zero;
        Time.timeScale = 0;
    }

    public void Out()
    {
        shop4Ui.anchoredPosition = Vector2.down *2000;
        Time.timeScale = 1;
    }

    private void OnMouseDown()
    {
        Enter();
    }
}
