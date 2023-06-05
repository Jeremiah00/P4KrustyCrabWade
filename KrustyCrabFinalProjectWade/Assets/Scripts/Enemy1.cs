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
    Animator animator;
    public float speed;
    
    public float range;
    public float attackRange;
    float timer = 2f;
 
    bool isTimerRunning = true;
    bool canMove =true;
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<MovePlayer>();
        enemy = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        Moves();
        if(canMove == false)
        {
            if (timer > 0f)
            {
                isTimerRunning = true;
                if (isTimerRunning)
                {
                    canMove = false;
                    timer -= Time.deltaTime;

                }
                if (timer <= 0f)
                {
                    isTimerRunning = false;
                    canMove = true;
                    timer = 2f;
                    
                }
            }

        }
        
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Player")
        {
            canMove = false;
            animator.SetTrigger("Attack_Trig");
        }
    }
    void Moves()
    {

        if(canMove)
        {
            Vector3 direction = player.transform.position - transform.position;
            Vector3 velocity = direction * speed;
            if (Vector3.Distance(player.transform.position, transform.position) <= range)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(velocity), 5f * Time.deltaTime);
                enemy.Move(velocity * Time.deltaTime);
                animator.SetTrigger("Player_Near");
            }
            else
            {
                animator.SetTrigger("Player_Fars");
            }
        }
        
    }
}
