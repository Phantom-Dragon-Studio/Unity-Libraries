﻿﻿using System;
using System.Collections.Generic;
using System.Linq;
using PhantomDragonStudio.PoolingSystem;

/// <summary>
/// This pool is tracked by the Transform InstanceID
/// </summary>
[Serializable]
public class CharacterPool : IPool<ICharacter>
{
    protected int startCount = default;
    private CharacterSheet characterToPool = default;
    [ShowOnly] private int currentSize = default;
    
    private ICharacter freshInstance;
    private KeyValuePair<int, ICharacter> pointer;
    private Dictionary<int, ICharacter> pool = new Dictionary<int, ICharacter>();

    public CharacterSheet CharacterToPool => characterToPool; 
    public int StartCount => startCount;
    public int CurrentSize => currentSize;
    public void GeneratePool()
    {
        currentSize = 0;
        for (int j = 0; j < startCount; j++)
        {
            freshInstance = FactoryRequest();
            DamageablePoolHandler.AddToPool(freshInstance as IDamageable);
        }
    }

    public ICharacter FindInPool(int key)
    {
        return pool.ContainsKey(key) ? pool[key] : null;
    }

    public void AddToPool(ICharacter character)
    {
        if (!pool.ContainsKey(character.GetInstanceID()))
        {
            pool.Add(character.GetInstanceID(), character);
            character.Deactivate();
            currentSize = pool.Count;
        } else
            Debug.LogError("Attempting to add an already existing character to " + this.name);
    }

    public ICharacter RemoveFromPool(ICharacter character = null)
    {
        if (pool.Count > 0)
        {
            pointer = pool.First();
            pool.Remove(pointer.Key);
            currentSize = pool.Count;
            pointer.Value.Activate();
            return pointer.Value;
        }
        freshInstance = FactoryRequest();
        freshInstance.Activate();
        DamageablePoolHandler.AddToPool(freshInstance as IDamageable);
        
        // Debug.LogWarning("Created NEW: " + freshInstance + " with InstanceID: " + freshInstance.GetInstanceID().ToString() + " for pool: " + this);
        return freshInstance;
    }

    protected  ICharacter FactoryRequest()
    {
        return CharacterFactory.Create(characterToPool.Prefab, this);
    }
}