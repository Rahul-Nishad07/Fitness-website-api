using System;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace COMMON_PROJECT_STRUCTURE_API.services
{
    public class getInformation
    {
        dbServices ds = new dbServices();

        public async Task<responseData> GetInformation(requestData rData)
        {
            responseData resData = new responseData();

            try
            {
                // Insert new subscription
                var insertQuery = @"insert into pc_student.information(name,duration,trainer,description,image) values(@name,@duration,@trainer,@description,@image)";
                MySqlParameter[] insertParams = new MySqlParameter[]
                {
                   
                  
                    new MySqlParameter("@fname", rData.addInfo["fname"]),
                    new MySqlParameter("@lname", rData.addInfo["lname"]),
                    new MySqlParameter("@email", rData.addInfo["email"]),
                    new MySqlParameter("@phone", rData.addInfo["phone"]),
                    new MySqlParameter("@dateOfbirth", rData.addInfo["dateOfbirth"]),
                    new MySqlParameter("@address", rData.addInfo["address"]),
                    new MySqlParameter("@message", rData.addInfo["message"])
   
                };

                var insertResult = ds.executeSQL(insertQuery, insertParams);

                resData.rData["rMessage"] = "Successfull";
            }
            catch (Exception ex)
            {
                resData.rData["rMessage"] = "An error occurred: " + ex.Message;
                // Log the exception as needed
            }

            return resData;
        }
    }
}