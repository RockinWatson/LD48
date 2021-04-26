using UnityEngine;
using Pathfinding;

public class SetTarget : MonoBehaviour
{
    private AIDestinationSetter _destinationSetter;
    // Start is called before the first frame update
    void Start()
    {
        _destinationSetter = gameObject.GetComponent<AIDestinationSetter>();
        _destinationSetter.target = GameObject.FindGameObjectWithTag("Player").transform;
    }
}
