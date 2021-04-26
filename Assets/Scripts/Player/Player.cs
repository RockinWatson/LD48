using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Vector3 GetPosition() { return this.gameObject.transform.position; }

    private CharacterController2D _characterController2D = null;
    public CharacterController2D GetCharacterController2D() { return _characterController2D; }

    private Rigidbody2D _rigidbody2D = null;
    public Rigidbody2D GetRigidBody2d() { return _rigidbody2D; }

    private static Player _instance = null;
    public static Player Get() { return _instance; }

    [SerializeField] private float _startingHealth = 100f;
    private float _health;

    private void Awake()
    {
        _instance = this;

        _characterController2D = this.GetComponent<CharacterController2D>();
        _rigidbody2D = this.GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        _health = _startingHealth;
    }

    public void TakeDamage(float damage)
    {
        _health -= damage;

        if (_health <= 0f)
        {
            _health = 0f;
            Die();
        }
    }

    private void Die()
    {
        Debug.LogError("Player has Died");
    }
}
