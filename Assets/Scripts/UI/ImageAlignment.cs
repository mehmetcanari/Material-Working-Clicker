using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageAlignment : MonoBehaviour
{
    public Camera _mainCamera;
    public Transform _assignedTextTransform;

    private void Start()
    {
        RotateText(new Vector3(0,-180f,0));
    }

    private void Update()
    {
        LookToCamera();
    }

    private void LookToCamera()
    {
        transform.LookAt(_mainCamera.transform);
    }

    private void RotateText(Vector3 _textRotation)
    {
        _assignedTextTransform.transform.rotation = Quaternion.Euler(_textRotation);
    }
}
