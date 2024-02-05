using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bypass : MonoBehaviour
{
    public GameObject ballPrefab; // destroyer for non-players

    private List<GameObject> spawnedBalls = new List<GameObject>(); // List to keep track of spawned balls

    private void Start()
    {
        SpawnBalls(5);
        Destroy(this); 
    }

    void SpawnBalls(int count)
    {
        for (int i = 0; i < count; i++)
        {
            // Instantiate the ball at the position of this spawn point
            GameObject newBall = Instantiate(ballPrefab, transform.position, Quaternion.identity);
            spawnedBalls.Add(newBall); // Add the ball to the list of spawned balls
        }
    }
}