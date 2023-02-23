using UnityEngine;

public class PlayerMovingState : PlayerBaseState
{
    private PlayerMovment playerMovement;

    public override void EnterState(Player player)
    {
        player.CurrentState = "Moving State";
        playerMovement = player.GetComponent<PlayerMovment>(); 
    }

    public override void ExitState(Player player)
    {
        player.jumpMultiplyer = 0;
    }

    public override void Update(Player player)
    {
        if (player.controls.Gameplay.Jump.triggered)
        {
            playerMovement.Jump(player.jumpMultiplyer);
            return;
        }

        if (player.downButtonHold && player.jumpMultiplyer < player.maxJumpMultiplayer)
        {
            player.jumpMultiplyer += player.jumpMultiplayerSpeed * Time.deltaTime;
        }
            

    }

    public override void FixedUpdate(Player player)
    {
        if (!playerMovement.IsGrounded())
        {
            player.TransitionToState(player.playerAirBoneState);
            return;
        }


        if (!player.downButtonHold)
        {
            playerMovement.Move(player.moveInput);
            return;
        }
            
    }

    public override void OnCollisionEnter2D(Player player, Collision2D colision)
    {
        
    }

    public override void OnCollisionExit2D(Player player, Collision2D colision)
    {
        
    }

    public override void OnTriggerEnter2D(Player player, Collider2D colider)
    {
        
    }

    public override void OnTriggerExit2D(Player player, Collider2D colider)
    {
        
    }
}
