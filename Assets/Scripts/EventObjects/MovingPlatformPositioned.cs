using System;
using DG.Tweening;
using UnityEngine;

namespace DefaultNamespace.EventObjects
{
    public class MovingPlatformPositioned : MovingPlatform
    {
        [SerializeField] private Transform _pos1;
        [SerializeField] private Transform _pos2;
        [SerializeField] private float _duration = 2f;
        [SerializeField] private Ease _ease = Ease.Linear;
        
        private Transform _currentPos;
        private bool _isMoving = false;

        private void Start()
        {
            _currentPos = _pos1;
            transform.position = _pos1.position;
        }

        public override void Move()
        {
            if(_isMoving) return;
            _isMoving = true;
            
            if (_currentPos == _pos1)
            {
                MoveToPos(_pos2);
            }
            else
            {
                MoveToPos(_pos1);
            }
        }

        private void MoveToPos(Transform targetPos)
        {
            _currentPos = targetPos;
            transform.DOMove(targetPos.position, _duration)
                .SetEase(_ease)
                .OnComplete(OnComplite);
        }

        private void OnComplite()
        {
            _isMoving = false;
        }
    }
}