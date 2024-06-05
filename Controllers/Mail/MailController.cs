using System.Text;
using System.Text.Json;
using Filtro.Models;
using Filtro.DTO;

namespace Filtro.Controllers.Mail
{
    public class MailController
    {
        public async void EnviarCorreoAsync()
        {
            try
            {
                //URL destino del POST
                string url= "https://api.mailersend.com/v1/email";

                //Token de autorización
                string jwtToken = "mlsn.e75e54a073a777826a2acefe6f57776eb0f60f7eb0279c1123c3096d15b8a1d0";

                //Objeto para contener los datos del msj del mail
                var emailMessage = new Email
                {
                    from = new From {email = "Solicitud@trial-3z0vklozzrx47qrx.mlsender.net"},
                    to =new[]
                    {
                        new To {email = "s.giraldo1315@gmail.com"}
                    },
                    subject = "Nueva cita",
                    text = "Tu cita ha sido agendada",
                    html = "Tu cita ha sido agendada"
                };
            

                //Serializar el objeto en formato JSON
                string jsonBody = JsonSerializer.Serialize(emailMessage);
                Console.WriteLine("JSON Enviado:");
                Console.WriteLine(jsonBody);
                //Crear el objeto HttpClient para realizar la solicitud HTTP
                using (HttpClient client = new HttpClient())
                {
                    //Configurar el encabezado Content-Type para indicar que el cuerpo es JSON
                    client.DefaultRequestHeaders.Add("Content-Type", "application/json");
                    //Configurar el encabezado Authorization para indicar el token de autorización
                    client.DefaultRequestHeaders.Add("Authorization", $"Bearer {jwtToken}");
                    //Crear el contenido de la solicitud POST como StringContent
                    StringContent content= new StringContent(jsonBody, Encoding.UTF8, "application/json");
                    //Realizar la solicitud POST
                    HttpResponseMessage response = await client.PostAsync(url, content);
                    //Verificar si la solicitud fue exitosa (200-299)
                    if(response.IsSuccessStatusCode)
                    {
                        //Leer la respuesta como una cadena
                        string responseBody = await response.Content.ReadAsStringAsync();
                        Console.WriteLine("Respuesta del servidor:");
                        Console.WriteLine(responseBody);
                    }else{
                        Console.WriteLine($"La solicitud falló con el codigo de estado:{response.StatusCode}");
                    }
                }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}