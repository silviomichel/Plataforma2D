using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moveplayer : MonoBehaviour
{
    [SerializeField] float _velocidade;
    [SerializeField] Rigidbody2D _rb;
    [SerializeField] float _moveX;
    [SerializeField] float _moveY;
    [SerializeField] float _jumpF;

    [SerializeField] bool _checkGround;
    [SerializeField] bool isFacingRight;
    [SerializeField] bool _checkIniciar;
    // Start is called before the first frame update
    void Start()
    {
       // _rb.gravityScale = 1.0f;  
    }

    // Update is called once per frame
    void Update()
    {
        if(_checkIniciar == true) 
        {
            Andar();

        }


        _rb.velocity = new Vector2(_moveX *_velocidade, _rb.velocity.y);
       // _rb.velocity = new Vector2(_moveX, _moveY);

      if (Input.GetKeyDown(KeyCode.Space) && _checkGround==true)
        {
            Pular();
        }
        if(_moveX > 0 && isFacingRight == false)
        {
            Flip();
        }
        else if (_moveX < 0 && isFacingRight == true)
        {
            Flip();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            _checkGround = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _checkGround = false;
        }
    }
    void Flip()
    {
        isFacingRight = !isFacingRight;

        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
        // Flip collider over the x-axis

    }
    void Andar()
    {
        Controle();
        _rb.velocity = new Vector2(_moveX * _velocidade, _rb.velocity.y);
    }
    void Controle()
    {
        _moveX = Input.GetAxisRaw("Horizontal");

        _moveY = Input.GetAxisRaw("Vertical");
    }
    void Pular()
    {
        _rb.AddForce(new Vector2(0, _jumpF * 10));
    }
}
