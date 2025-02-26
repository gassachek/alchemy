using MVP;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class BoilerView : View<BoilerPresenter>, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            eventData.pointerDrag.transform.SetParent(transform, true);

            RectTransform droppedObject = eventData.pointerDrag.GetComponent<RectTransform>();
            droppedObject.anchoredPosition = Vector2.zero;
            
            TMP_Text itemNameText = eventData.pointerDrag.GetComponentInChildren<TMP_Text>();
            
            if (itemNameText == null)
            {
                Debug.Log("ItemName не найден, предмет не добавлен.");
                return;
            }

            string itemName = itemNameText.text;
            Debug.Log($"Добавляется предмет: {itemName}");

            Presenter.Add(itemName);
        }
    }


    public void Boiling()
    {
        Presenter.Boiling();
    }
}