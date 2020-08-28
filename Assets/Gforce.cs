using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gforce : MonoBehaviour
{
    public Rigidbody rb;

    public static List<Gforce> Attractors;
    const float G = 200.4f;

    void FixedUpdate()
    {
        foreach (Gforce attractor in Attractors)
        {
            if (attractor != this)
                Attract(attractor);
        }
    }

    void OnEnable()
    {
        if (Attractors == null)
            Attractors = new List<Gforce>();

        Attractors.Add(this);
    }

    void OnDisable()
    {
        Attractors.Remove(this);
    }

    void Attract(Gforce anotherBody)
    {
        Rigidbody rbToAttract = anotherBody.rb;
        Vector3 direction= rb.position - rbToAttract.position;
        float distance = direction.magnitude;
        if (distance <= 5f)
        {
            return;
        }
        
        float forceMagnitude = G * (rb.mass * rbToAttract.mass) / Mathf.Pow(distance, 2);
        Vector3 force = direction.normalized * forceMagnitude;
        rbToAttract.AddForce(force);
        return;
    }
}
