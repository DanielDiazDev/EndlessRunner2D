using UnityEngine;

public class JumpController : MonoBehaviour
{
    [SerializeField] private float _jumpForce = 300f;
    [SerializeField] private float _jumpHorizontalForce = 2f; 
    [SerializeField] private float _returnSpeed = 5f;
    [SerializeField] private LayerMask _groundLayerMask;
    [SerializeField] private Transform _groundController;
    [SerializeField] private Vector3 _size;
    [SerializeField] private float gravityScale = 10;
    [SerializeField] private float fallingGravityScale = 40;
    private Player _player;
    private bool _isGrounded;
    private bool _isJump;
    private Rigidbody2D _rigidbody;
    private Animator _animator;

    private Vector2 _initialPosition; 

    private void Start()
    {
        _player = GetComponent<Player>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _initialPosition = transform.position; 
        _animator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        if (!_player.IsGameOver() && _player.IsStart())
        {
            if (Input.GetButtonDown("Jump"))
            {
                Jump();
            }
        }
        if (_isGrounded && !_isJump)
        {
            transform.position = Vector2.Lerp(transform.position, _initialPosition, _returnSpeed * Time.deltaTime);
        }
    }
    private void FixedUpdate()
    {
        _isGrounded = Physics2D.OverlapBox(_groundController.position, _size, 0, _groundLayerMask);
        _isJump = false;
        if (_rigidbody.velocity.y >= 0)
        {
            _rigidbody.gravityScale = gravityScale;
        }
        else if (_rigidbody.velocity.y < 0)
        {
            _rigidbody.gravityScale = fallingGravityScale;
        }
       _animator.SetBool("IsGrounded", _isGrounded);
       _animator.SetFloat("VelocityY", _rigidbody.velocity.y);
    }

    public void Jump()
    {
        if (_isGrounded && !_isJump)
        {

            _isGrounded = false;
            _isJump = true;
            _rigidbody.AddForce(new Vector2(_jumpHorizontalForce, _jumpForce), ForceMode2D.Impulse);
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(_groundController.position, _size);
    }
}
