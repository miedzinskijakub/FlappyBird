using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Movement : MonoBehaviour
{
    public GameManager gameManager;
    public float velocity;
    private Rigidbody2D rb;
    public AudioSource audioSource;
    public float volume = 0.01f;
    public AudioClip wingSound;
    public AudioClip hitSound;
    public AudioClip pointSound;
    public int scoreCount = 0;
    public Text text;
    public Text endScore;
    public bool isPlay = false;
    public Text highScore;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        highScore.text = PlayerPrefs.GetInt("HighScore").ToString();

    }

    // Update is called once per frame
    void Update()
    {
       text.text = scoreCount.ToString();

        if (isPlay)
		{

            if (Input.GetMouseButtonDown(0))
            {
                audioSource.PlayOneShot(wingSound, volume);
                rb.velocity = Vector2.up * velocity;
            }
        }


        transform.rotation = Quaternion.Euler(0, 0, rb.velocity.y * 10);


        if (scoreCount > PlayerPrefs.GetInt("HighScore"))
		{
            PlayerPrefs.SetInt("HighScore", scoreCount);
            highScore.text = scoreCount.ToString();
            PlayerPrefs.Save();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Obstacles")
		{
            audioSource.PlayOneShot(hitSound, volume);
            gameManager.GameOver();
            endScore.text = scoreCount.ToString();
        }
      
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        audioSource.PlayOneShot(pointSound, volume);
		if (collision.gameObject.CompareTag("score"))
		{
            scoreCount += 1;
		}

    }

}
