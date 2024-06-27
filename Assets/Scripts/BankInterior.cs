using UnityEngine;

public class BankInterior : MonoBehaviour
{
    private void Start()
    {
        SetActiveFalse();
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