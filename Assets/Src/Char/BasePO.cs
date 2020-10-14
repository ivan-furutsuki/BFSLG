using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Map;
using Command;

namespace Character
{
    /// <summary>
    /// 在一场战事中,地图上可出现的所有可互动物体(具备指令的,以及被指令作用)
    /// </summary>
    public class BasePO : MonoBehaviour
    {
        /// <summary>
        /// 用以表示的血量
        /// </summary>
        public virtual float HP
        {
            get { return hp;}
        }

        /// <summary>
        /// 该物体已被摧毁
        /// </summary>
        public bool isDead
        {
            get { return hp <= 0; }
        }

        /// <summary>
        /// 可操作的血量值
        /// </summary>
        protected float hp;

        /// <summary>
        /// 物体的识别符号
        /// </summary>
        public string Idetntifier
        {
            get;
        }

        /// <summary>
        /// 物体的名字
        /// </summary>
        public string Name
        {
            get;private set;
        }

        /// <summary>
        /// 从信息库中生成的
        /// </summary>
        protected string createKey;

        /// <summary>
        /// 位置
        /// </summary>
        public MapControl.坐标 Position;
        /// <summary>
        /// 朝向
        /// </summary>
        public MapControl.坐标 Direction;

        /// <summary>
        /// 该物体可使用的指令列表
        /// </summary>
        protected List<BaseCommand> CommadList;

        /// <summary>
        /// 一个物体占用自身格(0,0)以外的格子
        /// </summary>
        protected List<MapControl.坐标> extraSpace;

        /// <summary>
        /// Buff中控
        /// </summary>
        public BuffControl buffControl;

        /// <summary>
        /// 用以初始化每个
        /// </summary>
        public virtual void Init()
        {

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

}

