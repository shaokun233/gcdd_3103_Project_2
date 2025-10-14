using UnityEngine;

public class chaseenemy : Enemy
{

    public float chaseRange;

    public GameObject enemybullet;
    public GameObject bulletRespawn;

    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
     void FixedUpdate()
    {
        Behavior();
    }
    public override void attack()
    {
        if(attackRate< Time.time - lastAttack)
        {
            lastAttack = Time.time;
           Instantiate(enemybullet, bulletRespawn.transform);
        }
    }

    void Behavior()
    {
        float distance = Vector3.Distance(Player.transform.position, this.transform.transform.position);

        if (distance < chaseRange)
        {
            navMeshAgent.SetDestination(Player.position);
        }
        if (distance < attackRange)
        {
            attack();
        }
    }
}
