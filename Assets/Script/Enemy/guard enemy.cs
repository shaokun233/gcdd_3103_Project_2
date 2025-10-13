using UnityEngine;

public class guardenemy : Enemy
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    // Update is called once per frame
    public override void attack()
    {
        base.attack();
        Vector3 direction = (player.transform.position - this.transform.position).normalized;
        Rigidbody playrb = player.GetComponent<Rigidbody>();
        playrb.AddForce(direction * 5,ForceMode.Impulse);
    }

    public override void moveBywaypoint()
    {
        float distance = Vector3.Distance(player.transform.position, this.transform.transform.position);

        if (distance < attackRange)
        {
            attack();
            navMeshAgent.SetDestination(this.transform.position);
            this.transform.LookAt(player);
            hasReachWaypoint = true;
            return;
        }
        base.moveBywaypoint();
    }

   
}
