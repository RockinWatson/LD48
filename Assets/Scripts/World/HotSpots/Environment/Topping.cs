using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Topping : MonoBehaviour
{
    [SerializeField] private float _toppingAmount = 5f;

    [SerializeField] private GameObject _explodeyFX = null;

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

        SpawnExplodey();

        Destroy(this.gameObject);
    }

    private void SpawnExplodey()
    {
        var position = this.transform.position;
        var explodey = Instantiate(_explodeyFX);
        explodey.transform.position = position;
    }
}
