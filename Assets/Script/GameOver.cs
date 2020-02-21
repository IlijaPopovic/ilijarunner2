using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public Canvas canvas;
    public void show()
    {
        canvas.enabled = true;
    }

    public void restart()
    {
        GameManager.Instance.restartGame();
    }
}
