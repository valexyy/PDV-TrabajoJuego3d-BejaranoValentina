using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    #region Atributos
    private Vector3 fuerzaPorAplicar;
    private float tiempoDesdeUltimaFuerza;
    private float intervaloTiempo;
    private IMovementStrategy strategy;
    private Player player;
    #endregion

    #region Ciclo de vida del script
    private void Start()
    {
        fuerzaPorAplicar = new Vector3(0, 0, 5f);
        tiempoDesdeUltimaFuerza = 0f;
        intervaloTiempo = 2f;

        player = GetComponent<Player>();
        if (player == null)
        {
            Debug.LogError("No se encontró el componente Player en el GameObject.");
        }
        SetStrategy(new AceletareMovement());
    }

    private void Update()
    {
        MovePlayer();
    }

    private void FixedUpdate()
    {
        tiempoDesdeUltimaFuerza += Time.deltaTime;
        if (tiempoDesdeUltimaFuerza >= intervaloTiempo)
        {
            gameObject.GetComponent<Rigidbody>().AddForce(fuerzaPorAplicar, ForceMode.Impulse);
            tiempoDesdeUltimaFuerza = 0f;
        }
    }
    #endregion

    #region Logica de la estrategia
    public void SetStrategy(IMovementStrategy strategy)
    {
        this.strategy = strategy;
    }

    public void MovePlayer()
    {
        if (strategy != null && player != null)
        {
            strategy.Move(transform, player);
        }
    }
    #endregion
}