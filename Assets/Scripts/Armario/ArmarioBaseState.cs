using UnityEngine;

public abstract class ArmarioBaseState : MonoBehaviour
{
    public bool hasSwitchedState = false;
    public bool Full = true;
    public bool Close = true;


    public abstract void EnterState(ArmarioStateManager armario);
    public abstract void UpdateState(ArmarioStateManager armario);

    
}
