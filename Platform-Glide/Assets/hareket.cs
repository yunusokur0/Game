using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hareket : MonoBehaviour
{
    [SerializeField] private float forwardSpeed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        GetComponent<Rigidbody>().isKinematic = false;
        Vector3 downwardMovement = Vector3.down * forwardSpeed;
        GetComponent<Rigidbody>().velocity = new Vector3(GetComponent<Rigidbody>().velocity.x, downwardMovement.y, GetComponent<Rigidbody>().velocity.z);

    }
}
