using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleManager : MonoBehaviour
{
    public List<Toggle> toggles; // Toggle列表
    public List<GameObject> gameObjects; // 对应GameObject列表
    public bool hideAllOnStart = true;

    private Dictionary<Toggle, GameObject> toggleToObjectMapping;

    void Start()
    {
        toggleToObjectMapping = new Dictionary<Toggle, GameObject>();

        for (int i = 0; i < toggles.Count; i++)
        {
            Toggle currentToggle = toggles[i];
            toggleToObjectMapping[currentToggle] = gameObjects[i];
            currentToggle.onValueChanged.AddListener((bool isOn) => ToggleChanged(currentToggle, isOn));
        }

        // 初始时根据Toggle的状态设置GameObject
        foreach (var toggle in toggles)
        {
            GameObject obj;
            if (toggleToObjectMapping.TryGetValue(toggle, out obj))
            {
                obj.SetActive(toggle.isOn);
            }
        }

        //初始隐藏
        if (hideAllOnStart)
        {
            foreach (var gameObject in gameObjects)
            {
                gameObject.SetActive(false);
            }
        }
    }

    void ToggleChanged(Toggle toggle, bool isOn)
    {
        // 隐藏所有的 GameObjects
        foreach (var obj in gameObjects)
        {
            obj.SetActive(false);
        }

        // 显示当前被选中的 GameObject
        GameObject selectedObject;
        if (toggleToObjectMapping.TryGetValue(toggle, out selectedObject))
        {
            selectedObject.SetActive(isOn);
        }
    }
}
