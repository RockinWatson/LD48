using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Animator _animator = null;
    [SerializeField] private float _movementSpeed = 1f;

    [SerializeField]
    private float _dashTimeThreshold = 0.5f;
    private float _dashTimer = 0.0f;
    private bool _possibleDash = false;
    private float _possibleDashDirection = 0f;
    private bool _dash = false;

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

        UpdateDashMovement();

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

    private void UpdateDashMovement()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            _dash = true;
            _possibleDash = false;
            return;
        }
        if (_possibleDash)
        {
            _dashTimer += Time.deltaTime;
            if (_dashTimer >= _dashTimeThreshold)
            {
                _possibleDash = false;
            }
        }
        if (Input.GetButtonDown("Horizontal"))
        {
            _dashTimer = 0f;
            if (_possibleDash)
            {
                if (Mathf.Approximately(_horizontalMove, _possibleDashDirection))
                {
                    // Let's dash!
                    _dash = true;
                    _possibleDash = false;
                }
            }
            else
            {
                _possibleDash = true;
                _possibleDashDirection = _horizontalMove;
            }
        }
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
        if(_dash)
        {
            _characterController2D.Dash();
            _dash = false;
        }

        _characterController2D.Move(_horizontalMove, _crouch, _jump);
        _jump = false;
    }
}
