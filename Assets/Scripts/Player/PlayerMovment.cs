using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    private Animator animator;



    [SerializeField]
    private float speed = 0;

    [Header("Smooth time for fliping the player")]
    [SerializeField]
    private float turnSmoothTime = 0.1f;
    private float turnSmoothVelocity;

    [Header ("Smooth time for walking")]
    [SerializeField]
    private float velocitySmoothTime = 0.1f;
    private Vector2 velocitySmoothVelocity;

    [Header ("Parameters")]
    [SerializeField]
    private float damptimeMovement = 0.2f;

    [SerializeField]
    private float jumpForce = 2f;

    [SerializeField] private Transform cam;
    [SerializeField] private Transform gfxRotation;

    [SerializeField] private GroundCheck groundCheck;
    [SerializeField] private GroundCheck wallgrabCheck;



    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    public void Move(Vector3 movement)
    {
        Vector3 direction = movement.normalized;

        animator.SetFloat("MoveX", direction.x, damptimeMovement, Time.fixedDeltaTime);
        animator.SetFloat("MoveY", direction.z, damptimeMovement, Time.fixedDeltaTime);

        //There is an issue with the damptime where the float value is never 0 this IF is to force it to 0 when there is no movement
        if ((Mathf.Abs(animator.GetFloat("MoveX")) < 0.01f) && (Mathf.Abs(animator.GetFloat("MoveY")) < 0.01f))
        {
            animator.SetFloat("MoveX", 0);
            animator.SetFloat("MoveY", 0);
        }

        if(direction.magnitude > 0)
        {
            Vector2 targetVelocity = new Vector2(direction.x * speed, rigidBody.velocity.y);

            rigidBody.velocity = Vector2.SmoothDamp(rigidBody.velocity, targetVelocity, ref velocitySmoothVelocity, velocitySmoothTime);
        }
    }

    public void Jump()
    {
        Vector2 jumpVector = new Vector2(0, jumpForce);
        rigidBody.AddForce(jumpVector);
    }

    public void Jump(float multiplayer)
    {
        Vector2 jumpVector = new Vector2(0, jumpForce + multiplayer);
        rigidBody.AddForce(jumpVector);
    }

    public bool IsGrounded()
    {
        return groundCheck.check;
    }

    public bool WallGrabCheck()
    {
        return wallgrabCheck.check;
    }
}
