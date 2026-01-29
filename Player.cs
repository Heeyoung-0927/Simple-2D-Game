using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField]
    private string _horizontalAxis = "Horizontal", _verticalAxis = "Vertical";

    [SerializeField]
    private Rigidbody2D _rb2d;
    
    // Stores the X and Y input from the player
    private Vector2 _input;

    [SerializeField]
    private float _speed = 3f;

    // UnityEvent assigned in the Inspector to trigger GameOverUI
    public UnityEvent OnPlayerDie;

    private void FixedUpdate()
    {
        // Apply velocity to the Rigidbody
        _rb2d.linearVelocity = _input * _speed; 
    }

    void Update()
    {
        // Get vertical and hroizontal input (returns -1, 0, or 1)
        float horizontalInput = Input.GetAxisRaw(_horizontalAxis); // left and right
        float verticalInput = Input.GetAxisRaw(_verticalAxis); // up and down
        _input = new Vector2(horizontalInput, verticalInput);
        // Normalize the vector so that diagonal movement is the same as straight movement
        _input.Normalize();
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Invoke the death event when the player collides with enemy
        if (OnPlayerDie != null)
        {
            OnPlayerDie.Invoke();
        }
        // Remove the player object from the scene
        Destroy(gameObject);
    }
}
