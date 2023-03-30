using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace DefaultNamespace
{
    public class ChangePlateColor : MonoBehaviour
    {
        [SerializeField] private bool _isPressed ;
        private Renderer _renderer;

        public void PressedPlate()
        {
            _isPressed = true;
        }

        private void Start()
        {
            _renderer = gameObject.GetComponentInChildren<Renderer>();
        }

        private void Update()
        {
            if (_isPressed)
            {
                SetButtonColor(Color.magenta);
            }
        }
        
        private void OnTriggerExit(Collider other)
        {
            _isPressed = false;
            SetButtonColor(Color.blue);
        }
       
        private void SetButtonColor(Color color)
        {
            _renderer.material.SetColor("_Color", color);
        }
        
    }
}