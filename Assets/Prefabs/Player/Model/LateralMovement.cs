using UnityEngine;

public class LateralMovement : IMovementStrategy
{
    public void Move(Transform transform, Player player, float input)
    {
        float movement = input * player.Velocidad * Time.deltaTime;
        transform.Translate(movement, 0, 0);
    }
}