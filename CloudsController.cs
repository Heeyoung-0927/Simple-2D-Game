using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudsController : MonoBehaviour
{ 
    [SerializeField]
    private Transform[] _clouds = new Transform[6];

    [SerializeField]
    private float _speed = 1.0f;

    [SerializeField]
    private float _xLimit = 12.5f;

    void Start()
    {
        
    }

    void Update()
    {
        // Loop through all cloud objects
        for (int i = 0; i < _clouds.Length; i++)
        {
            // Move cloud to the right by 1 unit per frame over time
            _clouds[i].position = _clouds[i].position + Vector3.right * Time.deltaTime * _speed;

            // If the cloud goes too far right outside the scene...
            if (_clouds[i].position.x > _xLimit)
            {
                // ... change the position back to the start of left side of the scene to create an endless cloud-moving effect
                _clouds[i].position -= new Vector3(2 * _xLimit, 0, 0);
            }
        }
    }
}
