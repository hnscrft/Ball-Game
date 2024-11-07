using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngularMovementTest : MonoBehaviour
{
    [SerializeField] float speed = 5f;

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
        if (isGrounded)
        {
            rb2.AddTorque(speed * Time.deltaTime * Input.GetAxisRaw("Horizontal") * -1);
        }
        else
        {
            rb2.AddForce(new Vector2((speed * Time.deltaTime * Input.GetAxisRaw("Horizontal")) / 2, 0));
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {

       isGrounded = true;

    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
    }
}
