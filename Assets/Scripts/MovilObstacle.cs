using UnityEngine;

public class MovilObstacle : MonoBehaviour
{
    public Vector3 direccion = new Vector3(5, 0, 0);
    public float velocidad = 2f;

    private Vector3 posicionInicial;

    void Start()
    {
        posicionInicial = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float factor = Mathf.Sin(Time.time * velocidad);
        transform.position = posicionInicial + (direccion * factor);

    }
}
