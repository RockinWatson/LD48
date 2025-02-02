using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    [SerializeField] private float _heatTransferAmount = 20f;

    public GameObject explosion;

    public Animator _animator;

    private bool _isDead = false;
    public bool IsDead() { return _isDead; }

    public void Kill()
    {
        Player.Get().AddHeat(_heatTransferAmount);

        _isDead = true;

        var assploosion = Instantiate(explosion);
        assploosion.transform.position = transform.position;

        Destroy(this.gameObject);
        Destroy(assploosion, assploosion.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);
    }
}
