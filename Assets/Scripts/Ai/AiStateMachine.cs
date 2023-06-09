﻿using System;
using UnityEngine;

namespace DefaultNamespace
{
    [RequireComponent(typeof(CubeController))]
    public class AiStateMachine : MonoBehaviour
    {
        [SerializeField] private Vector3 _startDirection = Vector3.forward;
        
        private IAiState _currentState;
        private CubeController _cubController;
        

        private void Start()
        {
            _currentState = new WanderState(_startDirection);
            _cubController = GetComponent<CubeController>();
        }

        private void Update()
        {
            var direction = _currentState.GetDirection(transform.position);
            
            _cubController.Move(direction);
            
            _currentState.OnUpdate(Time.deltaTime);
            var newState = _currentState.GetNextState();
            if (newState != null)
            {
                _currentState = newState;
            }
        }
    }
}