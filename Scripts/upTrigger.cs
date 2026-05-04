using UnityEngine;

public class upTrigger : MonoBehaviour
{
    public HoopScore hoop;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            hoop.EnterTop(other.gameObject);
        }
    }
}