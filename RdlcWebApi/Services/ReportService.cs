using AspNetCore.Reporting;
using RdlcWebApi.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RdlcWebApi.Services
{
    public interface IReportService
    {
        //byte[] GenerateReportAsync(string type, string subType, string data);
        byte[] GenerateReportAsync(string type, string subType, Task<IEnumerable> data);
    }

    public class ReportService : IReportService
    {
        public byte[] GenerateReportAsync(string type, string subType, Task<IEnumerable> data)
        {
            string fileDirPath = Assembly.GetExecutingAssembly().Location.Replace("RdlcWebApi.dll", string.Empty);
            string rdlcFilePath = string.Format("{0}ReportFiles\\{1}_{2}.rdlc", fileDirPath, type, subType);

            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            Encoding.GetEncoding("utf-8");

            LocalReport report = new LocalReport(rdlcFilePath);

            // prepare data for report

            List<UserDto> userList = new List<UserDto>();

            var user = new UserDto { };

            Console.WriteLine(data);
            user = new UserDto { control_number = "dasdas", LastName = "Manriquez", Email = "mme@test.com", Phone = "+526561234567" };

            //switch (data)
            //{
            //    case "Manuel":
            //        user = new UserDto { control_number = "1213213123", LastName = "Manriquez", Email = "mme@test.com", Phone = "+526561234567" };
            //        break;
            //    case "Emanuel":
            //        user = new UserDto { control_number = "3123123", LastName = "Manriquez", Email = "mme@test.com", Phone = "+526561234567" };
            //        break;
            //    case "Anuel":
            //        user = new UserDto { control_number = "An3123123uel", LastName = "Manriquez", Email = "mme@test.com", Phone = "+526561234567" };
            //        break;
            //    default:
            //        user = new UserDto { control_number = "dasdasdasd", LastName = "Manriquez", Email = "mme@test.com", Phone = "+526561234567" };
            //        break;
            //}

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
