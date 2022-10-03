using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickController : MonoBehaviour
{
    public Joystick joystick;
    public int velocity;
    public Rigidbody2D rb;
    public bool touch;

    private void FixedUpdate()
    {
        Vector2 direction = Vector2.up * joystick.Vertical + Vector2.right * joystick.Horizontal;
        if(touch)
        {
            rb.AddForce(direction * velocity * Time.fixedDeltaTime, ForceMode2D.Impulse);
        }
        else
        {
            gameObject.transform.Translate(direction * velocity * Time.deltaTime);
        }
    }
}
