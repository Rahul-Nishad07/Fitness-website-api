using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace COMMON_PROJECT_STRUCTURE_API.services
{
    public class delete
    {
        dbServices ds = new dbServices();
        public async Task<responseData> Delete(requestData rData)
        {
            responseData resData = new responseData();

            try
            {
                // Your update query
                var query = @"DELETE FROM pc_student.student_data WHERE MOBILE_NO = @MOBILE_NO";
               
               
              // Check if mobile no is present in rData.addInfo and is not null or empty
                bool shouldExecuteDelete = true;

                if (shouldExecuteDelete)
                {
                    // Your parameters
                    MySqlParameter[] myParam = new MySqlParameter[]
                    {
                    new MySqlParameter("@MOBILE_NO", rData.addInfo["MOBILE_NO"]) 
                    };

                // Assuming MOBILE_NO is present in rData addInfo

                    int rowsAffected = ds.ExecuteDeleteSQL(query, myParam);

                    if (rowsAffected > 0)
                    {
                        resData.rData["rMessage"] = "delete Successfully";
                    }
                    else
                    {
                        resData.rData["rMessage"] = "No rows affected. Delete failed.";
                    }
                }
                else
                {
                    resData.rData["rMessage"] = "MOBILE_NO not provided or is empty. Delete query not executed.";
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