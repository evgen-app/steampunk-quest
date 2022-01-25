using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickPlayerExample : MonoBehaviour
{
    public float speed;
    public VariableJoystick variableJoystick;
    private Rigidbody2D rb;

    public void FixedUpdate()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        Vector2 direction = Vector2.up * variableJoystick.Vertical + Vector2.right * variableJoystick.Horizontal;
        Debug.LogWarning(direction * speed * Time.fixedDeltaTime);
        rb.AddForce(direction * speed * Time.fixedDeltaTime);
    }
}