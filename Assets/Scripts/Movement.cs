
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    public InputActionReference move;
    public CharacterController cr;
    public Vector2 _move;
    public float _speed;
    float T = Time.deltaTime;
    public Transform PlayerTras;

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;  
    }

    void Update()
    {
        _move = move.action.ReadValue<Vector2>();
        _move.x = _move.x * T;
        _move.y = _move.y * T;
    }

    private void FixedUpdate()
    {
        PlayerTras.transform.localPosition = _move;
    }
}
