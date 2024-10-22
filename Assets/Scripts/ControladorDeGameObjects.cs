using System.Collections.Generic;
using UnityEngine;

public class ControladorDeGameObjects : MonoBehaviour
{
    // Lista de GameObjects que, cuando estén activos, desactivarán otras listas
    public List<GameObject> listaDeActivadores;

    // Lista de GameObjects que se desactivarán/activarán
    public List<GameObject> listaDeObjetosADesactivar;

    // Lista de scripts que se desactivarán/activarán
    public List<MonoBehaviour> listaDeScriptsADesactivar;

    // Método que se llama una vez por frame
    void Update()
    {
        // Comprobar si alguno de los GameObjects en la lista de activadores está activo
        if (HayUnActivadorActivo())
        {
            // Si alguno está activo, desactivar los objetos y scripts
            DesactivarObjetosYScripts();
        }
        else
        {
            // Si ninguno está activo, reactivar los objetos y scripts
            ActivarObjetosYScripts();
        }
    }

    // Función que comprueba si al menos uno de los GameObjects en la lista está activo
    bool HayUnActivadorActivo()
    {
        foreach (GameObject activador in listaDeActivadores)
        {
            if (activador.activeSelf) // Si al menos uno está activo, devolvemos true
            {
                return true;
            }
        }
        return false; // Si ninguno está activo, devolvemos false
    }

    // Función que desactiva los GameObjects y scripts de las listas correspondientes
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

    // Función que activa los GameObjects y scripts de las listas correspondientes
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
