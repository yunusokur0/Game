using UnityEngine;


public class BallPhysicsController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Cup"))
        {
            transform.SetParent(other.transform);
            GetComponent<BoxCollider>().enabled = false;
            other.GetComponent<CupController>().Ball = gameObject;
        }
    }
}