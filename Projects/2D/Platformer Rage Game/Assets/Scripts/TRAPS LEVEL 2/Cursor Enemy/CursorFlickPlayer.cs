using UnityEngine;

public class CursorFlickPlayer : MonoBehaviour
{
    [SerializeField] private float knockBackForceX; 
    [SerializeField] private float knockBackForceY;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            Rigidbody2D playerRb = collision.collider.GetComponent<Rigidbody2D>();

            if (playerRb != null)
            {
                float xDirection = (playerRb.transform.position.x < transform.position.x) ? -1f : 1f;

                Vector2 knockbackDir = new Vector2(xDirection * knockBackForceX, knockBackForceY);

                playerRb.linearVelocity = Vector2.zero;
                playerRb.AddForce(knockbackDir, ForceMode2D.Impulse);
            }
        }
    }
}
