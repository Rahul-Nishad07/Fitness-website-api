using System;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace COMMON_PROJECT_STRUCTURE_API.services
{
    public class workout
    {
        dbServices ds = new dbServices();

        public async Task<responseData> Workout(requestData rData)
        {
            responseData resData = new responseData();

            try
            {
                // Insert new subscription
                var insertQuery = @"insert into pc_student.Workout(image,imagename,name,description,reps) values(@image,@imagename,@name,@description,@reps)";
                MySqlParameter[] insertParams = new MySqlParameter[]
                {
                    new MySqlParameter("@image", rData.addInfo["image"]),
                     new MySqlParameter("@imagename", rData.addInfo["imagename"]),
                    new MySqlParameter("@name", rData.addInfo["name"]),
                    new MySqlParameter("@description", rData.addInfo["description"]),
                    new MySqlParameter("@reps", rData.addInfo["reps"])
                    
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