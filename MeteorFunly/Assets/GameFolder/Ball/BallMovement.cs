using UnityEngine;
using Random = UnityEngine.Random;
using System.Collections.Generic;

namespace GameFolder.Ball
{
    public class BallMovement : MonoBehaviour
    {
        public float speed => _settingsMenu.Speed;
        
        private Rigidbody2D _rigidbody2D;
        private AudioSource _audioSource;
        
        public AudioClip touchSound;
        
        private SettingsMenu _settingsMenu;
        
        private Dictionary<string, AudioClip> _tagToSoundMap = new Dictionary<string, AudioClip>();

        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _audioSource = GetComponent<AudioSource>();
            
             _tagToSoundMap["AreaObject"] = touchSound;
             _tagToSoundMap["METEOR"] = touchSound;
             _tagToSoundMap["Player"] = touchSound;
        }

        private void Start()
        {
            // Calculate the direction based on the spawn point's name
            Vector2 direction = Vector2.zero;

            string spawnPointName = transform.parent.name;
            switch (spawnPointName)
            {
                case "Spawn.Point-LB":
                    direction = RandomDirection(-60f, -30f);
                    break;
                case "Spawn.Point-LT":
                    direction = RandomDirection(240f, 270f);
                    break;
                case "Spawn.Point-RB":
                    direction = RandomDirection(30f, 60f);
                    break;
                case "Spawn.Point-RT":
                    direction = RandomDirection(120f, 150f); 
                    break;
            }

            // Move the ball in the calculated direction with speed
            _rigidbody2D.velocity = direction.normalized * speed;
        }

        public void Init(SettingsMenu settingsMenu)
        {
            _settingsMenu = settingsMenu;
        }
        
        private void Update()
        {
            var dir = _rigidbody2D.velocity;
            _rigidbody2D.velocity =  dir.normalized * speed;
        }

        // Generate a random direction within the specified angle range
        Vector2 RandomDirection(float minAngle, float maxAngle)
        {
            float randomAngle = Random.Range(minAngle, maxAngle);
            return Quaternion.Euler(0f, 0f, randomAngle) * Vector2.up;
        }
        private void OnCollisionEnter2D(Collision2D collision)
        {
            // Check if the collision tag exists in the dictionary
            if (_tagToSoundMap.ContainsKey(collision.gameObject.tag))
            {
                _audioSource.PlayOneShot(_tagToSoundMap[collision.gameObject.tag]);
            }
        }
    }
}