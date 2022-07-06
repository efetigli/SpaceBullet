using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosePanel : MonoBehaviour
{
    [Header("Animation Time")]
    [SerializeField] private float time;

    [Header("Animator")]
    [SerializeField] private Animator panelAnimator;

    [Header("Panel")]
    [SerializeField] private GameObject panel;


    public void ClickClosePanelButton()
    {
        StartCoroutine(CloseAnimation());
    }

    private IEnumerator CloseAnimation()
    {
        panelAnimator.SetTrigger("Close");
        yield return new WaitForSeconds(time);
        panel.SetActive(false);
    }
}
