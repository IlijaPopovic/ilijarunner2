using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColision : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    private Coin coin;
    private Obsticle obsticle;
    
    public void OnTriggerEnter(Collider other) 
    {
        coin = other.GetComponent<Coin>();
        obsticle = other.GetComponent<Obsticle>();
        isCoinHit();
        isObsticleHit();
    }

    private void isCoinHit()
    {
        if (coin != null)
        {
            Destroy(coin.gameObject);
            gameManager.addCoins(coin);
        }
    }

    private void isObsticleHit()
    {
        if (obsticle != null)
        {
            gameManager.gameOver();
        }
    }
}
