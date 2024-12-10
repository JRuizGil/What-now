using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DientesLimpiosState : DientesBaseState
{
    public override void EnterState(DientesStateManager dientes)
    {
        Debug.Log("Cerrado y vacio");
        Clean = false;
        Close = true;
    }
    public override void UpdateState(DientesStateManager dientes)
    {

    }
}
