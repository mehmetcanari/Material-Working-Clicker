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
        StartCoroutine(CallingRecursive());
        IEnumerator CallingRecursive()
        {
            yield return new WaitForSeconds(Second * 4);
            CallHitTasks();
            StartCoroutine(CallingRecursive());
        }
        HitAllow = false;
    }

    private void CallHitTasks()
    {
        if (CurrentMine.Instance._activeMine.TryGetComponent(out RawProduce _produce))
        {
            OnHitScale();
            _produce.TaskCalling?.Invoke();
        }
    }

    private void OnHitScale()
    {
        Vector3 _defaultScale = CurrentMine.Instance._activeMine.transform.localScale;

        Vector3 _adjustedScale = new Vector3(2, 2, 2);

        CurrentMine.Instance._activeMine.transform.DOScale(_adjustedScale, 0.1f).OnComplete(() =>
        {
            CurrentMine.Instance._activeMine.transform.DOScale(_defaultScale, 0.1f);
        });
    }
}
