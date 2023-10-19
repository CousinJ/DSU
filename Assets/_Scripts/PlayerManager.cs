using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace JD {


public class PlayerManager : MonoBehaviour
{

    //custom types
InputHandler inputHandler;
CameraHandler cameraHandler;
PlayerLocomotion playerLocomotion;
Animator anim;



public bool isInteracting;
// other types 
[Header("Player Flags")]
  public bool isSprinting;



    // START
    void Start()
    {
        cameraHandler = CameraHandler.singleton;
        playerLocomotion = GetComponent<PlayerLocomotion>();
        inputHandler = GetComponent<InputHandler>();
        anim = GetComponentInChildren<Animator>();
    }

    // UPDATE
    void Update()
    {
        isInteracting = anim.GetBool("isInteracting");
    
        float delta = Time.deltaTime;
        inputHandler.TickInput(delta);

        isSprinting = inputHandler.b_Input;

        playerLocomotion.HandleMovement(delta);
        playerLocomotion.HandleRollingAndSprinting(delta);
    }
//FIXED UPDATE 
    private void FixedUpdate() {

    float delta = Time.fixedDeltaTime;

    if(cameraHandler != null) {
        cameraHandler.FollowTarget(delta);
        cameraHandler.HandleCameraRotation(delta, inputHandler.mouseX, inputHandler.mouseY);
    }
}


//LATE UPDATE
private void LateUpdate() {
    inputHandler.rollFlag = false;
    inputHandler.sprintFlag = false;
    isSprinting = inputHandler.b_Input;
}



}




}

