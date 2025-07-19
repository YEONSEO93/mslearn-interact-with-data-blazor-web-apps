using Microsoft.EntityFrameworkCore;

// 이 클래스는 BlazingPizza 프로젝트의 Data 폴더 내에 정의됨
namespace BlazingPizza.Data
{
    // PizzaStoreContext는 Entity Framework의 DbContext를 상속하여 데이터베이스 컨텍스트를 정의함
    public class PizzaStoreContext : DbContext
    {
        // 생성자: 외부에서 DbContextOptions를 받아 부모 클래스(DbContext)에 전달
        // 이 옵션은 데이터베이스 연결 문자열이나 기타 설정 정보를 포함함
        public PizzaStoreContext(DbContextOptions options) : base(options)
        {
        }

        // Specials는 PizzaSpecial 엔터티의 테이블에 해당
        // 이를 통해 PizzaSpecial 객체를 조회, 추가, 수정, 삭제할 수 있음
        public DbSet<PizzaSpecial> Specials { get; set; }
    }
}

// This class creates a database context we can use to register a database service.
// The context also allows us to have a controller that accesses the database.


