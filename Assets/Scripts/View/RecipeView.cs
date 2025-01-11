using MVP;
using UnityEngine;
using UnityEngine.EventSystems;

public class RecipeView : View<RecipePresenter>
{
    [SerializeField] private GameObject _map;
    
    public void ActivateMap()
    {
        Presenter.ActivateMap(_map);
    }
}