﻿using System.Collections;
using System.Collections.Generic;
using DefaultNamespace.EventObjects;
using UnityEngine;
using UnityEngine.Serialization;

public class ButtonEventController : MonoBehaviour
{
    [SerializeField] private string _playerTag = "Player";
    [SerializeField] private MovingPlatform _platform;

    private Renderer _renderer;
    private bool _isMoving;

    private void Start() {
        _renderer = gameObject.GetComponentInChildren<Renderer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_isMoving) return;
        if (other.gameObject.tag != _playerTag) return;

        SetButtonColor(Color.red);
        StartCoroutine(Moving());
    }

    private void OnTriggerExit(Collider other)
    {
        if (_isMoving) return;
        if (other.gameObject.tag != _playerTag) return;

        SetButtonColor(Color.blue);
        StartCoroutine(Moving());
    }

    IEnumerator Moving()
    {
        _isMoving = true;
        yield return new WaitForSeconds(0.3f);
        _isMoving = false;
    }

    private void OnTriggerStay(Collider other)
    {
        _platform.Move();
    }

    private void SetButtonColor(Color color)
    {
        if (_renderer == null) return;
        _renderer.material.SetColor("_Color", color);
    }
}