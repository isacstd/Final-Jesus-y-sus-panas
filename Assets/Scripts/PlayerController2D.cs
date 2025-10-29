#if UNITY_EDITOR
using UnityEditor.Experimental.GraphView;
#endif
using UnityEngine;
using TMPro; // para usar textos

public class PlayerController : MonoBehaviour
{
    public float speed = 5f; // velocidad del jugador

    public int panas = 0;
    public int chanclas = 0;
    public bool tieneLlave = false;

    public TextMeshProUGUI textoPanas;
    public TextMeshProUGUI textoChanclas;
    public TextMeshProUGUI textoLlave;
    public TextMeshProUGUI textoVictoria;
    public TextMeshProUGUI textoMuerte;

    void Start()
    {
        ActualizarUI();
        // Aseguramos que los paneles de victoria y muerte estén ocultos al inicio
        if (textoVictoria != null) textoVictoria.transform.parent.gameObject.SetActive(false);
        if (textoMuerte != null) textoMuerte.transform.parent.gameObject.SetActive(false);
    }

    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 direccion = new Vector3(moveHorizontal, moveVertical, 0);
        transform.Translate(direccion * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Collectable"))
        {
            if (other.name.Contains("Pana"))
            {
                panas++;
            }
            else if (other.name.Contains("Chancla"))
            {
                chanclas++;
            }

            ActualizarUI();
            Destroy(other.gameObject);
        }

        if (other.CompareTag("Water"))
        {
            Destroy(gameObject);
            if (textoMuerte != null)
                textoMuerte.transform.parent.gameObject.SetActive(true); // <-- muestra el panel de muerte
            Time.timeScale = 0f;
            Debug.Log("Has perdido");
        }

        if (other.CompareTag("Llave"))
        {
            if (panas >= 12 && chanclas >= 5)
            {
                tieneLlave = true;
                ActualizarUI();
                Destroy(other.gameObject);
                Debug.Log("¡Tienes la llave!");
            }
            else
            {
                Debug.Log("Aún no puedes recoger la llave. Reúne todos los panas y las chanclas primero.");
            }
        }

        // condición de victoria
        if (panas >= 12 && chanclas >= 5 && tieneLlave == true)
        {
            Debug.Log("Ganaste! Tienes los 12 panas, las 5 chanclas y la llave.");
            if (textoVictoria != null)
                textoVictoria.transform.parent.gameObject.SetActive(true); // <-- muestra el panel de victoria
            Time.timeScale = 0f;
        }
    }

    void ActualizarUI()
    {
        textoPanas.text = "Panas (12) = " + panas;
        textoChanclas.text = "Chanclas (5) = " + chanclas;
        textoLlave.text = "Llave (1) = " + (tieneLlave ? "Sí" : "No");
    }
}