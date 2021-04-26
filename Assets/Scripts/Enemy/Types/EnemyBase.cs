using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    public void Kill()
    {
        Player.Get().AddHeat(5f);

        Destroy(this.gameObject);
    }
}
