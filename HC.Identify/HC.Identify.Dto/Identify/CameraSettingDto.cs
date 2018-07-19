using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HC.Identify.Core.Identify.IdentifyEnum;

namespace HC.Identify.Dto.Identify
{
    public class CameraSettingShowDto
    {
        ///// <summary>
        ///// 主键
        ///// </summary>
        //public int Id { get; set; }

        /// <summary>
        /// 图片位置
        /// </summary>
        public string PicPath { get; set; }

        /// <summary>
        /// 相机外部模式
        /// </summary>
        public bool CameraMode { get; set; }

        /// <summary>
        /// 仿真
        /// </summary>
        public bool Simulation { get; set; }

        /// <summary>
        /// 保存数据
        /// </summary>
        public bool SaveData { get; set; }

        /// <summary>
        /// 显示图形
        /// </summary>
        public bool ShowPic { get; set; }

        /// <summary>
        /// 自动存图
        /// </summary>
        public bool AutoSave { get; set; }
    }
    public class CameraSettingCreateDto
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 配置项类型
        /// </summary>
        public CameraEnum? Code { get; set; }

        /// <summary>
        /// 配置项值
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// 配置项描述
        /// </summary>
        public string Desc { get; set; }
    }
}
