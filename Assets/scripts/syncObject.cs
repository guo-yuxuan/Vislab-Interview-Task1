using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class syncObject : MonoBehaviour
{
     // 需要同步状态的GameObjects
    public List<GameObject> linkedObjects = new List<GameObject>();

    // 更新所有linkedObjects显示状态
    private void UpdateVisibility()
    {
        foreach (var obj in linkedObjects)
        {
            if (obj != null)
            {
                obj.SetActive(gameObject.activeSelf);
            }
        }
    }

    // 当主GameObject的显示状态改变时调用
    private void OnEnable()
    {
        UpdateVisibility();
    }

    private void OnDisable()
    {
        UpdateVisibility();
    }

}
