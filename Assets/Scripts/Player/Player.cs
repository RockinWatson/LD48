using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    public float GetHealthPercent() { return _health / _startingHealth * 100f; }
    public void AddHealthPercent(float percent)
    {
        var amount = _startingHealth * percent / 100f;
        _health = Mathf.Min(_health + amount, _startingHealth);
    }

    [SerializeField] private float _maximumTemperature = 666f;
    [SerializeField] private float _temperatureLostPerMinute = 100f;
    [SerializeField] private float _startingTemperature = 200f;
    private float _temperature;
    public float GetTemperatureScale() { return _temperature / _maximumTemperature; }

    [SerializeField] private float _maximumDepth = 200f;
    [SerializeField] private float _startingDepth = 0.5f;
    private float _depth;
    public float GetDepthScale() { return _depth / _maximumDepth; }

    [SerializeField] private GameObject _dashFX = null;
    [SerializeField] private Transform _dashFXTransform = null;
    [SerializeField] private GameObject _doubleJumpFX = null;
    [SerializeField] private Transform _doubleJumpFXTransform = null;

    private bool _isDead = false;
    public bool IsDead() { return _isDead; }

    private bool _canTakeDmg = true;
    public bool CanTakeDmg() { return _canTakeDmg; }

    private void Awake()
    {
        _instance = this;

        _isDead = false;
        _characterController2D = this.GetComponent<CharacterController2D>();
        _rigidbody2D = this.GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        _health = _startingHealth;
        _temperature = _startingTemperature;
        _depth = _startingDepth;
    }

    public void TakeDamage(float damage)
    {
        _health -= damage;

        Debug.Log("Health: " + _health);
        if (_health <= 0f)
        {
            _canTakeDmg = false;
            
            //_health = 0f;
            Die();
        }
    }

    private void Die()
    {
        _isDead = true;
        this.gameObject.GetComponent<Animator>().Play("Player-Death");
        Debug.LogError("Player has Died");
        GameplayAudioInit.playerDamage2.Play();
        StartCoroutine(LoadGameOverScene());
    }

    public void AddHeat(float heat)
    {
        _temperature = Mathf.Min(_temperature + heat, _maximumTemperature);
    }

    public void AddToppings(float amount)
    {
        _depth = Mathf.Min(_depth + amount, _maximumDepth);
        GameplayAudioInit.pickup.Play();
    }

    private void Update()
    {
        UpdateTemperature();
    }

    private void UpdateTemperature()
    {
        var heatLost = _temperatureLostPerMinute * Time.deltaTime / 60f;
        _temperature = Mathf.Max(0f, _temperature - heatLost);
    }

    public void SpawnDashFX()
    {
        var fx = Instantiate(_dashFX);
        fx.transform.position = _dashFXTransform.position;
    }

    public void SpawnDoubleJumpFX()
    {
        var fx = Instantiate(_doubleJumpFX);
        fx.transform.position = _doubleJumpFXTransform.position;
    }

    IEnumerator LoadGameOverScene()
    {
        yield return new WaitForSeconds(4);
        SceneManager.LoadScene("GameLose");
    }
}
