using System;
using System.Threading.Tasks;
using Systems.Events;
using Enteties.Army;
using UnityEngine;

[Serializable]
public class TroopsManager
{
    [SerializeField] private TroopTypes _type;
    [SerializeField] private int _damage;
    [SerializeField] private int _hp;
    [SerializeField] private int _numberOfDivisions;
    [SerializeField] private int _queueOfDivisions;
    [SerializeField] private float _produceTime;
        
    private bool _isProduce;

    public TroopTypes Type
    {
        get => _type;
        set => _type = value;
    }
    public int Damage
    {
        get => _damage;
        set => _damage = value;
    }
    public int Hp
    {
        get => _hp;
        set => _hp = value;
    }
    public int NumberOfDivisions
    {
        get => _numberOfDivisions;
        set => _numberOfDivisions = value;
    }
    public int QueueOfDivisions
    {
        get => _queueOfDivisions;
        set => _queueOfDivisions = value;
    }
        
    public async void Produce()
    {
        if (!_isProduce)
        {
            _isProduce = true;
            while (true)
            {
                if (_queueOfDivisions != 0)
                {
                    await Task.Delay((int) (_produceTime * 1000));
                    _queueOfDivisions-- ;
                    _numberOfDivisions++ ;
                    LevelEventManager.PowerModify(_damage);
                    TroopsProducingEvents.ProducingFinished(Type);
                }
                else
                {
                    _isProduce = false;
                    break;
                }
            }
                
        }
    }
}