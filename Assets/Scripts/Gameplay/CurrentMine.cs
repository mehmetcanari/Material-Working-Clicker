using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentMine : MonoBehaviour
{
    public static CurrentMine Instance;
    public GameObject _activeMine;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
