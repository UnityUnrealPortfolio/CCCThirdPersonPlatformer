using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    [SerializeField] LayerMask environmentLayer;

    private void OnCollisionEnter(Collision collision)
    {
        //are we hitting environment?
        if (collision.gameObject.CompareTag("Environment"))
        {
            Debug.Log("Camera hitting Environment!");
        }
        else
        {
            Debug.Log("Camera not hitting Environment!");

        }
    }
}
