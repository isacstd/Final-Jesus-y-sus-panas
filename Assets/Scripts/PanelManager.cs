using UnityEngine;
using UnityEngine.SceneManagement;

public class PanelManager : MonoBehaviour
{
    public GameObject[] panels; // lista de paneles
    private int indexActual = 0;

    void Start()
    {
        MostrarSoloEste(indexActual);
    }

    public void SiguientePanel()
    {
        indexActual++;
        if (indexActual >= panels.Length)
        {
            indexActual = panels.Length - 1;
        }
        MostrarSoloEste(indexActual);
    }

    public void AnteriorPanel()
    {
        indexActual--;
        if (indexActual < 0)
        {
            indexActual = 0;
        }
        MostrarSoloEste(indexActual);
    }

    public void VolverAlMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    void MostrarSoloEste(int index)
    {
        for (int i = 0; i < panels.Length; i++)
        {
            panels[i].SetActive(i == index);
        }
    }
}
