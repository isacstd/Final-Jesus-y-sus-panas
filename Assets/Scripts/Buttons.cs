using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public GameObject panelCreditos;
    public GameObject panelSettings;

    public void Jugar()
    {
        SceneManager.LoadScene("Juego");
    }

    public void ComoJugar()
    {
        SceneManager.LoadScene("Jugabilidad");
    }

    public void MostrarCreditos()
    {
        panelCreditos.SetActive(true);
    }

    public void OcultarCreditos()
    {
        panelCreditos.SetActive(false);
    }

    public void AbrirSettings()
    {
        panelSettings.SetActive(true);
    }

    public void CerrarSettings()
    {
        panelSettings.SetActive(false);
    }

    public void Salir()
    {
        Debug.Log("Saliendo del juego...");
        Application.Quit();
    }
}