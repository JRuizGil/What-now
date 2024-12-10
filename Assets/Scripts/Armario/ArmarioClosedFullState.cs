
using UnityEngine;

public class ArmarioClosedFullState : ArmarioBaseState
{
    


    private bool isInsideTrigger = false;
    public GameObject PlayerController;
    public GameObject BotonesRopa;
    public GameObject Armario;
    public GameObject PopUp;
    public override void EnterState(ArmarioStateManager armario)
    {
        PlayerController.SetActive(true);
        Close = true;
        Full = true;
        BotonesRopa.SetActive(false);
        Armario.SetActive(false);
        PopUp.SetActive(false);
        Debug.Log("Armario redy para abrit");
    }
    public override void UpdateState(ArmarioStateManager armario)
    {
        if (isInsideTrigger)
        {
            AbrirArmario(armario);
        }        
    }
    
    public void AbrirArmario(ArmarioStateManager armario)
    {
        if (Full && Close && Input.GetKey(KeyCode.Q))
        {
            Close = false;
            armario.SwitchState(armario.OpenFull);
        }
    }
    void OnTriggerEnter2D(Collider2D armario)
    {
        if (armario.CompareTag("Player")) // Verifica si el objeto que entra tiene el tag "Player"
        {
            isInsideTrigger = true; // Activa la bandera
            Debug.Log("Objeto dentro del Trigger.");
            PopUp.SetActive(true);
        }
        
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Verifica si el objeto que sale tiene el tag "Player"
        {
            isInsideTrigger = false; // Desactiva la bandera
            Debug.Log("Objeto fuera del Trigger.");
            PopUp.SetActive(false);
        }
    }
}
