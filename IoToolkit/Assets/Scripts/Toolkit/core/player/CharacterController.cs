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

    private Rigidbody2D rigidbody;

    private FrameInput Input;
    
    private float lastJumpPressed = 0f;
    private float lastJump = 0f;

    private float lastGrounded = 0f;
    private bool isGrounded = false;
    
    private bool doubleJump = false;
    
    
    public float momentum = 0f;
    public bool hasMomentum = false;
    

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        interactIcon.SetActive(false);
        holder = transform.Find("Holder");
    }

    // Update is called once per frame
    void Update()
    {
        //do not rotate
        rigidbody.freezeRotation = true;

        // if holding something do not show interact icon
        if(holder.childCount > 0){
            interactIcon.SetActive(false);
        }


        checkInput();
        checkGrounded();

        if(isGrounded) {
            lastGrounded = Time.time;
            doubleJump = true;
            hasMomentum = false;
            momentum = 0f;
        }

        // TODO Fix momentum 
        /*
        if(hasJump()){
            hasMomentum = true;
            momentum = rigidbody.velocity.x * .5f;
        }
        */

        move();
        
    }

    bool hasJump(){
        return false;
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


        #region Interaction
        [Header("INTERACTION")] [SerializeField]
        private GameObject interactIcon;
        public Transform holder;
        private Vector2 boxSize = new Vector2(1.938797f, 3.20f);

        public void OpenInteactableIcon(){
            interactIcon.SetActive(true);
        }

        public void CloseInteactableIcon(){
            interactIcon.SetActive(false);
        }

        private void CheckInteraction(){

            RaycastHit2D[] hits = Physics2D.BoxCastAll(transform.position, new Vector2(10f, 10f), 0, Vector2.zero);
            if(hits.Length > 0) {
                foreach (RaycastHit2D hit in hits) {
                    if (hit.IsInteractable()) {

                        hit.Interact();
                        return;
                    }
                }
            }
        }
    
               
        public void Interact(InputAction.CallbackContext context) {
               
            if(context.performed) {
                CheckInteraction();
            } 
        }
        #endregion



}
