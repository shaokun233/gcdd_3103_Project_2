using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class Friend : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private Enemy closestEnemy;

    private List<Enemy> allEnemies; //all enemy in scenes
    private NavMeshAgent navMeshAgent;

    public GameObject bullet;
    private Transform bulletRespawn;

    private Transform player; // player place
    public float attackRange;
    protected float lastAttack;
    public float attackRate;
    void Start()
    {
        allEnemies = Enemy.GetEnemies();
        navMeshAgent = GetComponent<NavMeshAgent>();
        player = GameObject.Find("player").transform;
        bulletRespawn = transform.GetChild(0).transform;
    }

    // Update is called once per frame
    void Update()
    {
        Behavior();
    }
    void FindclosestEnemy()
    {
        closestEnemy = allEnemies.OrderBy(e => Vector3.Distance(transform.position, e.transform.position)).FirstOrDefault();
    }

    // Behavior of this AI
    void Behavior()
    {
        navMeshAgent.SetDestination(player.transform.position);

        FindclosestEnemy();
        if (closestEnemy != null) {
            float distance = Vector3.Distance(transform.position, closestEnemy.transform.position);
            if (distance <= attackRange) {
                attack();

            }
        }
    }
    //shot bullet
    void attack()
    {
        this.transform.LookAt(closestEnemy.transform);
        if (attackRate < Time.time - lastAttack)
        {
            lastAttack = Time.time;
            Instantiate(bullet, bulletRespawn.transform.position,bulletRespawn.transform.rotation);
        }
    }
}
