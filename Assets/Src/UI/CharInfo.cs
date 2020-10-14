using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CharInfo : MonoBehaviour
{
    public static CharInfo _instance;

    public Slider HPSlider;
    public Slider APSlider;
    public Slider MPSlider;

    /// <summary>
    /// 移动力
    /// </summary>
    public Text Mobility;
    /// <summary>
    /// 护甲
    /// </summary>
    public Text Armor;
    /// <summary>
    /// 命中
    /// </summary>
    public Text Accuracy;
    /// <summary>
    /// 格挡率
    /// </summary>
    public Text Defence;
    /// <summary>
    /// 闪避率
    /// </summary>
    public Text Dodge;
    /// <summary>
    /// 暴击率
    /// </summary>
    public Text Critical;

    /// <summary>
    /// 物理抗性
    /// </summary>
    public Text PhyRes;
    /// <summary>
    /// 精神抗性
    /// </summary>
    public Text PsyRes;
    /// <summary>
    /// 冲击修正
    /// </summary>
    public Text ImpMod;
    /// <summary>
    /// 冲锋强度
    /// </summary>
    public Text Charge;
    /// <summary>
    /// 护盾
    /// </summary>
    public Text Barrier;
    /// <summary>
    /// 盾牌
    /// </summary>
    public Image Sheild;

    void Awake()
    {
        _instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
