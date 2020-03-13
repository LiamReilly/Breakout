using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int lives;
    public int score;
    public Text livesText;
    public Text scoreText;
    public bool gameOver;
    public GameObject gameOverPanel;
    public int numberOfBricks;
    AudioSource click;
    public int levelNumber = 0;


    // Start is called before the first frame update
    void Start()
    {
        livesText.text = "Lives: " + lives;
        scoreText.text = "Score: " + score;
        numberOfBricks = GameObject.FindGameObjectsWithTag("block").Length;
        /*if (levelNumber > 0)
        {
            score += 22;
        }*/

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateLives(int changeInLives)
    {
        lives += changeInLives;
        if (lives <= 0)
        {
            lives = 0;
            GameOver();
        }
        livesText.text = "Lives: " + lives;

    }

    public void updateScore(int changeInScore)
    {
        score += changeInScore;
        scoreText.text = "Score: " + score;
    }

    public void updateNumberOfBricks()
    {
        numberOfBricks--;
        if (numberOfBricks <= 0 && levelNumber < 1)
        {
            SceneManager.LoadScene("RealMain 1");
            levelNumber++;
             
        }
        if (numberOfBricks <= 0 && levelNumber >= 1)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        gameOver = true;
        gameOverPanel.SetActive(true);
    }

    public void playAgain()
    {
        
        SceneManager.LoadScene("RealMain");
    }

    public void quit()
    {
        
        Application.Quit ();
        Debug.Log("game quit");
    }
    
}
