using UnityEngine;
using System.Collections;

public class FolderPlatform : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    [SerializeField] private float moveDistance = 5f; // The fixed distance it should travel before turning around

    private bool playerOnPlatform = false;
    private int direction = 1;
    private Coroutine moveRoutine;
    private Vector3 startPos;
    private Vector3 currentTarget;

    private void Start()
    {
        startPos = transform.position;
        currentTarget = startPos + Vector3.right * moveDistance;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            playerOnPlatform = true;

            if (moveRoutine == null)
                moveRoutine = StartCoroutine(MoveToDistanceAndBack());
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            playerOnPlatform = false;

            if (moveRoutine != null)
            {
                StopCoroutine(moveRoutine);
                moveRoutine = null;
            }
        }
    }

    private IEnumerator MoveToDistanceAndBack()
    {
        while (playerOnPlatform)
        {
            Vector3 start = transform.position;
            Vector3 end = start + Vector3.right * direction * moveDistance;
            float traveled = 0f;

            while (traveled < moveDistance && playerOnPlatform)
            {
                float step = speed * Time.deltaTime;
                transform.Translate(Vector2.right * direction * step);
                traveled += step;
                yield return null;
            }

            direction *= -1;
        }
    }
}

