using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    [SerializeField] private float _heatTransferAmount = 20f;

    private bool _isDead = false;
    public bool IsDead() { return _isDead; }


    public void Kill()
    {
        Player.Get().AddHeat(_heatTransferAmount);

        _isDead = true;

        Destroy(this.gameObject);
    }
}
