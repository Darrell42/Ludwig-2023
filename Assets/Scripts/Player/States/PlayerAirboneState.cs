using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAirboneState : PlayerBaseState
{
    private Vector2 lastMovementDirection;
    private PlayerMovment playerMovment;

    public override void EnterState(Player player)
    {
        player.CurrentState = "Airbone State";

        playerMovment = player.GetComponent<PlayerMovment>();
        lastMovementDirection = player.moveInput;

    }

    public override void ExitState(Player player)
    {
        
    }
    public override void Update(Player player)
    {
        if (player.controls.Gameplay.Jump.triggered && playerMovment.WallGrabCheck() && lastMovementDirection.x != 0)
        {
            lastMovementDirection = -lastMovementDirection;
            playerMovment.Jump();
        }
            
        
    }

    public override void FixedUpdate(Player player)
    {
        if (playerMovment.IsGrounded())
            player.TransitionToState(player.playerMovingState);

        if(player.moveInput.x != 0)
           playerMovment.Move(lastMovementDirection);

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
