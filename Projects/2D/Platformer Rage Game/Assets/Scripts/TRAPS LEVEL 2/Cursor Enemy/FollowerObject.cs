using UnityEngine;

public class FollowerObject : MonoBehaviour
{
    [SerializeField] private Transform player;    // Assign the player transform in Inspector
    [SerializeField] private float followSpeed = 3f;

    private void Update()
    {
        if (player != null)
        {
            // Move towards the player's position
            transform.position = Vector2.MoveTowards(transform.position, player.position, followSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(gameObject); // Disappear on touch
        }
    }
}
