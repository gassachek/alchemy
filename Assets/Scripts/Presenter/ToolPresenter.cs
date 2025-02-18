using UnityEngine;
using UnityEngine.UI;

public class ToolPresenter : MonoBehaviour
{
    private bool _isApplyMode;
    private Tool _selectedTool;

    public void ToggleApplyMode(Tool tool)
    {
        if(_isApplyMode && _selectedTool == tool)
        {
            _isApplyMode = false;
            _selectedTool = Tool.None;
            Debug.Log("inactive");
        }
        else
        {
            _isApplyMode = true;
            _selectedTool = tool;
            Debug.Log($"active {_selectedTool}");
        }
    }

    public void SelectItem(string ItemName)
    {
        GameManager.Get<IngredientsProcessor>().Process(ItemName, _selectedTool);
        //добавить проверку

        Debug.Log($"{_selectedTool} применён к {ItemName}");

        _isApplyMode = false;
        _selectedTool = Tool.None;
    }

    public void GraterButton()
    {
        ToggleApplyMode(Tool.Grater);
    }

    public void MortarButton()
    {
        ToggleApplyMode(Tool.Mortar);
    }
}