using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class renkdegis : MonoBehaviour
{
    public GameObject red;
    public GameObject Green;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            red.SetActive(false);
            Green.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            red.SetActive(true);
            Green.SetActive(false);
        }
    }
}