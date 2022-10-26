using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MazeHunter
{
    public class Sight : MonoBehaviour
    {
        public float distance;
        public float angle;
        public Collider detectedTarget;
        void Update()
        {
            Collider[] coliders = Physics.OverlapSphere(transform.position, distance, GameLayers.SharedInstance.PlayerObjLayer);
            detectedTarget = null;
            if(coliders.Length>0) detectedTarget = coliders[0];

        }
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, distance);

            Gizmos.color = Color.green;
            Vector3 rightDir = Quaternion.Euler(0, angle, 0) * transform.forward;
            Gizmos.DrawRay(transform.position, rightDir * distance);

            Vector3 leftDir = Quaternion.Euler(0, -angle, 0) * transform.forward;
            Gizmos.DrawRay(transform.position, leftDir * distance);
        }
    }
}
