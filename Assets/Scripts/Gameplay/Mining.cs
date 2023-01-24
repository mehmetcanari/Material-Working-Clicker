using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;

public class Mining : MonoBehaviour
{
    public GameObject _pickaxe;
    [SerializeField] private float _second;
    private bool _hitAllow = true;
    public UnityEvent TaskCaller;
    public Ease _easing;

    public float Second
    {
        get
        {
            return _second;
        }
        set
        {
            _second = value;
        }
    }

    public bool HitAllow
    {
        get
        {
            return _hitAllow;
        }
        set
        {
            _hitAllow = value;
        }
    }

    private void Awake()
    {
        SetData(gameObject);
    }

    private void Update()
    {
        switch (StateManager.Instance._states)
        {
            case GameStates.Play:
                TaskCaller?.Invoke();
                break;
        }
    }

    private void SetData(GameObject _pickaxe)
    {
        this._pickaxe = _pickaxe;
    }

    public void Hit()
    {
        if (!HitAllow) return;
        _pickaxe.transform.DORotate(new Vector3(0, -45f, 30), Second).SetLoops(-1, LoopType.Yoyo).SetEase(_easing);
        HitAllow = false;
    }
}