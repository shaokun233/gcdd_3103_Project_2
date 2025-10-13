using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;
using UnityEngine.Windows;

public class PlayerC : MonoBehaviour
{
    public int MaxHealth;           //Max Healthpoint player can have
    public int health;              // this is relly what it is.
    public float movespeed;         // like it name move speed for player
    public float inertia;           // inertia for player
    public float rotateSensitivity; //Mouse sensitivity


    private float movex, movey; //for movement
    private float lookx, looky; //for look

    private Transform tfc;    //transform for camera
    private Transform tf;     //play transform
    private Transform tfb;    //bullit respawn point


    private Vector3 velocity;   //current velocity
    private float rotateY;      //current rotation
    private float rotateX;

    private float LastDanmage;  //Last get hit.
    public float HealRate;   //to set heal 2 health point per how many second
    private float LastHeal;    //Last heal
    public enum Config { WASD, TFGH, CNTLR };          //useing for change control profile,not using now, 2025.8.25
    public Config config { get; private set; } = Config.WASD;

    public RectTransform healthbar;
    public TMP_Text healthText;
   
    //for display config
    public GameObject currentConfig;

    //differetn bullite
    public GameObject bullit;
    public GameObject bullit2;

    //player_C
    //private PlayerControl playercontrol; // just trying to use other way, but take some time, so leave for future self
    //private InputAction move_WASD;
    //private InputAction move_TFGH;
    //private InputAction move_cntlr;
    //private InputAction fire;


    void Start()
    {
        tf = GetComponent<Transform>();
        tfc = tf.GetChild(0).transform;
        tfb = tf.GetChild(0).GetChild(0);
        currentConfig.GetComponent<TMP_Text>().text = "WASD";
        
        
    }
    

    
    void Update()
    {
       
        if(health > MaxHealth)
        {
            health = MaxHealth;
        } 
        else if (10 < Time.time - LastDanmage  && health != MaxHealth && HealRate < Time.time - LastHeal)
        {
            health += 2;
            LastBeenHeal();
        }
        healthText.text = health.ToString();

        float ratio = (float)health / (float)MaxHealth;
        float y = 200 * ratio;
        healthbar.sizeDelta = new Vector2(y, healthbar.sizeDelta.y);

    }
   
    public void getHit(int damage)
    {
        LastBeenHit();
        health  -= damage;
    }


    private void FixedUpdate()
    {
        //for look
         rotateY += lookx * rotateSensitivity * Time.deltaTime;
        tf.rotation = Quaternion.Euler(0, rotateY, 0);

        rotateX += looky * rotateSensitivity * Time.deltaTime;

        if (rotateX > 90) { rotateX = 90; } else if (rotateX < -90) { rotateX = -90; }
        tfc.rotation = Quaternion.Euler(-rotateX, rotateY, 0);

        //for move
        Vector3 move = (movex * tf.right +  movey * tf.forward) * movespeed;
        if (move.magnitude > 0.1f)
        {
            velocity = move;
        }
        else
        {
            //not input,use Lerp to slow the speed
            velocity = Vector3.Lerp(velocity, Vector3.zero, Time.deltaTime * inertia);
        }
        tf.Translate(velocity * Time.fixedDeltaTime, Space.World);

    }

    void LastBeenHit()
    {
        LastDanmage = Time.time;
    }

    void LastBeenHeal()
    {
        LastHeal = Time.time;
    }


    //for WASD move
    void OnMove(InputValue moveValue)
    {
        if(config == Config.WASD)
        {
            Vector2 movevector = moveValue.Get<Vector2>();
            movex = movevector.x;
            movey = movevector.y;
        }
    }
    //for TFGH move
    void OnMove1(InputValue moveValue)
    {
        if(config == Config.TFGH)
        {
            Vector2 movevector = moveValue.Get<Vector2>();
            movex = movevector.x;
            movey = movevector.y;
        }
        
    }
    //for CNTLR move
    void OnMove2(InputValue moveValue)
    {
        if (config == Config.CNTLR)
        {
            Vector2 movevector = moveValue.Get<Vector2>();
            movex = movevector.x;
            movey = movevector.y;
        }

    }
    // for mouse 
    void OnLook(InputValue lookValue)
    {
        if (config == Config.WASD || config == Config.TFGH)
        {
            Vector2 lookVector = lookValue.Get<Vector2>();
            lookx = lookVector.x;
            looky = lookVector.y;
        }
      
    }
    //for CNTLR look
    void OnLook1(InputValue lookValue)
    {
        if(config == Config.CNTLR)
        {
            Vector2 lookVector = lookValue.Get<Vector2>();
            lookx = lookVector.x;
            looky = lookVector.y;
        }
        
    }
    
    //For keyboard
    void OnFire(InputValue fire)
    {
       if(Time.timeScale != 0)
        {
            this.GetComponent<inventory_UI_Manager>().UseItem();

        }
    }

    //Not use for this project

    //For controller
    //void OnFire1()
    //{

    //    int random = Random.Range(0, 2);
    //    if (random == 0)
    //    {
    //        GameObject b = Instantiate(bullit, tfb.position, tfb.rotation);
    //    }
    //    else
    //    {
    //        GameObject b = Instantiate(bullit2, tfb.position, tfb.rotation);


    //    }
    //}
     

    //change cofing of control
    //void OnChangeWASD(InputValue x)
    //{
    //    Change();
    //}
   
    //void OnChangeC(InputValue x)
    //{

    //    Change();
    //}

    //public void Change()
    //{
    //    if (Time.timeScale != 0)
    //    {
    //        if (config == Config.WASD)
    //        {
    //            config = Config.TFGH;
    //        }
    //        else if (config == Config.TFGH)
    //        {
    //            config = Config.CNTLR;
    //        }
    //        else
    //        {
    //            config = Config.WASD;
    //        }
    //        currentConfig.GetComponent<TMP_Text>().text = config.ToString();

    //    }
    //}
}
