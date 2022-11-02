using UnityEngine;

namespace MazeHunter
{
    public class JumpAbility : MonoBehaviour, IAbility
    {
        public float JumpDistance;
        private Vector3 target;

        void Start()
        {
            JumpDistance = 3f;
        }

        bool IsPathAvailable(Vector3 targetPosition)
        {
            var colliders = Physics.OverlapBox(targetPosition, Vector3.one/3,
                                    Quaternion.identity,GameLayers.SharedInstance.WallObjLayer);
  
            return !(colliders.Length>0);
        }
    public void Action()
        {
        
            target = transform.position;
            target.x += transform.forward.x * JumpDistance;
            target.z += transform.forward.z * JumpDistance;
            if (IsPathAvailable(target))
            {
                 Debug.Log("-------Saltar---------");
                 Debug.Log(target);
            }
            else
            {
                Debug.Log("-------HIT---------");
                Debug.Log(target);
            } 
        }

        void OnDrawGizmos()
        {
            Gizmos.color = Color.red;

            Gizmos.DrawWireCube(target, Vector3.one/3);
            Gizmos.DrawIcon(target, "target");
        }
    }
}
