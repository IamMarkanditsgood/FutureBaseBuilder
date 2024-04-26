using System;
using System.Collections;
using System.Collections.Generic;
using Systems.Events;
using Enteties.Buildings;
using UI.Level;
using UnityEngine;
using UnityEngine.UI;

public class ShopPanelManager : BasicPanelManager
{
    //TODO
    [SerializeField] private Button _buyMiner;
    [SerializeField] private Button _buyFarm;
    [SerializeField] private Button _buyReactor;
    
    
    private ByingParamethers _byingParamethers = new ByingParamethers();

    private void Start()
    {
        Subscribe();
    }
    private void OnDestroy()
    {
        Unsubscribe();
    }

    private void Subscribe()
    {
        _buyMiner.onClick.AddListener(BuyMiner);
        _buyFarm.onClick.AddListener(BuyFarm);
        _buyReactor.onClick.AddListener(BuyReactor);
        _close.onClick.AddListener(ClosePanel);   
    }

    private void Unsubscribe()
    {
        _buyMiner.onClick.RemoveListener(BuyMiner);
        _buyFarm.onClick.RemoveListener(BuyFarm);
        _buyReactor.onClick.RemoveListener(BuyReactor);
        _close.onClick.RemoveListener(ClosePanel);    
    }
    public void Init(ByingParamethers byingParamethers)
    {
        _byingParamethers = byingParamethers;
    }
    private void BuyMiner()
    {
        _byingParamethers.BuildingTypes = BuildingTypes.Miner;
        LevelEventManager.BuyBuild(_byingParamethers);
        gameObject.SetActive(false);
    }
    private void BuyFarm()
    {
        _byingParamethers.BuildingTypes = BuildingTypes.Farm;
        LevelEventManager.BuyBuild(_byingParamethers);
        gameObject.SetActive(false);
    }
    private void BuyReactor()
    {
        _byingParamethers.BuildingTypes = BuildingTypes.Reactor;
        LevelEventManager.BuyBuild(_byingParamethers);
        gameObject.SetActive(false);
    }
}