using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PlayerMovement1 playerMovement1;
    [SerializeField] private GameOver gameOver1;
    [SerializeField] private float score = 0.00f;
    public float coin = 0.00f;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI coinText;
    [SerializeField] private coinImage coinImage;
    [SerializeField] private ScoreImage scoreImage;


    public static GameManager Instance = null;

    private void Awake()
    {
        if(GameManager.Instance == null)
        {
            GameManager.Instance = this;
        }
    }

    void Update()
    {
        playerMovement1.Movement();
        writeScoreAndCoin();
    }

    private void writeScoreAndCoin()
    {
        score = Mathf.Round(playerMovement1.transform.position.z / 100);
        scoreText.text = "Score\n" + score.ToString();
        coinText.text = "Coins\n" + coin.ToString();
    }

    public void addCoins(Coin coin1)
    {
        coin += coin1.value;
    }

    public void playerCanMove()
    {
        playerMovement1.canMove = true;
        coinImage.DispalyScoreImage(true);
        scoreImage.DispalyScoreImage(true);
    }

    public void gameOver()
    {
        gameOver1.show();
        playerMovement1.canMove = false;
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }



}
