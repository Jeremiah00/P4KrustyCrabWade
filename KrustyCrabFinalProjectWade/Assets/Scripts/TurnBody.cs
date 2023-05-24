using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnBody : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform orientation;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = orientation.rotation;
    }
}
