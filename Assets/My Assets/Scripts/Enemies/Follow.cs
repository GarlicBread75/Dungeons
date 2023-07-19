using UnityEngine;

public class Follow : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float speed;

    void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position,target.position, speed * Time.fixedDeltaTime);
    }
}
