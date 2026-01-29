using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponRotation : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D _rb2d; // Rigidbody object

    [SerializeField]
    private float _speed = 200f; // Speed of rotation

    void Start()
    {
        
    }

    void FixedUpdate()
    {
        // Rotates the Rigidbody using physics engine calculations
        _rb2d.MoveRotation(_rb2d.rotation + _speed * Time.fixedDeltaTime);
    }
}
