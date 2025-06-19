using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class QieCaiGuiZi : MonoBehaviour
{
    ShiWu_Type MyShiWu = ShiWu_Type.空;  // 默认设置为空
    const int MaxIndex = 4;

    [SerializeField] Slider slider;

    [SerializeField] GameObject CaiPrefab, NaiLaoPrefab, TomatoPrefab;
    [SerializeField] Transform CutPoint;

    [SerializeField] GameObject CaiVisual, NaiLaoVisual, TomatoVisual;

    private void Awake()
    {
        slider.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Knife") && MyShiWu != ShiWu_Type.空)
        {
            slider.value++;
            if (slider.value >= slider.maxValue)
            {
                SpawnCutPrefab(MyShiWu);
                ResetState();
            }
            AudioManager.Instance.Play(YinXiao.切菜);
            return;
        }

        ShiWu shiWu = other.GetComponent<ShiWu>();
        if (shiWu != null && MyShiWu == ShiWu_Type.空)
        {
            if (shiWu.type == ShiWu_Type.生菜 || shiWu.type == ShiWu_Type.西红柿 || shiWu.type == ShiWu_Type.奶酪)
            {
                MyShiWu = shiWu.type;
                Destroy(shiWu.gameObject); // 销毁原始食物

                slider.maxValue = MaxIndex;
                slider.value = 0;
                slider.gameObject.SetActive(true);

                ShowVisual(MyShiWu);
            }
        }
    }

    void SpawnCutPrefab(ShiWu_Type type)
    {
        GameObject prefab = null;
        switch (type)
        {
            case ShiWu_Type.生菜:
                prefab = CaiPrefab;
                break;
            case ShiWu_Type.西红柿:
                prefab = TomatoPrefab;
                break;
            case ShiWu_Type.奶酪:
                prefab = NaiLaoPrefab;
                break;
        }

        if (prefab != null)
        {
            Instantiate(prefab, CutPoint.position, Quaternion.identity);
        }
    }

    void ShowVisual(ShiWu_Type type)
    {
        CaiVisual.SetActive(false);
        TomatoVisual.SetActive(false);
        NaiLaoVisual.SetActive(false);

        switch (type)
        {
            case ShiWu_Type.生菜:
                CaiVisual.SetActive(true);
                break;
            case ShiWu_Type.西红柿:
                TomatoVisual.SetActive(true);
                break;
            case ShiWu_Type.奶酪:
                NaiLaoVisual.SetActive(true);
                break;
        }
    }

    void ResetState()
    {
        MyShiWu = ShiWu_Type.空;
        slider.gameObject.SetActive(false);
        slider.value = 0;

        CaiVisual.SetActive(false);
        TomatoVisual.SetActive(false);
        NaiLaoVisual.SetActive(false);
    }
}
