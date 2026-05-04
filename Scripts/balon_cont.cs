using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(LineRenderer))]
public class BallController : MonoBehaviour
{
    private Rigidbody rb;
    private LineRenderer line;

    private bool isActive = false;
    private BallSpawner spawner;

    [Header("Fuerza")]
    public float maxForce = 20f;
    public float heightFactor = 0.5f;

    [Header("Trayectoria")]
    public int points = 25;
    public float timeStep = 0.08f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        line = GetComponent<LineRenderer>();

        rb.isKinematic = true;
        rb.useGravity = false;

        line.startWidth = 0.05f;
        line.endWidth = 0.05f;
    }

    public void Activate(BallSpawner sp)
    {
        isActive = true;
        spawner = sp;
    }

    void Update()
    {
        if (!isActive || !GameManager.instance.IsGameActive())
        {
            line.positionCount = 0;
            return;
        }

        DrawTrajectory();

        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        isActive = false;
        line.positionCount = 0;

        rb.isKinematic = false;
        rb.useGravity = true;

        Vector3 target = GetMousePointOnGround();
        Vector3 dir = target - transform.position;

        float distance = Mathf.Clamp(dir.magnitude, 0, maxForce);
        Vector3 direction = dir.normalized;

        Vector3 velocity = new Vector3(
            direction.x,
            heightFactor,
            direction.z
        ) * distance;

        rb.linearVelocity = velocity;

        StartCoroutine(Respawn());
    }

    IEnumerator Respawn()
    {
        yield return new WaitForSeconds(0.5f);

        if (GameManager.instance.IsGameActive())
        {
            spawner.SpawnBall();
        }
    }

    void DrawTrajectory()
    {
        line.positionCount = points;

        Vector3 startPos = transform.position;

        Vector3 target = GetMousePointOnGround();
        Vector3 dir = target - startPos;

        float distance = Mathf.Clamp(dir.magnitude, 0, maxForce);
        Vector3 direction = dir.normalized;

        Vector3 velocity = new Vector3(
            direction.x,
            heightFactor,
            direction.z
        ) * distance;

        for (int i = 0; i < points; i++)
        {
            float t = i * timeStep;

            Vector3 pos = startPos
                        + velocity * t
                        + 0.5f * Physics.gravity * t * t;

            line.SetPosition(i, pos);
        }
    }

    Vector3 GetMousePointOnGround()
    {
        Plane ground = new Plane(Vector3.up, Vector3.zero);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (ground.Raycast(ray, out float distance))
        {
            return ray.GetPoint(distance);
        }

        return transform.position;
    }
}