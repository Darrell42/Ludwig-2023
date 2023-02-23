using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    //String with th name of the current state
    private PlayerBaseState currentState;
    public string CurrentState;

    //Universal call of the current stages (Not Sure if is going to be used)
    public PlayerBaseState State
    {
        get { return currentState; }
    }

    //Public State
    public PlayerMovingState playerMovingState = new PlayerMovingState();
    public PlayerAirboneState playerAirBoneState = new PlayerAirboneState();
    //public PlayerWallGlideState playerSlideableState = new PlayerWallGlideState();

    //Variable to store the inputs used to move
    public Controls controls;
    public Vector2 moveInput;
    public bool downButtonHold;
    
    //Stuff for the carged jump to work 
    public float jumpMultiplyer = 0f;
    public float maxJumpMultiplayer = 500f;
    public float jumpMultiplayerSpeed = 1f;

    //This manage the transitions between States
    public void TransitionToState(PlayerBaseState nextState)
    {
        if (currentState != null)
            currentState.ExitState(this);

        currentState = nextState;
        currentState.EnterState(this);

    }

    // Start is called before the first frame update
    void Start()
    {
        //Sets the first player state (This can change)
        TransitionToState(playerMovingState);
    }

    private void Awake()
    {
        //Here goes the Controls settings
        controls = new Controls();
        controls.Gameplay.Movement.performed += ctx => moveInput = ctx.ReadValue<Vector2>();
        controls.Gameplay.Movement.canceled += ctx => moveInput = Vector2.zero;

        controls.Gameplay.CargeJump.started += ctx => downButtonHold = true;
        controls.Gameplay.CargeJump.canceled += ctx => { downButtonHold = false; jumpMultiplyer = 0; };
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        currentState.Update(this);
    }

    private void FixedUpdate()
    {
        currentState.FixedUpdate(this);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        currentState.OnCollisionEnter2D(this, collision);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        currentState.OnCollisionExit2D(this, collision);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        currentState.OnTriggerEnter2D(this, collision);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        currentState.OnTriggerExit2D(this, collision);
    }
}
