using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _movementSpeed = 1f;

    private CharacterController2D _characterController2D = null; 

    private void Awake()
    {
        _characterController2D = this.GetComponent<CharacterController2D>();
    }

    private void Update()
    {
        UpdatePlayerInput();
    }

    private void UpdatePlayerInput()
    {
        UpdatePlayerMovement();
    }

    private void UpdatePlayerMovement()
    {
        //Input.GetKey()

        //var movementInput = 0f;
        var movementTarget = 0f;
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            movementTarget -= _movementSpeed;
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            movementTarget += _movementSpeed;
        }

        var doJump = false;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            doJump = true;
        }
        
        var doCrouch = false;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            doCrouch = true;
        }

        _characterController2D.Move(movementTarget, doCrouch, doJump);
    }
}
