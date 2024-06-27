using UnityEngine;

public class BankExterior : MonoBehaviour
{
    private void Start()
    {
        SetActiveTrue();
    }

    public void SetActiveTrue()
    {
        gameObject.SetActive(true);
    }

    public void SetActiveFalse()
    {
        gameObject.SetActive(false);
    }
}