using UnityEngine;
using TMPro; // Important pour utiliser TextMeshPro
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public enum GameState { Playing, GameOver }
    public GameState currentState;

    [Header("UI Elements")]
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI bestText;

    private float currentTimer;
    private float bestChrono;
    [Header("Buttons")]
    public GameObject restartButton;
    public GameObject quitButton;

    void Awake()
    {
        Instance = this;
        currentState = GameState.Playing;

        // Charger le record et l'afficher immédiatement
        bestChrono = SaveSystem.LoadBestChrono();
        UpdateBestDisplay();
    }

    void Update()
    {
        if (currentState == GameState.Playing)
        {
            currentTimer += Time.deltaTime;
            UpdateTimerDisplay();
        }
    }

    public void QuitGame()
    {
        // 1. Pour la version WebGL (Navigateur)
#if UNITY_WEBGL
        // On quitte le mode plein écran
        Screen.fullScreen = false;
        Debug.Log("Sortie du mode plein écran WebGL");
        Application.OpenURL("https://azshizu.itch.io/");
#endif

        // 2. Pour la version Windows / Build Standalone
#if UNITY_STANDALONE
        // Ferme complètement l'application
        Application.Quit();
        Debug.Log("Fermeture du jeu Windows");
#endif

        // 3. Pour tester dans l'éditeur Unity (ne fait rien en jeu final)
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }

    // Formate le temps en 00:00.00
    void UpdateTimerDisplay()
    {
        if (timerText != null)
        {
            // "F2" limite à 2 chiffres après la virgule
            timerText.text = "Temps: " + currentTimer.ToString("F2") + "s";
        }
    }


public void RestartGame()
{
    // Relance la scène actuelle
    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    restartButton.SetActive(false);
    quitButton.SetActive(false);
    Time.timeScale = 1;
       
}

void UpdateBestDisplay()
    {
        if (bestText != null)
        {
            bestText.text = "Record: " + bestChrono.ToString("F2") + "s";
        }
    }

    public void TriggerGameOver()
    {
        currentState = GameState.GameOver;

        // Fige le moteur physique et le temps
        Time.timeScale = 0f;
        restartButton.SetActive(true);
        quitButton.SetActive(true);


        if (currentTimer > bestChrono)
        {
            bestChrono = currentTimer;
            SaveSystem.SaveBestChrono(bestChrono);
            UpdateBestDisplay();
        }
    }
}
