using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{

    [SerializeField] KeyCode dashKey = KeyCode.LeftShift;

    private Rigidbody2D rb;
    private bool canDash = true;
    [SerializeField] float dashspeed = 5f;
    private float dashingTime = 0.2f;
    private float dashingCooldown = 1f;
    private bool isDashing;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private IEnumerator Dash2(Vector2 direction)
    {
        canDash = false;
        isDashing = true;
        rb.velocity = direction * dashspeed;
        yield return null;
        yield return new WaitForSeconds(dashingTime);
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (canDash && Input.GetKeyDown(dashKey))
        {
            Vector2 dir = new Vector2(0, 0);
            if (Input.GetKey(KeyCode.W))
            {
                dir.y = 1;
            }
            else if (Input.GetKey(KeyCode.S))
            {
                dir.y = -1;
            }

            if (Input.GetKey(KeyCode.A))
            {
                dir.x = -1;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                dir.x = 1;
            }

            StartCoroutine(Dash2(dir));

        }
    }
}
