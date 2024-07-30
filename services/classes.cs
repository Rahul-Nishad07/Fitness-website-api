using System;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace COMMON_PROJECT_STRUCTURE_API.services
{
    public class classes
    {
        dbServices ds = new dbServices();

        public async Task<responseData> Classes(requestData rData)
        {
            responseData resData = new responseData();

            try
            {
                // Insert new subscription
                var insertQuery = @"insert into pc_student.Classes(image,imagename,name,duration,trainer,description,link) values(@image,@imagename,@name,@duration,@trainer,@description,@link)";
                MySqlParameter[] insertParams = new MySqlParameter[]
                {
                   
                    new MySqlParameter("@image", rData.addInfo["image"]),
                    new MySqlParameter("@imagename", rData.addInfo["imagename"]),
                    new MySqlParameter("@name", rData.addInfo["name"]),
                    new MySqlParameter("@duration", rData.addInfo["duration"]),
                    new MySqlParameter("@trainer", rData.addInfo["trainer"]),
                    new MySqlParameter("@description", rData.addInfo["description"]),
                     new MySqlParameter("@link", rData.addInfo["link"])
                     
   
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