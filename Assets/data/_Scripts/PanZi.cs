using UnityEngine;

public class PanZi : MonoBehaviour
{
    bool isBread, isCai, isNaiLao, isTamato, isRou;

    // 需要在 Inspector 中挂好
    public GameObject bread;
    public GameObject cai;
    public GameObject naiLao;
    public GameObject tamato;
    public GameObject rou;

    private void OnTriggerEnter(Collider other)
    {
        ShiWu shiwu = other.GetComponent<ShiWu>();
        if (shiwu == null) return;
        bool isTrg = false;

        switch (shiwu.type)
        {
            case ShiWu_Type.面包:
                if (!isBread)
                {
                    isBread = true;
                    isTrg = true;
                    if (bread != null) bread.SetActive(true);
                }
                break;

            case ShiWu_Type.生菜片:
                if (!isCai)
                {
                    isCai = true;
                    isTrg = true;
                    if (cai != null) cai.SetActive(true);
                }
                break;

            case ShiWu_Type.西红柿片:
                if (!isTamato)
                {
                    isTamato = true;
                    isTrg = true;
                    if (tamato != null) tamato.SetActive(true);
                }
                break;

            case ShiWu_Type.奶酪片:
                if (!isNaiLao)
                {
                    isNaiLao = true;
                    isTrg = true;
                    if (naiLao != null) naiLao.SetActive(true);
                }
                break;

            case ShiWu_Type.熟肉:
                if (!isRou)
                {
                    isRou = true;
                    isTrg = true;
                    if (rou != null) rou.SetActive(true);
                }
                break;
        }

        if (isTrg)
        {
            Destroy(shiwu.gameObject);
        }
    }
}
