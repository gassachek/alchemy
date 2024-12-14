using UnityEngine;
using UnityEngine.EventSystems;

public class BoilerView : MonoBehaviour, IDropHandler
{
    BoilerPresenter boilerPresenter;
    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            eventData.pointerDrag.transform.SetParent(transform, true);
            
            RectTransform droppedObject = eventData.pointerDrag.GetComponent<RectTransform>();
            droppedObject.anchoredPosition = Vector2.zero;
            boilerPresenter = GetComponent<BoilerPresenter>();
    
            if (boilerPresenter != null)
            {
                string itemName = eventData.pointerDrag.name;
                boilerPresenter.Add(itemName);
            }
        }
    }

    public void Boiling()
    {
        boilerPresenter.Boiling();
    }
}