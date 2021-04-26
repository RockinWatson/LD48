using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    [SerializeField] private float _heatTransferAmount = 20f;

    public void Kill()
    {
        Player.Get().AddHeat(_heatTransferAmount);

        Destroy(this.gameObject);
    }
}
