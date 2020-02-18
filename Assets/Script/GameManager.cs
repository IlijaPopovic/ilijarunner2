using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    private cameraMovement1 camera1;
    private PlayerMovement1 playerMovement1;
    private Transform playerPosition;
    private float score = 0.00f;
    private float coin = 0.00f;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI coinText;
    void Start()
    {
        playerPosition = GameObject.FindGameObjectWithTag("Player").transform;
        playerMovement1 = GameObject.FindObjectOfType<PlayerMovement1>();
        camera1 = GameObject.FindObjectOfType<cameraMovement1>();
    }

    void Update()
    {
        writeScoreAndCoin();
        canPlayerMove();
    }

    private void writeScoreAndCoin()
    {
        score = Mathf.Round(playerPosition.position.z / 100);
        scoreText.text = score.ToString();
        coinText.text = coin.ToString();
    }

    private void canPlayerMove()
    {
        if(camera1.isCameraAnimationFinished)
        {
            playerMovement1.canMove = true;
        }
        else
        {
            playerMovement1.canMove = false;
        }
    }
}
