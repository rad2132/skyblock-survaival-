using UnityEngine;

public class StarvingSystem : MonoBehaviour
{
    public static StarvingSystem Instance;
    public int MaxSatietyPoints = 20;
    public int CurrentSatietyPoints {  get; private set; }
    public float SaturationTime = 60f;
    public float CurrentSaturationTime {  get; private set; }
    public float StarvingIncreaseCooldown = 30f;
    private float _secondsUntilIncrease;
    private PlayerHealth _health;
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        _health = GetComponent<PlayerHealth>();
        CurrentSatietyPoints = MaxSatietyPoints;
        CurrentSaturationTime = SaturationTime;
    }
    private void FixedUpdate()
    {
        if (_health.CurrentHealth < _health.MaxHealth)
        {
            CurrentSaturationTime = 0f;
        }

        if (CurrentSaturationTime> 0)
        {
            CurrentSaturationTime -= Time.deltaTime;
            return;
        }

        if (_secondsUntilIncrease > 0)
        {
            _secondsUntilIncrease -= Time.deltaTime;
        }
        else if (CurrentSatietyPoints > 0)
        {
            ChangeSatiety(-1,0);
            _secondsUntilIncrease = StarvingIncreaseCooldown;
        }
        else if(_health.CurrentHealth > 6)
        {
            _health.ChangeHealthValue(-1);
            _secondsUntilIncrease = StarvingIncreaseCooldown;
        }
    }

    public void ChangeSatiety(int stietyValue,float saturationValue)
    {
        CurrentSatietyPoints += stietyValue;
        if(CurrentSatietyPoints >= MaxSatietyPoints)
        {
            CurrentSaturationTime += saturationValue;
            CurrentSatietyPoints = MaxSatietyPoints;
        }
        if (CurrentSatietyPoints < 0)
        {
            CurrentSatietyPoints = 0;
        }
    }
}
