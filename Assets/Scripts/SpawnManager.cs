using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enimies;

    private float spawnRangeX = 10;
    private float spawnRangey = 3;
    private float startDelay = 2;
    private float spawnInterval = 1.5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("SpawnRandom", startDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnRandom()
    {
        int index = Random.Range(0, enimies.Length);
        int spawnSide = Random.Range(0,2);

        if (spawnSide == 0)
        {
            Vector2 spawnPositon = new Vector2(-spawnRangeX, Random.Range(-spawnRangey, spawnRangey));
            Instantiate(enimies[index], spawnPositon, enimies[index].transform.rotation);
        }
        else
        {
            Vector2 spawnPositon = new Vector2(spawnRangeX, Random.Range(-spawnRangey, spawnRangey));
            Quaternion rotation = Quaternion.Euler(0, 180, 0);
            Instantiate(enimies[index], spawnPositon, rotation);
        }
    }
}
