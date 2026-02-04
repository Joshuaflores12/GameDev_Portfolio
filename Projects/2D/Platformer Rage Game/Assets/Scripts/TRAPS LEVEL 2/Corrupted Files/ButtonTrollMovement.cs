using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonTrollMovement : MonoBehaviour, IPointerEnterHandler
{
    [SerializeField] private int moveCount;
    [SerializeField] private RectTransform buttonRectTransform;

    private void Awake()
    {
        buttonRectTransform = GetComponent<RectTransform>();
    }

    public void OnPointerEnter(PointerEventData eventData) 
    {
        if (moveCount  <= 3) 
        {
            float randomX = Random.Range(-100f, 100f);
            float randomY = Random.Range(-100f, 100f);
            buttonRectTransform.anchoredPosition += new Vector2(randomX, randomY);
            moveCount++;
        }
        
    }
}
