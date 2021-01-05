using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[DisallowMultipleComponent]
public class Oscillator : MonoBehaviour
{
    [SerializeField] Vector3 movementVector;
    [Range(0, 1)] [SerializeField] float movementFactor;

    Vector3 stringPos;

    // Start is called before the first frame update
    void Start()
    {
        stringPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 offcet = movementVector * movementFactor;
        transform.position = stringPos + offcet;
    }
}
