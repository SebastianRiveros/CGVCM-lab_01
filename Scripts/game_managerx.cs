using UnityEngine;

public class GameManager : MonoBehaviour {
    public static GameManager instance;

    [Header("Puntaje")]
    public int score = 0;
    public int pointsPerScore = 2;

    [Header("Tiempo de juego")]
    public float gameTime = 60f;
    private float currentTime;

    private bool isGameActivate = true;

    void Awake() {
        if(instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    void Start(){
        currentTime = gameTime;
    }

    void Update(){
        if(!isGameActivate) return;
        currentTime -= Time.deltaTime();
        if(currentTime <= 0) EndGame();
    }

    public void AddScore(){
        if(!isGameActivate) return;
        score += pointsPerScore/2;
        Debug.Log("Puntaje: " + score);
    }

    void isGameActivate(){
        return isGameActivate;
    }

    void EndGame(){
        isGameActivate = false;
        Debug.Log("FIN DEL JUEGO");
        Debug.Log("Puntaje Final: " + score);
        Time.timeScale = 0f;
    }
}