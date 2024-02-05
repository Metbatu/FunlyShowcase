using UnityEngine;

namespace GameFolder.Scripts
{
    public class BallDestroyer : MonoBehaviour
    {
        private BallSpawner ballSpawner;

        private void Start()
        {
            ballSpawner = FindObjectOfType<BallSpawner>();
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Boundary"))
            {
                Destroy(this.gameObject);
                ballSpawner.DestroyBall(this.gameObject);
            }
        }
    }
}