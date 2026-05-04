using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("Puntaje")]
    public int score = 0;
    public int pointsPerScore = 2;

    [Header("Tiempo de juego")]
    public float gameTime = 60f;
    private float currentTime;

    private bool isGameActive = true;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        currentTime = gameTime;
    }

    void Update()
    {
        if (!isGameActive) return;

        currentTime -= Time.deltaTime;

        if (currentTime <= 0)
        {
            EndGame();
        }
    }

    public void AddScore()
    {
        if (!isGameActive) return;

        score += pointsPerScore/2;
        Debug.Log("Puntaje: " + score);
    }

    public bool IsGameActive()
    {
        return isGameActive;
    }

    void EndGame()
    {
        isGameActive = false;

        Debug.Log("FIN DEL JUEGO");
        Debug.Log("Puntaje final: " + score);

        Time.timeScale = 0f; // pausa total
    }
}