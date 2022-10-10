using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    CameraLogic cameraLogic;
    Vector3 ForwardmoveDirection = Vector3.zero;
    Vector3 SideMoveDirection =Vector3.zero;
    private void Start()
    {
        cameraLogic = FindObjectOfType<CameraLogic>();
    }

    private void Update()
    {
        float verticalInput = Input.GetAxisRaw("Vertical") * 5f * Time.deltaTime;
        float horizontalInput = Input.GetAxisRaw("Horizontal") * 5f*Time.deltaTime;

        ForwardmoveDirection = cameraLogic.GetForwardVector() * verticalInput;
        SideMoveDirection = cameraLogic.GetRightVector() * horizontalInput;

        Vector3 moveDirection = ForwardmoveDirection + SideMoveDirection;
        transform.Translate(moveDirection);
        Debug.Log("ForwardMoveDirection: " + ForwardmoveDirection);

    }
}
