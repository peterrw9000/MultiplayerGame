using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour
{
    Transform player1;
    Transform player2;
    PlayerHealth playerHealth1;
    PlayerHealth playerHealth2;
    EnemyHealth enemyHealth;
    UnityEngine.AI.NavMeshAgent nav;


    void Awake ()
    {
        player1 = GameObject.Find("Player 1").transform;
        player2 = GameObject.Find("Player 2").transform;
        playerHealth1 = player1.GetComponent<PlayerHealth>();
        playerHealth2 = player2.GetComponent<PlayerHealth>();
        enemyHealth = GetComponent<EnemyHealth>();
        nav = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }


    void Update ()
    {
        if(enemyHealth.currentHealth > 0 && (playerHealth1.currentHealth > 0 || playerHealth2.currentHealth > 0))
        {
            if (player2.gameObject.active)
            {
                if(Vector3.Distance(enemyHealth.gameObject.transform.position, player2.position) > 
                    Vector3.Distance(enemyHealth.gameObject.transform.position, player1.position))
                {
                    nav.SetDestination(player2.position);
                }
                else
                {
                    nav.SetDestination(player1.position);
                }
            }
            else
            {
                nav.SetDestination(player1.position);
            }
        }
        else
        {
            nav.enabled = false;
        }
    }
}
