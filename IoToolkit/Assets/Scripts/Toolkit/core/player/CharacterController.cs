using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public struct FrameInput {
    public float X;
    public bool JumpDown;
    public bool JumpUp;
}

public class CharacterController : MonoBehaviour
{

    public float speed = 5f;
    public float jumpForce = 5f;
    public float jumpTime = 0.2f;

    private FrameInput Input;
    private Rigidbody2D rigidbody;
    private float lastJumpPressed = 0f;
    private float lastGrounded = 0f;
    private bool isGrounded = false;
    private bool doubleJump = false;
    private float lastJump = 0f;
    private float momentumBufferTime = 0.2f;

    private Vector2 momentum = Vector3.zero;
    

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        checkInput();
        checkGrounded();

        // Gather momentum
        if(Input.JumpUp && !isGrounded) {
            momentum = rigidbody.velocity;
        }

        if(isGrounded) {
            lastGrounded = Time.time;
            doubleJump = true;
            momentum = Vector2.zero;
        }

        move();
        
    }

    void checkInput(){
        
        Input = new FrameInput {
            JumpDown = UnityEngine.Input.GetButtonDown("Jump"),
            JumpUp = UnityEngine.Input.GetButtonUp("Jump"),
            X = UnityEngine.Input.GetAxisRaw("Horizontal")
        };

        if (Input.JumpDown) {
           lastJumpPressed = Time.time;
        }

    } 

    void checkGrounded(){
        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, .75f, LayerMask.GetMask("Ground"));
    }

    bool CanJump(){

        if(doubleJump && Input.JumpDown && Time.time - lastJumpPressed < jumpTime){
            doubleJump = false;
            return true;
        }

        return isGrounded && Input.JumpDown && Time.time - lastJumpPressed < jumpTime;
    }

    bool IsMomentumActive(){
        return momentum != Vector2.zero && Time.time - lastGrounded < momentumBufferTime;
    }

    void move(){

        // Calculate the movement
        float xMovement = 0;

        if (Input.X != 0) {
            xMovement = Input.X * speed;
        } else {
            xMovement = 0;
        }

        // if momentum is active, add it to the movement
        if(IsMomentumActive()){
            xMovement = momentum.x * .75f;
        }       

        // move the player
        rigidbody.velocity = new Vector2(xMovement, rigidbody.velocity.y);

        // jump the player    
        if (CanJump()) {
            rigidbody.velocity = new Vector2(rigidbody.velocity.x, jumpForce);
        }

    }




}
