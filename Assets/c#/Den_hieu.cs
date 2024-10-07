using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Den_hieu : MonoBehaviour
{
    public enemy_move.huong chieu;

    public changecolor tren, duoi, phai, trai;

    private void Start()
    {
        chieu = enemy_move.huong.khongco;
    }

    // Update is called once per frame
    void Update()
    {
        baoden();
    }

    public void setchieu(enemy_move.huong ch)
    {
        chieu = ch;
    }

    void baoden()
    {
        switch (chieu)
        {
            case enemy_move.huong.xuong:
                {
                    tren.chieumau(true);
                    duoi.chieumau(false);
                    phai.chieumau(false);
                    trai.chieumau(false);
                    break;
                }
            case enemy_move.huong.len:
                {
                    duoi.chieumau(true);
                    tren.chieumau(false);
                    phai.chieumau(false);
                    trai.chieumau(false);
                    break;
                }
            case enemy_move.huong.trai:
                {
                    phai.chieumau(true);
                    tren.chieumau(false);
                    duoi.chieumau(false);
                    trai.chieumau(false);
                    break;
                }
            case enemy_move.huong.phai:
                {
                    trai.chieumau(true);
                    tren.chieumau(false);
                    duoi.chieumau(false);
                    phai.chieumau(false);
                    break;
                }
            default:
                {
                    break;
                }
        }
    }


}
