using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    
    public Transform Baño;
    public Camera Camara;
    private bool isInsideTrigger = false;
    public GameObject Door;
    public GameObject PopUpHabit;    
    public GameObject Player;
    public Transform BañoPlayer;
    public bool CurrentBath = false;

    // Start is called before the first frame update
    void Start()
    {
        PopUpHabit.SetActive(false);        
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
                Camara.transform.position = Baño.transform.position;
                Player.transform.position = BañoPlayer.transform.position;
                
            }
        }

    }
    void OnTriggerEnter2D(Collider2D armario)
    {
        if (armario.CompareTag("Player")) 
        {
            isInsideTrigger = true;
            PopUpHabit.SetActive(true);
        }

    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player")) 
        {
            isInsideTrigger = false;            
            PopUpHabit.SetActive(false);
            
        }
    }
}
