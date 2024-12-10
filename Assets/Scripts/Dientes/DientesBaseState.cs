using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DientesBaseState : MonoBehaviour
{
    
    public bool Clean = true;
    public bool Close = true;

    public abstract void EnterState(DientesStateManager dientes);
    public abstract void UpdateState(DientesStateManager dientes);
    

    
}
