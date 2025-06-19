using System.Collections;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using UnityEngine;
using UnityEngine.UI;

public class YouZhaGuiZi : MonoBehaviour
{
    [SerializeField] GameObject particleVisual, lightVisual;
    bool isZha;
    [SerializeField] GameObject shengVisual;
    float timer = 0, MaxTime = 6;
    [SerializeField] Slider slider;
    [SerializeField] GameObject rouPrefab;

    private void Awake()
    {
        slider.maxValue = MaxTime;
        slider.value = timer;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (isZha)
        {
            return;
        }
        ShiWu shiWu = other.GetComponent<ShiWu>();
        if (shiWu != null)
        {
            if (shiWu.type == ShiWu_Type.生肉)
            {
                Destroy(shiWu.gameObject); // 销毁原始食物
                OpenAndDown(true);

            }
        }
    }
    private void Update()
    {
        if (isZha)
        {
            timer += Time.deltaTime;
            slider.value = timer;
            if (timer >= MaxTime)
            {
                OpenAndDown(false);
                Instantiate(rouPrefab, shengVisual.transform.position, Quaternion.identity);
                timer = 0;
            }
        }

    }
    private void OpenAndDown(bool isOpen)
    {
        isZha = isOpen;
        particleVisual.SetActive(isOpen);
        lightVisual.SetActive(isOpen);
        shengVisual.SetActive(isOpen);
        slider.gameObject.SetActive(isOpen);
        AudioManager.Instance.ChossZha(shengVisual.transform.position);
    }
}
