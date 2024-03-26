using UnityEngine;

public class Health : MonoBehaviour
{
    public int MaxHealth = 20;
    public int CurrentHealth { get; private set; }
    private CharacterController characterController;

    private float _fallSpeed;
    private float _fallStartPoint;
    private bool _staredFalling = true;
    public virtual void Start()
    {
        characterController = GetComponent<CharacterController>();
        CurrentHealth = MaxHealth;
    }
    protected virtual void Update()
    {
        if (transform.position.y < -150)
        {
            OnCharacterDie();
        }
        if (characterController == null)
        {
            return;
        }

        if (!characterController.isGrounded)
        {
            if (_staredFalling)
            {
                _fallStartPoint = transform.position.y;
                _staredFalling = false;
            }
            _fallSpeed = characterController.velocity.y;

        }
        if (characterController.isGrounded && -_fallSpeed >3f)
        {
            float fallHeight = _fallStartPoint- transform.position.y;
            if (fallHeight > 2)
            {
                int fallDamage = (int)Mathf.Abs(_fallSpeed) / 3;
                ChangeHealthValue(-fallDamage);
            }

            _fallSpeed = 0;
            _staredFalling = true;
        }


    }

    public virtual void ChangeHealthValue(int value)
    {
        CurrentHealth += value;

        if (CurrentHealth > MaxHealth) CurrentHealth = MaxHealth;

        if (CurrentHealth <= 0) OnCharacterDie();
    }

    public virtual void OnCharacterDie()
    {
        Debug.Log(name + " is dead");
        Player player = GetComponent<Player>();
        if(player == null) Destroy(gameObject);
    }
}
