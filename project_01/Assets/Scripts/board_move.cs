using UnityEngine;

public class BackboardMovement : MonoBehaviour
{
    [Header("Movimiento en eje Z")]
    public float moveDistance = 3f; // cuánto se mueve desde el centro
    public float speed = 2f;        // velocidad

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        float offset = Mathf.Sin(Time.time * speed) * moveDistance;

        transform.position = new Vector3(
            startPos.x,
            startPos.y,
            startPos.z + offset
        );
    }
}