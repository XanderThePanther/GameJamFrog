using TMPro;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class SceneChanger : MonoBehaviour
{
    GameObject player;
    Player stats;

    GameObject scoreText;

    GameObject highScoreText;

    int highScore;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        scoreText = GameObject.FindGameObjectWithTag("Text");
        highScoreText = GameObject.FindGameObjectWithTag("HighScore");
        if (highScoreText != null)
        {
            highScoreText.GetComponent<TMP_Text>().text = "High Score: " + PlayerPrefs.GetInt("HighScore", 0);
        }

        if (player != null)
        {
            stats = player.GetComponent<Player>();
        }


    }

    // Update is called once per frame
    void Update()
    {
        if (stats != null)
        {
            int health = stats.health;
            if (health <= 0)
            {
                highScore = PlayerPrefs.GetInt("HighScore", 0);
                if(stats.score > highScore)
                {
                    PlayerPrefs.SetInt("HighScore", stats.score);
                    PlayerPrefs.Save();
                }
                DontDestroyOnLoad(scoreText);
                SceneManager.LoadScene("GameOver");
                

                
            }
        }
    }

    public void loadLevelScene()
    {
        if (scoreText != null) {
            Destroy(scoreText);
            }
        stats = null;
        SceneManager.LoadScene("SampleScene");

    }
}
