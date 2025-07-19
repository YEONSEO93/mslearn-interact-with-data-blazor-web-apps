using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BlazingPizza.Data;

namespace BlazingPizza.Controllers;

[Route("specials")]
[ApiController]
public class SpecialsController : Controller
{
    private readonly PizzaStoreContext _db;

    public SpecialsController(PizzaStoreContext db)
    {
        _db = db;
    }

    [HttpGet]
    // http://localhost:5000/specials GET 요청 -> 함수 실행
    public async Task<ActionResult<List<PizzaSpecial>>> GetSpecials()
    // ActionResult<T>는 HTTP 응답 + 실제 데이터를 함께 담는 래퍼(wrapper).
    // 성공 시 200 OK & PizzaSpecial 리스트 반환
    // 실패 시 400 or 500 err 반환
    // Task<...>는 비동기 작업 결과를 나타냄
    {
        return (await _db.Specials.ToListAsync()).OrderByDescending(s => s.BasePrice).ToList();
    }
}