using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float shiftFactor;      // kuculme buyume h�z�
    [SerializeField] private float forwardSpeed;
    private void Update()
    {
        
            //GetComponent<Rigidbody>().isKinematic = false;
            //Vector3 downwardMovement = Vector3.down * forwardSpeed;
            //GetComponent<Rigidbody>().velocity = new Vector3(GetComponent<Rigidbody>().velocity.x, downwardMovement.y, GetComponent<Rigidbody>().velocity.z);
        

        if (Input.GetMouseButton(0)) // Sol t�k kontrol�
        {
            float inputValue = Input.GetAxis("Mouse X"); // Mouse X y�n�ndeki de�i�im okunuyor
            if (inputValue != 0)
            {
                CalculateNewScale(inputValue);
            }
        }
    }

    private void CalculateNewScale(float inputValue)
    {

        float xScaleShiftAmout = inputValue * shiftFactor * Time.deltaTime;
        float yScaleShiftAmout = inputValue * shiftFactor * Time.deltaTime;
        SetNewScale(xScaleShiftAmout, yScaleShiftAmout);
    }
    private void SetNewScale(float xScaleShiftAmout, float yScaleShiftAmout)
    {
        Vector3 newScale = transform.localScale + new Vector3(xScaleShiftAmout, 0, yScaleShiftAmout);

        // �l�e�i .1 - 5 aras�nda s�n�rland�r
        newScale.x = Mathf.Clamp(newScale.x, 2.1f, 5.15f);
        newScale.z = Mathf.Clamp(newScale.z, 2.1f, 5.15f);
        transform.localScale = newScale;
    }
}
