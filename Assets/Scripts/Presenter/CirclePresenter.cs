using System;
using MVP;

public class CirclePresenter : Presenter
{
    public double[] GetCoordinatesCircle()
    {
        double len = 0.2;
        double degree = (90.0 / 2) * (Math.PI / 180.0);
        double[] coords = new double[2];

        coords[0] = len * Math.Cos(degree);
        coords[1] = len * Math.Sin(degree);

        return coords;
    }
}
