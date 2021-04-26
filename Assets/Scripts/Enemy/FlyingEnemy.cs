using Pathfinding;
using UnityEngine;

public class FlyingEnemy : MonoBehaviour
{
    private Rigidbody2D _rigidBody2D = null;

    // AI
    private AIPath _aiPath;
    private AIDestinationSetter _destinationSetter;

    private void Awake()
    {
        _rigidBody2D = this.GetComponent<Rigidbody2D>();

        _aiPath = this.GetComponent<AIPath>();
        _destinationSetter = this.GetComponent<AIDestinationSetter>();
    }

    private void Start()
    {
        SetPlayerTarget();
    }

    private void Update()
    {
        UpdateFacing();
    }

    private void SetPlayerTarget()
    {
        _destinationSetter.target = Player.Get().transform;
    }

    private void UpdateFacing()
    {
        if (_aiPath.desiredVelocity.x >= 0.01f)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else if (_aiPath.desiredVelocity.x <= -0.01f)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }
}
