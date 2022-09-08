using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class MagnetField : MonoBehaviour
{
    public float

            fieldWidth,
            fieldHeight;

    public bool powerOn;

    public Direction direction;

    public float strength;

    public float acceleration;

    public float maxSpeed;

    public BoxCollider2D collider;

    private List<Collider2D> onRangeObjects;

    public static readonly float DEFAULT_GRAVITY = 0f;
    public static readonly float NO_GRAVITY = 0f;

    // Start is called before the first frame update
    void Start()
    {
        this.onRangeObjects = new List<Collider2D>();

        if (this.collider == null)
        {
            this.collider = GetComponent<BoxCollider2D>();
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (powerOn)
        {
            this
                .onRangeObjects
                .ForEach(attractedCollider =>
                {
                    Rigidbody2D rgbd = attractedCollider.attachedRigidbody;

                    // TODO: must we disable gravity on horizontal attractors ????
                    rgbd.gravityScale = MagnetField.NO_GRAVITY;

                    Vector3 attractedObjectPosition = attractedCollider.gameObject.transform.position;
                    Vector3 magnetFieldPosition = collider.gameObject.transform.position;
                    float distance = Geometrics.PercentualDistance(Math.Abs(attractedObjectPosition[1]), Math.Abs(magnetFieldPosition[1]));

/*
                    Debug.Log("--------------------------------------");
                    Debug.Log("Magnet Y: " + attractedObjectPosition[1]);
                    Debug.Log("Attractor Y: " + magnetFieldPosition[1]);
                    Debug.Log("Distance: " + distance);
                    Debug.Log("--------------------------------------");
*/

                    Vector2 velocity = Physics.fakeGravitySpeed(rgbd, this.direction, this.acceleration, this.strength, this.maxSpeed, Time.fixedDeltaTime, distance);
                    rgbd.velocity = velocity;
                });
        } else  {
            this.onRangeObjects.ForEach(attractedCollider => { 
                Rigidbody2D rgbd = attractedCollider.attachedRigidbody;
                rgbd.gravityScale = MagnetField.DEFAULT_GRAVITY; 
                rgbd.velocity = new Vector2(0,0);
            });
        }
    }

    void resize()
    {
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Magnet" && !this.onRangeObjects.Contains(collider))
        {
            this.onRangeObjects.Add(collider);
            Debug.Log("Magnet detected and added to list");

        }
    }
    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.tag == "Magnet" && this.onRangeObjects.Contains(collider))
        {
            this.onRangeObjects.Remove(collider);
            Debug.Log("Magnet exit detected and removed from list");

            Rigidbody2D rgbd = collider.attachedRigidbody;
            rgbd.gravityScale = MagnetField.DEFAULT_GRAVITY; 
            rgbd.velocity = new Vector2(0,0);
        }
    }
}
