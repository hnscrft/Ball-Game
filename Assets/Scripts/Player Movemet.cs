using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovemet : MonoBehaviour
{
    [SerializeField] float moveForce = 5f;
    [SerializeField] float jumpForce = 10f;
    bool isGrounded = false;
    private Rigidbody2D rb2;

    // Start is called before the first frame update
    void Start()
    {
        rb2 = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb2.AddForce(new Vector2(moveForce * Time.deltaTime * Input.GetAxisRaw("Horizontal"), 0));

        if (Input.GetButtonDown("Jump"))
        {
            if (isGrounded == true)
            {
                Jump();
            }
        } 
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        isGrounded = true;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
    }

    void Jump()
    {

        rb2.AddForce(new Vector2(0, jumpForce));

    }
}
