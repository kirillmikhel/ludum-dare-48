using UnityEngine;

public class PickUpLog : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Lumberjack"))
        {
            other.GetComponent<LumberjackData>().wood += 1;
            Destroy(gameObject);
        }
    }
}