using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MazeHunter.Player
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(Collider))]

    public class CharacterGridMovement : MonoBehaviour
    {
        public bool isMoving { get; private set; }
        
        [Tooltip("Velocidad del Movimiento del personaje en N/s")]
        [Range(0, 100)]
        public float speed;
        private Rigidbody _rb;

        bool m_HitDetect;

        Collider m_Collider;
        RaycastHit m_Hit;

        float m_MaxDistance;

        void Start()
        {
            _rb = GetComponent<Rigidbody>();     
            m_Collider = GetComponent<Collider>();   
            m_MaxDistance = 1f;
        }

        public IEnumerator MoveTowards(Vector2 input)  
        {
            Vector3 moveDirection = new Vector3(input.x, 0, input.y);
            
            var targetPosition = transform.position;
            targetPosition.x += moveDirection.x;
            targetPosition.z += moveDirection.z;
            if (moveDirection != Vector3.zero) transform.forward = moveDirection;
            if(IsPathAvailable()) yield break;

            isMoving = true;
            while (Vector3.Distance(transform.position, targetPosition) > Mathf.Epsilon)
            {
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
                yield return null;
            }
            
            transform.position = targetPosition;
            isMoving = false;
        }

        bool IsPathAvailable()
        {
             return Physics.BoxCast(transform.position, Vector3.one / 5, transform.forward, out m_Hit, transform.rotation, m_MaxDistance, GameLayers.SharedInstance.CollisionLayers);
        }

        void OnDrawGizmos()
        {
            Gizmos.color = Color.green;

            if (m_HitDetect)
            {
                Gizmos.DrawRay(transform.position, transform.forward * m_Hit.distance);
                Gizmos.DrawWireCube(transform.position + transform.forward * m_Hit.distance, transform.localScale);
            }
            else
            {
                Gizmos.DrawRay(transform.position, transform.forward * m_MaxDistance);
                Gizmos.DrawWireCube(transform.position + transform.forward * m_MaxDistance, transform.localScale);
            }
    
        }
    }
}
