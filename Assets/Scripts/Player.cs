using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Vector3 movementVector;
    private Animator animator;
    private float speed;
    private RigidBody body;

    // Start is called before the first frame update
    void Start()
    {
        animator = transform.GetChild(0).GetComponent<Animator>();
        body = GetComponent<RigidBody>();
        speed = 1.5f;
    }

    void CalcualteMovement()
    {
        movementVector = new Vector3(Input.getAxis("Horizontal"), body.velocity.y, Input.GetAxis("Vertical"));
    }
    // start at calculateMovement method

    // Update is called once per frame
    void Update()
    {
        
    }
}
