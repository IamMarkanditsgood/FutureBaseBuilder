using System;
using System.Collections.Generic;
using UnityEngine;

namespace MainLevel.Data
{
    [Serializable]
    public class LevelStructures
    {
        public static LevelStructures instance;
        
        [SerializeField] private Transform _structuresContainer;
        [SerializeField] private List<GameObject> _structuresOnScene;
        
        public Transform StructuresContainer
        {
            get => _structuresContainer;
            set => _structuresContainer = value;
        }
        
        public List<GameObject> StructuresOnScene
        {
            get => _structuresOnScene;
            set => _structuresOnScene = value;
        }
        
        public void Init()
        {
            instance = this;
        }

    }
}
