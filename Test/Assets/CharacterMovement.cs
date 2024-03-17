using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private Rigidbody rb;
    private float movementSpeed, coefficient;
    private LayerMask WhatIsGround;

    void Start()
    {
        rb.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Movement();
    }

    void Update()
    {
        SurfaceAllignment();
    }

    private void Movement() {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertikal");
        Vector3 movement = new Vector3(x, 0, y);
        Vector3 counterMovement = new Vector3(-rb.velocity.x, 0, -rb.velocity.z);

        rb.AddForce(movement * movementSpeed);
        rb.AddForce(counterMovement * coefficient);
    }

    private void SurfaceAllignment()
    {
        Ray ray = new Ray(transform.position, -transform.up);
        RaycastHit info = new RaycastHit();
        if (Physics.Raycast(ray, out info, WhatIsGround))
        {
            transform.rotation = Quaternion.FromToRotation(Vector3.up, info.normal);
        }
    }
}
