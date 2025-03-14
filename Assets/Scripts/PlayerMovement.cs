using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float speed = 1f;
    public float MaxY = 0f;
    Rigidbody2D rb;
    Vector3 movement;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float horizontalMov = Input.GetAxis("Horizontal");
        float verticalMov = Input.GetAxis("Vertical");

        movement = new Vector3(horizontalMov, verticalMov);


        if (transform.position.y >= MaxY) {
            transform.position = new Vector3 (transform.position.x, MaxY, transform.position.z);
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = movement * speed;
    }
}
