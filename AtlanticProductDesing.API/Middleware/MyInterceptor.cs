using Newtonsoft.Json.Linq;
using NLog;
using System.Security.Cryptography;
using System.Text;

namespace AtlanticProductDesing.API.Middleware
{

    public class MyInterceptor
    {
        private readonly RequestDelegate _next;
        private readonly IHostEnvironment _env;
        private readonly Logger _logger = LogManager.GetCurrentClassLogger();
        private readonly string key; // Clave secreta (debes protegerla adecuadamente)
        private readonly string iv; // Vector de inicialización (debes protegerlo adecuadamente)


        public MyInterceptor(RequestDelegate next, IHostEnvironment env)
        {
            _next = next;
            _env = env;
            this.key = "miKey";
            this.iv = "miIv";
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // Aquí puedes interceptar la solicitud antes de que llegue al controlador
            // Por ejemplo, puedes encriptar IDs en las peticiones o desencriptarlos en las respuestas

            // Leer el cuerpo de la solicitud
            var requestBody = await ReadRequestBody(context.Request);

            // Aquí puedes buscar y encriptar los IDs en el JSON del cuerpo
            // Por ejemplo, si el JSON contiene un campo "id", puedes reemplazar su valor encriptado

            // Actualizar el cuerpo de la solicitud
            context.Request.Body = new MemoryStream(Encoding.UTF8.GetBytes(requestBody));

            await _next(context);
        }

        private async Task<string> ReadRequestBody(HttpRequest request)
        {
            using var reader = new StreamReader(request.Body, Encoding.UTF8);
            return await reader.ReadToEndAsync();
        }

        private string EncryptId(int id)
        {
            using var aesAlg = Aes.Create();
            aesAlg.Key = Encoding.UTF8.GetBytes(key);
            aesAlg.IV = Encoding.UTF8.GetBytes(iv);

            var encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

            using var msEncrypt = new MemoryStream();
            using var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write);
            using var swEncrypt = new StreamWriter(csEncrypt);

            swEncrypt.Write(id.ToString());

            return Convert.ToBase64String(msEncrypt.ToArray());
        }

        private int DecryptId(string encryptedId)
        {
            using var aesAlg = Aes.Create();
            aesAlg.Key = Encoding.UTF8.GetBytes(key);
            aesAlg.IV = Encoding.UTF8.GetBytes(iv);

            var decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

            using var msDecrypt = new MemoryStream(Convert.FromBase64String(encryptedId));
            using var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read);
            using var srDecrypt = new StreamReader(csDecrypt);

            var decryptedValue = srDecrypt.ReadToEnd();

            if (int.TryParse(decryptedValue, out int id))
            {
                return id;
            }

            throw new ArgumentException("Error al desencriptar el ID.");
        }


        public async Task<string> ProcessRequestBody(string requestBody)
        {
            // Deserializa el JSON
            var jsonObject = JObject.Parse(requestBody);

            // Busca el campo "id"
            if (jsonObject.TryGetValue("Id", out var idToken) && idToken.Type == JTokenType.Integer)
            {
                var id = (int)idToken;
                var encryptedId = EncryptId(id);
                jsonObject["Id"] = encryptedId;
            }

            // Serializa el JSON actualizado
            return jsonObject.ToString();
        }

    }
}
