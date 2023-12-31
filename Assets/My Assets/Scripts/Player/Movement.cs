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
    TrailRenderer tr;
    float dashCd;
    bool dashPressed;
    bool dashing;
    bool canDash;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        tr = GetComponent<TrailRenderer>();
    }

    void Update()
    {
        moveX = Input.GetAxisRaw("Horizontal");
        moveY = Input.GetAxisRaw("Vertical");

        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash && !dashing && (moveX !=0 || moveY != 0))
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
            dashCd -= Time.fixedDeltaTime;
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
        dashCd = dashCooldown;
        canDash = false;
        dashing = true;
        if (moveX != 0 && moveY != 0)
        {
            rb.velocity = new Vector2(moveX * (0.8f * dashSpeed), moveY * (0.8f * dashSpeed));
        }
        else
        {
            rb.velocity = new Vector2(moveX * dashSpeed, moveY * dashSpeed);
        }
        tr.emitting = true;
        yield return new WaitForSeconds(dashDuration);
        dashing = false;
        tr.emitting = false;
    }
}
