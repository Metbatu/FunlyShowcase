using System.Collections;
using System.Collections.Generic;
using GameFolder.Ball;
using UnityEngine;

namespace GameFolder.Scripts
{
    public class BallSpawner : MonoBehaviour
    {
        public GameObject ballPrefab;
        public List<Transform> spawners;
        public int minBalls = 3;
        public int maxBalls = 3;

        private List<GameObject> activeBalls = new List<GameObject>();
        private List<Transform> availableSpawners = new List<Transform>();

        [SerializeField] SettingsMenu settingsMenu;
        [SerializeField] private GameObject countDown;

        void Start()
        {
            StartCoroutine(StartDelayed(4.4f));
        }
        
        private IEnumerator StartDelayed(float delayTime)
        {
            yield return new WaitForSeconds(delayTime);
            countDown.SetActive(false);
            availableSpawners.AddRange(spawners); // Populate available spawners list with all spawners
            SpawnBalls(minBalls); // Spawn initial balls
        }

        void SpawnBalls(int count)
        {
            int ballsToSpawn = Mathf.Clamp(count, minBalls - activeBalls.Count, maxBalls - activeBalls.Count);

            for (int i = 0; i < ballsToSpawn; i++)
            {

                // Choose a random available spawner
                int randomIndex = Random.Range(0, availableSpawners.Count);
                Transform selectedSpawner = availableSpawners[randomIndex];

                // Instantiate the ball as a child of the selected spawner
                GameObject newBall = Instantiate(ballPrefab, selectedSpawner.position, Quaternion.identity, selectedSpawner);
                
                newBall.GetComponent<BallMovement>().Init(settingsMenu);

                activeBalls.Add(newBall); // Add the ball to the list of active balls
                availableSpawners.Remove(selectedSpawner); // Remove the used spawner from the available spawners list
            }
        }

        public void DestroyBall(GameObject ball)
        {
            if (activeBalls.Contains(ball))
            {
                Transform spawner = ball.transform.parent; // Get the parent spawner of the destroyed ball
                availableSpawners.Add(spawner); // Add the parent spawner back to the available spawners list
                activeBalls.Remove(ball);
                Destroy(ball);

                int ballsToSpawn = Mathf.Clamp(1, minBalls - activeBalls.Count, maxBalls - activeBalls.Count);
                SpawnBalls(ballsToSpawn); // Spawn a new ball to replace the destroyed one
            }
        }
    }
}