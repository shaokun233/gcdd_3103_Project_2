using UnityEngine;

public class chaseenemy : Enemy
{

    public float chaseRange;

    public GameObject enemybullit;
    public GameObject bullit_respown;

    

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
           Instantiate(enemybullit, bullit_respown.transform);
        }
    }

    void Behavior()
    {
        float distance = Vector3.Distance(player.transform.position, this.transform.transform.position);

        if (distance < chaseRange)
        {
            navMeshAgent.SetDestination(player.position);
        }
        if (distance < attackRange)
        {
            attack();
        }
    }
}
