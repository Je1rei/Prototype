using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(Collider))]
public class Coin : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private int _value = 1;
    [SerializeField] private float _rotationSpeed = 90f;
    [SerializeField] private float _collectAnimDuration = 0.5f;
    [SerializeField] private float _collectJumpHeight = 1.5f;
    [SerializeField] private ParticleSystem _collectEffect;

    private Collider _collider;
    private Tweener _rotationTween;
    private Sequence _collectSequence;
    private bool _isCollected;

    private void Awake()
    {
        _collider = GetComponent<Collider>();
    }

    private void Start()
    {
        StartRotation();
    }

    private void StartRotation()
    {
        _rotationTween = transform.DORotate(new Vector3(0, 360, 0), 360f/_rotationSpeed, RotateMode.FastBeyond360)
            .SetEase(Ease.Linear)
            .SetLoops(-1)
            .SetLink(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!_isCollected && other.CompareTag("Player"))
        {
            CollectCoin();
        }
    }

    private void CollectCoin()
    {
        _isCollected = true;
        _collider.enabled = false;

        if (_rotationTween != null && _rotationTween.IsActive())
            _rotationTween.Kill();

        ParticleSystem effectInstance = null;
        if (_collectEffect != null)
        {
            effectInstance = Instantiate(_collectEffect, transform.position, Quaternion.identity);
            effectInstance.Play();
        }

        _collectSequence = DOTween.Sequence();
        _collectSequence.Append(transform.DOJump(
            transform.position, 
            _collectJumpHeight, 
            1, 
            _collectAnimDuration
        ));
        _collectSequence.Join(transform.DOScale(0, _collectAnimDuration));
        _collectSequence.OnComplete(() => 
        {
            ScoreManager.Instance?.AddCoins(_value);
            
            if (effectInstance != null)
                Destroy(effectInstance.gameObject, effectInstance.main.duration);
                
            Destroy(gameObject);
        });
        
        _collectSequence.SetLink(gameObject);
    }

    private void OnDestroy()
    {
        if (_rotationTween != null && _rotationTween.IsActive())
            _rotationTween.Kill();

        if (_collectSequence != null && _collectSequence.IsActive())
            _collectSequence.Kill();
    }
    
    public void Init()
    {
        Debug.Log("The coins are initialized!");
    }
}