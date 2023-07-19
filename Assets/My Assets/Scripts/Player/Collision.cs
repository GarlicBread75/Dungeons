using UnityEngine;
using UnityEngine.Events;

public class Collision : MonoBehaviour
{
    [SerializeField] UnityEvent thingy;
    [SerializeField] string targetTag;
    [SerializeField] bool trigger;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(targetTag) && !trigger)
        {
            thingy.Invoke();
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(targetTag) && trigger)
        {
            thingy.Invoke();
        }
    }
}
