


using System.Collections.Generic;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace COMMON_PROJECT_STRUCTURE_API.services
{
    public class loginnew
    {
        dbServices ds = new dbServices();
        public async Task<responseData> Loginnew(requestData rData)
        {
            responseData resData = new responseData();
            try
            {
                var query = @"select * from pc_student.student_data where PASSWORD=@PASSWORD AND EMAIL=@EMAIL";
                MySqlParameter[] myParam = new MySqlParameter[]
                {
             
              
                new MySqlParameter("@PASSWORD", rData.addInfo["PASSWORD"]) ,
                   new MySqlParameter("@EMAIL",rData.addInfo["EMAIL"]),
                    
                };
                var dbData = ds.executeSQL(query, myParam);
                if (dbData[0].Count() > 0)
                {
                    resData.rData["rMessage"] = "login Successfull";
                }
                else
                {
                    
                    resData.rData["rMessage"] = "Invalid Email and Password....Please try again later";
                    
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
