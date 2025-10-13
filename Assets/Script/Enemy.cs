using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public int health; // the health enemy have


    private Transform HealthBar; //The HealthBar on the enemy
    private Transform Canava;    //the Canave on the enemy
    private TMP_Text Health;     // the number show on the HealthBar
    private Transform Player;    //the Player place

    protected NavMeshAgent navMeshAgent;
    protected Transform player;

    // the get the HealthBar,Canava,Player, and Health
    void Start()
    {
        player = GameObject.FindGameObjectsWithTag("player")[0].transform;
        navMeshAgent = GetComponent<NavMeshAgent>();

        HealthBar = transform.GetChild(0).GetChild(1);
        Canava = transform.GetChild(0);
        Player = GameObject.Find("player").transform;
        Health = transform.GetChild(0).GetChild(2).GetComponent<TMP_Text>();
    }


    //to make sure the enemy's health bar is always face to player,
    //make health bar shurt when enemy health get lower,
    //destory enemy when health is or lower then zero.
    void Update()
    {
        Canava.LookAt(Player.position);

        Health.text = health.ToString();
        float x = (float)(health * 0.01);
        float y = 190 * x;
        RectTransform HB = HealthBar.GetComponent<RectTransform>();
        HB.sizeDelta = new Vector2( y, HB.sizeDelta.y);

        if (health <= 0)
            Destroy(this.gameObject);

        if (navMeshAgent.enabled)
        {
            navMeshAgent.SetDestination(player.position);
        }



    }

   
}
