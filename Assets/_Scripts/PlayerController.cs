using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
public class PlayerController : MonoBehaviour
{

    PlayerMovement _playerMovement;

    Vector2 input;

    void Start()
    {
        _playerMovement = GetComponent<PlayerMovement>();
    }

    void Update()
    {
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");

        if(input != Vector2.zero)
        {
            if (input.y != 0) input.x = 0;
            _playerMovement.MoveTowards(input);
        }
    }
}
