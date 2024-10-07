using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class UI : MonoBehaviour
{
    int m_speed = 1, m_diem = 0, Highscore = 0;

    public Text Diem;

    public Text c_Diem;

    public Text diemcaonhat;

    public GameObject PLAY;

    public GameObject PAUSE;

    public GameObject GAMEOVER;

    public GameObject nut;

    public Text score2;

    public Text Speed;

    public Evenet chuyendiem;

    public void tamdung()
    {
        PAUSE.SetActive(true);
        PLAY.SetActive(false);
        Time.timeScale = 0f;
    }

    public void choitiep()
    {
        PAUSE.SetActive(false);
        PLAY.SetActive(true);
        Time.timeScale = 1f;
    }

    bool gameover = false;

    public bool getgame() { return gameover; }

    public int diem_luu;


    public void doc()
    {
        FileStream fs = new FileStream("save.txt", FileMode.Open);
        StreamReader rd = new StreamReader(fs, Encoding.UTF8);
        string temp = rd.ReadToEnd();
        diem_luu = Convert.ToInt32(temp);
        rd.Close();
        fs.Close();
    }


    public void luu(int a)
    {
        FileStream fw = new FileStream("save.txt", FileMode.Open);
        StreamWriter wd = new StreamWriter(fw, Encoding.UTF8);
        wd.Write(a.ToString());
        wd.Close();
        fw.Close();
    }

    public void themtocdo()
    {
        if (m_speed <= 9)
        {
            Speed.text = "SPEED : " + m_speed;
        }
        else
        {
            Speed.text = "SPEED : HARD";
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        doc();
        Highscore = diem_luu;
        chuyendiem = FindObjectOfType<Evenet>();
    }

    // Update is called once per frame
    void Update()
    {
        c_Diem.text = "Score: " + m_diem;
        Diem.text = "Score: " + m_diem;
        if (Highscore < m_diem) Highscore = m_diem;
        diemcaonhat.text = "HIGH SCORE : " + Highscore;
        score2.text = "HIGH SCORE : " + Highscore;
        m_speed = chuyendiem.getsp();
        themtocdo();
        chuyendiem.setd(m_diem);
        if (diem_luu < Highscore) luu(Highscore);
    }


    public void AddScore(int n) { if (gameover == false) m_diem += n; }

    public void overgame()
    {
        hienthongbao(true);
    }

    public void REPLAY()
    {
        hienthongbao(false);
        gameover = false;
        PLAY.SetActive(true);
        nut.SetActive(true);
        m_diem = 0;
        Time.timeScale = 1f;
        chuyendiem.replay();
    }    

    public void hienthongbao(bool hien)
    {
        if (GAMEOVER) GAMEOVER.SetActive(hien);
        gameover = true;
        if (hien == true)
        {
            PLAY.SetActive(false);
            nut.SetActive(false);
        }
    }
}
