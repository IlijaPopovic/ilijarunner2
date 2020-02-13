using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement1 : MonoBehaviour
{
    [SerializeField] private List<GameObject> PlayerPositions = new List<GameObject>();
    private cameraMovement1 camera1;
    private float moveSpeed = 100.0f;
    private float gravity = GRAVITY;
    private const float GRAVITY = -100f;
    private float jumpHeight = 45.0f;
    private float jumpSpeed = 300.0f;
    private float sideMoveSpeed = 400.0f;
    private bool moveLeft = false;
    private bool moveRight = false;
    private bool moveUp = false;
    private bool checkForGravity = true;
    private Vector3 moveTo = new Vector3(0,0,0);
    private float inAirSec = 0.05f;
    private float speedUp = 0.1f;
    void Start()
    {
        camera1 = GameObject.FindObjectOfType<cameraMovement1>();
    }

    void Update()
    {
        if(camera1.isCameraAnimationFinished)
        {
            Movement();
        }
    }

    private void Movement()
    {
        setMoveDestination();
        checkGravity();
        mainMovement();
    }

    private void mainMovement()
    {
        if (moveLeft)
        {
            if(transform.position.x > moveTo.x)
            {
                transform.position += new Vector3(-sideMoveSpeed, gravity, moveSpeed) * Time.deltaTime;
            }
            else if(transform.position.x < moveTo.x)
            {
                moveLeft = false;
                transform.position = new Vector3 (moveTo.x, transform.position.y, transform.position.z);
            }
        }
        else if (moveRight)
        {
            if(transform.position.x < moveTo.x)
            {
                transform.position += new Vector3(sideMoveSpeed, gravity, moveSpeed) * Time.deltaTime;
            }
            else if(transform.position.x > moveTo.x)
            {
                moveRight = false;
                transform.position = new Vector3 (moveTo.x, transform.position.y, transform.position.z);
            }
        }
        else
        {
            transform.position += new Vector3(0, gravity, moveSpeed) * Time.deltaTime;
        }

        if(moveUp)
        {
            if(transform.position.y < moveTo.y)
            {
                transform.position += new Vector3(0, jumpSpeed, moveSpeed) * Time.deltaTime;
            }
            else if(transform.position.y > moveTo.y)
            {
                moveUp = false;// Izbaci ovo ako ubacis corutine
                //StartCoroutine(waitForFall(inAirSec));
                transform.position += new Vector3(0, gravity, moveSpeed) * Time.deltaTime;
            }
        }
        else
        {
            transform.position += new Vector3(0, gravity, moveSpeed) * Time.deltaTime;
        }

        moveSpeed += speedUp;
    }
    private void checkGravity()
    {
        if(checkForGravity)
        {
            if(isPlayerGrounded())
            {
                gravity = 0;
            }
            else
            {
                gravity = GRAVITY;
            }
        }    
    }
    private void setMoveDestination()
    {
        if (Input.GetKeyUp("left") && transform.position.x == PlayerPositions[1].transform.position.x)
        {
            moveLeft = true;
            moveTo = new Vector3 (PlayerPositions[0].transform.position.x, moveTo.y, transform.position.z);
        }
        else if (Input.GetKeyUp("right") && transform.position.x == PlayerPositions[1].transform.position.x)
        {
            moveRight = true;
            moveTo = new Vector3 (PlayerPositions[2].transform.position.x, moveTo.y, transform.position.z);
        }
        else if (Input.GetKeyUp("left") && transform.position.x == PlayerPositions[2].transform.position.x)
        {
            moveLeft = true;
            moveTo = new Vector3 (PlayerPositions[1].transform.position.x, moveTo.y, transform.position.z);
        }
        else if (Input.GetKeyUp("right") && transform.position.x == PlayerPositions[0].transform.position.x)
        {
            moveRight = true;
            moveTo = new Vector3 (PlayerPositions[1].transform.position.x, moveTo.y, transform.position.z);
        }
        else if (Input.GetKeyUp("space") && isPlayerGrounded())
        {
            moveUp = true;
            moveTo = new Vector3 (moveTo.x, jumpHeight, moveTo.z);
        }
    }
    private bool isPlayerGrounded()
    {
        if(transform.position.y <= 0)
        {
            transform.position = new Vector3(transform.position.x, 0, transform.position.z); 
            return true;
        }
        else
        {
            return false;
        }
    }

    private IEnumerator waitForFall(float fallTime){
        gravity = 0;
        checkForGravity = false;
        yield return new WaitForSeconds(fallTime);
        moveUp = false;
        checkForGravity = true;
    }
}
