using Newtonsoft.Json;
using SalesOrder.Shared.DTOs;

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
    }
}