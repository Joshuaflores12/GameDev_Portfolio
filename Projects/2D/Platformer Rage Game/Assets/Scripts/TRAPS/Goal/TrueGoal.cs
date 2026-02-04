using UnityEngine;
using UnityEngine.SceneManagement;
public class TrueGoal : MonoBehaviour
{
    [SerializeField] private SpriteRenderer Goal;
    [SerializeField] private string Level2;
    private void Start()
    {
        if (Goal != null)
        {
            SetAlpha(0f);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && Goal != null)
        {
            SetAlpha(1f);
            SceneManager.LoadScene(Level2);
        }

    }

    private void SetAlpha(float alpha)
    {
        Color color = Goal.color;
        color.a = alpha;
        Goal.color = color;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player") && Goal != null)
        {
            SceneManager.LoadScene(Level2);
        }

    }
}
