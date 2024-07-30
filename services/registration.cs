


using System.Collections.Generic;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace COMMON_PROJECT_STRUCTURE_API.services
{
    public class registration
    {
        dbServices ds = new dbServices();
        public async Task<responseData> Registerr(requestData rData)
        {
            responseData resData = new responseData();
            try
            {
                var query = @"select * from pc_student.student_data where id=@id";
                MySqlParameter[] myParam = new MySqlParameter[]
                {
             
                new MySqlParameter("@EMAIL",rData.addInfo["EMAIL"]),
                 new MySqlParameter("@MOBILE_NO",rData.addInfo["MOBILE_NO"]),
                   new MySqlParameter("@PASSWORD", rData.addInfo["PASSWORD"]),
                     new MySqlParameter("@USERNAME", rData.addInfo["USERNAME"]) 
                };
                var dbData = ds.executeSQL(query, myParam);
                if (dbData[0].Count() > 0)
                {
                    resData.rData["rMessage"] = "Duplicate Credentials";
                }
                else
                {
                    var sq=@"insert into pc_student.student_data(EMAIL,MOBILE_NO,PASSWORD,USERNAME ) values(@EMAIL,@MOBILE_NO,@PASSWORD,@USERNAME)";
                     MySqlParameter[] insertParams = new MySqlParameter[]
                    {
              
                      new MySqlParameter("@EMAIL",rData.addInfo["EMAIL"]),
                 new MySqlParameter("@MOBILE_NO",rData.addInfo["MOBILE_NO"]),
                   new MySqlParameter("@PASSWORD", rData.addInfo["PASSWORD"]),
                     new MySqlParameter("@USERNAME", rData.addInfo["USERNAME"])  
                    };
                    var insertResult = ds.executeSQL(sq, insertParams);

                    resData.rData["rMessage"] = "Registration Successful";
                    
                }

            }
            catch (Exception ex)
            {

                throw;
            }
            return resData;
        }
    }
}





