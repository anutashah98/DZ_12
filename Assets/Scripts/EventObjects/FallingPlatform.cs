using DG.Tweening;
using UnityEngine;

namespace DefaultNamespace.EventObjects
{
    public class FallingPlatform : MovingPlatform
    {
        [SerializeField] private float _distance = 10f;
        [SerializeField] private float _duration = 1f; // время затраченное на падение

        public override void Move()
        {
            
            transform.DOMove(Vector3.down * _distance, _duration)
                .OnComplete(OnComplite);
        }

        private void OnComplite()
        {
            Destroy(gameObject);
        }
    }
}