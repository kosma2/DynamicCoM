using UnityEngine;
using System.Collections.Generic;

public class DynamicCOMCalculator : MonoBehaviour
{
    public List<Rigidbody> bodyParts;
    private Vector3 dynamicCOM;

    void Start()
    {
        // Initialize bodyParts with all the Rigidbody components attached to the character's bones
        Rigidbody[] rigidbodies = GetComponentsInChildren<Rigidbody>();
        bodyParts = new List<Rigidbody>(rigidbodies);
    }

    void Update()
    {
        // Calculate the dynamic center of mass each frame
        dynamicCOM = CalculateCOM();
        Debug.DrawLine(Vector3.zero, dynamicCOM, Color.red);
    }

    private Vector3 CalculateCOM()
    {
        Vector3 com = Vector3.zero;
        float totalMass = 0f;

        foreach (Rigidbody rb in bodyParts)
        {
            com += rb.worldCenterOfMass * rb.mass;
            totalMass += rb.mass;
        }

        return com / totalMass;
    }

    public Vector3 GetDynamicCOM()
    {
        return dynamicCOM;
    }
}
