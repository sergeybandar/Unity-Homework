using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Homework2 : MonoBehaviour
{
  


    void Start()
    {
        int intValue = Random.Range(0, 10);
        float floatValue = Random.Range(0.0f, 10.0f);
        bool boolValue = Random.Equals(intValue, floatValue);

        Debug.Log($"int:{intValue}, float:{floatValue}, bool:{boolValue}");


    }

    void Update()
    {
        
    }
}
