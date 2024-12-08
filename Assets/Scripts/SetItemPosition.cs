using UnityEngine;
using UnityEngine.EventSystems;

public class SetItemPosition : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private GameManager gameManager;
    private RectTransform _rectTransform;
    private CanvasGroup _canvasGroup;
    private Transform _originalParent;
    private Canvas _parentCanvas;

    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
        _canvasGroup = GetComponent<CanvasGroup>();
        gameManager = FindFirstObjectByType<GameManager>();
        _parentCanvas = GetComponentInParent<Canvas>();
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
        if (gameManager != null)
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
        else
        {
            Debug.LogError("GameManager is not initialized!");
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        _canvasGroup.blocksRaycasts = true;
        if (transform.parent == _parentCanvas.transform)
        {
            transform.SetParent(_originalParent, true);
            _rectTransform.position = Vector2.zero;
        }
    }
}
