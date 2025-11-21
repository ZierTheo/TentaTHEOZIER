using System;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.InputSystem;

            /////////////// INFORMATION ///////////////
// This script automatically adds a Rigidbody2D and a CapsuleCollider2D component in the inspector.
// The following components are needed: Player Input

[RequireComponent(typeof(Rigidbody2D), typeof(CapsuleCollider2D))]
public class TopDownMovement : MonoBehaviour
   
{
    public float maxSpeed = 7;

    
    
    public bool controlEnabled { get; set; } = true;    // You can edit this variable from Unity Events
    
    private Vector2 moveInput;
    private Rigidbody2D rb;

    public Animator animator;
    
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        
        // Set gravity scale to 0 so player won't "fall" 
        rb.gravityScale = 0;
    }

    private void Update()
    {
        
    }
    
    private void FixedUpdate()
    {
        // Set velocity based on direction of input and maxSpeed
        if (controlEnabled)
        {
            rb.linearVelocity = moveInput.normalized * maxSpeed;
        }
            
        else
        {
            rb.linearVelocity = Vector2.zero;
        }

        

        // Write code for walking animation here. (Suggestion: send your current velocity into the Animator for both the x- and y-axis.)
        animator.SetFloat("Blend", moveInput.x);
        

        //flippar playern med unitys transform scale x
        if (moveInput.x > 0.01f) 
            transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
        else if (moveInput.x < -0.01f)
            transform.localScale = new Vector3(-0.3f, 0.3f, 0.3f);
    }
    
    // Handle Move-input
    // This method can be triggered through the UnityEvent in PlayerInput
    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>().normalized;
        
    }
}
