using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{
    public static GameControl instance;
    public GameObject gameOverText;
    public TextMeshProUGUI ScoreText;
    //public Text scoreText;
    public bool gameOver = false;
    public float scrollSpeed = -1.5f;

    private int score = 0;
    AudioSource audiosource;
    public AudioClip scoreSound;


    // Start is called before the first frame update

    private void Start()
    {
        audiosource = GetComponent<AudioSource>();
    }

    void Awake ()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy (gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver == true && Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void BirdScored()
    {
        if (gameOver)
        {
            return;
        }
        score++;
        ScoreText.text = "Score: " + score.ToString ();
        PlaySound(scoreSound);
    }

    public void BirdDied()
    {
        gameOverText.SetActive(true);
        gameOver = true;
    }

    public void PlaySound(AudioClip clip)
    {
        audiosource.PlayOneShot(clip);
    }
}
