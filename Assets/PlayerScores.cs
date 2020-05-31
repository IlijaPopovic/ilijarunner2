using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScores : MonoBehaviour
{
    [SerializeField] private GameObject PlayerScore;
    [SerializeField] private float spawnLocationY = 0.00f;
    void Start()
    {
        for (int i = 0; i < 7; i++)
        {
            GameObject Entryrow = Instantiate(PlayerScore, this.transform) as GameObject;
            Entryrow.GetComponent<PlayerScore>().playerNameText.text = "IME";
            Entryrow.GetComponent<PlayerScore>().playerscoreText.text = "SCORE";
            Entryrow.transform.position = new Vector2(Entryrow.transform.position.x, Entryrow.transform.position.y - spawnLocationY);
            spawnLocationY += 200;
        }
    }
}
