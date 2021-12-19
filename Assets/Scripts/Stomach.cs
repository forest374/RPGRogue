using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stomach : MonoBehaviour
{
    int[] m_big = new int[4];
    int[] m_column = new int[5];
    LineAge[,] m_small = new LineAge[5, 5];

    MasicStoneStatus m_stoneStatus = new MasicStoneStatus();

    public void SkillSet()
    {
        //m_big
    }

    /// <summary>
    /// 魔石の数に応じてステータスが上がる
    /// </summary>
    public void StomachCheck()
    {
        for (int c = 0; c < m_column.Length; c++)
        {
            bool bonus = true;
            LineAge lineAge = LineAge.Bug;
            for (int i = 0; i < 5; i++)
            {
                if (i == 0) 
                {
                    lineAge = m_small[c, i];
                }
                else if(lineAge != m_small[c, i]) bonus = false;

                StatusUp(m_small[c, i]);
            }

            if (bonus)
            {
                BonusUp(lineAge, m_column[c]);
            }
        }
    }

    /// <summary>
    /// 魔石の種類に応じて上げるステータスを変える
    /// </summary>
    /// <param name="age"></param>
    void StatusUp(LineAge age)
    {
        switch (age)
        {
            case LineAge.Fish:
                m_stoneStatus.HP++;
                break;
            case LineAge.Beast:
                m_stoneStatus.HP++;
                break;
            case LineAge.Slime:
                m_stoneStatus.MP++;
                break;
            case LineAge.Devil:
                m_stoneStatus.MP++;
                break;
            case LineAge.Ogre:
                m_stoneStatus.ATK++;
                break;
            case LineAge.Bird:
                m_stoneStatus.ATK++;
                break;
            case LineAge.Bug:
                m_stoneStatus.DEF++;
                break;
            case LineAge.Machine:
                m_stoneStatus.DEF++;
                break;
            default:
                break;
        }
    }

    /// <summary>
    /// 魔石ボーナスでステータスを上げる
    /// </summary>
    /// <param name="age"></param>
    /// <param name="mag"></param>
    void BonusUp(LineAge age, int mag)
    {
        switch (age)
        {
            case LineAge.Devil:
                m_stoneStatus.HP += mag;
                m_stoneStatus.MP += mag;
                break;
            case LineAge.Fish:
                m_stoneStatus.HP += mag * 2;
                break;
            case LineAge.Beast:
                m_stoneStatus.HP += mag;
                m_stoneStatus.ATK += mag;
                break;
            case LineAge.Bug:
                m_stoneStatus.HP += mag;
                m_stoneStatus.DEF += mag;
                break;
            case LineAge.Slime:
                m_stoneStatus.MP += mag * 2;
                break;
            case LineAge.Bird:
                m_stoneStatus.MP += mag;
                m_stoneStatus.ATK += mag;
                break;
            case LineAge.Machine:
                m_stoneStatus.MP += mag;
                m_stoneStatus.DEF += mag;
                break;
            case LineAge.Ogre:
                m_stoneStatus.ATK += mag;
                m_stoneStatus.DEF += mag;
                break;
            default:
                break;
        }
    }
}
