using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class Mining : ProduceDataset
{
    private GameObject _pickaxe;
    [SerializeField] private float _second;
    public bool _hitAllow = true;

    public UnityEvent HitCalling;
    public AnimationCurve _easing;
    private int hitCount;

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

    protected bool HitAllow
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
                HitCalling?.Invoke();
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
        _pickaxe.transform.DORotate(new Vector3(0, -45f, 0), Second).SetLoops(-1, LoopType.Yoyo).SetEase(_easing).SetId("Mining").OnStepComplete(
            () =>
            {
                hitCount++;
                if (hitCount % 2 == 0)
                {
                    CallHitTasks();
                }
            });
        HitAllow = false;
    }

    private void CallHitTasks()
    {
        if (CurrentMine.Instance._activeMine.TryGetComponent(out RawBehaviour _produce))
        {
            ProduceTargetItem(_produce._rawMaterial, _produce._mineConveyorPath, Vector3.one * 1.75f, 
                CurrentMine.Instance._activeMine.transform);
        }
    }
}
