using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    public GameObject ballPrefab;
    public Transform spawnPoint;

    void Start()
    {
        SpawnBall();
    }

    public void SpawnBall()
    {
        if (!GameManager.instance.IsGameActive()) return;

        GameObject ball = Instantiate(ballPrefab, spawnPoint.position, spawnPoint.rotation);

        BallController bc = ball.GetComponent<BallController>();
        bc.Activate(this);
    }
}