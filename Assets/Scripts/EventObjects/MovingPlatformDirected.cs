using UnityEngine;

namespace DefaultNamespace.EventObjects
{
    public class MovingPlatformDirected : MovingPlatform
    {
        [SerializeField] private Vector3 _direction = new Vector3(0, 0, -0.5f);


        public override void Move()
        {
            transform.position += _direction * Time.deltaTime;
            
        }
        
    }
}