using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumper : MonoBehaviour
{

    private readonly bool DEFAULT_ENABLED = true;
    public bool enabled;
    public float jumpForce = 10f;
    public float jumpTime = 0.5f;

    


    // Start is called before the first frame update
    void Start()
    {
        if(this.enabled == null) {
            this.enabled = DEFAULT_ENABLED;
        }

        if(gameObject.GetComponent<BoxCollider2D>() == null) {
            gameObject.AddComponent<BoxCollider2D>();
        }

      
    }

    // Update is called once per frameb
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D other) 
    {
       // if (other.gameObject.name == "Player" && this.enabled)
        if(true)
        {
            Jump(other);
            Debug.Log("Jump");
        }
    }

    void Jump(Collision2D other)
    {
       
        Rigidbody2D rb = other.gameObject.GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.up * jumpForce;
        //StartCoroutine(DisableJump(rb));
        
    }


}
