using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SegmentGenerator : MonoBehaviour
{
    private Transform playerPosition; 
    public GameObject[] segments;
    private float spawnLocationZ = 0.0f;
    private float segmentLenght = 500f;
    private int maxSegments = 5;
    public Vector3[] coinPositions;
    public GameObject Floor;
    public GameObject Obstacle;
    public GameObject Coin;
    void Start()
    {
        playerPosition = GameObject.FindGameObjectWithTag("Player").transform;

        for (int i = 0; i < maxSegments; i++)
        {
            createSegment2();
        }
    }

    void Update()
    {
        createSegementEverySegmentPassed();
    }

    private void createSegementEverySegmentPassed()
    {
        if(playerPosition.transform.position.z > spawnLocationZ - segmentLenght * maxSegments)
        {
            createSegment2();
        }
    }
    private void createSegment()// Ovo je sa prethodno definisanim pref
    {
        int randomSegment = Random.Range(0, segments.Length);
        GameObject go = Instantiate(segments[randomSegment]) as GameObject;
        go.transform.SetParent(transform);
        go.transform.position = new Vector3(0, 0, spawnLocationZ);
        spawnLocationZ += segmentLenght;
    }

    private void createSegment2()// Ovo je random
    {
        createFloor();
        createCoin();
        createObsticle();
        spawnLocationZ += segmentLenght;
    }
    
    private void createFloor()
    {
        GameObject f = Instantiate(Floor) as GameObject;
        f.transform.SetParent(transform);
        f.transform.position = new Vector3(0, 0, spawnLocationZ);
    }

    private void createCoin()
    {
        int randomCoinPosition = Random.Range(0, coinPositions.Length);
        GameObject c = Instantiate(Coin) as GameObject;
        c.transform.SetParent(transform);
        c.transform.position = coinPositions[randomCoinPosition] + new Vector3(0, 0, spawnLocationZ + segmentLenght);
        //c.transform.position.z = spawnLocationZ + segmentLenght / 2; ffs ovo ne radi proveri zasto
    }

    private void createObsticle()
    {
        int numberOfObsticles = Random.Range(1, 4);
        for (int i = 0; i < numberOfObsticles; i++)
        {
            int randomObstaclePosition = Random.Range(0, 3);//Kako da izbacim mogucnost dobijanja istog random broja kao i coin
            GameObject o = Instantiate(Obstacle) as GameObject;
            o.transform.SetParent(transform);
            o.transform.position = coinPositions[randomObstaclePosition] + new Vector3(0, 0, spawnLocationZ + segmentLenght);
        }
    }
}
