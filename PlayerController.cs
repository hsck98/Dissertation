using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float moveSpeed;
    public CharacterController controller;

    private Vector3 moveDirection;
    public float gravityScale;

    public Joystick joystick;
    
	// Use this for initialization
	void Start () {
        controller = GetComponent<CharacterController>();
    }
	
	// Update is called once per frame
	void Update () {
        //store the character's y direction
        float yStore = moveDirection.y;
        //calculate the direction of movement by adding the vertical and the horizontal displacement of the movement joystick
        moveDirection = (transform.forward * joystick.Vertical) + (transform.right * joystick.Horizontal);

        //normalize to prevent double speed when moving diagonally
        moveDirection = moveDirection.normalized * moveSpeed;
        moveDirection.y = yStore;

        //change our direction vector's y component to follow whichever direction the gravity of the game pulls it towards
        moveDirection.y = moveDirection.y + (Physics.gravity.y * gravityScale * Time.deltaTime);
        //move the character towards the direction vector calculated
        controller.Move(moveDirection * Time.deltaTime);
    }
}
