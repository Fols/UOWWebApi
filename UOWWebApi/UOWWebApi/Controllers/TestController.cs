using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UOWWebApi.DAL.UnitOfWork;
using UOWWebApi.Models;

namespace UOWWebApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public TestController(IUnitOfWork unitOfWork) {
            _unitOfWork = unitOfWork;

            if (_unitOfWork.Test.GetAll().Count() == 0) {
                _unitOfWork.Test.Add(new TestItem { Name = "MyTestItem" });
                _unitOfWork.Complete();
            }
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TestItem>>> GetTestItemsAsync() {
            return await Task.Run(() =>_unitOfWork.Test.GetAll().ToList());
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<TestItem>> GetTestItemAsync(long id) {

            var searchItem = await Task.Run(() => _unitOfWork.Test.Get(id));
            if (searchItem is null) {
                return NotFound();
            }

            return searchItem;
        }

        [HttpPost]
        public async Task<ActionResult<TestItem>> PostTestItemAsync(TestItem item) {
            await Task.Run(() => _unitOfWork.Test.Add(item));
            _unitOfWork.Complete();

            return CreatedAtAction(nameof(GetTestItemAsync), new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutTestItemAsync(long id, TestItem item) {
            
            if (id!=item.Id) {
                return BadRequest();
            }

            _unitOfWork.Test.PutTestItem(item);

            await Task.Run(() => _unitOfWork.Complete());

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTestItemAsync(long id) {
            var itemToDelete = await Task.Run(()=>_unitOfWork.Test.Get(id));
            if (itemToDelete is null) {
                return NotFound();
            }

            _unitOfWork.Test.Remove(itemToDelete);
            _unitOfWork.Complete();

            return Ok();
        }

    }
}