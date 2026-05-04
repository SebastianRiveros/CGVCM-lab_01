using UnityEngine;
using System.Collections.Generic;

public class HoopScore : MonoBehaviour
{
    private HashSet<GameObject> validBalls = new HashSet<GameObject>();
    private HashSet<GameObject> scoredBalls = new HashSet<GameObject>();

    public void EnterTop(GameObject ball)
    {
        if (!validBalls.Contains(ball))
        {
            validBalls.Add(ball);
        }
    }

    public void ExitBottom(GameObject ball)
    {
        // BLOQUEO TOTAL
        if (scoredBalls.Contains(ball)) return;

        if (validBalls.Contains(ball))
        {
            validBalls.Remove(ball);

            // marcar ANTES de sumar
            scoredBalls.Add(ball);

            GameManager.instance.AddScore();
        }
    }
}