using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement1 : MonoBehaviour
{
    [SerializeField] private List<GameObject> PlayerPositions = new List<GameObject>();
    //[SerializeField] private Vector3 playerPosition;
    private cameraMovement1 camera1;
    private float moveSpeed = 0f;
    private float gravity = GRAVITY;
    private const float GRAVITY = -100f;
    private float jumpHeight = 45.0f;
    private float sideMoveSpeed = 3.0f;
    private float transition = 0.0f;
    void Start()
    {
        //playerPosition = transform.position;
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
        if (Input.GetKeyUp("left") && transform.position.x == PlayerPositions[1].transform.position.x)
        {
            transform.position = new Vector3 (PlayerPositions[0].transform.position.x, transform.position.y, transform.position.z);
        }
        else if (Input.GetKeyUp("right") && transform.position.x == PlayerPositions[1].transform.position.x)
        {
            transform.position = new Vector3 (PlayerPositions[2].transform.position.x, transform.position.y, transform.position.z);
        }
        else if (Input.GetKeyUp("left") && transform.position.x == PlayerPositions[2].transform.position.x)
        {
            transform.position = new Vector3 (PlayerPositions[1].transform.position.x, transform.position.y, transform.position.z);
        }
        else if (Input.GetKeyUp("right") && transform.position.x == PlayerPositions[0].transform.position.x)
        {
            transform.position = new Vector3 (PlayerPositions[1].transform.position.x, transform.position.y, transform.position.z);
        }
        else if (Input.GetKeyUp("space") && isPlayerGrounded())
        {
            transform.position = new Vector3 (transform.position.x, jumpHeight, transform.position.z);
        }
        else
        {
            transition += Time.deltaTime / sideMoveSpeed;
            Debug.Log(transition);
        }

        if(isPlayerGrounded())
        {
            gravity = 0;
        }
        else
        {
            gravity = GRAVITY;
        }

        transform.position += new Vector3(0, gravity, moveSpeed) * Time.deltaTime;
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
}
