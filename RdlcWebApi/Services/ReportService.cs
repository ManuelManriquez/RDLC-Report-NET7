using AspNetCore.Reporting;
using RdlcWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RdlcWebApi.Services
{
    public interface IReportService
    {
        byte[] GenerateReportAsync(string type, string subType, string data);
    }

    public class ReportService : IReportService
    {
        public byte[] GenerateReportAsync(string type, string subType, string data)
        {
            string fileDirPath = Assembly.GetExecutingAssembly().Location.Replace("RdlcWebApi.dll", string.Empty);
            string rdlcFilePath = string.Format("{0}ReportFiles\\{1}_{2}.rdlc", fileDirPath, type, subType);

            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            Encoding.GetEncoding("utf-8");

            LocalReport report = new LocalReport(rdlcFilePath);

            // prepare data for report
            List<UserDto> userList = new List<UserDto>();

            var user = new UserDto { };
            switch (data)
            {
                case "Manuel":
                    user = new UserDto { FirstName = "Manuel", LastName = "Manriquez", Email = "mme@test.com", Phone = "+526561234567" };
                    break;
                case "Emanuel":
                    user = new UserDto { FirstName = "Emanuel", LastName = "Manriquez", Email = "mme@test.com", Phone = "+526561234567" };
                    break;
                case "Anuel":
                    user = new UserDto { FirstName = "Anuel", LastName = "Manriquez", Email = "mme@test.com", Phone = "+526561234567" };
                    break;
                default:
                    user = new UserDto { FirstName = "Default", LastName = "Manriquez", Email = "mme@test.com", Phone = "+526561234567" };
                    break;
            }



            userList.Add(user);

            report.AddDataSource("dsUsers", userList);

            Dictionary<string, string> parameters = new Dictionary<string, string>();
            var result = report.Execute(GetRenderType("pdf"), 1, parameters);

            return result.MainStream;
        }

        private RenderType GetRenderType(string reportType)
        {
            var renderType = RenderType.Pdf;
            return renderType;
        }

    }
}
