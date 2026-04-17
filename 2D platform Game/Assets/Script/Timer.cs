using UnityEngine;
using TMPro; // Nécessaire pour TextMeshPro

public class Chronometre : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    private float tempsEcoule;

    void Update()
    {
        tempsEcoule += Time.deltaTime;

        // Formatage pour afficher minutes:secondes
        int minutes = Mathf.FloorToInt(tempsEcoule / 60F);
        int secondes = Mathf.FloorToInt(tempsEcoule % 60F);
    }
}
