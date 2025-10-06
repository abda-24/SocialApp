
namespace Domain.Common; 

public abstract class BaseEntity<Tkey>
{
    public Tkey Id { get; set; }
}
