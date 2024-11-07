using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoostLeft : MonoBehaviour
{
    private float boost = 20f;

    //private void OnCollisionEnter2D(Collision2D collision)
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.left * boost, ForceMode2D.Impulse);
        }
    }
}