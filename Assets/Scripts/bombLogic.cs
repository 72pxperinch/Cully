using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class bombLogic : MonoBehaviour
{

    public int score = 0;
    public Text scoreText;
    public GameObject gameOverScreen;
    public GameObject spawnCoin;
    public GameObject spawnPowerup;


    void Start()
    {

        Screen.orientation = ScreenOrientation.Portrait;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            restartGame();
        }
    }

    public void addScore(int ScoreToAdd)
    {
        score += ScoreToAdd;
        scoreText.text = score.ToString();
    }

    public void restartGame()
    {
        spawnCoin.GetComponent<SpawnCoinBombManager>().currentSpawnRate = 2.5f;
        Debug.Log("Spawnrate reseted");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameOver()
    {
        GameObject[] coins = GameObject.FindGameObjectsWithTag("Coin");

        foreach (GameObject coin in coins)
        {
            Rigidbody2D coinRigidbody = coin.GetComponent<Rigidbody2D>();

            if (coinRigidbody != null)
            {
                coinRigidbody.gravityScale = 0;
                coinRigidbody.linearVelocity = Vector2.zero;
            }
        }
        gameOverScreen.SetActive(true);
        spawnCoin.SetActive(false);
        spawnPowerup.SetActive(false);
    }

}
