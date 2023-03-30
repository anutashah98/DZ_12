using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PressurePlate : MonoBehaviour
{
    [SerializeField] private string _playerTag = "Player";
    
    public UnityEvent OnPressed;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != _playerTag) return;
        OnPressed.Invoke();
    }
}
