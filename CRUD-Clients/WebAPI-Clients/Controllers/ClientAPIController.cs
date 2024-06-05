using Microsoft.AspNetCore.Mvc;
using Models;
using WebAPI_Clients.Services.Interfaces;

namespace WebAPI_Clients.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientAPIController : ControllerBase
    {
        private readonly IClientService _clientService;
        private readonly ILogger<ClientAPIController> _logger;
        public ClientAPIController(IClientService clientService, ILogger<ClientAPIController> logger)
        {
            _clientService = clientService;
            _logger = logger;
        }

        // GET: api/ClientAPI
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Client>>> GetClients()
        {
            try
            {
                var clients = await _clientService.GetAllClientsAsync();
                _logger.LogInformation("Clientes obtenidos correctamente");
                return Ok(clients);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error interno del servidor: {ex.Message}");
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        // GET: api/ClientAPI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Client>> GetClient(int id)
        {
            try
            {
                var client = await _clientService.GetClientByIdAsync(id);
                if (client == null)
                {
                    _logger.LogWarning("Cliente no encontrado");
                    return NotFound("Cliente no encontrado");
                }
                _logger.LogInformation("Cliente obtenido correctamente");
                return client;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error interno del servidor: {ex.Message}");
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        // POST: api/ClientAPI
        [HttpPost]
        public async Task<ActionResult<Client>> PostClient([FromBody]Client client)
        {
            try
            {
                await _clientService.AddClientAsync(client);
                _logger.LogInformation("Cliente agregado exitosamente");
                return Ok("Cliente agregado exitosamente");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error interno del servidor: {ex.Message}");
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        // PUT: api/Client/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClient(int id, Client updatedClient)
        {
            if (id != updatedClient.Id)
            {
                _logger.LogWarning("ID del cliente no coincide");
                return BadRequest("ID del cliente no coincide");
            }

            try
            {
                var existingClient = await _clientService.GetClientByIdAsync(id);
                if (existingClient == null)
                {
                    _logger.LogWarning("Cliente no encontrado");
                    return NotFound("Cliente no encontrado");
                }
                existingClient.FirstName = updatedClient.FirstName;
                existingClient.LastName = updatedClient.LastName;
                existingClient.Email = updatedClient.Email;
                existingClient.State = updatedClient.State;
                await _clientService.UpdateClientAsync(existingClient);
                _logger.LogInformation("Cliente actualizado exitosamente");
                return Ok("Cliente actualizado exitosamente");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error interno del servidor: {ex.Message}");
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        // DELETE: api/ClientAPI/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClient(int id)
        {
            try
            {
                await _clientService.DeleteClientAsync(id);
                _logger.LogInformation("Cliente eliminado exitosamente");
                return Ok("Cliente eliminado exitosamente");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error interno del servidor: {ex.Message}");
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }
    }
}
