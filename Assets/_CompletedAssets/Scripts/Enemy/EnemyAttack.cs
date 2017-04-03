using UnityEngine;
using System.Collections;

namespace CompleteProject
{
    public class EnemyAttack : MonoBehaviour
    {
        public float timeBetweenAttacks = 0.5f;     // Tiempo entre ataques
        public int attackDamage = 10;               //Daño


        Animator anim;                              // Variables
        GameObject player;                          // Variable que no se pa que vale
        PlayerHealth playerHealth;                  // Salud
        EnemyHealth enemyHealth;                    //Salud enemigo
        bool playerInRange;                         // Rango del Jugador
        float timer;                                // Temporizador


        void Awake ()
        {
            // References.
            player = GameObject.FindGameObjectWithTag ("Player");
            playerHealth = player.GetComponent <PlayerHealth> ();
            enemyHealth = GetComponent<EnemyHealth>();
            anim = GetComponent <Animator> ();
        }


        void OnTriggerEnter (Collider other)
        {
            
            if(other.gameObject == player)
            {
               
                playerInRange = true;
            }
        }


        void OnTriggerExit (Collider other)
        {
            
            if(other.gameObject == player)
            {
                
                playerInRange = false;
            }
        }


        void Update ()
        {
            // Add the time since Update was last called to the timer.
            timer += Time.deltaTime;

            // If the timer exceeds the time between attacks, the player is in range and this enemy is alive...
            if(timer >= timeBetweenAttacks && playerInRange && enemyHealth.currentHealth > 0)
            {
                // ... attack.
                Attack ();
            }

            // If the player has zero or less health...
            if(playerHealth.currentHealth <= 0)
            {
                // ... tell the animator the player is dead.
                anim.SetTrigger ("PlayerDead");
            }
        }


        void Attack ()
        {
            // Reset the timer.
            timer = 0f;

            // If the player has health to lose...
            if(playerHealth.currentHealth > 0)
            {
                //damage  player.
                playerHealth.TakeDamage (attackDamage);
            }
        }
    }
}