using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTriggerBath : MonoBehaviour
{
    public Transform Habitacion;
    public GameObject PopUpBaño;
    public Camera Camara;
    private bool isInsideTrigger = false;
    public GameObject Door;

    public GameObject Player;
    public Transform HabitPlayerPos;
    public bool CurrentBath = true;

    // Start is called before the first frame update
    void Start()
    {
        PopUpBaño.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (isInsideTrigger)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                CurrentBath = !CurrentBath;
                Debug.Log("CurrenbathCambiado a true");
                Camara.transform.position = Habitacion.transform.position;
                Player.transform.position = HabitPlayerPos.transform.position;

            }
        }
    }
    void OnTriggerEnter2D(Collider2D armario)
    {
        if (armario.CompareTag("Player"))
        {
            isInsideTrigger = true;
            PopUpBaño.SetActive(true);
        }

    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isInsideTrigger = false;
            PopUpBaño.SetActive(false);

        }
    }
}
