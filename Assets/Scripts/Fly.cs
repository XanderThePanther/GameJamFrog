using UnityEngine;

public class Fly : MonoBehaviour
{
    public int speed = 5;
    public int xBoundary = 10;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);

        if(transform.position.x >= xBoundary || transform.position.x <= -xBoundary)
        {
            Destroy(gameObject);
        }
    }
}
