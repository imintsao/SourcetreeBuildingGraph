 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphImin : MonoBehaviour
{

    [SerializeField]
    Transform pointPrefab = default;

    [SerializeField, Range(10, 100)]
    int resolution = 10;

    //[SerializeField, Range(0, 2)]

    [SerializeField]

    FunctionLibraryImin.FunctionName function;

    Transform[] points; // add points field, and turn field into an array

    void Awake()
    {
        float step = 2f / resolution;
        //int i = 0;
        //while(i < 10)
        //    {
        //    i = i + 1;
        //Vector3 position;
        //var scale = Vector3.one / 5f;
        var scale = Vector3.one * step;
        //var position = Vector3.zero;
        points = new Transform [resolution * resolution];
        for (int i = 0; i < points.Length; i++) {
            //if (x == resolution)
            //{
            //    x = 0;
            //    z += 1;
            //}
            Transform point = Instantiate(pointPrefab);
            //point.localPosition = Vector3.right * i;
            //point.localPosition = Vector3.right * i / 5f;
            //point.localPosition = Vector3.right * ((i + 0.5f) / 5f - 1f);
            //point.localScale = Vector3.one / 5f;
            //position.x = (i + 0.5f) / 5f - 1f;
            //position.x = (x + 0.5f) * step - 1f;
            //position.z = (z + 0.5f) * step - 1f;
                //position.y = position.x; //(becomes like a stair)
            //position.y = position.x * position.x; //(becomes like a curve)
            //position.y = position.x * position.x * position.x; //why using Y?
            //point.localPosition = position;
            point.localScale = scale;
            point.SetParent(transform, false);
            points[i] = point;
        }

        //Transform point = Instantitae(pointPrefab);

        //point = Instantiate(pointPrefab);
        //point.localPosition = Vector3.right * 2f;

    }

    /*private void Update()
    {
        FunctionLibraryImin.Function f = FunctionLibraryImin.GetFunction(function);
        float time = Time.time;
        for (int i = 0; i < points.Length; i++)
        {
            Transform point = points[i];
            Vector3 position = point.localPosition;
            //position.y = position.x * position.x * position.x;
            //position.y = Mathf.Sin(Mathf.PI * (position.x + time));
            //position.y = FunctionLibraryImin.Wave(position.x, time);
            //it's now possible to invoke this method inside "Graph.Update"

            //if (function == 0)
            //{
            //    position.y = FunctionLibraryImin.Wave(position.x, time);
            //}
            //else if (function == 1)
            //{
            //    position.y = FunctionLibraryImin.MultiWave(position.x, time);
            //}
            //else
            //{
            //    position.y = FunctionLibraryImin.Ripple(position.x, time);
            //}
            position.y = f(position.x, position.z, time);
            point.localPosition = position;
        }
    }*/

    private void Update()
    {
        FunctionLibraryImin.Function f = FunctionLibraryImin.GetFunction(function);
        float time = Time.time;
        float step = 2f / resolution;
        float v = 0.5f * step - 1f;
        
        for (int i = 0, x = 0, z = 0; i< points.Length; i++, x++)
        {
            if (x == resolution)
            {
                x = 0;
                z += 1;
                v = (z + 0.5f) * step - 1f;


            }
            float u = (x + 0.5f) * step - 1f;
            //float v = (z + 0.5f) * step - 1f;
            
            points[i].localPosition = f(u, v, time);
        }
    }
}


