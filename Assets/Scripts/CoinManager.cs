using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class CoinManager : MonoBehaviour
{
    /// <summary>
    /// Here its The Used Variables For This Script.
    /// coinPrefab => For The Coin Object.
    /// poolSize   => For The Size Of The Pool As We Need.
    /// spawnInterval   => For The Respawn Time.
    /// positionRange   => For The position Range And where we need to Spawn The Coins.
    /// Life   => For The Life Objects and How many Life we need.
    /// lifeCounter => is A integer to get the Life Count.
    /// playerManger => Is the Player Manager Script And here i inherit From The PlayerManager
    /// gameOverPanel => Is the Gameover panel to enable and disable it.
    /// loseSound => Is the Sound Lose Source.
    /// coins => Is the List Of the coins That used in Instantiate The Objects.
    /// currCoinIndex => Is the Current Coins index to detect the Index of Coin.
    /// </summary>
 

    public GameObject coinPrefab;
    public int poolSize;
    public float spawnInterval;
    public Vector2 positionRange;
    public GameObject[] life;
    public int lifeCounter = 0;
    public PlayerManager playerManger;
    public GameObject gameOverPanel;
    public AudioSource loseSound;
    private GameObject[] coins;
    private int currCoinIndex;

    void Start()
    {
        /// <summary>
        /// Here Is the Object Pooling System Inslization To Activate and Instantiate The Objects 
        /// </summary>
        coins = new GameObject[poolSize];
        for (int i = 0; i < poolSize; i++)
        {
            coins[i] = Instantiate(coinPrefab, transform);
            coins[i].SetActive(false);
        }
        /// <summary>
        /// Here Is The Calling Funcation Here is the Coroitine starting to Activated and Deactivate the Objects And Respawn Them in a spcefic Time.
        /// </summary>
        StartCoroutine(SpawnCoins());
    }
    void Update()
    {
        /// <summary>
        /// Here is the Playing Lose Audio And The Loading Score To Load The Player Data and Score Data also Show The Game Over Panel and Stop The Game.
        /// </summary>
        if (lifeCounter >= 3)
        {
            loseSound.Play();
            gameOverPanel.SetActive(true);
            playerManger.LoadPlayerData();
            Time.timeScale = 0;
        }
    }
    /// <summary>
    /// Here Is The start to Activated and Deactivate the Objects And Respawn Them in a spcefic Time.
    /// </summary>
    private IEnumerator SpawnCoins()
    {
        while (true)
        {
            GameObject coin = coins[currCoinIndex];
            coin.transform.position = new Vector2(Random.Range(-positionRange.x, positionRange.x), positionRange.y);
            coin.SetActive(true);
            currCoinIndex = (currCoinIndex + 1) % poolSize;
            yield return new WaitForSeconds(spawnInterval);
        }
    }
    /// <summary>
    /// Here Is The Restarting Method To Restart the Game and Play it Again Also Deactivate the GameOver Panel and Reload The Play Scene
    /// </summary>
    public void Restart()
    {
        gameOverPanel.SetActive(false);
        lifeCounter = 0;
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
