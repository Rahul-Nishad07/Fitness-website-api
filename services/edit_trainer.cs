using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace COMMON_PROJECT_STRUCTURE_API.services
{
    public class edit_trainer
    {
        dbServices ds = new dbServices();
        public async Task<responseData> Edit_trainer(requestData rData)
        {
            responseData resData = new responseData();

            try
            {
                // Your update query
                var query = @"UPDATE pc_student.Trainers SET image = @image,imagename = @imagename, name = @name, experience = @experience ,work = @work WHERE id = @id";

               
                // Your parameters
                MySqlParameter[] myParam = new MySqlParameter[]
                {
            new MySqlParameter("@id", rData.addInfo["id"]),        
            new MySqlParameter("@image", rData.addInfo["image"]),
            new MySqlParameter("@imagename", rData.addInfo["imagename"]),
            new MySqlParameter("@name", rData.addInfo["name"]),
             new MySqlParameter("@experience", rData.addInfo["experience"]),
              new MySqlParameter("@work", rData.addInfo["work"])
           
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