
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CircleCollider2D playerCollider;
    public Rigidbody2D rb;

    private const int Force = 30;

    private bool _aPress, _sPress, _dPress, _wPress;
    

    // Update is called once per frame
    void Update()
    {
        GetInput();
    }

    private void FixedUpdate()
    {
        if (_aPress)
        {
            rb.AddForce(new Vector2(-Force,0));
        }
        if (_sPress)
        {
            rb.AddForce(new Vector2(0,-Force));
        }
        if (_dPress)
        {
            rb.AddForce(new Vector2(Force,0));
        }
        if (_wPress)
        {
            rb.AddForce(new Vector2(0,Force));
        }
    }

    void GetInput()
    {
        _aPress = Input.GetKey(KeyCode.A);
        _wPress = Input.GetKey(KeyCode.W);
        _sPress = Input.GetKey(KeyCode.S);
        _dPress = Input.GetKey(KeyCode.D);
    }
    
    
    
    
}
