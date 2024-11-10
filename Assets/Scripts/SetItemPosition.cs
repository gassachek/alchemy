using UnityEngine;
using UnityEngine.EventSystems;

public class SetItemPosition: MonoBehaviour, IDragHandler
{
    private RectTransform _rectTransform;
    private Vector3 _startingPosition;

    private void Start()
    {
        _rectTransform = GetComponent<RectTransform> ();
    }

    public void OnDrag(PointerEventData eventData)
    {
        _rectTransform.anchoredPosition += eventData.delta;
    }

}
