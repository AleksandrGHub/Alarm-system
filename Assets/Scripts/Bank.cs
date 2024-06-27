using UnityEngine;

public class Bank : MonoBehaviour
{
    [SerializeField] private Siren _siren;
    [SerializeField] private BankExterior _bankExterior;
    [SerializeField] private BankInterior _bankInterior;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Robber>(out _))
        {
            _siren.TurnOnSiren();
            _bankExterior.SetActiveFalse();
            _bankInterior.SetActiveTrue();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Robber>(out _))
        {
            _siren.TurnOffSiren();
            _bankExterior.SetActiveTrue();
            _bankInterior.SetActiveFalse();
        }
    }
}