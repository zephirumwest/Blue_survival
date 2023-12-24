using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    // .. �����յ��� ������ ����
    public GameObject[] prefabs;

    // .. Ǯ ����� �ϴ� ����Ʈ��
    List<GameObject>[] pools;

    // ..������ ����Ʈ�� 1:1 ���� 

    private void Awake()
    {
        pools = new List<GameObject>[prefabs.Length];

        for (int i = 0; i < pools.Length; i++) {
            pools[i] = new List<GameObject>();
        }
    }

    public GameObject Get(int index)
    {
        GameObject select = null;

        // ... ������ Ǯ�� ��� (��Ȱ��ȭ ��) �ִ� ���ӿ�����Ʈ ����
           

        foreach (GameObject item in pools[index]) {
            if (!item.activeSelf)
            {
                // ... �߰��ϸ� select ������ �Ҵ�
                select = item;
                select.SetActive(true);
                break;
            }
        }

        // ... �� ã�Ҵٸ�?
            
        if (!select) {
            // ... ���Ӱ� �����ϰ�  select ������ �Ҵ�
            select = Instantiate(prefabs[index], transform);
            pools[index].Add(select);
        }

        return select;
    }
}
