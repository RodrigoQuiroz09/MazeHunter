using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MazeHunter.Player
{
        [RequireComponent(typeof(CharacterGridMovement))]
    public class Character : MonoBehaviour
    {
            
        
        CharacterGridMovement _playerMovement;

        Vector2 input;

        void Start()
        {
            _playerMovement = GetComponent<CharacterGridMovement>();
        }

        void Update()
        {
            if(!_playerMovement.isMoving)
            {
                input.x = Input.GetAxisRaw("Horizontal");
                input.y = Input.GetAxisRaw("Vertical");

                if(input != Vector2.zero)
                {
                    if (input.y != 0) input.x = 0;
                    StartCoroutine( _playerMovement.MoveTowards(input));
                }
            }
        }
    }
}
