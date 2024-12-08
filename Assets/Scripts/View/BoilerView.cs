using UnityEngine;
using UnityEngine.EventSystems;

public class ViewBoiler : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            eventData.pointerDrag.transform.SetParent(transform, true);
            
            RectTransform droppedObject = eventData.pointerDrag.GetComponent<RectTransform>();
            droppedObject.anchoredPosition = Vector2.zero;
        }
    }
}