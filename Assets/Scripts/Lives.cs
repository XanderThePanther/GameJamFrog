using TMPro;
using UnityEngine;

public class Lives : MonoBehaviour
{
    public Player player;
    [SerializeField] private TextMeshPro uiTextElement;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        int lives = player.lives;
        uiTextElement.SetText("Lives: {0}", lives);
    }
}
