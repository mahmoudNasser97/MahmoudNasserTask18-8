using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerManager : MonoBehaviour
{   /// <summary>
    /// Here is Player Manager Script That Control Player Movement and PlayerPrefs TO Save and Load Player data.
    /// </summary>


    /// <summary>
    /// Here its The Used Variables For This Script.
    /// score => is the Score Integer To calculate the Player Score.
    /// scoreText   => Is the Text to show the player Score.
    /// highScore   => is the highScore Integer To calculate the Player highScore.
    /// highScoreText   => Is the Text to show the player highScore.
    /// anim   => Is The Player Animatior Controller For The Player Animation.
    /// coinSound => is the audioSource For The Coin When collecting It.
    /// speed => Is the Player speed controller
    /// rb => Is the RigidBody Controller To Controll Player Gravity.
    /// </summary>
 
    public int score;
    public TMP_Text scoreText;
    public int highScore = 0;
    public TMP_Text highScoreText;
    public Animator anim;
    public AudioSource coinSound;
    [SerializeField] private float speed;
    private Rigidbody2D rb;

    /// <summary>
    /// Here is the Inherit and Initialize the Rigidbody
    /// </summary>
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    /// <summary>
    /// Here is Used To Get The Player HighScore and Load It.
    /// </summary>
    private void Start()
    {
        if (PlayerPrefs.HasKey("MyScore"))
        {
            highScore = PlayerPrefs.GetInt("MyScore");
        }
        else
        {
            highScore = 0;
        }
    }
     /// <summary>
    /// Here Is The Player Movement Controller 
    /// </summary>
    private void Update()
    {
        /// <summary>
        /// Here its The KeyPress Detection And Play Player Animation.
        /// </summary>
        if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, rb.velocity.y);
            anim.SetBool("IsRun", true);
            anim.SetBool("IsIdle", false);
            anim.SetBool("IsJumping", false);
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, rb.velocity.y);
            anim.SetBool("IsRun", true);
            anim.SetBool("IsIdle", false);
            anim.SetBool("IsJumping", false);
        }
        /// <summary>
        /// Here its the Jumping Method To Make The Player Jump Up.
        /// </summary>
        if (Input.GetKey(KeyCode.Space))
        {
            /// <summary>
            /// Here is to Control The Player Jump Ratio To Control The Player From Jumping Up to the Screen and Brake the Game.
            /// </summary>
            if (rb.position.y < 0f)
            {
                rb.velocity = new Vector2(rb.velocity.x, speed);
                anim.SetBool("IsJumping", true);
                anim.SetBool("IsIdle", false);
                anim.SetBool("IsRun", false);
            }
            else
            {
                anim.SetBool("IsIdle", true);
                anim.SetBool("IsJumping", false);
                anim.SetBool("IsRun", false);
            }
        }
        /// <summary>
        /// Here is to save Player Data For the PlayerPrefs
        /// </summary>
        if (score > PlayerPrefs.GetInt("MyScore"))
        {
            highScore = score;
            SavePlayerData();
        }
    }
    /// <summary>
    /// Here is the Player Coin Detection & Play The SOund When Collecting The Coin.
    /// </summary>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Coin"))
        {
            score++;
            scoreText.text = "Score::  " + score;
            collision.gameObject.SetActive(false);
            coinSound.Play();
        }
    }
    /// <summary>
    /// Here is the Save Player Data Method To Save Player Score
    /// </summary>
    public void SavePlayerData()
    {
        PlayerPrefs.SetInt("MyScore", highScore);
    }
    /// <summary>
    /// Here is the Load Player Data Method To Load Player Score
    /// </summary>
    public void LoadPlayerData()
    {
        highScoreText.text = PlayerPrefs.GetInt("MyScore").ToString();
    }

}
