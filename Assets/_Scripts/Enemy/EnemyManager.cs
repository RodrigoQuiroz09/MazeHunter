using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MazeHunter
{

    public class EnemyManager : MonoBehaviour
    {
        [SerializeField] private List<EnemyFSM> enemiesInBase;

        private IEnumerator Start() 
        {
            while(enemiesInBase.Count>0)
            {
                int tmp = Random.Range(0, enemiesInBase.Count);
                enemiesInBase[tmp].currentState = EnemyStates.PATROL;
                enemiesInBase.RemoveAt(tmp);
                yield return new WaitForSeconds(10f);
            }
            
        }
        


    }
}
