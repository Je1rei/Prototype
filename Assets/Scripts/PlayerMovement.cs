using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _jumpForce = 7f;
    
    private Rigidbody _rb;
    
    void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }
    
    private void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");
        
        Vector3 move = new Vector3(moveX, 0, moveZ) * _speed;
        _rb.linearVelocity = new Vector3(move.x, _rb.linearVelocity.y, move.z);
        
        if (Input.GetKeyDown(KeyCode.Space))
            _rb.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
    }
    
    public void Init()
    {
        Debug.Log("Player initialized!");
    }
}
