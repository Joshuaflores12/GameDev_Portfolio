using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private float FollowSpeed;
    [SerializeField] private Transform target;
    [SerializeField] private float yOffset;

    // Update is called once per frame
    void Update()
    {
        Vector3 newPos = new Vector3(target.position.x, target.position.y + yOffset, -10f);
        transform.position = Vector3.Slerp(transform.position, newPos, FollowSpeed * Time.deltaTime);
    }
}
