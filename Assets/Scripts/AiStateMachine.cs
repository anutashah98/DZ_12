using System;
using UnityEngine;

namespace DefaultNamespace
{
    [RequireComponent(typeof(CubeController))]
    public class AiStateMachine : MonoBehaviour
    {
        private IAiState _currentState;
        private CubeController _cubController;
        

        private void Start()
        {
            _currentState = new WanderState();
            _cubController = GetComponent<CubeController>();
        }

        private void Update()
        {
            var direction = _currentState.GetDirection(transform.position);
            
            _cubController.Move(direction);

            var newState = _currentState.GetNextState();
            if (newState != null)
            {
                _currentState = newState;
            }
        }


    }

    public interface IAiState
    {
        public Vector3 GetDirection(Vector3 transformPosition);

        public IAiState GetNextState();
    }

    public class WanderState : IAiState
    {
        private IAiState _nexState;

        public Vector3 GetDirection(Vector3 transformPosition)
        {
            
            
            if (BlockChecker.HasBlockInDirection(transformPosition, Vector3.forward))
            {
                return Vector3.forward;
            }
            else
            {
                _nexState = new WaitState(); 
                return Vector3.zero;
            }
            
        }

        public IAiState GetNextState()
        {
            return _nexState;
        }
    }


    public class WaitState : IAiState
    {
        public Vector3 GetDirection(Vector3 transformPosition)
        {
            return Vector3.zero;
        }

        public IAiState GetNextState()
        {
            return null;
        }
    }
}