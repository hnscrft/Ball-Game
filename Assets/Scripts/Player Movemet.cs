using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovemet : MonoBehaviour
{
    [SerializeField] float moveForce = 5f;

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
    }
}
