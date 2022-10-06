using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(OldPlayerMovement))]
public class OldPlayerController : MonoBehaviour
{

    OldPlayerMovement _playerMovement;

    Vector2 input;

    void Start()
    {
        _playerMovement = GetComponent<OldPlayerMovement>();
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
