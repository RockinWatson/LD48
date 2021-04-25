using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBackgroundBounds : MonoBehaviour
{
    private void FixedUpdate()
    {
        var position = this.transform.position;
        var playerPosition = Player.Get().transform.position;
        this.transform.position = new Vector3(position.x, playerPosition.y, position.z);
    }
}
