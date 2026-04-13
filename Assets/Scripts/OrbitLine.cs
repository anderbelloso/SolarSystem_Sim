using UnityEngine;

[ExecuteInEditMode] // Esto permite verlo en el editor sin darle a Play
public class OrbitLine : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public Transform centro; // Aquí arrastra tu SOL
    public float radio = 10f;
    [Range(10, 100)] public int segmentos = 50; // Calidad del círculo

    void Update()
    {
        DibujaCiclo();
    }

    void DibujaCiclo()
    {
        lineRenderer.positionCount = segmentos + 1;
        float angulo = 0f;

        for (int i = 0; i <= segmentos; i++)
        {
            // Calculamos la posición X y Z usando Seno y Coseno
            float x = Mathf.Sin(Mathf.Deg2Rad * angulo) * radio;
            float z = Mathf.Cos(Mathf.Deg2Rad * angulo) * radio;

            // La posición es relativa al centro (el Sol)
            Vector3 punto = new Vector3(x, 0f, z) + centro.position;

            lineRenderer.SetPosition(i, punto);
            angulo += (360f / segmentos);
        }
    }
}