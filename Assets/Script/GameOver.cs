using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public Canvas canvas;
    [SerializeField] private Button StartMenuButton;

    private void Start() 
    {
        StartMenuButton.onClick.AddListener(OnStartMenuButtonClick);
    }
    public void show()
    {
        canvas.enabled = true;
    }

    public void restart()
    {
        GameManager.Instance.restartGame();
    }

    private void OnStartMenuButtonClick()
    {
        Debug.Log("click");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
