using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    public int lives = 3;

    [SerializeField]
    private Text livesText;

    [SerializeField]
    private Text bricksText;

    public GameObject gameOverUI;

    int numOfBricks;

    bool gameOver;

    private void Awake()
    {
        livesText.text = "Lives: " + lives.ToString();
        numOfBricks = GameObject.FindGameObjectsWithTag("Brick").Length;
        Debug.Log("numOfBricks" + numOfBricks.ToString());
        bricksText.text = "Bricks: " + numOfBricks.ToString();
        gameOver = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver && Input.anyKeyDown)
            Restart();
    }

    public void LoseLive()
    {
        lives--;
        livesText.text = "Lives: " + lives.ToString();

        if (lives <= 0)
            GameOver();

    }

    void GameOver()
    {
        gameOver = true;
        gameOverUI.SetActive(true);
        Time.timeScale = 0f;

    }

    public void HitBrick()
    {
        numOfBricks--;
        bricksText.text = "Bricks: " + numOfBricks.ToString();

        if(numOfBricks <= 0)
        {
            Invoke("NextLevel", 2f);
        }
    }

    void NextLevel()
    {
        SceneManager.LoadScene("Level02");
    }

    void Restart()
    {
        SceneManager.LoadScene("Level01");
        Time.timeScale = 1f;

    }
}
