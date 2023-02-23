using Newtonsoft.Json;
using SalesOrder.Shared.DTOs;
using SalesOrder.Shared.DTOs.JAS;
using SalesOrder.Shared.Models;

namespace SalesOrder.API.Helpers
{
    public static class ResponseSerializer
    {
        private static JsonSerializerSettings jsonOptions = new JsonSerializerSettings
        {
            Formatting = Formatting.Indented
        };

        /// <summary>
        /// Static function to write a json file for a failed response for a sales order.
        /// </summary>
        public static string CreateFailedResponseJsonFile(List<MessageDTO> messages, string fileName)
        {
            // Format
            FailedResponseStructureDTO response = new FailedResponseStructureDTO(messages);
            string json = JsonConvert.SerializeObject(response, Formatting.Indented);

            // File info
            string path = Path.Combine(Path.GetTempPath(), fileName);

            // Write file
            using (StreamWriter file = File.CreateText(path))
            {
                file.Write(json);
            }

            string fileContents = File.ReadAllText(path);
            return fileContents;
        }

        /// <summary>
        /// Static function to write a json file for a succesful response for a sales order.
        /// </summary>
        public static string CreateSuccessResponseJsonFile(Order order, string fileName)
        {
            // Format
            SuccessResponseStructureDTO response = new SuccessResponseStructureDTO(order);
            string json = JsonConvert.SerializeObject(response, Formatting.Indented);

            // File info
            string path = Path.Combine(Path.GetTempPath(), fileName);

            // Write file
            using (StreamWriter file = File.CreateText(path))
            {
                file.Write(json);
            }

            string fileContents = File.ReadAllText(path);
            return fileContents;
        }

        /// <summary>
        /// Static function to write a json file for a succesful response for a sales order [JAS].
        /// </summary>
        public static string CreateSuccessResponseJsonFile(JASSalesOrderResponseDTO order, string fileName)
        {
            // Format
            string json = JsonConvert.SerializeObject(order, Formatting.Indented);

            // File info
            string path = Path.Combine(Path.GetTempPath(), fileName);

            // Write file
            using (StreamWriter file = File.CreateText(path))
            {
                file.Write(json);
            }

            string fileContents = File.ReadAllText(path);
            return fileContents;
        }
    }
}