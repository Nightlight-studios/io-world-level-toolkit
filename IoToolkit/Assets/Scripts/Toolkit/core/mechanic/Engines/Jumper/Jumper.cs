using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumper : MonoBehaviour
{

    private readonly bool DEFAULT_ENABLED = true;
    public bool enabled;
    public float jumpForce = 10f;
    public float jumpTime = 0.5f;
    public float rotation = 0;


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
      UpdateRotation();  
    }

    void UpdateRotation(){
        this.rotation = gameObject.transform.localRotation.eulerAngles.z;
    }

    void OnCollisionEnter2D(Collision2D other) 
    {
       // if (other.gameObject.name == "Player" && this.enabled)
        if(true)
        {
            Jump(other);
        }
    }

    void Jump(Collision2D other)
    {
       
        Rigidbody2D rb = other.gameObject.GetComponent<Rigidbody2D>();
        float y = 0;
        float x = 0;

        // X Axis check
        if(Geometrics.IsUp(this.rotation)) {
            y = Geometrics.CalculateYAxis(this.rotation);
        } else if(Geometrics.IsDown(this.rotation)) {
            y = Geometrics.CalculateYAxis(this.rotation);
        }

        Debug.Log("ROTATION: " + rotation);
        Debug.Log("Y: " + y);
        Debug.Log("X: " + x);

        // Y Axis check
        if(Geometrics.IsRight(this.rotation)) {
            x = Geometrics.CalculateXAxis(this.rotation);
        } else if(Geometrics.IsLeft(this.rotation)) {
            x = Geometrics.CalculateXAxis(this.rotation);
        }

        // Set item velocity
        Vector2 velocity = new Vector2(x,y) * jumpForce;
        rb.velocity = velocity;

        // Debug.Log(velocity);

    }


}
