using FoodOrdering.Application.DTOs;
using FoodOrdering.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FoodOrdering.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderItemController : ControllerBase
    {
        private readonly IOrderItemService _orderItemService;

        public OrderItemController(IOrderItemService orderItemService)
        {
            _orderItemService = orderItemService;
        }

        [HttpGet]
        public async Task<ActionResult<List<OrderItemDto>>> GetAll()
        {
            var items = await _orderItemService.GetAllOrderItemsAsync();
            return Ok(items);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrderItemDto>> GetById(int id)
        {
            var item = await _orderItemService.GetOrderItemByIdAsync(id);
            if (item == null) return NotFound();
            return Ok(item);
        }

        [HttpPost]
        public async Task<ActionResult<OrderItemDto>> Create(CreateOrderItemDto dto)
        {
            var created = await _orderItemService.AddOrderItemAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.OrderItemId }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateOrderItemDto dto)
        {
            if (id != dto.OrderItemId)
                return BadRequest("ID mismatch");

            var updated = await _orderItemService.UpdateOrderItemAsync(dto);
            if (!updated) return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _orderItemService.DeleteOrderItemAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}
