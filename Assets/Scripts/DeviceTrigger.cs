using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeviceTrigger : MonoBehaviour
{
    // ������ ������� ��������, �������
    // ����� ������������ ������ �������.
    [SerializeField]
    GameObject[] targets;

    [SerializeField]
    public bool requireKey;

    // ����� OnTriggerEnter() ���������� ��� ���������
    // ������� � ���� ��������.
    private void OnTriggerEnter(Collider other)
    {
        // �������� ���������� ��� ������
        // ��������������� � ������������� �����.
        if (requireKey && Managers.Inventory.equippedItem != "key")
        {
            return;
        }

        foreach (GameObject target in targets)
        {
            target.SendMessage("Activate");
        }
    }

    // ����� OnTriggerExit() ���������� ��� ������
    // �� ���� ��������.
    private void OnTriggerExit(Collider other)
    {
        foreach (GameObject target in targets)
        {
            target.SendMessage("Deactivate");
        }
    }
}
