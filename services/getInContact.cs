using System;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace COMMON_PROJECT_STRUCTURE_API.services
{
    public class getInContact
    {
        dbServices ds = new dbServices();

        public async Task<responseData> GetInContact(requestData rData)
        {
            responseData resData = new responseData();

            try
            {
                // Insert new subscription
                var insertQuery = @"insert into pc_student.contactus(name,email,subject,message) values(@name,@email,@subject,@message)";
                MySqlParameter[] insertParams = new MySqlParameter[]
                {
                   
                  
                    new MySqlParameter("@name", rData.addInfo["name"]),
                    new MySqlParameter("@email", rData.addInfo["email"]),
                    new MySqlParameter("@subject", rData.addInfo["subject"]),
                    new MySqlParameter("@message", rData.addInfo["message"]),

   
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