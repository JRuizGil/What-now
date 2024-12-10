using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmarioStateManager : MonoBehaviour
{
    ArmarioBaseState currentState;

    public ArmarioClosedFullState ClosedFull = new ArmarioClosedFullState();
    public ArmarioClosedEmptyState ClosedEmpty = new ArmarioClosedEmptyState();
    public ArmarioOpenFullState OpenFull = new ArmarioOpenFullState();
    

    void Start()
    {        
        currentState = ClosedFull;
        currentState.EnterState(this);
    }
    void Update()
    {
        currentState.UpdateState(this);
    }

    public void SwitchState(ArmarioBaseState state)
    {
        currentState = state;
        state.EnterState(this);
    }

}
