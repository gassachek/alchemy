using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPosition : MonoBehaviour
{
    private Vector2 _pointScreen;
    private Vector2 _offset;
    private void OnMouseDown() {
        _pointScreen = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        _offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
    }

    private void OnMouseDrag() {
        Vector2 curScreenPoint = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint);
        transform.position = curPosition;
    }
}
