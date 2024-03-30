using UnityEngine;

public class PlayerHealth : Health
{
    private StarvingSystem _starvingSystem;
    public float IncreaseHealthCooldown = 10f;
    private float _secondsUntilIncrease;
    
    public override void Start()
    {
        base.Start();
        _starvingSystem = GetComponent<StarvingSystem>();
    }

    private void FixedUpdate()
    {
        if (_starvingSystem.CurrentSaturationTime > 0f)
        {
            _secondsUntilIncrease -= Time.deltaTime;
        }

        if (_starvingSystem.CurrentSaturationTime > 0 && _secondsUntilIncrease <= 0f)
        {
            ChangeHealthValue(1);
            _secondsUntilIncrease = IncreaseHealthCooldown;
        }
    }
}