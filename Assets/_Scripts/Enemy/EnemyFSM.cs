using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
namespace MazeHunter
{
    public enum EnemyStates{
        INBASE, CHASE, PATROL
    }
    public class EnemyFSM : MonoBehaviour
    {
        int postionArr=1;
        public EnemyStates currentState = EnemyStates.INBASE;
        private AIDestinationSetter _destinationSetter;
        [SerializeField] private List<Transform> BasePositions;
        [SerializeField] private List<Transform> PatrolPositions;

        void Awake()
        {
            _destinationSetter = GetComponent<AIDestinationSetter>();
        }

         private void Update() 
         {
            if (currentState == EnemyStates.INBASE) { WanderInBase(); }
            else if(currentState == EnemyStates.PATROL) { Patrol(); }
        }

        private void WanderInBase()
        {
            if(_destinationSetter.target.position != transform.position) return;
            postionArr = (postionArr+1) % 2;
            SetDestination(BasePositions[postionArr]);
        }

        private void Patrol()
        {
            if(_destinationSetter.target.position != transform.position) return;
            postionArr = (postionArr+1) % 3;
            SetDestination(PatrolPositions[postionArr]);
        }

        public void SetDestination(Transform pos)
        {
            _destinationSetter.target = pos;
        }


    }
}
