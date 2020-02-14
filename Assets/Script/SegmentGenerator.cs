using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SegmentGenerator : MonoBehaviour
{
    private Transform playerPosition; 
    private float spawnLocationZ = 0.0f;
    private float segmentLenght = 500f;
    private int maxSegments = 5;
    [SerializeField] private List<GameObject> positions = new List<GameObject>();
    private List<GameObject> privremeniPositions;
    private List<GameObject> segmentsToDelete = new List<GameObject>();
    public GameObject Floor;
    public GameObject Obstacle;
    public GameObject Coin;
    public GameObject Segment;
    GameObject s;
    private bool startCreateAndDeleteSegments = false;
    
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
            createAndDeleteSegementEverySegmentPassed();
    }

    private void createAndDeleteSegementEverySegmentPassed()
    {
        if(playerPosition.transform.position.z > spawnLocationZ + segmentLenght - segmentLenght * maxSegments)
        {
            createSegment2();
            Destroy(segmentsToDelete[0]);
            segmentsToDelete.RemoveAt(0);
        }
    }

    private void createSegment2()
    {
        createParentSegment();
        createFloor();
        createCoin();
        createObsticles();
        segmentsToDelete.Add(s);
        spawnLocationZ += segmentLenght;
    }

    private void createParentSegment()
    {
        s = Instantiate(Segment) as GameObject;
        s.transform.SetParent(transform);
    }
    private void createFloor()
    {
        GameObject f = Instantiate(Floor) as GameObject;
        f.transform.SetParent(s.transform);
        f.transform.position = new Vector3(0, 0, spawnLocationZ);
    }

    private void createCoin()
    {
        privremeniPositions = new List<GameObject>(positions);
        int randomCoinPosition = Random.Range(0, privremeniPositions.Count);
        GameObject c = Instantiate(Coin) as GameObject;
        c.transform.SetParent(s.transform);
        c.transform.position = privremeniPositions[randomCoinPosition].transform.position + new Vector3(0, 0, spawnLocationZ + segmentLenght / 2 );
        privremeniPositions.RemoveAt(randomCoinPosition);
    }

    private void createObsticles()
    {
        int numberOfObsticles = Random.Range(1, 4);

        for (int i = 0; i < numberOfObsticles; i++)
        {
            int randomObstaclePosition = Random.Range(0, privremeniPositions.Count);
            GameObject o = Instantiate(Obstacle) as GameObject;
            o.transform.SetParent(s.transform);
            o.transform.position = privremeniPositions[randomObstaclePosition].transform.position + new Vector3(0, 0, spawnLocationZ + segmentLenght / 2 );
            privremeniPositions.RemoveAt(randomObstaclePosition);
        }
    }

    private int ReturnRandomFreePosition(int start, int end)
    {
        return 0;
    }

    private bool IsNumberInList(int number, List<int> list)
    {
        foreach (int x in list)
        {
            if (number == x)
            {
                return true;
            }
        }
        return false;
    }
}
