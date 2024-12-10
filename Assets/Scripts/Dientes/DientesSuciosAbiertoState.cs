using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DientesSuciosAbiertoState : DientesBaseState
{
    public GameObject Espejo;   
    public GameObject PlayerController;
    public GameObject BotonesDientes;
    public GameObject Cepillo;
    public GameObject TodoDientes;

    public Transform initialPosition; // Posici�n inicial
    public Transform secondPosition; // N�mero de pulsaciones necesarias
    private int pressCountA = 0; // Contador de pulsaciones de 'A'
    private int pressCountD = 0; // Contador de pulsaciones de 'D'
    private bool isAtInitialPosition = true; // Bandera para saber la posici�n actual
    public float moveDuration = 1f;

    public override void EnterState(DientesStateManager dientes)
    {
        Cepillo.transform.position = initialPosition.transform.position;
        PlayerController.SetActive(false);
        Close = false;
        Clean = false;
        Espejo.SetActive(true);
        Cepillo.SetActive(true);
        BotonesDientes.SetActive(true);
        Debug.Log("Espejo Abierto");
    }
    public override void UpdateState(DientesStateManager dientes)
    {
        DientesGame();
        if (Clean == true)
        {
            PlayerController.SetActive(true);
            BotonesDientes.SetActive(false);
            Espejo.SetActive(false);
            TodoDientes.SetActive(false);
            Close = true;
            dientes.SwitchState(dientes.LimpiosState);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {            
            dientes.SwitchState(dientes.suciosState);
        }
    }
    public void DientesGame()
    {
        if (Input.GetKeyDown(KeyCode.A) && isAtInitialPosition)
        {
            StartCoroutine(MoveToPosition(secondPosition.position)); // Desliza hacia la segunda posici�n
            pressCountA++;
        }
        if (Input.GetKeyDown(KeyCode.D) && !isAtInitialPosition)
        {
            StartCoroutine(MoveToPosition(initialPosition.position)); // Desliza hacia la posici�n inicial
            pressCountD++;
        }
        if(pressCountA == 10 && pressCountD == 10)
        {
            Limpios();
        }
    }
    private IEnumerator MoveToPosition(Vector3 targetPosition)
    {
        Vector3 startPosition = Cepillo.transform.position;
        float timeElapsed = 0f;

        while (timeElapsed < moveDuration)
        {
            Cepillo.transform.position = Vector3.Lerp(startPosition, targetPosition, timeElapsed / moveDuration);
            timeElapsed += Time.deltaTime;
            yield return null; // Espera hasta el siguiente frame
        }

        // Asegurarse de que la posici�n final sea exactamente la del objetivo
        Cepillo.transform.position = targetPosition;

        // Cambiar el estado de la posici�n
        if (targetPosition == secondPosition.position)
        {
            isAtInitialPosition = false;
        }
        else
        {
            isAtInitialPosition = true;
        }
    }
    private IEnumerator WaitAndDoSomething(float delay)
    {
        Debug.Log("Esperando...");
        yield return new WaitForSeconds(delay); // Espera el tiempo especificado
        Debug.Log("Han pasado 2 segundos. Ejecutando acci�n...");
        Clean = true;
        // Aqu� colocas la acci�n que deseas realizar despu�s de esperar

    }
    private void Limpios()
    {
        StartCoroutine(WaitAndDoSomething(2f));
        Debug.Log("�Se ha cumplido el n�mero de pulsaciones necesarias! Ejecutando acci�n...");
        
    }

}
