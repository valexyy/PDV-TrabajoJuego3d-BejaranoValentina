using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Player player;
    private IMovementStrategy movementStrategy;

    private Vector3 fuerzaPorAplicar;
    private float tiempoDesdeUltimaFuerza;
    private float intervaloTiempo;

    void Start()
    {
        player = new Player(velocidad: 5f, aceleracion: 2f);
        movementStrategy = new LateralMovement(); // Estrategia inicial

        fuerzaPorAplicar = new Vector3(0, 0, 300f);
        tiempoDesdeUltimaFuerza = 0f;
        intervaloTiempo = 2f;
    }

    void Update()
    {
        float input = Input.GetAxis("Horizontal");
        MovePlayer(input);
    }

    public void MovePlayer(float input)
    {
        if (movementStrategy != null && player != null)
        {
            movementStrategy.Move(transform, player, input);
        }
    }

    public void SetMovementStrategy(IMovementStrategy strategy)
    {
        this.movementStrategy = strategy;
    }

    void FixedUpdate()
    {
        tiempoDesdeUltimaFuerza += Time.fixedDeltaTime;
        if (tiempoDesdeUltimaFuerza >= intervaloTiempo)
        {
            GetComponent<Rigidbody>().AddForce(fuerzaPorAplicar);
            tiempoDesdeUltimaFuerza = 0f;
        }
    }
}