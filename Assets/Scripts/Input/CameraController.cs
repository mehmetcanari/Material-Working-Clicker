using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraController : MonoBehaviour
{
    private Vector2 _startPosition;
    private Vector2 _deltaPosition;
    [SerializeField] private int _rotateSpeed;
    [SerializeField] private int _rotateSmoothness;
    
    private void Update()
    {
        switch (StateManager.Instance._states)
        {
            case GameStates.Play:
                Rotate();
                break;
        }
    }

    private void Rotate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _startPosition = Input.mousePosition;
        }

        if (Input.GetMouseButton(0))
        {
            _deltaPosition = (Vector2)Input.mousePosition - _startPosition;

            transform.eulerAngles = new Vector3(transform.eulerAngles.x,
                Mathf.Lerp(transform.eulerAngles.y,
                    transform.eulerAngles.y + (_deltaPosition.x / Screen.width) * _rotateSpeed,
                    Time.deltaTime * _rotateSmoothness), transform.eulerAngles.z);
        }
    }
}
