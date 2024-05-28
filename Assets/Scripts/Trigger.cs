using System;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public event Action TriggerOccupied;
    public event Action TriggerVacated;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Robber>(out _))
        {
            TriggerOccupied?.Invoke();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Robber>(out _))
        {
            TriggerVacated?.Invoke();
        }
    }
}