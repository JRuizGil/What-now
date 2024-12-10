using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateManager : MonoBehaviour
{
    PlayerBaseState currentState;
    public PlayerStartingState StartingState = new PlayerStartingState();
    public PlayerDressState DressState = new PlayerDressState();
    public PlayerTeethState TeethState = new PlayerTeethState();
    public PlayerTeethDressState TeehtDressState = new PlayerTeethDressState();
    public GameObject ChecklistDressed;
    public GameObject ChecklistNotDressed;
    public GameObject ChecklistTeeth;
    public GameObject ChecklisNotTeeth;

    void Start()
    {

        currentState = StartingState;
        currentState.EnterState(this);        
    }

    
    void Update()
    {
        currentState.UpdateState(this);
        ChecklistActualizar();
    }

    public void SwitchState(PlayerBaseState state)
    {
        currentState = state;
        state.EnterState(this);
    }
    public void ChecklistActualizar()
    {
        if(currentState == DressState)
        {
            ChecklistDressed.SetActive(true);
        }
        if (currentState == TeethState)
        {
            ChecklistTeeth.SetActive(true);
        }
        if (currentState == TeehtDressState)
        {
            ChecklistDressed.SetActive(true);
            ChecklistTeeth.SetActive(true);
        }
    }
}
