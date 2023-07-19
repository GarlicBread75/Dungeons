using UnityEngine;
using UnityEngine.Events;

public class Collectible : MonoBehaviour
{
    [SerializeField] UnityEvent[] thingy;
    [SerializeField] string targetTag;

    void OnTriggerEnter2D(Collider2D trigger)
    {
        if (trigger.gameObject.CompareTag(targetTag))
        {
            for (int i = 0; i < thingy.Length; i++)
            {
                thingy[i].Invoke();
            }
            Destroy(gameObject);
        }
    }
}
