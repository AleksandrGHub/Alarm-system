using UnityEngine;

public class Bank : MonoBehaviour
{
    [SerializeField] private Trigger _trigger;

    private HouseExterior _houseExterior;
    private HouseInterior _houseInterior;

    private void OnEnable()
    {
        _trigger.TriggerOccupied += SetActiveHouseExteriorFalse;
        _trigger.TriggerOccupied += SetActiveHouseInteriorTrue;
        _trigger.TriggerVacated += SetActiveHouseExteriorTrue;
        _trigger.TriggerVacated += SetActiveHouseInteriorFalse;
    }

    private void OnDisable()
    {
        _trigger.TriggerOccupied -= SetActiveHouseExteriorFalse;
        _trigger.TriggerOccupied -= SetActiveHouseInteriorTrue;
        _trigger.TriggerVacated -= SetActiveHouseExteriorTrue;
        _trigger.TriggerVacated -= SetActiveHouseInteriorFalse;
    }
    private void Start()
    {
        _houseExterior = GetComponentInChildren<HouseExterior>();
        _houseInterior = GetComponentInChildren<HouseInterior>();
        _houseInterior.gameObject.SetActive(false);
        _houseExterior.gameObject.SetActive(true);
    }

    private void SetActiveHouseExteriorTrue()
    {
        _houseExterior.gameObject.SetActive(true);
    }

    private void SetActiveHouseExteriorFalse()
    {
        _houseExterior.gameObject.SetActive(false);
    }

    private void SetActiveHouseInteriorTrue()
    {
        _houseInterior.gameObject.SetActive(true);
    }

    private void SetActiveHouseInteriorFalse()
    {
        _houseInterior.gameObject.SetActive(false);
    }
}