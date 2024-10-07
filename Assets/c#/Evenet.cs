using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Eve
{
    public GameObject su_kien_game;
    public float vt_x, vt_y;
    public enemy_move.huong chieu_di;
}


public class Evenet : MonoBehaviour
{
    public Den_hieu den;

    public Eve[] Enemy_spawn;

    public float dotre;

    float t_dotre;

    float m_dotre;

    int ran;

    public int Diem;

    GameObject sukien;

    int Temp = 0;

    int Temp1 = 1;

    public void setd(int n)
    {
        Diem = n;
    }

    public void replay()
    {
        t_dotre = dotre;
        Temp = 0;
        Temp1 = 1;
    }


    // Start is called before the first frame update
    void Start()
    {
        ran = 0;
        sukien = null;
        m_dotre = dotre;
        t_dotre = dotre;
    }



    // Update is called once per frame
    void Update()
    {
        leveup(Diem);
        Spawn();
        Debug.Log(t_dotre);
    }

    void leveup(int a)
    {
        if (dotre != 0.8)
        {
            if (Diem - Temp == 10)
            {
                Temp = Diem;
                t_dotre = t_dotre - 0.1f;
                Temp1 += 1;
            }
        }
    }

    public int getsp() { return Temp1; }


    void Spawn()
    {
        if (sukien == null)
        {
            ran = Random.Range(0, Enemy_spawn.Length);
            sukien = Enemy_spawn[ran].su_kien_game;
            den.setchieu(Enemy_spawn[ran].chieu_di);
        }
        Vector2 vitri = new Vector2(Enemy_spawn[ran].vt_x, Enemy_spawn[ran].vt_y);
        if (m_dotre <= 0)
        {
            Instantiate(sukien, vitri, Quaternion.identity);
            m_dotre = t_dotre;
            sukien = null;
            den.setchieu(enemy_move.huong.khongco);
        }
        else
        {
            m_dotre -= Time.deltaTime;
        }

    }

}

