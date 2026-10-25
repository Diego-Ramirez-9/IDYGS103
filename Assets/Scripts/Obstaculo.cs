using UnityEngine;

public class Obstaculo : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnTriggerEnter2D(Collider2D other)
    {
        MovimientoJugador j = other.GetComponent<MovimientoJugador>();
        if (j != null) j.colorActual = Color.black;
    }
}
