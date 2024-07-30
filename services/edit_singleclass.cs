using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace COMMON_PROJECT_STRUCTURE_API.services
{
    public class edit_singleclass
    {
        dbServices ds = new dbServices();
        public async Task<responseData> Edit_singleclass(requestData rData)
        {
            responseData resData = new responseData();

            try
            {
                // Your update query
                var query = @"UPDATE pc_student.Singleclass SET image = @image, name = @name, duration = @duration, trainer = @trainer, description = @description , deschead = @deschead , description2 = @description2, workbenifits = @workbenifits, heading1 = @heading1, heading2 = @heading2, heading3 = @heading3, heading4 = @heading4 WHERE id = @id";

               
                // Your parameters
                MySqlParameter[] myParam = new MySqlParameter[]
                {
            new MySqlParameter("@id", rData.addInfo["id"]),        
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
                      new MySqlParameter("@heading4", rData.addInfo["heading4"]),
           
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