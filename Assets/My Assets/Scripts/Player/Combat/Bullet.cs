using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage;
    [SerializeField] LayerMask targetLayer;
    [SerializeField] bool areaDamage;
    [SerializeField] float areaRadius;

    private void Awake()
    {
        Destroy(gameObject, 10);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (areaDamage)
        {
            Collider2D[] thing = Physics2D.OverlapCircleAll(transform.position, areaRadius, targetLayer);
            for (int i = 0; i < thing.Length; i++)
            {
                if (collision.gameObject.CompareTag("Enemy"))
                {
                    thing[i].GetComponent<EnemyHealthArmour>().TakeDmg(damage);
                }
            }
        }
        else
        {
            if (collision.gameObject.CompareTag("Enemy"))
            {
                collision.GetComponent<EnemyHealthArmour>().TakeDmg(damage);
            }
        }
        Destroy(gameObject);
    }
}
