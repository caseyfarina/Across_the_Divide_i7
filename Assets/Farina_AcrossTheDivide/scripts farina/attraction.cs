using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class attraction : MonoBehaviour
{
    public float GC = 0.0000000000667384f; // Gravitational Constant OBS: the Newton's Universal Gravitational Constant is 6.67408 * 10e11
    List<Rigidbody> rigidBodyObjects; // List of all RigidBody objects on the scene
    public GameObject centerOfMassObject; // Set the object that represents the center of mass

    void Start()
    {
        // Instantiate the list of RigidBody Objects
        rigidBodyObjects = new List<Rigidbody>();

        // It searchs for all RigidBody Objects on the scene and it stores them in the "rigidBodyObjects" variable
        foreach (Collider collider in Physics.OverlapSphere(transform.position, Mathf.Infinity))
        {
            if (collider.transform.GetComponent<Rigidbody>())
            {
                rigidBodyObjects.Add(collider.transform.GetComponent<Rigidbody>());
            }
        }
    }

    // OPTIONAL: Set the position of the center of mass 
    Vector3 centerOfMass()
    {
        Vector3 sumMassXPosition = Vector3.zero;
        float totalMass = 0;
        foreach (Rigidbody RB in rigidBodyObjects)
        {
            sumMassXPosition += RB.mass * RB.transform.position;
            totalMass += RB.mass;
        }
        return sumMassXPosition / totalMass;
    }

    void Update()
    {
        // Go through the "rigidBodyObjects" list
        foreach (Rigidbody RB in rigidBodyObjects)
        {
            // Resultant Force over each rigid body object set to zero at each frame
            Vector3 resultForce = Vector3.zero;
            foreach (Rigidbody RB2 in rigidBodyObjects)
            {
                //  Calculates the force over each object by all the other objects
                if (RB.name != RB2.name)
                {
                    Vector3 forceDirection = RB.transform.position - RB2.transform.position;
                    // Summarises each force in the resultant force 
                    resultForce += GC * forceDirection.normalized * ((RB.mass * RB2.mass) / (forceDirection.magnitude * forceDirection.magnitude));
                }
            }
            // Add the resultant force into each rigid body object
            RB.AddForce(-resultForce);
        }

        #region Optional - Center of Mass

        centerOfMassObject.transform.position = centerOfMassObject.transform.position;

        #endregion
    }
}