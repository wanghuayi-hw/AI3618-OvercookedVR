using System.Collections;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GuiZi : MonoBehaviour
{
    public GameObject foodPrefab;      // 可抓取物体的预制体
    public Transform spawnPoint;       // 食品生成位置
    public float rotateSpeed = 45f;    // 每秒旋转角度

    private GameObject currentFood;

    private void Start()
    {
        SpawnFood();
    }

    private void Update()
    {
        if (currentFood == null)
        {
            SpawnFood();
        }
        else
        {
            // 持续旋转
            currentFood.transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime);
        }
    }
    private void SpawnFood()
    {
        currentFood = Instantiate(foodPrefab, spawnPoint.position, Quaternion.identity);

        Rigidbody rb = currentFood.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.useGravity = false;
            rb.isKinematic = true;
        }

        XRGrabInteractable grab = currentFood.GetComponent<XRGrabInteractable>();
        if (grab != null)
        {
            grab.throwOnDetach = false;

            grab.selectExited.RemoveListener(OnFoodReleased);
            grab.selectExited.AddListener(OnFoodReleased);
        }
    }

    private void OnFoodReleased(SelectExitEventArgs args)
    {
        GameObject releasedObject = args.interactableObject.transform.gameObject;

        if (releasedObject == currentFood)
        {
            Rigidbody rb = releasedObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.useGravity = true;
                rb.isKinematic = false;
            }

            currentFood = null;
        }
    }


}
