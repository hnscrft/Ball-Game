using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{

    [SerializeField] KeyCode jumpKey = KeyCode.Space;

    private Rigidbody2D rb;
    private bool canJump = true;
    [SerializeField] float jumpPower = 10f;
    private float jumpCooldown = 1f;
    private float jumpTime = 0.5f;
    private bool isJumping;
    bool isGrounded = false;

    private IEnumerator Dash2()
    {
        canJump = false;
        isJumping = true;
        rb.velocity = new Vector2(rb.velocity.x, jumpPower);
        yield return null;
        yield return new WaitForSeconds(jumpTime);
        isJumping = false;
        if (isGrounded)
        {
            canJump = true;
        }
        else
        {
            while (isGrounded == false)
            {
                yield return null;
                if (isGrounded == true)
                {
                    canJump = true;
                }


            }
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        isGrounded = true;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (canJump && Input.GetKeyDown(jumpKey))
        {

            StartCoroutine(Dash2());

        }
    }
}