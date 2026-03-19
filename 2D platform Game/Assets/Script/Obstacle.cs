using UnityEngine;

public class Obstacle : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    float minSize = 0.75f;
    float maxSize = 3f;
    void Start()
    {
        float randomSize = Random.Range(minSize, maxSize);
        transform.localScale = new Vector3(randomSize, randomSize, 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
