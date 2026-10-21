using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;

    public void Update()
    {
        // Even though the player won't move if it's paused. I put this in because...
        // of the state based behavior section on brightspace saying input should be disabled

        // This one if statement is the only part of this entire script that's relevant to the project.
        if (GameStateManager.Instance.CurrentState != GameState.Playing)
        {
            return;
        }

        Keyboard keyboard = Keyboard.current;

        if (keyboard == null)
        {
            return;
        }

        Vector2 move = Vector2.zero;

        if (keyboard.wKey.isPressed)
        {
            move.y += 1;
        }

        if (keyboard.sKey.isPressed)
        {
            move.y -= 1;
        }
        if (keyboard.aKey.isPressed)
        {
            move.x -= 1;
        }
        if (keyboard.dKey.isPressed)
        {
            move.x += 1;
        }

        move = move.normalized;

        transform.Translate(move * speed * Time.deltaTime);
    }
}
