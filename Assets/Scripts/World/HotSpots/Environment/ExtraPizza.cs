using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraPizza : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _startSprite = null;
    [SerializeField] private SpriteRenderer _deliveredSprite = null;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            AddPizza();
        }
    }

    private void AddPizza()
    {
        PizzaHealth.Get().AddPizza();

        //@TODO: SFX:
        //GameplayAudioInit.playerDamage1.Play();
        GameplayAudioInit.chomp1.Play();

        _startSprite.enabled = false;
        _deliveredSprite.enabled = true;

        //Destroy(this.gameObject);
    }
}
