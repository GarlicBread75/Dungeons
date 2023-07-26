using UnityEngine;
using System.Collections;

public class Melee : MonoBehaviour
{
    [SerializeField] int damage;
    [SerializeField] float sizeX;
    [SerializeField] float sizeY;
    [SerializeField] float attackSpeed;
    bool atkPressed;
    float atkSpd;
    [SerializeField] LayerMask targetLayer;
    SpriteRenderer sr;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.color = new Color(1, 1, 1, 0.25f);
        transform.localScale = new Vector3(sizeX, sizeY, transform.localScale.z);
        transform.localPosition = new Vector3(0, transform.localScale.y/2 + 0.5f, 0);
    }

    void Update()
    {
        if (atkSpd > 0)
        {
            return;
        }

        if (Input.GetMouseButton(0))
        {
            atkPressed = true;
        }
    }

    void FixedUpdate()
    {
        if (atkSpd > 0)
        {
            atkSpd -= Time.fixedDeltaTime;
            sr.color = new Color(1, 1, 1, 0.25f);
        }
        else
        {
            sr.color = new Color(0, 1, 0, 0.25f);
        }

        if (atkPressed)
        {
            atkPressed = false;
            StartCoroutine(Attack());
        }
    }

    IEnumerator Attack()
    {
        Collider2D[] thing = Physics2D.OverlapBoxAll(transform.position, new Vector2(sizeX, sizeY), 0, targetLayer);
        for (int i = 0; i < thing.Length; i++)
        {
            thing[i].GetComponent<EnemyHealthArmour>().TakeDmg(damage);
        }
        atkSpd = attackSpeed;
        yield return null;
    }
}