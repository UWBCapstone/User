﻿﻿﻿﻿﻿﻿﻿﻿using System;
using System.Collections.Generic;
using System.Linq;

public class GenericVector
{
    //list of floats that's creating the GenericVector
    public List<float> Points = new List<float>();

    //CONSTRUCTORS
    //Creates a new GenericVector with the points given
    public GenericVector(List<float> points)
    {
        Points = points;
    }

    //Creates a new GeneriVector with the points as long as the size given
    public GenericVector(int size)
    {
        for (var i = 0; i < size; i++)
        {
            Points.Add(0);
        }
    }

    public GenericVector()
    {
    }

    //GenericVector METHODS
    public void Add(float point)
    {
        Points.Add(point);
    }

    public int Size
    {
        get { return Points.Count; }
    }

    public void Sum(GenericVector vectorToSum)
    {
        if (Size != vectorToSum.Size)
            throw new Exception("GenericVector size of vectorToSum not equal to instance vector size");

        for (var i = 0; i < Points.Count; i++)
        {
            Points[i] = Points[i] + vectorToSum.Points[i];
        }
    }

    //Returns the length of the Vector
    public double VectorLength()
    {
        return (float) Math.Sqrt(Points.Sum(item => Math.Pow(item, 2)));
    }

    //Override ToString-Method to show the content of the GenericVector
    public override string ToString()
    {
        return string.Join("\n", Points.Select(x => x.ToString()).ToArray());
    }

    public bool IsBiggerAs(GenericVector v)
    {
        return Points.Where((p, i) => p > v.Points[i]).Count() > Points.Count;
    }

    public float BiggestPoint()
    {
        return Points.Max();
    }

    //STATIC GENERICVECTOR METHODS
    public static float DotProduct(GenericVector vectorA, GenericVector vectorB)
    {
        if (vectorA.Size != vectorB.Size)
            throw new Exception("GenericVector a size of dotProduct not equal to GenericVector b size");
        var aTimesBpoints = vectorA.Points.Select((t, i) => t * vectorB.Points[i]).ToList();

        return aTimesBpoints.Sum();
    }

    public static float GetAngle(GenericVector a, GenericVector b)
    {
        var x = DotProduct(a, b) / (a.VectorLength() * b.VectorLength());
        if (x > 1 || x < -1)
            return 0;
        return (float) Math.Acos(x);
    }

    public static double Distance(GenericVector a, GenericVector b)
    {
        var aMinusBpoints = a.Points.Select((t, i) => t - b.Points[i]).ToList();

        return aMinusBpoints.Sum(item => Math.Pow(item, 2));
    }
}
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                   