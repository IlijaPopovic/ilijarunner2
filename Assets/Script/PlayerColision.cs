using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColision : MonoBehaviour
{
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
            GameManager.Instance.addCoins(coin);
        }
    }

    private void isObsticleHit()
    {
        if (obsticle != null)
        {
            GameManager.Instance.gameOver();
        }
    }
}
