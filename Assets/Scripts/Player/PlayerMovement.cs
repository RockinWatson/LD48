using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Animator _animator = null;
    [SerializeField] private float _movementSpeed = 1f;

    private CharacterController2D _characterController2D = null;

    // State variables:
    private float _horizontalMove = 0f;
    private bool _jump = false;
    private bool _crouch = false;

    private void Awake()
    {
        _characterController2D = this.GetComponent<CharacterController2D>();
        _animator = this.GetComponent<Animator>();
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
        _horizontalMove = Input.GetAxisRaw("Horizontal") * _movementSpeed;

        //var doJump = false;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _jump = true;
        }

        if (Input.GetButtonDown("Jump"))
        {
            _jump = true;
            _animator?.SetBool("IsJumping", true);
        }

        //if (Input.GetButtonDown("Crouch"))
        //{
        //    _crouch = true;
        //}
        //else if (Input.GetButtonUp("Crouch"))
        //{
        //    _crouch = false;
        //}
    }

    public void OnLanding()
    {
        _animator?.SetBool("IsJumping", false);
    }

    public void OnCrouching(bool isCrouching)
    {
        _animator?.SetBool("IsCrouching", isCrouching);
    }

    private void FixedUpdate()
    {
        _characterController2D.Move(_horizontalMove, _crouch, _jump);
        _jump = false;
    }
}
