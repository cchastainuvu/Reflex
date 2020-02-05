using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

public class FPS_Camera : MonoBehaviour
{
    private Vector3 _position;
    
    public float orientSpeed;
    
    private float _rotationX = 0F;
    private float _orientationX, _orientationY;

    public Transform playerBody;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    
    private void Update()
    {
        _orientationX = Input.GetAxis("Mouse X") * orientSpeed * Time.deltaTime;
        _orientationY = Input.GetAxis("Mouse Y") * orientSpeed * Time.deltaTime;

        _rotationX -= _orientationY;
        _rotationX = Mathf.Clamp(_rotationX, -90F, 90F);
        
        transform.localRotation = Quaternion.Euler(_rotationX, 0F, 0F);
        playerBody.Rotate(Vector3.up * _orientationX);
    }
}
