using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MovePlayer : MonoBehaviour
{
    // Start is called before the first frame update

    //Stuff for checking the ground 
    public float Playerheight;
    public float groundDrag;
    public bool grounded;
    public float gravityModifier;
    public LayerMask Ground;
    public LayerMask Ceiling;
    bool ceiling;

    

    //For my inputs
    float horziontalInput;
    float verticalInput;

    Rigidbody rb;
    public Transform orientation;
    private float moveSpeed;
    public float runningSpeed;
    bool running;
    public float walkingSpeed;
    public bool wallRuning = false;
    public float wallRunSpeed;

    Vector3 moveDirection;
    public float JumpForce;
    public float airMultiplier;
    public float crounchSpeed;
    float startYScale;
    float crounchYScale;
    bool crounching;
    public float maxAngle;
    RaycastHit slopeHit;
    void Start()
    {

        rb = GetComponent<Rigidbody>();
        startYScale = transform.localScale.y;
        crounchYScale = startYScale / 2;
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        // Fires raycast down to find if we are grounded
        grounded = Physics.Raycast(transform.position, Vector3.down, Playerheight * 0.5f + 0.2f);
        ceiling = Physics.Raycast(transform.position, Vector3.up, Playerheight * 0.5f + 0.2f, Ceiling);
        horziontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
       
        if (!crounching)
            SpeedLimit();

        if (Input.GetKeyDown(KeyCode.Space) && grounded)
            Jump();
        //grounded = false;

        if (Input.GetKey(KeyCode.LeftShift))
            running = true;
        else
        {
            running = false;
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            transform.localScale = new Vector3(transform.localScale.x, crounchYScale, transform.localScale.z);
            moveSpeed = crounchSpeed;
            crounching = true;
        }

        else if (Input.GetKeyUp(KeyCode.C))
        {
            if (!ceiling)
                transform.localScale = new Vector3(transform.localScale.x, startYScale, transform.localScale.z);
            rb.AddForce(Vector3.down * 5f, ForceMode.Impulse);
            moveSpeed = walkingSpeed;
            crounching = false;
        }

        

        if (grounded)
        {

            rb.drag = groundDrag;
        }
        else
        {
            rb.drag = 0;
        }
    }
    void FixedUpdate()
    {
        Movement();
        MoveState();
    }

    void Movement()
    {
        moveDirection = orientation.forward * verticalInput + orientation.right * horziontalInput;
        if (grounded)
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);


        else if (!grounded)
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f * airMultiplier, ForceMode.Force);

    }
    void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        rb.AddForce(transform.up * JumpForce, ForceMode.Impulse);
    }
    void SpeedLimit()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        if (flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }

    void MoveState()
    {
        if (running)
            moveSpeed = runningSpeed;

        else if (wallRuning)
        {
            moveSpeed = wallRunSpeed;
        }



        else
            moveSpeed = walkingSpeed;

    }

 }






