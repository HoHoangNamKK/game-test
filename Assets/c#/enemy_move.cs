using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_move : MonoBehaviour
{
    UI ui;
    public enum huong {len, xuong, phai, trai, khongco};

    public huong chieu;

    public bool quay_lai;

    public float Speed;

    public float quaylai_x, quaylai_y;

    bool d_tam = false, da_ql = false;

    int Max_x = 15, Max_y = 15, Min_x = -15, Min_y = -15;

    private void Start()
    {
        ui = FindObjectOfType<UI>();
    }

    // Update is called once per frame
    void Update()
    {
        kt();
        doi_c();
        xoa_ql();
        enemy_dichuyen();
    }

    public void enemy_dichuyen()
    {
        switch (chieu)
        {
            case huong.len:
                {
                    transform.position += Vector3.up * Speed * Time.deltaTime;
                    break;
                }
            case huong.xuong:
                {
                    transform.position += Vector3.down * Speed * Time.deltaTime;
                    break;
                }
            case huong.phai:
                {
                    transform.position += Vector3.right * Speed * Time.deltaTime;
                    break;
                }
            case huong.trai:
                {
                    transform.position += Vector3.left * Speed * Time.deltaTime;
                    break;
                }
            default:
                break;
        }
    }
    private void kt()
    {
        if (da_ql == false)
        switch (chieu)
        {
            case huong.len:
                {
                    if (transform.position.y >= quaylai_y) d_tam = true;
                    break;
                }
            case huong.xuong:
                {
                    if (transform.position.y <= quaylai_y) d_tam = true;
                    break;
                }
            case huong.phai:
                {
                    if (transform.position.x >= quaylai_x) d_tam = true;
                    break;
                }
            case huong.trai:
                {
                    if (transform.position.x <= quaylai_x) d_tam = true;
                    break;
                }
            default:
                break;
        }
    }

    void xoa_ql()
    {
        if (transform.position.y > Max_y || transform.position.y < Min_y || transform.position.x > Max_x || transform.position.x < Min_x || ui.getgame() == true)
        {
           Destroy(gameObject);
            ui.AddScore(1);
        }
    }

    private void doi_c()
    {
        if (quay_lai)
        {
            if (d_tam)
                switch (chieu)
                {
                    case huong.len:
                        {
                            chieu = huong.xuong;
                            d_tam = false;
                            da_ql = true;
                            break;
                        }
                    case huong.xuong:
                        {
                            chieu = huong.len;
                            d_tam = false;
                            da_ql = true;
                            break;
                        }
                    case huong.phai:
                        {
                            chieu = huong.trai;
                            d_tam = false;
                            da_ql = true;
                            break;
                        }
                    case huong.trai:
                        {
                            chieu = huong.phai;
                            d_tam = false;
                            da_ql = true;
                            break;
                        }
                    default:
                        break;
                }
        }
    }
}