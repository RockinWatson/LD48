using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomBounce : MonoBehaviour
{
    [SerializeField] private float _bounceForce = 1000f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            ApplyBounceForceToPlayer();
            GameplayAudioInit.bounce.Play();
        }
    }

    private void ApplyBounceForceToPlayer()
    {
        var player = Player.Get();
        player.GetCharacterController2D().ResetDoubleJump();
        var playerRigidBody = player.GetRigidBody2d();
        playerRigidBody.velocity = Vector2.zero;
        playerRigidBody.AddForce(new Vector2(0f, _bounceForce));
    }
}
