using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float velocidad;
    [SerializeField] private float aceleracion;

    public float Velocidad { get { return velocidad; } set { velocidad = value; } }
    public float Aceleracion { get { return aceleracion; } set { aceleracion = value; } }
}