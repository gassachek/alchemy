using UnityEngine;
using UnityEngine.EventSystems;

public class SetItemPosition: MonoBehaviour
{
    public void SetPosition(Transform item)
    {
        item.position = Input.mousePosition;
    }
}
