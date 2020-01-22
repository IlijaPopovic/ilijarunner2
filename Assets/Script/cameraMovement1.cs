using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMovement1 : MonoBehaviour
{
    private Transform playerPosition;
    private Vector3 cameraMove;
    private Vector3 cameraDistanceFromPlayer;
    private Vector3 startAnimationCameraPosition;
    private Vector3 endAnimationCameraPosition;
    private Vector3 offsetAnimationCameraPosition;
    private float cameraTransition = 0.0f;
    private float startAnimationDuration = 3.0f;
    public bool isCameraAnimationFinished = false;
    public float playerHeight = 15.0f;

    void Start()
    {
        playerPosition = GameObject.FindGameObjectWithTag("Player").transform;

        cameraDistanceFromPlayer = transform.position - playerPosition.position;

        offsetAnimationCameraPosition = new Vector3(0, 300, Mathf.Abs(cameraDistanceFromPlayer.z));
        startAnimationCameraPosition = transform.position + offsetAnimationCameraPosition;
        endAnimationCameraPosition = transform.position;
    }
    void Update()
    {
        if(cameraTransition > 1.0f)
        {
            isCameraAnimationFinished = true;
            FolowPlayer();
        }
        else
        {
            DoStartCameraAnimation();
        }
    }


    private void FolowPlayer()
    {
        cameraMove = new Vector3(cameraDistanceFromPlayer.x, cameraDistanceFromPlayer.y + playerHeight, playerPosition.position.z + cameraDistanceFromPlayer.z);
        transform.position = cameraMove;
    }

    private void DoStartCameraAnimation()
    {
        transform.position = Vector3.Lerp(startAnimationCameraPosition, endAnimationCameraPosition, cameraTransition);
        cameraTransition += Time.deltaTime / startAnimationDuration;
        transform.LookAt(playerPosition);
    }
}
