using UnityEngine;

public class RecycleBinPullTrigger : MonoBehaviour
{
    [SerializeField] private float pullForce; 
    [SerializeField] private Transform player;
    [SerializeField] private Rigidbody2D playerRb;
    [SerializeField] private bool isPulling = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            player = other.transform;
            playerRb = other.GetComponent<Rigidbody2D>();
            isPulling = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPulling = false;
            player = null;
            playerRb = null;
        }
    }

    private void FixedUpdate()
    {
        if (isPulling && playerRb != null)
        {
            Vector2 direction = (transform.position - player.position).normalized;
            playerRb.AddForce(direction * pullForce);
        }
    }
}
