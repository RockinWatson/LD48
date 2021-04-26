using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashFX : MonoBehaviour
{
    [SerializeField] private float _lifeTime = 2f;
    private float _timer = 0;

    private SpriteRenderer _sprite = null;

    private void Awake()
    {
        _sprite = this.GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        UpdateFX();
    }

    private void UpdateFX()
    {
        _timer += Time.deltaTime;

        if(_timer >= _lifeTime)
        {
            Destroy(this.gameObject);
        }
        else
        {
            var alpha = 1f - (_timer / _lifeTime);
            var color = _sprite.color;
            color.a = alpha;
            _sprite.color = color;
        }
    }
}
