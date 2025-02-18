using UnityEngine;
using UnityEngine.EventSystems;

public class SetItemPosition : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private RectTransform _rectTransform;
    private CanvasGroup _canvasGroup;
    private Transform _originalParent;
    private Canvas _parentCanvas;
    private Vector2 _originalSize;

    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
        _canvasGroup = GetComponent<CanvasGroup>();
        _parentCanvas = GetComponentInParent<Canvas>();
        _originalSize = _rectTransform.sizeDelta;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        _originalParent = transform.parent;
        
        transform.SetParent(_parentCanvas.transform, true);
        
        _canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 localPoint;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            _parentCanvas.transform as RectTransform, 
            eventData.position, 
            _parentCanvas.worldCamera, 
            out localPoint
        );
        _rectTransform.position = _parentCanvas.transform.TransformPoint(localPoint);
        
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        _canvasGroup.blocksRaycasts = true;
        
        _rectTransform.sizeDelta = _originalSize;

        if (transform.parent == _parentCanvas.transform)
        {
           
            transform.SetParent(_originalParent, true);
            _rectTransform.anchoredPosition = Vector2.zero;

            _rectTransform.sizeDelta = _originalSize;
        }
    }
}
