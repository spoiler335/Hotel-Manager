using UnityEngine;

public class InputManager
{
    private PlayerInput inputs;
    public InputManager()
    {
        inputs = new PlayerInput();
        inputs.Enable();
    }

    public float forward => inputs.Player.Move.ReadValue<Vector2>().x;
    public float right => inputs.Player.Move.ReadValue<Vector2>().y;
}