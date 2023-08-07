using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [SerializeField] private float _mouseSensitivity = 100f;
    [SerializeField] private Transform _playerBody;
    private float _inputX = 0f;
    private float _inputY = 0f;
    private float cameraVerticalRotation = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        CollectMouseInput(); 
        RotateAroundLocalXAxis(_inputY);
        RotatePlayerAndCameraAroundYAxis(_inputX, _playerBody);
    }

    private void CollectMouseInput()
    {
        _inputX = Input.GetAxis("Mouse X") * _mouseSensitivity * Time.deltaTime;
        _inputY = Input.GetAxis("Mouse Y") * _mouseSensitivity * Time.deltaTime;
    }

    private void RotateAroundLocalXAxis(float inputY)
    {
        
        cameraVerticalRotation -= _inputY;
        cameraVerticalRotation = Mathf.Clamp(cameraVerticalRotation, -90f, 90f);
        transform.localEulerAngles = Vector3.right * cameraVerticalRotation;
        
    }

    private void RotatePlayerAndCameraAroundYAxis(float inputX, Transform playerBody)
    {
        playerBody.Rotate(Vector3.up * inputX);
    }
}
