using KeyValueServices.Data;
using KeyValueServices.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KeyValueServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KeysController : ControllerBase
    {
        private readonly IKeyRepository _repository;

        public KeysController(IKeyRepository repository)
        {
            _repository = repository;
        }
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            try
            {
                var result = await _repository.GetAllKeysAsync();
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Database failure");
            }
        }
        [HttpGet("{key}")]
        public async Task<ActionResult> Get(string key)
        {
            try
            {
                var result = await _repository.GetKeyAsync(key);
                if(result==null) return NotFound();
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Database failure");
            }
        }
        [HttpPost]
        public async Task<ActionResult<Key[]>> Post(Key key)
        {
            try
            {
                var exist = await _repository.GetKeyAsync(key.key);
                if (exist != null)
                {
                    return Conflict("Key are allready exist");
                }
                _repository.Add(key);
                await _repository.SaveChangesAsync();
                return Ok("Added key");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Database failure");
            }
        }
        [HttpDelete("{key}")]
        public async Task<ActionResult<Key>> Delete(string key)
        {
            try
            {
                var oldkey = await _repository.GetKeyAsync(key);
                if (oldkey == null) return NotFound();
                _repository.Delete(oldkey);
                if (await _repository.SaveChangesAsync())
                {
                    return Ok();
                }
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Database failure");
            }
        }
        [HttpPatch("{key}")]
        [Route("api/[controller]/key")]
        public async Task<ActionResult<Key[]>> Patch(string key, Key keymodal)
        {
            try
            {
                var existKey = await _repository.GetKeyAsync(key);
                if (existKey != null)
                {
                    existKey.key = keymodal.key;
                    _repository.GetKeyAsync(key);
                    return Ok();
                }
                else
                    return NotFound();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Database failure");
            }
        }
    }
}
