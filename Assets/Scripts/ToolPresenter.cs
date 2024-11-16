using UnityEngine;
using UnityEngine.UI;

public class ToolPresenter : MonoBehaviour
{
    private bool _isApplyMode = false;
    private Tool? _selectedTool = null;

    public void ToggleApplyMode(Tool tool)
    {
        if(_isApplyMode && _selectedTool == tool)
        {
            _isApplyMode = false;
            _selectedTool = null;
            Debug.Log("active");
        }
        else
        {
            _isApplyMode = true;
            _selectedTool = tool;
            Debug.Log($"inactive {_selectedTool}");
        }
    }

    public void SelectItem(string ItemName)
    {
        IngredientsProcessor processor = new IngredientsProcessor(GameManager.Instance.inventory, GameManager.Instance.ingredientManufactoreDB);
        processor.Process(ItemName, _selectedTool.Value);

        Debug.Log($"{_selectedTool.Value} применён к {ItemName}");

        _isApplyMode = false;
        _selectedTool = null;
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