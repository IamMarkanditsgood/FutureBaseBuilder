using System;
using MainLevel.Data;

namespace Systems.Events
{
    public static class ResourcesEventManager
    {
        public static event Action<int, ResourceTypes> OnResourceModify;
        
        public static void ResourceModify(int amount, ResourceTypes type)
        {
            OnResourceModify?.Invoke(amount, type);
        }
        
    }
}