using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] float _velocidade;
    [SerializeField] float _jumpF;
    [SerializeField] float _moveX;
    [SerializeField] Rigidbody2D _rb;

    [SerializeField] bool _checkGround;
    [SerializeField] bool _checkIniciar;
    [SerializeField] Vector2 _inputvalue;
    [SerializeField] bool _isFacingRight;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Andar();
        if (Input.GetKeyDown(KeyCode.Space) && _checkGround == true)
        {
            Pular();
        }
        if (_inputvalue.x > 0 && _isFacingRight == false)
        {
            Flip();
        }
        else if (_inputvalue.x < 0 && _isFacingRight == true)
        {
            Flip();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
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
        _isFacingRight = !_isFacingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
        // Flip collider over the x-axis
    }
    void Andar()
    {
        Controle();
        _rb.velocity = _inputvalue;

    }
    void Controle()
    {
        _inputvalue.x = Input.GetAxisRaw("Horizontal") * _velocidade;
        _inputvalue.y = _rb.velocity.y;

    }
    void Pular()
    {
        _rb.AddForce(new Vector2(0, _jumpF * 10));
    }
}
