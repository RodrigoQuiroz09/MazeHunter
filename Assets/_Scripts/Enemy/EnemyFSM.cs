using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
namespace MazeHunter
{
    public enum EnemyStates{
        INBASE, CHASE, PATROL
    }
    [RequireComponent(typeof(Sight))]
    public class EnemyFSM : MonoBehaviour
    {
        int postionArr=1;
        public EnemyStates currentState = EnemyStates.INBASE;
        private AIDestinationSetter _destinationSetter;
        private Sight _sight;
        private bool transition = false;
        [SerializeField] private List<Transform> BasePositions;
        [SerializeField] private List<Transform> PatrolPositions;

        void Awake()
        {
            _destinationSetter = GetComponent<AIDestinationSetter>();
            _sight = GetComponent<Sight>();
        }

         private void Update() 
         {
            if (currentState == EnemyStates.INBASE) { WanderInBase(); }
            else if(currentState == EnemyStates.PATROL) { Patrol(); }
            else if (currentState == EnemyStates.CHASE) { Chase(); }
        }

        private void WanderInBase()
        {
            if(_destinationSetter.target.position != transform.position) return;
            postionArr = (postionArr+1) % 2;
            SetDestination(BasePositions[postionArr]);
        }

        private void Patrol()
        {
            if (_sight.detectedTarget != null)
            { 
                currentState = EnemyStates.CHASE;
                return;
            }
            if(_destinationSetter.target.position != transform.position && !transition) return;
            postionArr = (postionArr+1) % 3;
            transition = false;
            SetDestination(PatrolPositions[postionArr]);
            
        }

        private void Chase()
        {

            if (_sight.detectedTarget == null) 
            { 
                currentState = EnemyStates.PATROL;
                transition = true;
                return;
            }

            SetDestination(_sight.detectedTarget.transform);
        }

        public void SetDestination(Transform pos)
        {
            _destinationSetter.target = pos;
        }


    }
}
