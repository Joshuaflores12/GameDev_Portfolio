using UnityEngine;

public class InvisibleBlocks : MonoBehaviour
{
    [SerializeField] private SpriteRenderer invisibleBlock;
    [SerializeField] private float revealDelay = 1f; // Delay before showing the block

    private void Start()
    {
        if (invisibleBlock != null)
        {
            SetAlpha(0f);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && invisibleBlock != null)
        {
            StopAllCoroutines(); // Stop previous fade-outs if player re-enters
            StartCoroutine(RevealAfterDelay());
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && invisibleBlock != null)
        {
            StopAllCoroutines(); // Stop reveal coroutine if player leaves
            SetAlpha(0f); // Instantly hide on exit (can be changed to fade if desired)
        }
    }

    private System.Collections.IEnumerator RevealAfterDelay()
    {
        yield return new WaitForSeconds(revealDelay);
        SetAlpha(1f);
    }

    private void SetAlpha(float alpha)
    {
        Color color = invisibleBlock.color;
        color.a = alpha;
        invisibleBlock.color = color;
    }
}

