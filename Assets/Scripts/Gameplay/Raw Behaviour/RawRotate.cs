using System;
using System.Collections;
using System.Collections.Generic;
using Dreamteck.Splines;
using UnityEngine;

public class RawRotate : MonoBehaviour
{
    public float _rotateSpeed;
    
    private Vector3 GetMotionData()
    {
        SplineFollower _follower = gameObject.GetComponent<SplineFollower>();

        Vector3 _rotationOffset = _follower.motion.rotationOffset;

        return _rotationOffset;
    }

    private void UpdateRotation(Vector3 _finalMotion)
    {
        SplineFollower _follower = gameObject.GetComponent<SplineFollower>();
        
        _finalMotion = new Vector3(_finalMotion.x, _finalMotion.y + _rotateSpeed * Time.deltaTime, _finalMotion.z);

        _follower.motion.rotationOffset = _finalMotion;
    }

    private void Update()
    {
        switch (StateManager.Instance._states)
        {
            case GameStates.Play:
                UpdateRotation(GetMotionData());
                break;
        }
    }
}
