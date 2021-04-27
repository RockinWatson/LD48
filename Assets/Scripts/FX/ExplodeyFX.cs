using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeyFX : MonoBehaviour
{
    private Animator _animator = null;
    private float _lifeTime = 0f;
    private float _timer = 0f;

    //private SpriteRenderer _sprite = null;

    private void Awake()
    {
        _animator = this.GetComponent<Animator>();
    }

    private void Start()
    {
        _lifeTime = _animator.runtimeAnimatorController.animationClips[0].length;
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
        //else
        //{
        //    var alpha = 1f - (_timer / _lifeTime);
        //    var color = _sprite.color;
        //    color.a = alpha;
        //    _sprite.color = color;
        //}
    }
}
