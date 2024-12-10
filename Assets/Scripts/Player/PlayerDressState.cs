using UnityEngine;

public class PlayerDressState : PlayerBaseState
{
    public GameObject TodoDientes;
    public GameObject TodoArmario;
    
    
    public override void EnterState(PlayerStateManager player)
    {
        Dress = true;
        Teeth = false;
        
        Debug.Log("Helo dress state");
    }
    public override void UpdateState(PlayerStateManager player)
    {
        
        if (TodoDientes != null && !TodoDientes.activeSelf)
        {
            Debug.Log("DientesTodo está desactivado.");
            Dress = true;
            player.SwitchState(player.TeehtDressState);
        }
    }
    
}
