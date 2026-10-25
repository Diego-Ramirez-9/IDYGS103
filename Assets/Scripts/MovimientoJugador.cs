using UnityEngine;

public class MovimientoJugador : MonoBehaviour
{
    public float velocidad = 5f;
    public Color colorActual;
    SpriteRenderer SR;

    void Awake()
    {
        SR = GetComponent<SpriteRenderer>();
        colorActual = SR.color;
    }

    void Update()
    {
        Vector3 move = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0f);
        transform.Translate(move * velocidad * Time.deltaTime);
        SR.color = colorActual;
    }

}
