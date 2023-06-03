using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MealComponentsBoxShowAndHider : MonoBehaviour
{
    private int _show = 1;
    private bool _inProcess = false;
    //
    private float _animFPS = 30;
    private float _deltaPos = 746 + 846;
    private float _speed = 100;

    private void Start()
    {
        Debug.Log(GetComponent<RectTransform>().anchoredPosition);
    }

    public void ShowHide()
    {
        if (!_inProcess)
        {
            StartCoroutine(ShowHideAnimation());
        }
    }

    private IEnumerator ShowHideAnimation()
    {
        _inProcess = true;
        RectTransform rectTransform = GetComponent<RectTransform>();
        float endPosX = rectTransform.anchoredPosition.x + _deltaPos * _show;
        while(!IsInPos(endPosX, rectTransform))
        {
            rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x + _speed * _show, rectTransform.anchoredPosition.y);
            yield return new WaitForSeconds(1 / _animFPS);
        }
        _show = _show * -1;
        _inProcess = false;
        yield return null;
    }

    private bool IsInPos(float endPosX, RectTransform rectTransform)
    {
        if (_show == 1)
            return rectTransform.anchoredPosition.x >= endPosX;
        else
            return rectTransform.anchoredPosition.x <= endPosX;
    }
}
