using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cognex.VisionPro;
using Cognex.VisionPro.ToolBlock;
using HC.Identify.Application.Helpers;
using HC.Identify.Dto.VisionPro;

namespace HC.Identify.Application.VisionPro
{
    public class VisionProAppService : IdentifyAppServiceBase, IVisionProAppService
    {
        CogToolBlock _cogToolBlock;
        ICogImage _icogColorImage;
        CogRecordDisplay _cogRecordDisplay;
        string _appPath;
        List<CsvSpecification> _csvSpecList = new List<CsvSpecification>();

        public VisionProAppService(CogToolBlock cogToolBlock, ICogImage icogColorImage, CogRecordDisplay cogRecordDisplay, string appPath)
        {
            _cogToolBlock = cogToolBlock;
            _icogColorImage = icogColorImage;
            _cogRecordDisplay = cogRecordDisplay;
            _appPath = appPath;
            _csvSpecList = VisionProDataAppService.Instance.GetCsvSpecificationList();
        }

        public CogFrameGrabbers GetFrames()
        {
            CogFrameGrabbers mFrameGrabbers = new CogFrameGrabbers();
            return mFrameGrabbers;
        }

        public CsvSpecification GetMatchSpecification()
        {
            var tbvals = GetToolBlockValues();
            if (tbvals.Count == 0)
            {
                CommHelper.WriteLog(_appPath, "GetMatchSpecification->GetToolBlockValues", "没有读取到值");
                return null;
            }

            return null;
        }

        public ArrayList GetToolBlockValues()
        {
            _cogToolBlock.Inputs["InputImage"].Value = _icogColorImage;
            _cogToolBlock.Inputs["iRow"].Value = 4;
            _cogToolBlock.Inputs["iCol"].Value = 12;
            _cogToolBlock.Inputs["bForceLeft"].Value = false;    //左边线错误
            _cogToolBlock.Inputs["bForceRight"].Value = false;   //右边线错误
            _cogToolBlock.Inputs["bShowGraphic"].Value = false;  //显示图形
            _cogToolBlock.Run();

            ICogRecords subRecords = _cogToolBlock.CreateLastRunRecord().SubRecords;
            _cogRecordDisplay.Record = subRecords["CogIPOneImageTool1.OutputImage"];
            _cogRecordDisplay.Fit(true);
            return (ArrayList)_cogToolBlock.Outputs["SubRectValues"].Value;
        }
    }
}
