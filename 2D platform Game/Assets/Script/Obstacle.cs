using UnityEngine;

public class Obstacle : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float minSize = 0.75f;
    public float maxSize = 3f;
    Rigidbody2D rb;
    public float minSpeed = 50f;
    public float maxSpeed = 150f;

    void Start()
    {
        Vector2 randomDirection = Random.insideUnitCircle;
        float randomSize = Random.Range(minSize, maxSize);
        transform.localScale = new Vector3(randomSize, randomSize, 1);
        rb = GetComponent<Rigidbody2D>();
        float randomSpeed = Random.Range(minSpeed, maxSpeed);
        rb.AddForce(randomDirection * randomSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
