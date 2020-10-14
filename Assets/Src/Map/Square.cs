using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Character;

namespace Map
{
    /// <summary>
    /// 地格
    /// </summary>
    public class Square : MonoBehaviour
    {
        /// <summary>
        /// 该格子内所持有的全部物体,原则上角色使用0号索引
        /// </summary>
        public List<BasePO> 物体Hold;

        /// <summary>
        /// 格子的所在位置,绝对坐标表示
        /// </summary>
        public MapControl.坐标 Position;
        /// <summary>
        /// 地格高度
        /// </summary>
        public float Height
        {
            get; private set;
        }
        /// <summary>
        /// 设置坐标的初始化方法
        /// </summary>
        /// <param name="X">东西方向(绝对表示法,0起始)</param>
        /// <param name="Y">南北方向(同上)</param>
        public void SetPosition(int X, int Y)
        {
            Position.x = X;
            Position.y = Y;
            this.transform.Translate(new Vector3(X, 0, Y));
        }
        public void SetHeight(float H)
        {
            this.Height = H;
            this.transform.Translate(Vector3.up * H);
        }
        public void SetPosition(int X, int Y,float H)
        {
            SetPosition(X, Y);
            SetHeight(H);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="moving"></param>
        /// <returns></returns>
        public virtual float CostMobility(BaseChar moving)
        {
            return 1;
        }

        public SqureType Type = SqureType.平地;
        public List<SqureTag> Tags = new List<SqureTag>();

        // Start is called before the first frame update
        void Start()
        {
        }

        public override string ToString()
        {
            return string.Format("SQUARE>>Position[X:{0},Y:{1}];Height:{2};Type:{3} ", Position.x, Position.y,Height, Type);
        }

        // Update is called once per frame
        void Update()
        {
            
        }
        public enum SqureType
        {

            /// <summary>
            /// 平地
            /// </summary>
            平地,
            /// <summary>
            /// 树林
            /// </summary>
            树林,
            /// <summary>
            /// 草地
            /// </summary>
            草地,
            /// <summary>
            /// 深水
            /// </summary>
            深水,
            /// <summary>
            /// 浅水
            /// </summary>
            浅水,
            /// <summary>
            /// 山地
            /// </summary>
            山地,
            /// <summary>
            /// 悬空
            /// </summary>
            悬空,
            /// <summary>
            /// 不整
            /// </summary>
            不整
        }

        public enum SqureTag
        {
            不可进入, 燃烧, 阻拦大型
        }


    }
}

