using UnityEngine;

public class ParallaxEfecto : MonoBehaviour
{
    public Transform camara; // Cámara principal
    public float velocidadParallax = 0.5f; // Cuánto se mueve esta capa
    private float parallaxFactor;
    private float inicioX;
    private float anchoSprite;

    void Start()
    {
        inicioX = transform.position.x;
        anchoSprite = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        float temp = (camara.position.x * (1 - parallaxFactor));
        float distancia = camara.position.x * velocidadParallax;
        transform.position = new Vector3(inicioX + distancia, transform.position.y, transform.position.z);
        if (temp > inicioX + anchoSprite) inicioX += anchoSprite;
        else if (temp < inicioX - anchoSprite) inicioX -= anchoSprite;
    }
}
