using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GrabBag<T> : IDisposable
{
    protected struct Item
    {
        public T obj;
        public float weight;

        public Item(T obj, float _weight)
        {
            this.obj = obj;
            weight = _weight;
        }
    }

    private bool disposed;

    private List<Item> weightedItems = new List<Item>();

    public void AddItem(T obj, float weight)
    {
        Item item = new Item(obj, weight);
        weightedItems.Add(item);
    }

    public void Dispose()
    {
        if (disposed)
            return;
        disposed = true;
    }

    public T Grab()
    {
        float totalWeight = 0f;

        foreach (Item item in weightedItems)
        {
            float weight = item.weight;
            totalWeight += weight;
        }

        float randomWeight = Random.Range(0, totalWeight);
        T chosenObject = default;

        foreach (Item item in weightedItems)
        {
            T obj = item.obj;
            float weight = item.weight;

            if (randomWeight < weight)
            {
                chosenObject = obj;
                break;
            }

            randomWeight -= weight;
        }

        return chosenObject;
    }

    public void Reset()
    {
        weightedItems.Clear();
    }

    public void Shuffle()
    {

    }
}
