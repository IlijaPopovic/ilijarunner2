using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float maxLeft = -40f;
    public float maxRight = 40f;
    public float sideMoveSize = 40f;
    public float movementSpeed = 100f;
    public float moveTransition = 0f;
    public float jumpSize = 10f;
    public float Gravity = 50f;
    private Vector3 moveDirection = Vector3.zero;
    private CharacterController palyerController;
    private cameraMovement1 camera;
    void Start()
    {
        camera = GameObject.FindObjectOfType<cameraMovement1>();
        palyerController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(camera.isCameraAnimationFinished)
        {
            Movement();
        }
    }

    private void Movement()
    {
        if (Input.GetKeyUp("left") && transform.position.x > maxLeft)
        {
            moveDirection.x = -sideMoveSize;
        }
        else if (Input.GetKeyUp("right") && transform.position.x < maxRight)
        {
            moveDirection.x = sideMoveSize;
        }
        else
        {
            moveDirection.x = 0;
        }

        if (palyerController.isGrounded && Input.GetKeyUp("space"))
        {
            moveDirection.y = jumpSize;
        }
        else
        {
            moveDirection.y -= Gravity * Time.deltaTime;
        }
            
        moveDirection.z = movementSpeed;
        
        //tansform.position = Vector3.Lerp(transform.position, moveDirection, moveTransition);
        palyerController.Move(moveDirection);
        //moveTransition += Time.deltaTime / 3.0f;
    }
}
