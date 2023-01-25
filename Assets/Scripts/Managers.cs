using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ����������� ������������� ��������� �����������.
[RequireComponent(typeof(PlayerManager))]
[RequireComponent(typeof(InventoryManager))]
public class Managers : MonoBehaviour
{
    // ����������� ��������, �������� ���������
    // ��� ���������� ��� ������� � �����������.
    public static PlayerManager Player { get; private set; }
    public static InventoryManager Inventory { get; private set; }

    // ������ �����������, ������� ���������������
    // � ����� �� ����� ��������� ������������������.
    private List<IGameManager> _startSequence;

    // ����� ������� Start().
    private void Awake()
    {
        Player = GetComponent<PlayerManager>();
        Inventory = GetComponent<InventoryManager>();

        _startSequence = new List<IGameManager>();
        _startSequence.Add(Player);
        _startSequence.Add(Inventory);
        StartCoroutine(StartupManagers());
    }

    // �������� ������ ���� �����������.
    private IEnumerator StartupManagers()
    {
        // ������������� ������ �����������
        // � ��������� ��� ������� ����� Startup().
        foreach (IGameManager manager in _startSequence)
        {
            manager.Startup();
        }

        yield return null;

        int numModuls = _startSequence.Count;
        int numReady = 0;

        // ���������� ����, ���� �� ������ ��������
        // ��� ����������.
        while (numReady < numModuls)
        {
            int lastReady = numReady;
            numReady = 0;

            foreach (IGameManager manager in _startSequence)
            {
                if (manager.status == ManagerStatus.Started)
                {
                    numReady++;
                }
            }

            if (numReady > lastReady)
            {
                Debug.Log("Progress: " + numReady + "/" + numModuls);

                // ��������� �� ���� ���� �����
                // ��������� ���������.
                yield return null;
            }
            Debug.Log("All managers started up");
        }
    }
}
