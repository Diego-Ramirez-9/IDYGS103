using UnityEngine;

public class ColorMeta : MonoBehaviour
{

    public static Color[] colores = { Color.red, Color.green, Color.blue, Color.yellow };
    public SpriteRenderer SR;

    public float tiempoCambio = 3f;
    float temporizador;

    void Awake()
    {
        SR = GetComponent<SpriteRenderer>();
        ElegirColor();
        temporizador = tiempoCambio;
    }

    void Update()
    {
        temporizador -= Time.deltaTime;
        if (temporizador <= 0)
        {
            ElegirColor();
            temporizador = tiempoCambio;
        }
    }

    void ElegirColor()
    {
        Color nuevo;
        do
        {
            nuevo = colores[Random.Range(0, colores.Length)];
        } while (ColorUsado(nuevo));

        SR.color = nuevo;
    }

    bool ColorUsado(Color c)
    {
        foreach (ColorMeta m in FindObjectsByType<ColorMeta>(FindObjectsSortMode.None))
        {
            if (m != this && m.SR != null && m.SR.color == c) return true;
        }
        return false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        MovimientoJugador j = other.GetComponent<MovimientoJugador>();
        if (j == null) return;

        j.colorActual = SR.color;
        ElegirColor();
        temporizador = tiempoCambio;
    }
}
