using UnityEngine;

public class Obstacle : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float minSize = 0.75f;
    public float maxSize = 3f;
    Rigidbody2D rb;
    public float minSpeed = 5f;
    public float maxSpeed = 15f;
    public float maxSpinSpeed = 10f;

    void Start()
    {
        Vector2 randomDirection = Random.insideUnitCircle;
        float randomSize = Random.Range(minSize, maxSize);
        transform.localScale = new Vector3(randomSize, randomSize, 1);
        rb = GetComponent<Rigidbody2D>();
        float randomSpeed = Random.Range(minSpeed, maxSpeed) / randomSize;
        rb.AddForce(randomDirection * randomSpeed);
        float randomTorque = Random.Range(-maxSpinSpeed, maxSpinSpeed);
        rb.AddTorque(randomTorque);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate() // Utilise FixedUpdate pour la physique
    {
        // On vérifie la magnitude (la longueur du vecteur vitesse)
        if (rb.linearVelocity.magnitude < minSpeed)
        {
            // On ré-applique la vitesse minimum tout en gardant la direction actuelle
            rb.linearVelocity = rb.linearVelocity.normalized * minSpeed;
        }

        float distanceFromCenter = Vector2.Distance(transform.position, Vector2.zero);

       
        if (distanceFromCenter > 10f)
        {
            Vector2 directionToCenter = (Vector2.zero - (Vector2)transform.position).normalized;
            rb.AddForce(directionToCenter * 5f);
        }
    }
}
