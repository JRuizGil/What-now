using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DientesStateManager : MonoBehaviour
{
    DientesBaseState currentState;

    public DientesSuciosState suciosState = new DientesSuciosState();
    public DientesLimpiosState LimpiosState = new DientesLimpiosState();
    public DientesSuciosAbiertoState AbiertoSucioState = new DientesSuciosAbiertoState();
    
    void Start()
    {
        currentState = suciosState;
        currentState.EnterState(this);
    }
    void Update()
    {
        currentState.UpdateState(this);
    }

    public void SwitchState(DientesBaseState state)
    {
        currentState = state;
        state.EnterState(this);
    }
}
