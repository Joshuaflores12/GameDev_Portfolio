using UnityEngine;

public class DoorController : MonoBehaviour
{
    public float moveDistance = 3f;         
    public float moveSpeed = 2f;           
    private Vector3 targetPosition;
    private bool shouldMove = false;

    private void Start()
    {
        targetPosition = transform.position - new Vector3(0, moveDistance, 0);
    }

    private void Update()
    {
        if (shouldMove)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
        }
    }

    public void ActivateDoor()
    {
        shouldMove = true;
    }
}

