using UnityEngine;

public class MovimientoPlayer : MonoBehaviour
{
    public float velocidad = 5f;
    public float fuerzaSalto = 7f;
    public Transform sueloCheck;
    public LayerMask Arboles;

    private Rigidbody2D rb;
    private float direccionX;
    private bool enSuelo;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Verifica si está tocando el suelo
        enSuelo = Physics2D.OverlapCircle(sueloCheck.position, 0.1f, Arboles);

        // Aplica el movimiento en X
        rb.linearVelocity = new Vector2(direccionX * velocidad, rb.linearVelocity.y);
    }

    // Método llamado desde el PlayerInput (eventos)
    public void Movimiento(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        direccionX = context.ReadValue<float>();
    }

    public void Salto(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        if (context.performed && enSuelo)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, fuerzaSalto);
        }
    }
}
