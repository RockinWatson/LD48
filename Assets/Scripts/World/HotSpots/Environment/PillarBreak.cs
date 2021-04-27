using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillarBreak : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _startSprite = null;
    [SerializeField] private SpriteRenderer _endSprite = null;

    [SerializeField] private GameObject _explodeyFX = null;

    private bool _isBroken = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!_isBroken && collision.gameObject.tag == "Player")
        {
            if (Player.Get().IsDashing())
            {
                BreakPillar();
            }
        }
    }

    private void BreakPillar()
    {
        PizzaHealth.Get().AddPizza();

        _isBroken = true;

        GameplayAudioInit.crumble.Play();

        SpawnExplodey();

        _startSprite.enabled = false;
        _endSprite.enabled = true;
    }

    private void SpawnExplodey()
    {
        var position = this.transform.position;
        var explodey = Instantiate(_explodeyFX);
        explodey.transform.position = position;
    }
}
