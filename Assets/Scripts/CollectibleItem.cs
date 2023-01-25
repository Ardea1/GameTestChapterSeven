using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleItem : MonoBehaviour
{
    // ������� ��� ����� ��������
    // �� ������ Inspector.
    [SerializeField]
    string itemName;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Item collected: " + itemName);

        Managers.Inventory.AddItem(name);

        Destroy(this.gameObject);
        /* �����.Destroy().������.����������.���.���������.this.gameObject,.�.��.this!.��.
        �������.���.����;.��������.�����.this.���������.������.��.���������.��������,.�.��.�����.���.��-
        �������.this.gameObject.���������.��.������,.�.��������.�����������.��������. */
    }
}
