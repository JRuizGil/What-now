using UnityEngine;

public class PlayerTeethState : PlayerBaseState 
{
    public GameObject TodoArmario;
    public GameObject TodoDientes;
    
    
    public override void EnterState(PlayerStateManager player)
    {
        Teeth = true;
        Dress = false;
        
        Debug.Log("Helo teeth state");
        
    }
    public override void UpdateState(PlayerStateManager player)
    {
        // if dress while teeth cleaned, the state changes
        
        
        if (TodoArmario != null && !TodoArmario.activeSelf)
        {
            Debug.Log("Armariotodo está desactivado.");
            Dress = true;
            player.SwitchState(player.TeehtDressState);
        }
    }
    
}
