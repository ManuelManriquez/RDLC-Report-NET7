using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RdlcWebApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;

namespace RdlcWebApi.Controllers
{
    [Route("procedure/print")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private IReportService _reportService;

        public ReportController(IReportService reportService)
        {
            _reportService = reportService;
        }

        [HttpGet("{type}/{subType}/{data}")]
        public ActionResult Get(string type, string subType, string data)
        {
            var reportNameWithLang = type + "_" + subType;
            var reportFileByteString = _reportService.GenerateReportAsync(type, subType, data);
            return File(reportFileByteString, MediaTypeNames.Application.Octet, getReportName(reportNameWithLang, ".pdf"));
        }


        private string getReportName(string type, string subType)
        {
            var outputFileName = type + subType + ".pdf";
            return outputFileName;
        }

    }
}
