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
    float timer;
    bool isTimerRunning;
    bool canMove;
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<MovePlayer>();
        enemy = GetComponent<CharacterController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();

    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Player")
        {
            if(isTimerRunning)
            {
                timer -= Time.deltaTime;
                canMove = false;
            }
            if (timer <= 0)
            {
                canMove = true; 
            }

        }
    }
    void Move()
    {

        if(canMove)
        {
            Vector3 direction = player.transform.position - transform.position;
            Vector3 velocity = direction * speed;
            if (Vector3.Distance(player.transform.position, transform.position) <= range)
            {
                enemy.Move(velocity * Time.deltaTime);
            }
        }

    }
}
