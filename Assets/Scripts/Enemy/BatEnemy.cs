using UnityEngine;

namespace Assets.Scripts.Enemy
{
    public class BatEnemy : MonoBehaviour
    {
        public float Speed;
        public float StoppingDistance;

        private Transform _target;

        private void Start()
        {
            _target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        }

        private void Update()
        {
            if (Vector2.Distance(transform.position, _target.position) > StoppingDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, _target.position, Speed * Time.deltaTime);
            }
        }
    }
}
