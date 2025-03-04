using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Text.Json;
using System.Net;
using System.Net.Mail;

namespace COMMON_PROJECT_STRUCTURE_API.services
{
   public class updatepassword
{
    public  dbServices ds = new dbServices();

   public async Task<responseData> Updatepassword(requestData rData)
		{
			responseData resData = new responseData();

            string connectionString = "server=210.210.210.50;user=test_user;password=test*123;port=2020;database=pc_student; Max Pool Size=200;";

            try
            {
                string email = rData.addInfo["EMAIL"].ToString();
                string newPassword = rData.addInfo["PASSWORD"].ToString();

                // Update password in the database
                var updatePasswordQuery = @"UPDATE pc_student.student_data SET PASSWORD = @PASSWORD WHERE EMAIL = @EMAIL";

                using (var connection = new MySqlConnection(connectionString))
                {
                    await connection.OpenAsync();

                    using (var cmd = new MySqlCommand(updatePasswordQuery, connection))
                    {
                        // Implement your password hashing logic here if necessary
                        cmd.Parameters.AddWithValue("@PASSWORD", HashPassword(newPassword));
                        cmd.Parameters.AddWithValue("@EMAIL", email);

                        int rowsAffected = await cmd.ExecuteNonQueryAsync();

                        if (rowsAffected > 0)
                        {
                            resData.rData["success"] = true;
                            resData.rData["message"] = "Password updated successfully.";
                        }
                        else
                        {
                            resData.rData["message"] = "Failed to update password.";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                resData.rData["message"] = "Exception occurred: " + ex.Message;
                Console.WriteLine("Exception in UpdatePassword: " + ex.Message);
            }

            return resData;
        }

    
        private string HashPassword(string password)
        {
            
            return password; 
        }
    }
}
