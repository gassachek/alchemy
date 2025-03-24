using MVP;
using UnityEngine;
using System;

public class CircleView : View<CirclePresenter>
{
    void Start()
    {
        CirclePresenter presenter = new CirclePresenter();
        
        double[] coordinates = presenter.GetCoordinatesCircle();

        GameObject circle = new GameObject("Circle");

        GameObject parentCircle = GameObject.Find("Circle");
        if (parentCircle != null)
        {
            circle.transform.SetParent(parentCircle.transform, false);
        }

        circle.transform.localPosition = new Vector3(
            Convert.ToSingle(coordinates[0]),
            Convert.ToSingle(coordinates[1]),
            0
        );
    }
}
