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
    public float momentum = 0f;
    public bool hasMomentum = false;
    

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

        if(isGrounded) {
            lastGrounded = Time.time;
            doubleJump = true;
            hasMomentum = false;
            momentum = 0;
        }

        if(hasJump()){
            hasMomentum = true;
            momentum = rigidbody.velocity.x * .5;
        }

        move();
        
    }

    bool hasJump(){

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

        // Short jump
        if (Input.JumpUp && Time.time - lastJumpPressed < jumpTime) {
            rigidbody.velocity = new Vector2(rigidbody.velocity.x, rigidbody.velocity.y * .5f);
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

    void move(){

        // Calculate the movement
        float xMovement = 0;

        if (Input.X != 0) {
            xMovement = Input.X * speed;
        } else {
            xMovement = 0;
        }    

        // move the player
        rigidbody.velocity = new Vector2(xMovement, rigidbody.velocity.y);

        // jump the player    
        if (CanJump()) {
            rigidbody.velocity = new Vector2(rigidbody.velocity.x, jumpForce);
        }

        // if the player has momentum, add it to the velocity
        if(hasMomentum) {
            rigidbody.velocity = new Vector2(rigidbody.velocity.x + momentum, rigidbody.velocity.y);
        }

    }




}
