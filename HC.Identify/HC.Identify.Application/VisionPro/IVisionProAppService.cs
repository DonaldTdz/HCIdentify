using Cognex.VisionPro;
using Cognex.VisionPro.ToolBlock;
using HC.Identify.Dto.VisionPro;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HC.Identify.Application.VisionPro
{
    public interface IVisionProAppService
    {
        /// <summary>
        /// 获取相机
        /// </summary>
        CogFrameGrabbers GetFrames();

        /// <summary>
        /// 获取灰度值
        /// </summary>
        ArrayList GetToolBlockValues();

        /// <summary>
        /// 获取匹配结果
        /// </summary>
        CsvSpecification GetMatchSpecification();
    }
}
