using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap;
using Leap.Unity;

public class CupMoving : MonoBehaviour {

    /// <summary>
    /// Reference to the rigid body of the object that this script is attached to.
    /// </summary>
    public Rigidbody2D rb2d;

    

    /// <summary>
    /// Reference to the controller class.
    /// </summary>
    Controller controller;

    private float HandPalmYaw;    
    //private float HandWristRot;
    private float HandPalmRoll;

    private float HandWristRot;




    /// <summary>
    /// Assigns the RigidBody and Edge collider components to their referenced values.
    /// </summary>
    void Start ()
    {

        controller = new Controller();                              //Makes new controller.
        rb2d = GetComponent<Rigidbody2D>();        
	}

    /// <summary>
    /// Update method that controls the cup, moving it left and right via leap motion hand yaw.
    /// </summary>
    void Update ()
    {

        Frame frame = controller.Frame();
        List<Hand> hands = frame.Hands;

        // Asks if there is a hand in the frame, if yes then it assign it as a new hand.
        if (frame.Hands.Count > 0)
        {
            Hand firstHand = hands[0];
        }

        // Assigns the Yaw value of the hand to be the new hand's yaw value.
        HandPalmYaw = hands[0].Direction.Yaw;        
        //HandPalmRoll = hands[0].PalmNormal.Roll;
        //HandWristRot = hands[0].WristPosition.Pitch;

        //HandWristRot = hands[0].WristPosition.Pitch;



        Debug.Log("Yaw: " + HandPalmYaw);
        //Debug.Log("Roll: " + HandPalmRoll);
        //Debug.Log("Rot: " + HandWristRot);


        if (HandPalmYaw > -0.5f && HandPalmYaw < 0f)
        {            
            rb2d.velocity = Vector2.zero;
            rb2d.AddForce(new Vector2(-200f, 0f));
            //rb2d.transform.Translate(new Vector2(-0.2f, 0));
            //rb2d.MovePosition(transform.position = new Vector2(-0.2f, 0));
        }
        else if (HandPalmYaw < 0.5f && HandPalmYaw > 0)
        {
            rb2d.velocity = Vector2.zero;
            rb2d.AddForce(new Vector2(200f, 0f));
            //rb2d.transform.Translate(new Vector2(0.2f, 0));
            //rb2d.MovePosition(transform.position = new Vector2(0.2f, 0));
            
        }

    }


    void OnCollisionEnter2D(Collision2D other)
    {
        rb2d.velocity = Vector2.zero;
    }
    
}
