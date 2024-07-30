using System;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace COMMON_PROJECT_STRUCTURE_API.services
{
    public class trainers
    {
        dbServices ds = new dbServices();

        public async Task<responseData> Trainers(requestData rData)
        {
            responseData resData = new responseData();

            try
            {
                // Insert new subscription
                var insertQuery = @"insert into pc_student.Trainers(image,imagename,name,experience,work) values(@image,@imagename,@name,@experience,@work)";
                MySqlParameter[] insertParams = new MySqlParameter[]
                {
                    // new MySqlParameter("@id", rData.addInfo["id"]),
                    new MySqlParameter("@image", rData.addInfo["image"]),
                    new MySqlParameter("@imagename", rData.addInfo["imagename"]),
                    new MySqlParameter("@name", rData.addInfo["name"]),
                    new MySqlParameter("@experience", rData.addInfo["experience"]),
                    new MySqlParameter("@work", rData.addInfo["work"])
 
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