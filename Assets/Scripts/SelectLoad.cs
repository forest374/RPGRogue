using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class SelectLoad : MonoBehaviour
{
    [SerializeField, Header("進路数")]
    int m_course = 3;
    [SerializeField, Header("出現％")]
    PLevel m_pLevel = default;
    [SerializeField, Header("進路先prefab")]
    CoursePregabs m_coursePrefab = default;
    [Header("")]
    [SerializeField]
    int m_space = default;
    [SerializeField]
    int m_step = default;
    [SerializeField]
    Canvas m_canvas = default;

    bool[] m_oneTime = new bool[6];
    bool m_bug = false;

    // 最初に（シード値を設定して）すべて（一定範囲）のルートを決めてそれを並べていく感じにする


    private void Start()
    {
        SettingsCheck();

        if (m_bug)
        {
            Debug.LogError("設定が間違っています！！");
            return;
        }
        TuningPercent();
        CourseDisplay();
    }


    /// <summary>
    /// 進路先をキャンバスに表示する
    /// </summary>
    private void CourseDisplay()
    {
        int random;
        Level level;
        GameObject obj;
        for (int i = 0; i < m_course; i++)
        {
            random = Random.Range(0, 100);
            level = LevelSetting(random);

            obj = Instantiate(LoadApp(level), m_canvas.transform);

            if (m_course == 3)
                obj.transform.localPosition = new Vector3(-m_space + m_space * i, 0, 0);
            else if (m_course == 6)
                obj.transform.localPosition = new Vector3(-m_space + (m_space * i) - (m_space * 3 * (i / 3)), -m_step + m_step * 2 * (i / 3), 0);
            else
                obj.transform.localPosition = new Vector3(-m_space + m_space * 2 * (i % 2), -m_step + m_step * 2 * (i / 2), 0);
        }
    }

    /// <summary>
    /// %をひとつ前のlevelと合わせた数にする
    /// </summary>
    void TuningPercent()
    {
        m_pLevel.lucky = m_pLevel.one + m_pLevel.two + m_pLevel.three + m_pLevel.boss + m_pLevel.chest;
        m_pLevel.chest = m_pLevel.one + m_pLevel.two + m_pLevel.three + m_pLevel.boss;
        m_pLevel.boss = m_pLevel.one + m_pLevel.two + m_pLevel.three;
        m_pLevel.three = m_pLevel.one + m_pLevel.two;
        m_pLevel.two = m_pLevel.one;
    }

    /// <summary>
    /// 乱数を受け取りlevelを返す
    /// </summary>
    /// <param name="random">乱数</param>
    /// <returns>進路先のレベル</returns>
    private Level LevelSetting(int random)
    {
        if (random < m_pLevel.lucky)
        {
            return Level.lucky;
        }
        else if (random < m_pLevel.chest)
        {
            return Level.chest;
        }
        else if (random < m_pLevel.boss)
        {
            return Level.boss;
        }
        else if (random < m_pLevel.three)
        {
            return Level.three;
        }
        else if (random < m_pLevel.two)
        {
            return Level.two;
        }
        else
            return Level.one;
    }

    /// <summary>
    /// levelにあった進路先を出現させる
    /// </summary>
    /// <param name="level">進路先のレベル</param>
    /// <returns>進路先のゲームオブジェクト</returns>
    private GameObject LoadApp(Level level)
    {
        switch (level)
        {
            case Level.one:
                return m_coursePrefab.one;
            case Level.two:
                return m_coursePrefab.two;
            case Level.three:
                return m_coursePrefab.three;
            case Level.boss:
                return m_coursePrefab.boss;
            case Level.chest:
                return m_coursePrefab.chest;
            case Level.lucky:
                return m_coursePrefab.lucky;
            default:
                return null;
        }
    }

    /// <summary>
    /// 設定値確認
    /// </summary>
    private void SettingsCheck()
    {
        if (m_course != 3 && m_course != 4 && m_course != 6)
        {
            m_bug = true;
            Debug.LogError("進路数は3,4,6のいずれかを設定してください");
        }

        int total = m_pLevel.one + m_pLevel.two + m_pLevel.three + m_pLevel.boss + m_pLevel.chest + m_pLevel.lucky;
        if (total != 100)
        {
            m_bug = true;
            Debug.LogError("合計値が100になっていません");
        }
        if (m_coursePrefab.one == null || m_coursePrefab.two == null || m_coursePrefab.three == null || m_coursePrefab.boss == null || m_coursePrefab.chest == null || m_coursePrefab.lucky == null)
        {
            m_bug = true;
            Debug.LogError("進路先が設定されてません");
        }

        if (m_canvas == null)
        {
            m_bug = true;
            Debug.LogError("canvasが設定されてません");
        }
    }


    [System.Serializable]
    struct PLevel
    {
        public int one;
        public int two;
        public int three;
        public int boss;
        public int chest;
        public int lucky;
    }
    enum Level
    {
        one, two, three, boss, chest, lucky
    }
    [System.Serializable]
    struct CoursePregabs
    {
        public GameObject one;
        public GameObject two;
        public GameObject three;
        public GameObject boss;
        public GameObject chest;
        public GameObject lucky;
    }



    /// <summary>
    /// ボックスミュラー法 -30～30までで約98%の確率(*10をしている)
    /// </summary>
    /// <returns>float型の数</returns>
    float RandomBoxMuller()
    {
        //　±1以内は約68% ±2以内95%(27%)
        float x = Random.Range(0, 1f);
        float y = Random.Range(0, 1f);
        float r = Mathf.Sqrt(-2 * Mathf.Log(x)) * Mathf.Cos(2 * Mathf.PI * y);

        int random = (int)r * 10;
        return random;
    }

}
