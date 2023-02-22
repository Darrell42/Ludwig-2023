using UnityEngine;
public abstract class PlayerBaseState
{
    public abstract void EnterState(Player player);
    public abstract void ExitState(Player player);

    public abstract void Update(Player player);
    public abstract void FixedUpdate(Player player);

    public abstract void OnCollisionEnter2D(Player player, Collision2D colision);
    public abstract void OnCollisionExit2D(Player player, Collision2D colision);

    public abstract void OnTriggerEnter2D(Player player, Collider2D colider);

    public abstract void OnTriggerExit2D(Player player, Collider2D colider);

}
