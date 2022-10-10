using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLogic : MonoBehaviour
{
    [SerializeField] float baseTurnRate;
    [SerializeField] float turnSensitivity;
    [SerializeField] float lookUpSensitivity;
    [SerializeField] float distanceZBehindPlayer;
    [SerializeField] float heightYAbovePlayer;
    float sideLookInput;
    float upDownLookInput;
  
    GameObject CameraTarget;
    Vector3 CameraOffset;

    private void Start()
    {
        CameraTarget = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        //position camera at player then add height offfset
        CameraOffset = CameraTarget.transform.position;
        CameraOffset.y += heightYAbovePlayer;

        sideLookInput += Input.GetAxis("Mouse X") * baseTurnRate * turnSensitivity;
        upDownLookInput -= Input.GetAxis("Mouse Y") * baseTurnRate * lookUpSensitivity;  

    }
    private void LateUpdate()
    {
        Quaternion rot = Quaternion.Euler(upDownLookInput, sideLookInput, 0f);
        Vector3 camOffsetDist = new Vector3(0f, 0f, -distanceZBehindPlayer);
        transform.position = CameraOffset + (rot * camOffsetDist);

        transform.LookAt(CameraTarget.transform);
        
    }
    public Vector3 GetForwardVector()
    {
        Quaternion rot = Quaternion.Euler(0f, sideLookInput, 0f);

        return rot * Vector3.forward;
    }

    public Vector3 GetRightVector()
    {
        Quaternion rot = Quaternion.Euler(0f, sideLookInput, 0f);
        return rot * Vector3.right;
    }
}
