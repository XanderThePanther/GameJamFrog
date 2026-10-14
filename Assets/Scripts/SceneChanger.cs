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
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        scoreText = GameObject.FindGameObjectWithTag("Text");
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
            int health = stats.lives;
            if (health <= 0)
            {
                DontDestroyOnLoad(scoreText);
                SceneManager.LoadScene("GameOver");
                Text textComponet = scoreText.GetComponent<Text>();
                textComponet.text = "Score: " + stats.score.ToString();
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
