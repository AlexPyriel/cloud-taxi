using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sphere : MonoBehaviour, Test
{
    public void Log()
    {
        Debug.Log("Test");
    }

    // Start is called before the first frame update
    void Start()
    {
        Log();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

interface Test
{
    void Log();
}
