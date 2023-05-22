using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;

public class Fallthrough : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject street;

    void Start()
    {
        //street = GetComponent<MeshCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        MovePlayer player = other.GetComponent<MovePlayer>();
        if(player)
        {

        }
    }
}
