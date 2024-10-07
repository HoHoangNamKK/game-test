using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changecolor : MonoBehaviour
{
    public Color mau;

    Color f_mau;

    public Renderer m_color;

    public bool doi;

    // Start is called before the first frame update
    void Start()
    {
        f_mau = m_color.material.color;
    }

    // Update is called once per frame
    void Update()
    {
        if (doi == true) doimau();
        else doilai();
    }

    public void chieumau(bool h)
    {
        doi = h;
    }

    public void doilai()
    {
        m_color.material.color = f_mau;
    }
    public void doimau()
    {
        m_color.material.color = mau;
    }
}
