using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChecklistManager : MonoBehaviour
{
    public GameObject TodoArmario;
    public GameObject TodoDientes;
    public GameObject ChecklistDressed;
    public GameObject ChecklistUndressed;
    public GameObject ChecklistTeeth;
    public GameObject ChecklistNotTeeth;
    private bool actionExecutedArmario = false;
    private bool actionExecutedDientes = false;

    // Start is called before the first frame update
    void Start()
    {
        ChecklistDressed.SetActive(false);
        ChecklistUndressed.SetActive(false);
        ChecklistTeeth.SetActive(false);
        ChecklistNotTeeth.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(TodoArmario != null && !TodoArmario.activeSelf && !actionExecutedArmario)
        {
            ChecklistDressed.SetActive(true); // Llama a la función para realizar la acción.
            actionExecutedArmario = true; // Marca la acción como realizada.
        }
        if (TodoDientes != null && !TodoDientes.activeSelf && !actionExecutedDientes)
        {
            ChecklistTeeth.SetActive(true); // Llama a la función para realizar la acción.
            actionExecutedDientes = true; // Marca la acción como realizada.
        }
    }
}
