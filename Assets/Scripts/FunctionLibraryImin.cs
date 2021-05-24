using UnityEngine;

using static UnityEngine.Mathf;// implicitly using a type 

public static class FunctionLibraryImin //ok,it is "static". so it let us
                                        // to use

{
    /* public static float Wave(float x, float z, float t) */ //ok,public + static, 
        // float means it can produce a result
        //put float into parameter list, so it will be just like for the
        //mathematical function.
       //return Mathf.Sin(Mathf.PI * (x + t));
        /* {return Sin(PI* (x + z + t));} */
        // now we are inside the method!
        // "return" to return a float value

    public static Vector3 Wave (float u, float v, float t)
    {
        Vector3 p;
        p.x = u;
        p.y = Sin(PI * (u + v + t));
        p.z = v;
        return p;
    }
    



    /* public delegate float Function(float x, float z, float t); */ //a method signature
                                                                     //without an implementation

    public delegate Vector3 Function(float u, float v, float t);

    public enum FunctionName {Wave, MultiWave, Ripple, Sphere, Torus }

    static Function[] functions = { Wave, MultiWave, Ripple, Sphere, Torus };

    public static Vector3 Sphere (float u, float v, float t)

    {

        //float r = Cos(0.5f * PI * v);
        //float r = 0.5f + 0.5f * Sin(PI * t);  //Scaling sphere.
        //float r = 0.9f + 0.1f * Sin(8f * PI * u); // vary it based on u,
        // and also based on v. And remember
        // its the UV Sphere.
        //float r = 0.9f + 0.1f * Sin(8f * PI * v); //Sphere with horizontal bands.
        float r = 0.9f + 0.1f + Sin(PI * (6f * u + 4f * v + t)); // Rotating twisted sphere.
        float s = r * Cos(0.5f * PI * v);
        Vector3 p;
        p.x = s * Sin(PI * u);
        p.y = r * Sin(0.5f * PI * v);
        p.z = s * Cos(PI * u);
        //p.x = Sin(PI * u);
        //p.x = r * Sin(PI * u);
        //p.y = 0f; a point cycle
        //p.y = v; // A Cylinder
        //p.y = Sin(PI * 0.5f * v); // A Sphere
        //p.z = Cos(PI * u);
        //p.z = r * Cos(PI * u);
        return p;
    }

    public static Vector3 Torus(float u, float v, float t)
    {

        //float r = 1f;
        //float s = r * Cos(0.5f * PI * v); // again a Sphere
        //float s = 0.5f + r * Cos(0.5f * PI * v); //going to dig a hole in Sphere
        //float r1 = 0.75f; // a torus
        //float r2 = 0.25f; // a torus
        //float s = 0.5f + r * Cos(PI * v);
        float r1 = 0.7f + 0.1f * Sin(PI * (6f * u + 0.5f * t));        // Twisting torus
        float r2 = 0.15f + 0.05f * Sin(PI * (8f * u + 4f * v + 2f * t)); // Twisting torus
        float s = r1 + r2 * Cos(PI * v);
        Vector3 p;
        p.x = s * Sin(PI * u);
        //p.y = r * Sin(0.5f * PI * v); //going to dig a hole in Sphere
        p.y = r2 * Sin(PI * v);
        p.z = s * Cos(PI * u);
        return p;
    }

    public static Function GetFunction (FunctionName name)
    {
        return functions[(int)name];
        //if (index == 0)
        //{
        //    return Wave;
        //}
        //else if (index == 1)
        //{
        //    return MultiWave;
        //}
        //else
        //{
        //    return Ripple;
        //}
    }

    /*public static float MultiWave (float x, float z, float t)//A Second Function
    {
        //return Sin(PI * (x + t));
        //float y = Sin(PI * (x + t));
        float y = Sin(PI * (x + 0.5f * t));
        //y += Sin(2f * PI * (x + t)) / 2f;
        //y += 0.5f * Sin(2f * PI * (x + t));
        //return y / 1.5f;
        /* y += 0.5f * Sin(2f * PI * (z + t)); //two waves in different dimensions
        return y * (2f / 3f); */

        /*y += Sin(PI * (x + z + 0.25f * t)); // Triple Wave
        return y * (1f / 2.5f);

    }*/

    public static Vector3 MultiWave (float u, float v, float t)
    {
        Vector3 p;
        p.x = u;
        p.y = Sin(PI * (u + 0.5f * t));
        p.y += 0.5f * Sin(2f * PI * (v + t));
        p.y += Sin(PI * (u + v + 0.25f * t));
        p.y *= 1f / 2.5f;
        p.z = v;
        return p;
    }


    /*public static float Ripple (float x, float z, float t)
    {
        //float d = Abs(x);

        float d = Sqrt(x * x + z * z);
        float y = Sin(PI * (4f * d - t));  //final result, Ripple on XZ plane.
        return y / (1f + 10f * d);

        //float y = Sin(4f * PI * d);
        /* return y; *

        
    }*/

    public static Vector3 Ripple(float u, float v, float t)
    {
        float d = Sqrt(u * u + v * v);
        Vector3 p;
        p.x = u;
        p.y = Sin(PI * (4f * d - t));
        p.y /= 1f + 10f * d;
        p.z = v;
        return p;
    }

}