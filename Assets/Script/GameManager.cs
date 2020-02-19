using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private cameraMovement1 camera1;
    [SerializeField] private PlayerMovement1 playerMovement1;
    [SerializeField] private float score = 0.00f;
    public float coin = 0.00f;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI coinText;

    void Update()
    {
        writeScoreAndCoin();
    }

    private void writeScoreAndCoin()
    {
        score = Mathf.Round(playerMovement1.transform.position.z / 100);
        scoreText.text = score.ToString();
        coinText.text = coin.ToString();
    }

    public void addCoins(Coin coin1)
    {
        coin += coin1.value;
    }

    public void playerCanMove()
    {
        playerMovement1.canMove = true;
    }

    public void gameOver()
    {
        playerMovement1.canMove = false;
        Debug.Log("gameOver");
    }
}
