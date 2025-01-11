using System;
using UnityEngine;

namespace MVP
{
    public class View<TPresenter>: MonoBehaviour where TPresenter : Presenter, new()
    {
        protected TPresenter Presenter{get;private set;} 
        private void Start()
        {
            Presenter = new TPresenter();
            
        }
        
    }
}