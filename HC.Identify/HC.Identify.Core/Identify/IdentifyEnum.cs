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
            图片位置=1,
            相机外部模式=2,
            仿真=3,
            保存数据=4,
            显示图形=5,
            自动存图=6
        }

        public enum ConfigEnum
        {
            图像=1,
            中软=2,
            条码=3,
            调试模式=4,
        }
        public enum SwitchEnum
        {
            上一户 = 0,
            下一户 = 1
        }
    }
}
