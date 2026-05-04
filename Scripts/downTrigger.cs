using UnityEngine;

public class downTrigger : MonoBehaviour
{
    public HoopScore hoop;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            hoop.ExitBottom(other.gameObject);
        }
    }
}