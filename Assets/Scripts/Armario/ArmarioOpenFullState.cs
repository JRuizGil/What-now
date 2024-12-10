using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ArmarioOpenFullState : ArmarioBaseState
{
    

    public GameObject PlayerController;
    public GameObject parentObject;
    public GameObject Armario;
    public GameObject TeclaZ;
    public GameObject TeclaT;
    public GameObject TeclaV;
    public GameObject TeclaN;
    public GameObject TeclaP;
    public GameObject RopaN;
    public GameObject RopaP;
    public GameObject RopaT;
    public GameObject RopaV;
    public GameObject RopaZ;
    public GameObject TodoArmario;
    private bool accionRealizada = false;
    private HashSet<GameObject> objetosDesactivados = new HashSet<GameObject>();
    private Dictionary<KeyCode, GameObject> teclaMap;

    private ArmarioStateManager armarioManager; // Agregar como variable de clase

    public override void EnterState(ArmarioStateManager armario)
    {
        armarioManager = armario; // Guarda la referencia
        PlayerController.SetActive(false);
        accionRealizada = false;
        Close = false;
        Full = true;
        parentObject.SetActive(true);
        Armario.SetActive(true);

        Debug.Log("Instancia creada.");
        teclaMap = new Dictionary<KeyCode, GameObject>
        {
        { KeyCode.Z, TeclaZ },
        { KeyCode.T, TeclaT },
        { KeyCode.V, TeclaV },
        { KeyCode.N, TeclaN },
        { KeyCode.P, TeclaP }
        };
    }

    public override void UpdateState(ArmarioStateManager armario)
    {
        ArmarioGame();
        DesactivarSprites();
        if(Full == false && accionRealizada)
        {            
            parentObject.SetActive(false);
            Armario.SetActive(false);            
            TodoArmario.SetActive(false);
            PlayerController.SetActive(true);
            armario.SwitchState(armario.ClosedEmpty);
            Close = true;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Close = true;
            armario.SwitchState(armario.ClosedFull);
        }
        
    }
    
    public void ArmarioGame()
    {
        foreach (var pair in teclaMap)
        {
            if (Input.GetKeyDown(pair.Key))
            {
                if (pair.Value.activeSelf)
                {
                    pair.Value.SetActive(false);
                    
                }

                if (TodosDesactivados() && !accionRealizada)
                {
                    Debug.Log("¡Todas las teclas han sido desactivadas!");
                    accionRealizada = true; // Marca que la acción ya fue realizada

                    DoSomethingAfterDelay(); 

                }
            }
        }
    }

    private bool TodosDesactivados()
    {
        foreach (var obj in teclaMap.Values)
        {
            if (obj.activeSelf) return false;
        }
        return true;

    }
    private IEnumerator WaitAndDoSomething(float delay)
    {
        Debug.Log("Esperando...");
        yield return new WaitForSeconds(delay); // Espera el tiempo especificado
        Debug.Log("Han pasado 2 segundos. Ejecutando acción...");
        Full = false;   
    }
    public void DoSomethingAfterDelay()
    {
        StartCoroutine(WaitAndDoSomething(2f));
    }
    

    public void DesactivarSprites()
    {
        // Verificar y registrar desactivación para cada tecla
        if (TeclaZ != null && !TeclaZ.activeSelf && !objetosDesactivados.Contains(TeclaZ))
        {
            RopaZ.SetActive(false);
            objetosDesactivados.Add(TeclaZ);
            Debug.Log("Pantalon está desactivado.");
        }

        if (TeclaT != null && !TeclaT.activeSelf && !objetosDesactivados.Contains(TeclaT))
        {
            RopaT.SetActive(false);
            objetosDesactivados.Add(TeclaT);
            Debug.Log("camisa está desactivado.");
        }

        if (TeclaP != null && !TeclaP.activeSelf && !objetosDesactivados.Contains(TeclaP))
        {
            RopaP.SetActive(false);
            objetosDesactivados.Add(TeclaP);
            Debug.Log("chaqueta está desactivado.");
        }

        if (TeclaN != null && !TeclaN.activeSelf && !objetosDesactivados.Contains(TeclaN))
        {
            RopaN.SetActive(false);
            objetosDesactivados.Add(TeclaN);
            Debug.Log("calconchines está desactivado.");
        }

        if (TeclaV != null && !TeclaV.activeSelf && !objetosDesactivados.Contains(TeclaV))
        {
            RopaV.SetActive(false);
            objetosDesactivados.Add(TeclaV);
            Debug.Log("calcetines está desactivado.");
        }
    }
}
