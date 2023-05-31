using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;

public class Fallthrough : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject street;
    public GameObject floor;
    public GameObject worldLight;
    MeshCollider meshCollider;
    MeshCollider meshCollider2;
    Light lights;

    void Start()
    {
        meshCollider = street.GetComponent<MeshCollider>();
        meshCollider2 = floor.GetComponent<MeshCollider>();
        lights = worldLight.GetComponent<Light>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
       
        if (other.gameObject.GetComponent<MovePlayer>() != null)
        {
            
            meshCollider.enabled = false;
            meshCollider2.enabled = false;
            lights.enabled = !lights.enabled;
        }
    }
}
