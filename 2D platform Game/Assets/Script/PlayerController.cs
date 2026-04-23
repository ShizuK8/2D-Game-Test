using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    public float thrustForce = 1f;
    public float maxSpeed = 5f;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        GetComponent<LifeSystem>();
    }

    void Update()
    {
        if (Mouse.current.leftButton.isPressed) //permet le déplacement
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.value);
            Vector2 direction = (mousePos - transform.position).normalized;
            transform.up = direction;
            rb.AddForce(direction * thrustForce);
            if (rb.linearVelocity.magnitude > maxSpeed)
            {
                rb.linearVelocity = rb.linearVelocity.normalized * maxSpeed;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       LifeSystem.instance.Life = LifeSystem.instance.Life - 1;
        if ((LifeSystem.instance.Life == 0) & (GameManager.Instance.currentState == GameManager.GameState.Playing))
        {
           
            GameManager.Instance.TriggerGameOver();
        }
    }
}
