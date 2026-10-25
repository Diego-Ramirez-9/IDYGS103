using UnityEngine;
using UnityEngine.SceneManagement;

public class Objetivo : MonoBehaviour
{
    public float tiempoLimite = 5f;
    public int vidas = 3;

    public SpriteRenderer SR;
    Color pedido;
    float tiempoRestante;

    void Awake()
    {
        SR = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        NuevoPedido();
    }

    void Update()
    {
        tiempoRestante -= Time.deltaTime;
        if (tiempoRestante <= 0)
        {
            Perder();
        }
    }

    void NuevoPedido()
    {
        ColorMeta[] cuadros = FindObjectsByType<ColorMeta>(FindObjectsSortMode.None);
        pedido = cuadros[Random.Range(0, cuadros.Length)].SR.color;
        SR.color = pedido;
        tiempoRestante = tiempoLimite;
    }

    void Perder()
    {
        vidas--;

        if (vidas <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else
        {
            NuevoPedido();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        MovimientoJugador j = other.GetComponent<MovimientoJugador>();
        if (j != null && j.colorActual == pedido)
        {
            NuevoPedido();
        }
    }

    // Dibuja el tiempo y las vidas en la esquina superior izquierda
    void OnGUI()
    {
        GUIStyle estilo = new GUIStyle(GUI.skin.label);
        estilo.fontSize = 32;
        estilo.normal.textColor = Color.white;

        GUI.Label(new Rect(20, 20, 300, 50), "Tiempo: " + Mathf.Ceil(tiempoRestante), estilo);
        GUI.Label(new Rect(20, 70, 300, 50), "Vidas: " + vidas, estilo);
    }
}
