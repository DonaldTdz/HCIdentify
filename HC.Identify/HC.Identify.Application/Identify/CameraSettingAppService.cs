using HC.Identify.Dto.Identify;
using HC.Identify.EntityFramework.Services.Identify;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HC.Identify.Application.Identify
{
    public class CameraSettingAppService
    {
        private CameraSettingService cameraSettingService;
        public CameraSettingAppService()
        {
            cameraSettingService = new CameraSettingService();
        }
        public bool SaveCameraSetting(List<CameraSettingCreateDto> cameraSettings)
        {
            return cameraSettingService.SaveCameraSetting(cameraSettings);
        }

        public IList<CameraSettingCreateDto> GetCameraSetting()
        {
            return cameraSettingService.GetCameraSetting();
        }

        public bool UpdateSingleSetting(CameraSettingCreateDto dto)
        {
            var result = cameraSettingService.UpdateSingleSetting(dto);
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
