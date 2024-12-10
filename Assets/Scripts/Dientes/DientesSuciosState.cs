using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DientesSuciosState : DientesBaseState
{
    public bool isInsideTrigger = false;
    public GameObject PlayerController;
    public GameObject Espejo;
    public GameObject PopUp;
    public GameObject Cepillo;
    public GameObject BotonesDientes;
    public override void EnterState(DientesStateManager dientes)
    {
        
        Close = true;
        Espejo.SetActive(false);
        PopUp.SetActive(false); 
        BotonesDientes.SetActive(false);
        Cepillo.SetActive(false);        
        
    }
    public override void UpdateState(DientesStateManager dientes)
    {       
        
        if (isInsideTrigger)
        {
            AbrirDientes(dientes);
            
        }

    }
    public void AbrirDientes(DientesStateManager dientes)
    {
        if (Clean == false && Close && Input.GetKeyDown(KeyCode.Q))
        {
            Close = false;
            dientes.SwitchState(dientes.AbiertoSucioState);
        }
    }
    void OnTriggerEnter2D(Collider2D dientes)
    {
        if (dientes.CompareTag("Player"))
        {

            Debug.Log("Objeto dentro del Trigger.");
            PopUp.SetActive(true);
            isInsideTrigger = true;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Desactiva la bandera
            Debug.Log("Objeto fuera del Trigger.");
            PopUp.SetActive(false);
            isInsideTrigger = false;
        }
    }
    

}
