using JB.Models;

namespace JB.Services
{
    public class DogWcfClientService
    {
        public async Task<DogViewModel> ObtenerPerritoDelDia()
        {
            var model = new DogViewModel();

            try
            {
                // ✅ Usar el nombre CORRECTO de la referencia
                var client = new DogServiceReference.DogServiceClient();

                string imagenUrl = await client.ObtenerPerritoDelDiaAsync();

                if (string.IsNullOrWhiteSpace(imagenUrl))
                {
                    model.Mensaje = "No se pudo obtener el perrito del día.";
                    return model;
                }

                model.ImagenUrl = imagenUrl;
                model.Mensaje = "Perrito del día recuperado correctamente.";
            }
            catch (Exception ex)
            {
                model.Mensaje = "Error al consumir el WCF: " + ex.Message;
            }

            return model;
        }
    }
}