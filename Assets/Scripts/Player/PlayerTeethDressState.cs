using UnityEngine;

public class PlayerTeethDressState : PlayerBaseState
{
    public GameObject SalirPuerta;
    public override void EnterState(PlayerStateManager player)
    {
        Teeth = true;
        Dress = true;  
        SalirPuerta.SetActive(false);
        Debug.Log("Helo teethdress state");
    }
    public override void UpdateState(PlayerStateManager player)
    {        
        
    }
    
}
