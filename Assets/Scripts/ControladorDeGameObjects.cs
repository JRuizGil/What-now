using System.Collections.Generic;
using UnityEngine;

public class ControladorDeGameObjects : MonoBehaviour
{
    // Lista de GameObjects que, cuando est�n activos, desactivar�n otras listas
    public List<GameObject> listaDeActivadores;

    // Lista de GameObjects que se desactivar�n/activar�n
    public List<GameObject> listaDeObjetosADesactivar;

    // Lista de scripts que se desactivar�n/activar�n
    public List<MonoBehaviour> listaDeScriptsADesactivar;

    // M�todo que se llama una vez por frame
    void Update()
    {
        // Comprobar si alguno de los GameObjects en la lista de activadores est� activo
        if (HayUnActivadorActivo())
        {
            // Si alguno est� activo, desactivar los objetos y scripts
            DesactivarObjetosYScripts();
        }
        else
        {
            // Si ninguno est� activo, reactivar los objetos y scripts
            ActivarObjetosYScripts();
        }
    }

    // Funci�n que comprueba si al menos uno de los GameObjects en la lista est� activo
    bool HayUnActivadorActivo()
    {
        foreach (GameObject activador in listaDeActivadores)
        {
            if (activador.activeSelf) // Si al menos uno est� activo, devolvemos true
            {
                return true;
            }
        }
        return false; // Si ninguno est� activo, devolvemos false
    }

    // Funci�n que desactiva los GameObjects y scripts de las listas correspondientes
    void DesactivarObjetosYScripts()
    {
        // Desactivar todos los GameObjects de la lista
        foreach (GameObject objeto in listaDeObjetosADesactivar)
        {
            if (objeto != null && objeto.activeSelf)
            {
                objeto.SetActive(false);
            }
        }

        // Desactivar todos los scripts de la lista
        foreach (MonoBehaviour script in listaDeScriptsADesactivar)
        {
            if (script != null && script.enabled)
            {
                script.enabled = false;
            }
        }
    }

    // Funci�n que activa los GameObjects y scripts de las listas correspondientes
    void ActivarObjetosYScripts()
    {
        // Activar todos los GameObjects de la lista
        foreach (GameObject objeto in listaDeObjetosADesactivar)
        {
            if (objeto != null && !objeto.activeSelf)
            {
                objeto.SetActive(true);
            }
        }

        // Activar todos los scripts de la lista
        foreach (MonoBehaviour script in listaDeScriptsADesactivar)
        {
            if (script != null && !script.enabled)
            {
                script.enabled = true;
            }
        }
    }
}
