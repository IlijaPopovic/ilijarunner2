using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Button OptionsButton;
    [SerializeField] private Button LeaderboardButton;
    [SerializeField] private Button StartButton;
    [SerializeField] private Button OptionsBackButton;
    [SerializeField] private Button LeaderboardBackButton;
    [SerializeField] private GameObject Options;
    [SerializeField] private GameObject Leaderboard;


    void Start()
    {
        OptionsButton.onClick.AddListener(OnOptionsButtonClick);
        LeaderboardButton.onClick.AddListener(OnLeaderboardButtonClick);
        StartButton.onClick.AddListener(OnStartButtonClick);
        OptionsBackButton.onClick.AddListener(OnOptionsBackButtonClick);
        LeaderboardBackButton.onClick.AddListener(OnLeaderboardBackButtonClick);
    }

    private void OnStartButtonClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    
    private void OnOptionsButtonClick()
    {
        Options.SetActive(true);
        this.gameObject.SetActive(false);
    }
    private void OnOptionsBackButtonClick()
    {
        Options.SetActive(false);
        this.gameObject.SetActive(true);
    }

    private void OnLeaderboardButtonClick()
    {
        Leaderboard.SetActive(true);
        this.gameObject.SetActive(false);
    }

    private void OnLeaderboardBackButtonClick()
    {
        Leaderboard.SetActive(false);
        this.gameObject.SetActive(true);
    }
}
