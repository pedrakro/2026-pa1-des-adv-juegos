using UnityEngine;

public class playerMovimiento : MonoBehaviour
{
    public float velocidad = 5f;
    public float fuerzaSalto = 7f;

    private Rigidbody2D rb;
    private bool enSuelo;

    public Transform puntoSuelo;
    public float radioSuelo = 0.2f;
    public LayerMask capaSuelo;
    private Animator anim;

    void Start()
 {
     rb = GetComponent<Rigidbody2D>();
     anim = GetComponent<Animator>();
 }

    void Update()
    {
float movimiento = Input.GetAxis("Horizontal");
rb.linearVelocity = new Vector2(movimiento * velocidad, rb.linearVelocity.y);

// Animación de velocidad
anim.SetFloat("velocidad", Mathf.Abs(movimiento));
if (movimiento != 0)
{
    transform.localScale = new Vector3(Mathf.Sign(movimiento), 1, 1);
}

// Salto
if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space)) && enSuelo)
{
    rb.linearVelocity = new Vector2(rb.linearVelocity.x, fuerzaSalto);
}
    }

    void FixedUpdate()
    {
        enSuelo = Physics2D.OverlapCircle(puntoSuelo.position, radioSuelo, capaSuelo);

// Animación de suelo
anim.SetBool("enSuelo", enSuelo);
    }
    
}