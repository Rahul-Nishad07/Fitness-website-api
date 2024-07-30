using System;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace COMMON_PROJECT_STRUCTURE_API.services
{
    public class setbodybuilding
    {
        dbServices ds = new dbServices();

        public async Task<responseData> Setbodybuilding(requestData rData)
        {
            responseData resData = new responseData();

            try
            {
                // Insert new subscription
                var insertQuery = @"insert into pc_student.Singleclass(image,name,duration,trainer,description,deschead,description2,workbenifits,heading1,heading2,heading3,heading4) values(@image,@name,@duration,@trainer,@description,@deschead,@description2,@workbenifits,@heading1,@heading2,@heading3,@heading4)";
                MySqlParameter[] insertParams = new MySqlParameter[]
                {
                  
                    new MySqlParameter("@image", rData.addInfo["image"]),
                    new MySqlParameter("@name", rData.addInfo["name"]),
                    new MySqlParameter("@duration", rData.addInfo["duration"]),
                    new MySqlParameter("@trainer", rData.addInfo["trainer"]),
                    new MySqlParameter("@description", rData.addInfo["description"]),
                    new MySqlParameter("@deschead", rData.addInfo["deschead"]),
                    new MySqlParameter("@description2", rData.addInfo["description2"]),
                    new MySqlParameter("@workbenifits", rData.addInfo["workbenifits"]),
                    new MySqlParameter("@heading1", rData.addInfo["heading1"]),
                    new MySqlParameter("@heading2", rData.addInfo["heading2"]),
                    new MySqlParameter("@heading3", rData.addInfo["heading3"]),
                    new MySqlParameter("@heading4", rData.addInfo["heading4"])
                     
                   
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