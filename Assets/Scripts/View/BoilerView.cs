using MVP;
using UnityEngine;
using UnityEngine.EventSystems;

public class BoilerView : View<BoilerPresenter>, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            eventData.pointerDrag.transform.SetParent(transform, true);
            
            RectTransform droppedObject = eventData.pointerDrag.GetComponent<RectTransform>();
            droppedObject.anchoredPosition = Vector2.zero;
        
            string itemName = eventData.pointerDrag.name;
            Presenter.Add(itemName);
            
        }
    }

    public void Boiling()
    {
        Presenter.Boiling();
    }
}