using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Mov : MonoBehaviour
{
    [SerializeField] Vector2 _move;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
      void SetMove(InputAction.CallbackContext value)
    {
        _move = value.ReadValue<Vector2>();
    }
}
