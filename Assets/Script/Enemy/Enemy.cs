using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

public abstract class Enemy : MonoBehaviour
{
    public int health; // the health enemy have


    private Transform HealthBar; //The HealthBar on the enemy
    private Transform Canava;    //the Canave on the enemy
    private TMP_Text Health;     // the number show on the HealthBar
    protected Transform Player;    //the Player place
    private float lastbeenHit;

    protected NavMeshAgent navMeshAgent;
    public Transform[] waypoints; // waypoint for enemy
    protected int currentWayPoint;
    protected bool isReturning = false;
    protected bool hasReachWaypoint = false;// Because navMeshAgent.remainingDistance will be less than or equal to
                                            // stoppingDistance for several consecutive frames when approaching the target,
                                            // this is a lock used to prevent multiple judgments.
    public float attackRange;
    protected float lastAttack;
    public float attackRate;

    public static List<Enemy> allEnemies = new List<Enemy>();//A list have all enemy in the scenes, use for Friend class


    // the get the HealthBar,Canava,Player, and Health
    void Start()
    {
        lastAttack = 0;
        currentWayPoint  = 0;
        lastbeenHit = -10;
        navMeshAgent = GetComponent<NavMeshAgent>();

        HealthBar = transform.GetChild(0).GetChild(1);
        Canava = transform.GetChild(0);
        Player = GameObject.Find("player").transform;
        Health = transform.GetChild(0).GetChild(2).GetComponent<TMP_Text>();
    }


    //Add or remove enemy when it create or destory
    private void OnEnable()=> allEnemies.Add(this);
    private void OnDisable() =>allEnemies.Remove(this);

    public static List<Enemy> GetEnemies() { return allEnemies; }

    protected virtual void Update()
    {

        displayhealthbar();
        if (health <= 0)
         Destroy(this.gameObject);

        //if (navMeshAgent.enabled)
        //{
        //    navMeshAgent.SetDestination(player.position);
        //}
    }
     void FixedUpdate()
    {
        moveBywaypoint();
    }


    //to make sure the enemy's health bar is always face to player,
    //make health bar shurt when enemy health get lower,
    //destory enemy when health is or lower then zero.
    void displayhealthbar()
    {
        Canava.LookAt(Player.position);

        Health.text = health.ToString();
        float x = (float)(health * 0.01);
        float y = 190 * x;
        RectTransform HB = HealthBar.GetComponent<RectTransform>();
        HB.sizeDelta = new Vector2(y, HB.sizeDelta.y);

        if (10<Time.time - lastbeenHit)
            Canava.gameObject.SetActive(false);
        else
            Canava.gameObject.SetActive(true);
    }

    //get danmage, and set the lastbeenHit
    public void getHit(int damage)
    {
        health -= damage;
        lastbeenHit = Time.time;

    }
    // Used to make subsets of enemies with different attacks
    public virtual void attack()
    {
       
    }

    // base waypoint movement, if not in waypoint will just stay there.
    public virtual void moveBywaypoint()
    {
        if (waypoints == null || waypoints.Length == 0 || !navMeshAgent.enabled)
            return;

        //set to Destination waypoint
        navMeshAgent.SetDestination(waypoints[currentWayPoint].position);

        //if it reachwaypoint, select next waypoint.
        if (currentWayPoint < waypoints.Length && !isReturning)
            {            
                if ( !hasReachWaypoint && navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
                {
                    hasReachWaypoint = true;
                    currentWayPoint +=1;
                }
                if(currentWayPoint == waypoints.Length)
                {
                    isReturning = true;
                    currentWayPoint =waypoints.Length-2;
                }
             }
            else
            {

            if (!hasReachWaypoint && navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
            {
                hasReachWaypoint = true;
                currentWayPoint--;
            }
                if (currentWayPoint == -1)
                {
                    isReturning = false;
                    currentWayPoint =1;
                }
            }

        if (navMeshAgent.remainingDistance > navMeshAgent.stoppingDistance)
        {
            hasReachWaypoint = false;
        }

    }









}
