using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DoorTriggerEnd : MonoBehaviour
{
    public Transform FinalBG;
    public Camera Camara;
    private bool isInsideTrigger = false;
    public GameObject Door;
    public GameObject PopUpHabitEnd;
    public GameObject Player;
    public bool CurrentEnd = false;
    public GameObject SalirPuerta;
    public GameObject FinalActiv;


    [Header("Text Settings")]
    public TextMeshProUGUI textComponent; // Referencia al componente TMP
    [TextArea] public string fullText; // El texto completo que se escribirá
    public float typingSpeed = 0.05f; // Velocidad entre cada letra

    private string currentText = "";

    // Start is called before the first frame update
    void Start()
    {
        PopUpHabitEnd.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (isInsideTrigger)
        {

            if (Input.GetKeyDown(KeyCode.E))
            {
                CurrentEnd = !CurrentEnd;
                Debug.Log("CurrenbathCambiado a true");
                Camara.transform.position = FinalBG.transform.position;
                Player.SetActive(false);
                FinalActiv.SetActive(false);
                StartCoroutine(TypeText());
            }
        }

    }
    void OnTriggerEnter2D(Collider2D armario)
    {
        if (armario.CompareTag("Player") && SalirPuerta != null && !SalirPuerta.activeSelf)
        {
            isInsideTrigger = true;
            PopUpHabitEnd.SetActive(true);
        }

    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && SalirPuerta != null && !SalirPuerta.activeSelf)
        {
            isInsideTrigger = false;
            PopUpHabitEnd.SetActive(false);

        }
    }
    private IEnumerator TypeText()
    {
        textComponent.text = ""; // Limpia el texto al inicio
        currentText = "";

        foreach (char letter in fullText)
        {
            currentText += letter;
            textComponent.text = currentText;
            yield return new WaitForSeconds(typingSpeed);
        }

        OnTypingComplete();
    }

    private void OnTypingComplete()
    {
        Debug.Log("Escritura completada.");
        // Aquí puedes llamar a otra función o activar algo una vez terminado
    }
}
