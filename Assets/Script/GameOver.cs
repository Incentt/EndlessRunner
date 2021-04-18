using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject player;

    [Header("Scoring")]
    public ScoreController score;
    public float scoringRatio;
    private float lastPositionX;
    private bool gameisover;

    public GameObject GameOverScreen;
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        int distancePassed = Mathf.FloorToInt(transform.position.x - lastPositionX);
        int scoreIncrement = Mathf.FloorToInt(distancePassed / scoringRatio);

        if (scoreIncrement > 0)
        {
            score.IncreaseCurrentScore(scoreIncrement);
            lastPositionX += distancePassed;
        }
        if (Input.GetMouseButtonDown(0) && gameisover == true)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject == player)
        {
           Destroy(player);
            Gameover();
        }
    }

    void Gameover()
    {
        score.FinishScoring();
        GameOverScreen.SetActive(true);
        gameisover = true;
    }

}

