using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HC.Identify.Core.Identify
{
    public class IdentifyEnum
    {
        public enum CameraEnum
        {
            图片位置 = 1,
            相机外部模式 = 2,
            仿真 = 3,
            保存数据 = 4,
            显示图形 = 5,
            自动存图 = 6
        }

        public enum ConfigEnum
        {
            图像 = 1,
            中软 = 2,
            读码 = 3,
            调试模式 = 4,
            视觉相机沉睡 = 5,
            订单顺序模式 = 6,
            分拣线路 = 7,
            匹配值 = 8,
            相机曝光度 = 9,
            Com口 = 10,
            烟序模板 = 11,
        }
        public enum SwitchEnum
        {
            上一户 = 0,
            下一户 = 1
        }
        /// <summary>
        /// 触发模式
        /// </summary>
        public enum BurstModeEnum
        {
            手动 = 1,
            自动 = 2
        }
    }
}
