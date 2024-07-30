using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace COMMON_PROJECT_STRUCTURE_API.services
{
    public class update
    {
        dbServices ds = new dbServices();
        public async Task<responseData> Update(requestData rData)
        {
            responseData resData = new responseData();

            try
            {
                // Your update query
                var query = @"UPDATE pc_student.student_data SET PASSWORD = @PASSWORD, MOBILE_NO = @MOBILE_NO, EMAIL = @EMAIL, USERNAME = @USERNAME  WHERE MOBILE_NO = @MOBILE_NO";

               
                // Your parameters
                MySqlParameter[] myParam = new MySqlParameter[]
                {
            new MySqlParameter("@PASSWORD", rData.addInfo["PASSWORD"]),
            new MySqlParameter("@MOBILE_NO", rData.addInfo["MOBILE_NO"]),
            new MySqlParameter("@EMAIL", rData.addInfo["EMAIL"]),
            new MySqlParameter("@USERNAME", rData.addInfo["USERNAME"]),
         
                };
 
                // Condition for execute the update query
                
                bool shouldExecuteUpdate = true;
                    

                if (shouldExecuteUpdate)
                {
                    int rowsAffected = ds.ExecuteUpdateSQL(query, myParam);

                    if (rowsAffected > 0)
                    {
                        resData.rData["rMessage"] = "update Successfully";
                    }
                    else
                    {
                        resData.rData["rMessage"] = "No rows affected. Update failed.";
                    }
                }
                else
                {
                    resData.rData["rMessage"] = "Condition not met. Update query not executed.";
                }
            }
            catch (Exception ex)
            {
                resData.rData["rMessage"] = "Exception occurred: " + ex.Message;
            }
            return resData;
        }

    }
}