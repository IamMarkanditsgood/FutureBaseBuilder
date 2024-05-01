using System;
using Entities.Army.Troops;
using UnityEngine;
using UnityEngine.Serialization;

[Serializable]
public class TroopsPageParameters
{
    [SerializeField] private TroopTypes _troopType;
    [SerializeField] private String _name;
    [SerializeField] private Sprite _image;
    [SerializeField] private int _buyingPriceCrystal;
    [SerializeField] private int _buyingPriceFood;
    [SerializeField] private int _buyingPriceEnergy;
    [SerializeField] private int _producedTroopsQueue;

    public int ProducedTroopsQueue
    {
        get => _producedTroopsQueue;
        set => _producedTroopsQueue = value;
    }

    public TroopTypes TroopType
    {
        get => _troopType;
        set => _troopType = value;
    }

    public string Name
    {
        get => _name;
        set => _name = value;
    }

    public Sprite Image
    {
        get => _image;
        set => _image = value;
    }

    public int BuyingPriceCrystal
    {
        get => _buyingPriceCrystal;
        set => _buyingPriceCrystal = value;
    }

    public int BuyingPriceFood
    {
        get => _buyingPriceFood;
        set => _buyingPriceFood = value;
    }

    public int BuyingPriceEnergy
    {
        get => _buyingPriceEnergy;
        set => _buyingPriceEnergy = value;
    }

        
}