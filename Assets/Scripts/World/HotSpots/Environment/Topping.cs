using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Topping : MonoBehaviour
{
    [SerializeField] private float _toppingAmount = 5f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            AddToppings();
        }
    }

    private void AddToppings()
    {
        Player.Get().AddToppings(_toppingAmount);

        //@TODO: Toppings SFX:
        //GameplayAudioInit.playerDamage1.Play();

        Destroy(this.gameObject);
    }
}
