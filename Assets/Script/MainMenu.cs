using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    List<GameObject> PanelOrder = new List<GameObject>();

    [SerializeField] private GameObject Options;
    [SerializeField] private GameObject Leaderboard;

    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
