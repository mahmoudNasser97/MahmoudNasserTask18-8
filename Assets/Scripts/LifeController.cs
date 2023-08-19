using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeController : MonoBehaviour
{
    /// <summary>
    /// The Life Controller Script Is To Control The Player Life And enable and disbale the Life Image & Also Deactiving the Coins When hitting the ground.
    /// </summary>


    /// <summary>
    /// Here its The Used Variables For This Script.
    /// Coin Manager => Is The CoinManager Manger i inherit It Here TO Use it For Getting LifeCounter
    /// </summary>
    public CoinManager coinManager;

    private void Start()
    {
        /// <summary>
        /// Here is the Inherit and Initialize the CoinManager
        /// </summary>
        coinManager = GetComponentInParent<CoinManager>();
    }
    /// <summary>
    /// Here is the Collider Detection To Deactivate The Coins When Colliding With the ground
    /// </summary>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            coinManager.life[coinManager.lifeCounter].SetActive(false);
            this.gameObject.SetActive(false);
            coinManager.lifeCounter++;
        }
    }
}
