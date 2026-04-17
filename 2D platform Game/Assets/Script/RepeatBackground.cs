using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    private Vector3 startPosition;
    private float repeatWidth;

    void Start()
    {
        startPosition = transform.position;
        // Calcule la moitié de la largeur du sprite
        repeatWidth = GetComponent<BoxCollider2D>().size.x / 2;
    }

    void Update()
    {
        // Déplacez le fond (exemple vers la gauche)
        // transform.Translate(Vector3.left * speed * Time.deltaTime);

        // Si le fond est sorti de l'écran, le réinitialiser
        if (transform.position.x < startPosition.x - repeatWidth)
        {
            transform.position = startPosition;
        }
    }
}
