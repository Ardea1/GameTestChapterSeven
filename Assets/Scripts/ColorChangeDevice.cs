using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChangeDevice : MonoBehaviour
{
    // ?????????? ?????? ? ????? ?? ??????,
    // ??? ? ???????? ??? ?????.
    public void Operate()
    {
        // ??? ????? ???????????? ????? RGB-????????
        // ? ????????? ?? 0 ?? 1.
        Color randomColor = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));

        // ???? ???????? ? ??????????? ??????? ?????????.
        GetComponent<Renderer>().material.color = randomColor;
    }
}
