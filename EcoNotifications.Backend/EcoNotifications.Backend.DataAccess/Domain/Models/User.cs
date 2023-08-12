using EcoNotifications.Backend.DataAccess.Domain.Interfaces;

namespace EcoNotifications.Backend.DataAccess.Models;

public class User : IEntity
{
    public Guid? Id { get; set; }
    public string FullName { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public int Coins { get; set; }
    public DateTime LastLogin { get; set; }

    #region Entity
    
    public string? CreatedBy { get; set; }
    public string? ModifiedBy { get; set; }
    public DateTime? CreatedOn { get; set; }
    public DateTime? ModifiedOn { get; set; }
    public bool IsDeleted { get; set; }

    #endregion
}