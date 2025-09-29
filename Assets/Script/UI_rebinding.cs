using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using static PlayerC;
using static UnityEngine.Timeline.DirectorControlPlayable;

public class UI_rebinding : MonoBehaviour
{

    public InputActionAsset InputActionAsset; // Input Actions Asset we use for player

    private InputActionRebindingExtensions.RebindingOperation rebindOperation;  // for rebinding

    //UI object
    public GameObject WASD;  
    public GameObject TFGH;
    public GameObject CNTLR;

    //Button
    private Button W,A,S,D,T,F,G,H,Left,Right;
    public Config config;



    //Each Action
    private InputAction move;
    private InputAction move1;
    private InputAction move2;
    private InputAction look1;
    private InputAction fire;

    //for pause only
    private InputAction pasue;
    private InputAction pause2;

    //to get all value this script need
    void Awake()
    {
        move = InputActionAsset.FindAction("Move");
        move1 = InputActionAsset.FindAction("Move1");
        move2 = InputActionAsset.FindAction("Move2");
        look1 = InputActionAsset.FindAction("Look1");

        pasue = InputActionAsset.FindAction("Navigate");
        pause2 = InputActionAsset.FindAction("Navigate2");



        W = WASD.transform.GetChild(0).GetComponent<Button>();
        A = WASD.transform.GetChild(1).GetComponent<Button>();
        S = WASD.transform.GetChild(2).GetComponent<Button>();
        D = WASD.transform.GetChild(3).GetComponent<Button>();

        T = TFGH.transform.GetChild(0).GetComponent<Button>();
        F = TFGH.transform.GetChild(1).GetComponent<Button>();
        G = TFGH.transform.GetChild(2).GetComponent<Button>();
        H = TFGH.transform.GetChild(3).GetComponent<Button>();

        Left = CNTLR.transform.GetChild(0).GetComponent<Button>();
        Right = CNTLR.transform.GetChild(1).GetComponent<Button>();

    }
    private void OnEnable()
    {
        pasue.Enable();
        pause2.Enable();
        pasue.started += OnPause;
        pause2.started += OnPause2;
    }

    private void OnDisable()
    {
        pasue.started -= OnPause;
        pause2.started -= OnPause2;
        pasue.Disable();
        pause2.Disable();
    }

    //using esc to pause, pop out keyboard rebind menu
    private void OnPause(InputAction.CallbackContext context)
    {
        config = GameObject.Find("player").GetComponent<PlayerC>().config;
        if (config == Config.WASD || config == Config.TFGH)
        {
            bool isOpen = WASD.activeSelf;
            WASD.SetActive(!isOpen);
            TFGH.SetActive(!isOpen);
            Time.timeScale = isOpen ? 1f : 0f;
        }
        
    }

    //using start to pause, pop out CNTLR rebind menu

    private void OnPause2(InputAction.CallbackContext context)
    {
        config = GameObject.Find("player").GetComponent<PlayerC>().config;
        if (config == Config.CNTLR)
        {
            bool isOpen = CNTLR.activeSelf;
            CNTLR.SetActive(!isOpen);
            Time.timeScale = isOpen ? 1f : 0f;
            if (!isOpen)
            {
                EventSystem.current.SetSelectedGameObject(null);
                EventSystem.current.SetSelectedGameObject(CNTLR.transform.GetChild(0).gameObject);
            }
        }
        
    }

    //the pirnt the key on rebing menu
    void Update()
    {

        W.GetComponentInChildren<TMP_Text>().text =  move.bindings[1].effectivePath.ToString().Substring(11);
        A.GetComponentInChildren<TMP_Text>().text = move.bindings[2].effectivePath.ToString().Substring(11);
        S.GetComponentInChildren<TMP_Text>().text = move.bindings[3].effectivePath.ToString().Substring(11);
        D.GetComponentInChildren<TMP_Text>().text = move.bindings[4].effectivePath.ToString().Substring(11);

        T.GetComponentInChildren<TMP_Text>().text = move1.bindings[1].effectivePath.ToString().Substring(11);
        F.GetComponentInChildren<TMP_Text>().text = move1.bindings[2].effectivePath.ToString().Substring(11);
        G.GetComponentInChildren<TMP_Text>().text = move1.bindings[3].effectivePath.ToString().Substring(11);
        H.GetComponentInChildren<TMP_Text>().text = move1.bindings[4].effectivePath.ToString().Substring(11);

        Left.GetComponentInChildren<TMP_Text>().text = move2.bindings[0].effectivePath.ToString().Substring(10);
        Right.GetComponentInChildren<TMP_Text>().text = look1.bindings[0].effectivePath.ToString().Substring(10);

    }

    void Rebind(InputAction action, int index)
    {
        action.Disable();//stop action
                                // start to rebinding         
        rebindOperation = action.PerformInteractiveRebinding(index).

            //what need to do after rebinding
            OnComplete(rebind => { 
            
            } )

            //the button start rebinding
            .Start();

        //start action
        action.Enable();
    }

    public void RebindingW()
    {
        Rebind(move, 1);
    }
    public void RebindingA()
    {
        Rebind(move, 2);
    }
    public void RebindingS()
    {
        Rebind(move, 3);
    }
    public void RebindingD()
    {
        Rebind(move, 4);
    }



    public void RebindingT()
    {
        Rebind(move1, 1);
    }
    public void RebindingF()
    {
        Rebind(move1, 2);
    }
    public void RebindingG()
    {
        Rebind(move1, 3);
    }
    public void RebindingH()
    {
        Rebind(move1, 4);
    }

    public void RebindingLeft()
    {
        Rebind(move2, 0);
    }

    public void RebindingRight()
    {
        Rebind(look1, 0);
    }







}
