using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    // Start is called before the first frame update
    MovePlayer player;
    CharacterController enemy;
    public float speed;
    
    public float range;
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<MovePlayer>();
        enemy = GetComponent<CharacterController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = player.transform.position - transform.position;
        Vector3 velocity = direction * speed;
        if(Vector3.Distance(player.transform.position, transform.position) <= range)
        {
            enemy.Move(velocity * Time.deltaTime);
        }

    }
}
