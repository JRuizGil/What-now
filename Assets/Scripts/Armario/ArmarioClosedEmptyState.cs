using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmarioClosedEmptyState : ArmarioBaseState
{
    

    public override void EnterState(ArmarioStateManager armario)
    {
        Debug.Log("Cerrado y vacio");
        Full = false;
        Close = true;
        
    }
    public override void UpdateState(ArmarioStateManager armario)
    {
        
    }
    
}
