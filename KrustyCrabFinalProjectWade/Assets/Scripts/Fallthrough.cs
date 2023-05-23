using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;

public class Fallthrough : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject street;
    public GameObject floor;
    MeshCollider meshCollider;
    MeshCollider meshCollider2;

    void Start()
    {
        meshCollider = street.GetComponent<MeshCollider>();
        meshCollider2 = floor.GetComponent<MeshCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
       
        if (other.gameObject.GetComponent<MovePlayer>())
        {
            meshCollider.enabled = false;
            meshCollider.enabled = false;
        }
    }
}
