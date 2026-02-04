using UnityEngine;
using System.Collections;
public class VirusMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float minMoveTime;
    [SerializeField] private float maxMoveTime;
    [SerializeField] private int direction = 1;
    void Start()
    {
        StartCoroutine(SwitchDirectionRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * direction * speed * Time.deltaTime);
    }

    private IEnumerator SwitchDirectionRoutine() 
    {
        while (true) 
        {
            float waitTime = Random.Range(minMoveTime, maxMoveTime);
            yield return new WaitForSeconds(waitTime);
            direction *= -1;
        }
    }
}
