using UnityEngine;

public class PlayerStartingState : PlayerBaseState
{
    public GameObject TodoArmario;
    public GameObject TodoDientes;
    public override void EnterState(PlayerStateManager player)
    {     
        Teeth = false;
        Dress = false;   
        
        Debug.Log("Helo starting state");

    }
    public override void UpdateState(PlayerStateManager player)
    {

        if (TodoDientes != null && !TodoDientes.activeSelf)
        {
            Debug.Log("Dientestodo está desactivado.");
            Dress = true;
            player.SwitchState(player.TeethState);
        }
        if (TodoArmario != null && !TodoArmario.activeSelf)
        {
            Debug.Log("Armariotodo está desactivado.");
            Dress = true;
            player.SwitchState(player.DressState);
        }
    }
}
