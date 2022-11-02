using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MazeHunter
{
    [RequireComponent (typeof(Collider))]
    public class Pickable : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other) {
            Debug.Log("A");
            if(other.tag == "Player")
            {
                Debug.Log("B");
                Destroy(this.gameObject);
            }
        }
    }
}
