using System.Collections;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] float speed;
    Rigidbody2D rb;
    float moveX, moveY;

    [Space]

    [Header("Dashing")]
    [SerializeField] float dashSpeed;
    [SerializeField] float dashDuration;
    [SerializeField] float dashCooldown;
    [SerializeField] float cdAcceleration;
    TrailRenderer tr;
    [Space]
    [Space]
    [Space]
    [SerializeField] float dashCd;
    [SerializeField] bool dashPressed;
    [SerializeField] bool dashing;
    [SerializeField] bool canDash;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        tr = GetComponent<TrailRenderer>();
        dashCd = dashCooldown;
    }

    void Update()
    {
        moveX = Input.GetAxisRaw("Horizontal");
        moveY = Input.GetAxisRaw("Vertical");

        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash && !dashing)
        {
            dashPressed = true;
        }
    }

    void FixedUpdate()
    {
        if (!dashing)
        {
            Vector2 move = new Vector2(moveX, moveY).normalized;
            rb.velocity = move * speed;
        }

        if (dashCd > 0)
        {
            dashCd -= Time.fixedDeltaTime * cdAcceleration;
        }
        else
        {
            canDash = true;
        }

        if (dashPressed)
        {
            dashPressed = false;
            StartCoroutine(Dashing());
        }
    }

    IEnumerator Dashing()
    {
        dashing = true;
        canDash = false;
        rb.velocity = new Vector2(moveX * dashSpeed, moveY * dashSpeed);
        tr.emitting = true;
        yield return new WaitForSeconds(dashDuration);
        tr.emitting = false;
        dashing = false;
        dashCd = dashCooldown;
    }
}
