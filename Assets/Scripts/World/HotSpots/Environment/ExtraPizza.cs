using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraPizza : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _startSprite = null;
    [SerializeField] private SpriteRenderer _deliveredSprite = null;

    private bool isDelivered = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isDelivered && collision.gameObject.tag == "Player")
        {
            AddPizza();
        }
    }

    private void AddPizza()
    {
        PizzaHealth.Get().AddPizza();

        isDelivered = true;

        //@TODO: SFX:

        GameplayAudioInit.chomp1.Play();

        _startSprite.enabled = false;
        _deliveredSprite.enabled = true;

        //Destroy(this.gameObject);
    }
}
