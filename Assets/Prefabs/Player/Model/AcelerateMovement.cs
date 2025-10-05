
using UnityEngine;

public class AcelerateMovement : IMovementStrategy
{
    public void Move(Transform transform, Player player, float input)
    {
        float movement = input * (player.Velocidad * player.Aceleracion) * Time.deltaTime;
        transform.Translate(movement, 0, 0);
    }
}